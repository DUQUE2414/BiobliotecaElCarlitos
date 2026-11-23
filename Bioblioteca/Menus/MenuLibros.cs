using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaElCarlitos.models;
using BibliotecaElCarlitos.Services;

namespace BibliotecaElCarlitos.Menus
{
    public static class MenuLibros
    {
        public static void ShowBooksMenu(ContextoBiblioteca biblioteca)
        {
            string? opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("1) Menú de Libros");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Listar libros");
                Console.WriteLine("3. Ver detalle de libro (por ISBN)");
                Console.WriteLine("4. Actualizar libro");
                Console.WriteLine("5. Eliminar libro");
                Console.WriteLine("0. Volver al menú principal");
                Console.WriteLine("-----------------------------");
                Console.Write("Selecciona una opción (0-5): ");

                opcion = Console.ReadLine()?.Trim();

                switch (opcion)
                {
                    case "1": RegisterBook(biblioteca); break;
                    case "2": ShowListBooksMenu(biblioteca); break;
                    case "3": ViewBookDetail(biblioteca); break;
                    case "4": UpdateBook(biblioteca); break;
                    case "5": DeleteBook(biblioteca); break;
                    case "0": break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Consola.Pausa();
                        break;
                }
            } while (opcion != "0");
        }

        private static void RegisterBook(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("1.1) Registrar libro");
            string titulo = Consola.LeerTexto("Ingrese Título: ");
            string autor = Consola.LeerTexto("Ingrese Autor: ");
            string categoria = Consola.LeerTexto("Ingrese Categoría: ");
            ushort anio = Consola.LeerAnio("Ingrese Año de Publicación: ")!.Value;

            Libro libro = new Libro(titulo, autor, categoria, anio);
            biblioteca.Libros.AgregarLibro(libro);

            Console.WriteLine($"\nLibro registrado con éxito: {libro.TituloLibro} (ISBN: {libro.Isbn})");
            Console.WriteLine($"Total de libros en la colección: {biblioteca.Libros.ObtenerTotalLibros()}");
            Consola.Pausa();
        }

        private static void ShowListBooksMenu(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("1.2) Listado de libros");
            Console.WriteLine("Ordenar por: 1) ISBN  2) Título  3) Año");
            Console.Write("Opción (Enter = ISBN): ");
            string? orden = Console.ReadLine()?.Trim();

            List<Libro> lista = orden switch
            {
                "2" => biblioteca.Libros.OrdenarPorTitulo(),
                "3" => biblioteca.Libros.OrdenarPorAnio(),
                _ => biblioteca.Libros.ObtenerTodos().OrderBy(l => l.Isbn).ToList()
            };

            Console.WriteLine("\n--- Listado de Libros ---");
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay libros registrados.");
            }
            else
            {
                foreach (var l in lista)
                {
                    string estado = l.EstaDisponible ? "Disponible" : "Prestado";
                    Console.WriteLine($"{l.Isbn} | {l.TituloLibro} | {l.Autor} | {l.AnioPublicacion} | {estado}");
                }
                Console.WriteLine($"\nTotal: {lista.Count}");
            }
            Consola.Pausa();
        }

        private static void ViewBookDetail(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("1.3) Detalle de libro");
            string isbn = Consola.LeerTexto("Ingrese ISBN a consultar: ");
            var libro = biblioteca.Libros.BuscarPorIsbn(isbn);

            Console.WriteLine();
            Console.WriteLine(libro == null
                ? $"No se encontró ningún libro con ISBN {isbn}."
                : libro.DetalleCompleto());
            Consola.Pausa();
        }

        private static void UpdateBook(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("1.4) Actualizar libro");
            string isbn = Consola.LeerTexto("Ingrese ISBN del libro a actualizar: ");
            var libro = biblioteca.Libros.BuscarPorIsbn(isbn);

            if (libro == null)
            {
                Console.WriteLine($"\nNo se encontró ningún libro con ISBN {isbn}.");
                Consola.Pausa();
                return;
            }

            Console.WriteLine($"\n{libro.DetalleCompleto()}");
            Console.WriteLine("\n(Deja vacío para conservar el valor actual)\n");

            string titulo = Consola.LeerTexto($"Título [{libro.TituloLibro}]: ", false);
            string autor = Consola.LeerTexto($"Autor [{libro.Autor}]: ", false);
            string categoria = Consola.LeerTexto($"Categoría [{libro.Categoria}]: ", false);
            ushort? anio = Consola.LeerAnio($"Año [{libro.AnioPublicacion}]: ", true);

            biblioteca.Libros.ActualizarLibro(
                libro.Isbn,
                titulo.Length == 0 ? libro.TituloLibro : titulo,
                autor.Length == 0 ? libro.Autor : autor,
                categoria.Length == 0 ? libro.Categoria : categoria,
                anio ?? libro.AnioPublicacion);

            Console.WriteLine("\nLibro actualizado:");
            Console.WriteLine(libro.DetalleCompleto());
            Consola.Pausa();
        }

        private static void DeleteBook(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("1.5) Eliminar libro");
            string isbn = Consola.LeerTexto("Ingrese ISBN del libro a eliminar: ");
            var libro = biblioteca.Libros.BuscarPorIsbn(isbn);

            if (libro == null)
            {
                Console.WriteLine($"\nNo se encontró ningún libro con ISBN {isbn}.");
                Consola.Pausa();
                return;
            }

            bool tienePrestamoActivo = biblioteca.Prestamos.ObtenerTodos()
                .Any(p => p.IsbnLibro == libro.Isbn && p.Estado != EstadoPrestamo.Devuelto);

            if (tienePrestamoActivo)
            {
                Console.WriteLine("\nNo se puede eliminar: el libro tiene un préstamo activo.");
                Consola.Pausa();
                return;
            }

            Console.WriteLine($"\n{libro.DetalleCompleto()}");
            if (Consola.Confirmar("\n¿Seguro que deseas eliminarlo?"))
            {
                biblioteca.Libros.EliminarLibroPorIsbn(libro.Isbn);
                Console.WriteLine($"\nLibro {isbn} eliminado. Total restante: {biblioteca.Libros.ObtenerTotalLibros()}");
            }
            else
            {
                Console.WriteLine("\nOperación cancelada.");
            }
            Consola.Pausa();
        }
    }
}
