using System;

namespace BibliotecaElCarlitos.Menus
{
    public static class MenuPersistencia
    {
        public static void ShowPersistenceMenu()
        {
            byte opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("5) Menú de Guardar / Cargar Datos");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Guardar datos");
                Console.WriteLine("2. Cargar datos");
                Console.WriteLine("0. Volver al menú principal");
                Console.WriteLine("-----------------------------");
                Console.Write("Selecciona una opción (0-2): ");

                if (byte.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1: SaveData(); break;
                        case 2: LoadData(); break;
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

        private static void SaveData()
        {
            Console.Clear();
            Console.WriteLine("Guardando datos en disco exitosamente...");
            Pausa();
        }

        private static void LoadData()
        {
            Console.Clear();
            Console.WriteLine("Cargando datos desde disco exitosamente...");
            Pausa();
        }

        private static void Pausa()
        {
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}