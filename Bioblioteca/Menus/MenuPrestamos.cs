using System;

namespace BibliotecaElCarlitos.Menus
{
    public static class MenuPrestamos
    {
        public static void ShowLoansMenu()
        {
            byte opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("3) Menú de Préstamos");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Crear préstamo");
                Console.WriteLine("2. Listar préstamos");
                Console.WriteLine("3. Registrar devolución");
                Console.WriteLine("0. Volver al menú principal");
                Console.WriteLine("-----------------------------");
                Console.Write("Selecciona una opción (0-3): ");

                if (byte.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1: CreateLoan(); break;
                        case 2: ListLoans(); break;
                        case 3: ReturnLoan(); break;   // AGREGADO
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

        private static void CreateLoan()
        {
            Console.Clear();
            Console.Write("ISBN del Libro: ");
            string libro = Console.ReadLine()!;
            Console.Write("Documento Usuario: ");
            string user = Console.ReadLine()!;
            Console.WriteLine($"\nPréstamo creado con éxito para el usuario {user}.");
            Pausa();
        }

        private static void ListLoans()
        {
            Console.Clear();
            Console.WriteLine("--- Préstamos Activos ---");
            Console.WriteLine("Préstamo #501 | Libro: 101 | Usuario: 100123 | Activo");
            Pausa();
        }

        private static void ReturnLoan()
        {
            Console.Clear();
            Console.Write("ID del préstamo a devolver: ");
            string id = Console.ReadLine()!;
            Console.WriteLine($"\nDevolución registrada para el préstamo {id}.");
            Pausa();
        }

        private static void Pausa()
        {
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}