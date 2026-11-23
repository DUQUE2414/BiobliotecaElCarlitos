using System;
using System.Linq;
using BibliotecaElCarlitos.models;
using BibliotecaElCarlitos.Services;

namespace BibliotecaElCarlitos.Menus
{
    public static class MenuUsuarios
    {
        public static void ShowUsersMenu(ContextoBiblioteca biblioteca)
        {
            string? opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("2) Menú de Usuarios");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Registrar usuario");
                Console.WriteLine("2. Listar usuarios");
                Console.WriteLine("3. Ver detalle de usuario");
                Console.WriteLine("4. Actualizar usuario");
                Console.WriteLine("5. Eliminar usuario");
                Console.WriteLine("0. Volver al menú principal");
                Console.WriteLine("-----------------------------");
                Console.Write("Selecciona una opción (0-5): ");

                opcion = Console.ReadLine()?.Trim();

                switch (opcion)
                {
                    case "1": RegisterUser(biblioteca); break;
                    case "2": ListUsers(biblioteca); break;
                    case "3": ViewUserDetail(biblioteca); break;
                    case "4": UpdateUser(biblioteca); break;
                    case "5": DeleteUser(biblioteca); break;
                    case "0": break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Consola.Pausa();
                        break;
                }
            } while (opcion != "0");
        }

        private static void RegisterUser(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("2.1) Registrar usuario");
            string doc = Consola.LeerTexto("Ingrese Documento: ");

            if (biblioteca.Usuarios.BuscarPorDocumento(doc) != null)
            {
                Console.WriteLine($"\nYa existe un usuario con el documento {doc}.");
                Consola.Pausa();
                return;
            }

            string nombre = Consola.LeerTexto("Ingrese Nombre: ");
            string contacto = Consola.LeerTexto("Ingrese Contacto (teléfono): ");

            biblioteca.Usuarios.AgregarUsuario(new Usuario(doc, nombre, contacto));
            Console.WriteLine($"\nUsuario {nombre} registrado exitosamente.");
            Console.WriteLine($"Total de usuarios en la colección: {biblioteca.Usuarios.ObtenerTotalUsuarios()}");
            Consola.Pausa();
        }

        private static void ListUsers(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("2.2) Lista de usuarios");
            var lista = biblioteca.Usuarios.OrdenarPorNombre();

            if (lista.Count == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
            }
            else
            {
                foreach (var u in lista)
                {
                    string estado = u.EstaActivo ? "Activo" : "Inactivo";
                    Console.WriteLine($"Doc: {u.Documento} | {u.Nombre} | {u.Contacto} | {estado}");
                }
                Console.WriteLine($"\nTotal: {lista.Count}");
            }
            Consola.Pausa();
        }

        private static void ViewUserDetail(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("2.3) Detalle de usuario");
            string doc = Consola.LeerTexto("Ingrese Documento: ");
            var usuario = biblioteca.Usuarios.BuscarPorDocumento(doc);

            Console.WriteLine();
            if (usuario == null)
            {
                Console.WriteLine($"No se encontró ningún usuario con documento {doc}.");
            }
            else
            {
                Console.WriteLine(usuario.DetalleCompleto());
                int activos = biblioteca.Prestamos.ObtenerTodos()
                    .Count(p => p.DocumentoUsuario == usuario.Documento && p.Estado != EstadoPrestamo.Devuelto);
                Console.WriteLine($"Préstamos pendientes: {activos}");
            }
            Consola.Pausa();
        }

        private static void UpdateUser(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("2.4) Actualizar usuario");
            string doc = Consola.LeerTexto("Ingrese Documento del usuario a actualizar: ");
            var usuario = biblioteca.Usuarios.BuscarPorDocumento(doc);

            if (usuario == null)
            {
                Console.WriteLine($"\nNo se encontró ningún usuario con documento {doc}.");
                Consola.Pausa();
                return;
            }

            Console.WriteLine($"\n{usuario.DetalleCompleto()}");
            Console.WriteLine("\n(Deja vacío para conservar el valor actual)\n");

            string nombre = Consola.LeerTexto($"Nombre [{usuario.Nombre}]: ", false);
            string contacto = Consola.LeerTexto($"Contacto [{usuario.Contacto}]: ", false);
            string estadoTxt = Consola.LeerTexto($"¿Activo? s/n [{(usuario.EstaActivo ? "s" : "n")}]: ", false).ToLower();

            bool activo = estadoTxt == "s" ? true : estadoTxt == "n" ? false : usuario.EstaActivo;

            biblioteca.Usuarios.ActualizarUsuario(
                usuario.Documento,
                nombre.Length == 0 ? usuario.Nombre : nombre,
                contacto.Length == 0 ? usuario.Contacto : contacto,
                activo);

            Console.WriteLine("\nUsuario actualizado:");
            Console.WriteLine(usuario.DetalleCompleto());
            Consola.Pausa();
        }

        private static void DeleteUser(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("2.5) Eliminar usuario");
            string doc = Consola.LeerTexto("Ingrese Documento del usuario a eliminar: ");
            var usuario = biblioteca.Usuarios.BuscarPorDocumento(doc);

            if (usuario == null)
            {
                Console.WriteLine($"\nNo se encontró ningún usuario con documento {doc}.");
                Consola.Pausa();
                return;
            }

            bool tienePrestamos = biblioteca.Prestamos.ObtenerTodos()
                .Any(p => p.DocumentoUsuario == usuario.Documento && p.Estado != EstadoPrestamo.Devuelto);

            if (tienePrestamos)
            {
                Console.WriteLine("\nNo se puede eliminar: el usuario tiene préstamos pendientes.");
                Consola.Pausa();
                return;
            }

            Console.WriteLine($"\n{usuario.DetalleCompleto()}");
            if (Consola.Confirmar("\n¿Seguro que deseas eliminarlo?"))
            {
                biblioteca.Usuarios.EliminarUsuarioPorDocumento(usuario.Documento);
                Console.WriteLine($"\nUsuario {doc} eliminado. Total restante: {biblioteca.Usuarios.ObtenerTotalUsuarios()}");
            }
            else
            {
                Console.WriteLine("\nOperación cancelada.");
            }
            Consola.Pausa();
        }
    }
}
