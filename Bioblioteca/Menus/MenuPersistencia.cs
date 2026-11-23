using System;
using BibliotecaElCarlitos.Services;

namespace BibliotecaElCarlitos.Menus
{
    public static class MenuPersistencia
    {
        public static void ShowPersistenceMenu(ContextoBiblioteca biblioteca)
        {
            string? opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("5) Menú de Guardar / Cargar Datos");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Guardar datos");
                Console.WriteLine("2. Cargar datos");
                Console.WriteLine("3. Restaurar datos predefinidos");
                Console.WriteLine("0. Volver al menú principal");
                Console.WriteLine("-----------------------------");
                Console.Write("Selecciona una opción (0-3): ");

                opcion = Console.ReadLine()?.Trim();

                switch (opcion)
                {
                    case "1": SaveData(biblioteca); break;
                    case "2": LoadData(biblioteca); break;
                    case "3": RestoreDefaults(biblioteca); break;
                    case "0": break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Consola.Pausa();
                        break;
                }
            } while (opcion != "0");
        }

        // Simulado: no se crea ningún archivo, solo se muestra por consola lo que hay en las colecciones.
        private static void SaveData(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("5.1) Guardar datos (simulado)");
            Console.WriteLine("Guardando datos... (Simulacion)\n");
            MostrarDatos(biblioteca);
            Console.WriteLine("\nDatos guardados exitosamente (simulación).");
            Consola.Pausa();
        }

        // Simulado: los datos ya viven en las colecciones en memoria.
        private static void LoadData(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("5.2) Cargar datos (simulado)");
            Console.WriteLine("Cargando datos... (no se lee ningún archivo)\n");
            MostrarDatos(biblioteca);
            Console.WriteLine("\nDatos cargados exitosamente (simulación).");
            Consola.Pausa();
        }

        private static void RestoreDefaults(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("5.3) Restaurar datos predefinidos");
            if (Consola.Confirmar("Se perderán los cambios hechos. ¿Continuar?"))
            {
                biblioteca.CargarDatosPredefinidos();
                Console.WriteLine("\nDatos predefinidos restaurados.");
            }
            else
            {
                Console.WriteLine("\nOperación cancelada.");
            }
            Consola.Pausa();
        }

        private static void MostrarDatos(ContextoBiblioteca biblioteca)
        {
            Console.WriteLine($"--- LIBROS ({biblioteca.Libros.ObtenerTotalLibros()}) ---");
            foreach (var l in biblioteca.Libros.ObtenerTodos())
                Console.WriteLine($"  {l.DetalleCompleto()}");

            Console.WriteLine($"\n--- USUARIOS ({biblioteca.Usuarios.ObtenerTotalUsuarios()}) ---");
            foreach (var u in biblioteca.Usuarios.ObtenerTodos())
                Console.WriteLine($"  {u.DetalleCompleto()}");

            Console.WriteLine($"\n--- PRÉSTAMOS ({biblioteca.Prestamos.ObtenerTotalPrestamos()}) ---");
            foreach (var p in biblioteca.Prestamos.ObtenerTodos())
                Console.WriteLine($"  {p.ResumenCorto()}");
        }
    }
}
