using System;
using BibliotecaElCarlitos.models;
using BibliotecaElCarlitos.Menus;
using BibliotecaElCarlitos.Testing;

namespace BibliotecaElCarlitos.Menus
{
    class Program
    {
        static void Main()
        {
            PooTesting.EjecutarPruebasEvidencia();
            ShowMainMenu();
        }

        static void ShowMainMenu()
        {
            byte opcionMenu;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu Principal");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Libros");
                Console.WriteLine("2. Usuarios");
                Console.WriteLine("3. Préstamos");
                Console.WriteLine("4. Búsquedas y reportes");
                Console.WriteLine("5. Guardar / Cargar datos");
                Console.WriteLine("6. Salir");
                Console.WriteLine("-----------------------------");
                Console.Write("Selecciona una opción (1-6): ");

                if (byte.TryParse(Console.ReadLine(), out opcionMenu))
                {
                    switch (opcionMenu)
                    {
                        case 1: MenuLibros.ShowBooksMenu(); break;
                        case 2: MenuUsuarios.ShowUsersMenu(); break;
                        case 3: MenuPrestamos.ShowLoansMenu(); break;
                        case 4: MenuReportes.ShowSearchReportsMenu(); break;
                        case 5: MenuPersistencia.ShowPersistenceMenu(); break;
                        case 6:
                            Console.WriteLine("\nSaliendo del sistema. ¡Hasta pronto!");
                            break;
                        default:
                            Console.WriteLine("\nOpción no válida. Presione una tecla...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nOpción inválida. Presione una tecla...");
                    Console.ReadKey();
                    opcionMenu = 0;
                }
            } while (opcionMenu != 6);
        }
    }
}