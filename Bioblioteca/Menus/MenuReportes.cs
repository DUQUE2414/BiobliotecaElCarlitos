using System;

namespace BibliotecaElCarlitos.Menus
{
    public static class MenuReportes
    {
        public static void ShowSearchReportsMenu()
        {
            byte opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("4) Menú de Búsquedas y Reportes");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Buscar libro");
                Console.WriteLine("2. Buscar usuario");
                Console.WriteLine("3. Reporte general");
                Console.WriteLine("0. Volver al menú principal");
                Console.WriteLine("-----------------------------");
                Console.Write("Selecciona una opción (0-3): ");

                if (byte.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1: SearchBook(); break;
                        case 2: SearchUser(); break;
                        case 3: ReportSummary(); break;
                        case 0: break;
                        default: Console.WriteLine("\nOpción no válida."); Pausa(); break;
                    }
                }
                else
                {
                    Console.WriteLine("\nOpción inválida.");
                    Pausa();
                }
            } while (opcion != 0);
        }

        private static void SearchBook()
        {
            Console.Clear();
            Console.Write("Ingrese título o autor a buscar: ");
            string criterio = Console.ReadLine()!;
            Console.WriteLine($"\nBuscando coincidencias para '{criterio}'...");
            Pausa();
        }

        private static void SearchUser()
        {
            Console.Clear();
            Console.Write("Ingrese documento del usuario: ");
            string doc = Console.ReadLine()!;
            Console.WriteLine($"\nBuscando usuario '{doc}'...");
            Pausa();
        }

        private static void ReportSummary()
        {
            Console.Clear();
            Console.WriteLine("--- Reporte General ---");
            Console.WriteLine("Total de libros: 15 | Disponibles: 12 | Prestados: 3");
            Pausa();
        }

        private static void Pausa()
        {
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}