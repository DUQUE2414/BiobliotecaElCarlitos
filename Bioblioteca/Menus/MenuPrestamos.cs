using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaElCarlitos.models;
using BibliotecaElCarlitos.Services;

namespace BibliotecaElCarlitos.Menus
{
    public static class MenuPrestamos
    {
        public static void ShowLoansMenu(ContextoBiblioteca biblioteca)
        {
            string? opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("3) Menú de Préstamos");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Crear préstamo");
                Console.WriteLine("2. Listar préstamos");
                Console.WriteLine("3. Registrar devolución");
                Console.WriteLine("4. Ver detalle de préstamo");
                Console.WriteLine("5. Eliminar préstamo");
                Console.WriteLine("0. Volver al menú principal");
                Console.WriteLine("-----------------------------");
                Console.Write("Selecciona una opción (0-5): ");

                opcion = Console.ReadLine()?.Trim();

                switch (opcion)
                {
                    case "1": CreateLoan(biblioteca); break;
                    case "2": ListLoans(biblioteca); break;
                    case "3": ReturnLoan(biblioteca); break;
                    case "4": ViewLoanDetail(biblioteca); break;
                    case "5": DeleteLoan(biblioteca); break;
                    case "0": break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Consola.Pausa();
                        break;
                }
            } while (opcion != "0");
        }

        private static void CreateLoan(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("3.1) Crear préstamo");
            string isbn = Consola.LeerTexto("ISBN del Libro: ");
            var libro = biblioteca.Libros.BuscarPorIsbn(isbn);

            if (libro == null)
            {
                Console.WriteLine($"\nNo existe un libro con ISBN {isbn}.");
                Consola.Pausa();
                return;
            }
            if (!libro.EstaDisponible)
            {
                Console.WriteLine($"\nEl libro '{libro.TituloLibro}' ya está prestado.");
                Consola.Pausa();
                return;
            }

            string doc = Consola.LeerTexto("Documento Usuario: ");
            var usuario = biblioteca.Usuarios.BuscarPorDocumento(doc);

            if (usuario == null)
            {
                Console.WriteLine($"\nNo existe un usuario con documento {doc}.");
                Consola.Pausa();
                return;
            }
            if (!usuario.EstaActivo)
            {
                Console.WriteLine($"\nEl usuario {usuario.Nombre} está inactivo y no puede pedir préstamos.");
                Consola.Pausa();
                return;
            }

            var prestamo = new Prestamo(biblioteca.Prestamos.GenerarNuevoId(), libro.Isbn, usuario.Documento, usuario.Nombre, DateTime.Now);
            biblioteca.Prestamos.AgregarPrestamo(prestamo);
            libro.EstaDisponible = false;

            Console.WriteLine($"\nPréstamo {prestamo.IdPrestamo} creado con éxito.");
            Console.WriteLine($"Libro: {libro.TituloLibro} | Usuario: {usuario.Nombre}");
            Console.WriteLine($"Fecha límite de devolución: {DateTime.Now.AddDays(14):dd/MM/yyyy}");
            Consola.Pausa();
        }

        private static void ListLoans(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("3.2) Listado de préstamos");
            Console.WriteLine("Filtrar: 1) Todos  2) Activos  3) Devueltos  4) Vencidos");
            Console.Write("Opción (Enter = todos): ");
            string? filtro = Console.ReadLine()?.Trim();

            List<Prestamo> lista = filtro switch
            {
                "2" => biblioteca.Prestamos.BuscarPorEstado(EstadoPrestamo.Activo),
                "3" => biblioteca.Prestamos.BuscarPorEstado(EstadoPrestamo.Devuelto),
                "4" => biblioteca.Prestamos.ObtenerTodos().Where(p => p.EstaVencido()).ToList(),
                _ => biblioteca.Prestamos.OrdenarPorFecha()
            };

            Console.WriteLine("\n--- Préstamos ---");
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay préstamos para mostrar.");
            }
            else
            {
                foreach (var p in lista)
                {
                    string vencido = p.EstaVencido() ? " | VENCIDO" : "";
                    Console.WriteLine($"{p.ResumenCorto()}{vencido}");
                }
                Console.WriteLine($"\nTotal: {lista.Count}");
            }
            Consola.Pausa();
        }

        private static void ReturnLoan(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("3.3) Registrar devolución");
            string id = Consola.LeerTexto("ID del préstamo a devolver (ej. P-001): ");
            var prestamo = biblioteca.Prestamos.ObtenerPorId(id);

            if (prestamo == null)
            {
                Console.WriteLine($"\nNo existe el préstamo {id}.");
                Consola.Pausa();
                return;
            }
            if (prestamo.Estado == EstadoPrestamo.Devuelto)
            {
                Console.WriteLine($"\nEl préstamo {id} ya fue devuelto.");
                Consola.Pausa();
                return;
            }

            biblioteca.Prestamos.RegistrarDevolucion(prestamo.IdPrestamo);

            var libro = biblioteca.Libros.BuscarPorIsbn(prestamo.IsbnLibro);
            if (libro != null) libro.EstaDisponible = true;

            Console.WriteLine($"\nDevolución registrada para el préstamo {prestamo.IdPrestamo}.");
            if (libro != null) Console.WriteLine($"El libro '{libro.TituloLibro}' vuelve a estar disponible.");
            Consola.Pausa();
        }

        private static void ViewLoanDetail(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("3.4) Detalle de préstamo");
            string id = Consola.LeerTexto("ID del préstamo: ");
            var prestamo = biblioteca.Prestamos.ObtenerPorId(id);

            Console.WriteLine();
            Console.WriteLine(prestamo == null ? $"No existe el préstamo {id}." : prestamo.DetalleCompleto());
            Consola.Pausa();
        }

        private static void DeleteLoan(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("3.5) Eliminar préstamo");
            string id = Consola.LeerTexto("ID del préstamo a eliminar: ");
            var prestamo = biblioteca.Prestamos.ObtenerPorId(id);

            if (prestamo == null)
            {
                Console.WriteLine($"\nNo existe el préstamo {id}.");
                Consola.Pausa();
                return;
            }

            Console.WriteLine($"\n{prestamo.ResumenCorto()}");
            if (Consola.Confirmar("\n¿Seguro que deseas eliminarlo?"))
            {
                // Si estaba activo, el libro vuelve a quedar disponible
                if (prestamo.Estado != EstadoPrestamo.Devuelto)
                {
                    var libro = biblioteca.Libros.BuscarPorIsbn(prestamo.IsbnLibro);
                    if (libro != null) libro.EstaDisponible = true;
                }
                biblioteca.Prestamos.EliminarPrestamoPorId(prestamo.IdPrestamo);
                Console.WriteLine($"\nPréstamo {id} eliminado. Total restante: {biblioteca.Prestamos.ObtenerTotalPrestamos()}");
            }
            else
            {
                Console.WriteLine("\nOperación cancelada.");
            }
            Consola.Pausa();
        }
    }
}
