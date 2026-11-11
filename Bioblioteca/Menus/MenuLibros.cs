using System;
using BibliotecaElCarlitos.models;

namespace BibliotecaElCarlitos.Menus
{
    public static class MenuLibros
    {
        public static void ShowBooksMenu()
        {
            byte opcionLibro;

            do
            {
                Console.Clear();
                Console.WriteLine("1) Menú de Libros");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Listar libros");
                Console.WriteLine("3. Ver detalle de libro (por ID/ISBN)");
                Console.WriteLine("4. Actualizar libro");
                Console.WriteLine("5. Eliminar libro");
                Console.WriteLine("0. Volver al menú principal");
                Console.WriteLine("-----------------------------");
                Console.Write("Selecciona una opción (0-5): ");

                if (byte.TryParse(Console.ReadLine(), out opcionLibro))
                {
                    switch (opcionLibro)
                    {
                        case 1: RegisterBook(); break;
                        case 2: ShowListBooksMenu(); break;
                        case 3: ViewBookDetail(); break;
                        case 4: UpdateBookMenu(); break;
                        case 5: DeleteBook(); break;
                        case 0: Console.WriteLine("\nVolviendo..."); break;
                        default: Console.WriteLine("\nOpción no válida."); Pausa(); break;
                    }
                }
                else
                {
                    Console.WriteLine("\nOpción inválida.");
                    Pausa();
                }
            } while (opcionLibro != 0);
        }

        private static void RegisterBook()
        {
            Console.Clear();
            Console.WriteLine("1.1) Registrar Libro");
            Console.Write("Ingrese Título: ");
            string titulo = Console.ReadLine()!;
            Console.Write("Ingrese Autor: ");
            string autor = Console.ReadLine()!;
            Console.Write("Ingrese Categoría: ");
            string categoria = Console.ReadLine()!;
            Console.Write("Ingrese Año de Publicación: ");

            if (!ushort.TryParse(Console.ReadLine(), out ushort anio))
            {
                Console.WriteLine("\nAño inválido. No se registró el libro.");
                Pausa();
                return;
            }

            Libro libro = new Libro(titulo, autor, categoria, anio);
            Console.WriteLine($"\nLibro registrado con éxito: {libro.TituloLibro} (ISBN: {libro.Isbn})");
            Pausa();
        }

        private static void ShowListBooksMenu()
        {
            Console.Clear();
            Console.WriteLine("--- Listado de Libros ---");
            Console.WriteLine("1. Cien Años de Soledad | Disponible");
            Console.WriteLine("2. El Principito | Prestado");
            Pausa();
        }

        private static void ViewBookDetail()
        {
            Console.Clear();
            Console.Write("Ingrese ISBN a consultar: ");
            string id = Console.ReadLine()!;
            Console.WriteLine($"\nDetalles del libro con ISBN {id}: Encontrado.");
            Pausa();
        }

        private static void UpdateBookMenu()
        {
            Console.Clear();
            Console.WriteLine("Menú Actualizar Libro (Simulado)");
            Pausa();
        }

        private static void DeleteBook()
        {
            Console.Clear();
            Console.Write("Ingrese ISBN del libro a eliminar: ");
            string id = Console.ReadLine()!;
            Console.WriteLine($"\nLibro {id} eliminado exitosamente.");
            Pausa();
        }

        private static void Pausa()
        {
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}