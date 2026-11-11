using System;

namespace BibliotecaElCarlitos.Menus
{
    public static class MenuUsuarios
    {
        public static void ShowUsersMenu()
        {
            byte opcionUsuario;
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

                if (byte.TryParse(Console.ReadLine(), out opcionUsuario))
                {
                    switch (opcionUsuario)
                    {
                        case 1: RegisterUser(); break;
                        case 2: ListUsers(); break;
                        case 3: ViewUserDetail(); break;
                        case 0: break;
                        default: Console.WriteLine("\nOpción no válida."); Pausa(); break;
                    }
                }
                else { Pausa(); }
            } while (opcionUsuario != 0);
        }

        private static void RegisterUser()
        {
            Console.Clear();
            Console.Write("Ingrese Documento: ");
            string doc = Console.ReadLine()!;
            Console.Write("Ingrese Nombre: ");
            string nombre = Console.ReadLine()!;
            Console.WriteLine($"\nUsuario {nombre} registrado exitosamente.");
            Pausa();
        }

        private static void ListUsers()
        {
            Console.Clear();
            Console.WriteLine("--- Lista de Usuarios ---");
            Console.WriteLine("Doc: 100123 | Carlos Pérez | Activo");
            Pausa();
        }

        private static void ViewUserDetail()
        {
            Console.Clear();
            Console.Write("Ingrese Documento: ");
            string doc = Console.ReadLine()!;
            Console.WriteLine($"\nDetalles del usuario {doc}.");
            Pausa();
        }

        private static void Pausa()
        {
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}