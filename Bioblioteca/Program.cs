using System;
using System.Text;
using BibliotecaElCarlitos.Menus;
using BibliotecaElCarlitos.Testing;
using BibliotecaElCarlitos.Services;

namespace BibliotecaElCarlitos.Menus
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Colecciones en memoria + datos predefinidos
            var biblioteca = new ContextoBiblioteca();
            biblioteca.CargarDatosPredefinidos();

            ShowMainMenu(biblioteca);
        }

        static void ShowMainMenu(ContextoBiblioteca biblioteca)
        {
            string? opcion;

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
                Console.WriteLine("6. Ver Testing POO");
                Console.WriteLine("7. Ver Testing KPIs");
                Console.WriteLine("0. Salir");
                Console.WriteLine("-----------------------------");
                Console.Write("Selecciona una opción (0-7): ");

                opcion = Console.ReadLine()?.Trim();

                switch (opcion)
                {
                    case "1": MenuLibros.ShowBooksMenu(biblioteca); break;
                    case "2": MenuUsuarios.ShowUsersMenu(biblioteca); break;
                    case "3": MenuPrestamos.ShowLoansMenu(biblioteca); break;
                    case "4": MenuReportes.ShowSearchReportsMenu(biblioteca); break;
                    case "5": MenuPersistencia.ShowPersistenceMenu(biblioteca); break;
                    case "6": PooTesting.EjecutarPruebasEvidencia(); break;
                    case "7": PruebaKpis.EjecutarSimulacionKpis(); break;
                    case "0":
                        Console.WriteLine("\nSaliendo del sistema. ¡Hasta pronto!");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione una tecla...");
                        Console.ReadKey(true);
                        break;
                }
            } while (opcion != "0");
        }
    }
}
