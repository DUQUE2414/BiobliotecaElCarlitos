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
                Console.WriteLine("1. Guardar datos en disco");
                Console.WriteLine("2. Cargar datos desde disco");
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

        private static void SaveData(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("5.1) Guardar datos");
            try
            {
                PersistenciaService.Guardar(biblioteca);
                Console.WriteLine($"Datos guardados correctamente en:\n{PersistenciaService.RutaArchivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo guardar: {ex.Message}");
            }
            Consola.Pausa();
        }

        private static void LoadData(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("5.2) Cargar datos");
            try
            {
                if (PersistenciaService.Cargar(biblioteca))
                {
                    Console.WriteLine("Datos cargados correctamente.");
                    Console.WriteLine($"Libros: {biblioteca.Libros.ObtenerTotalLibros()} | Usuarios: {biblioteca.Usuarios.ObtenerTotalUsuarios()} | Préstamos: {biblioteca.Prestamos.ObtenerTotalPrestamos()}");
                }
                else
                {
                    Console.WriteLine("No existe un archivo guardado todavía. Primero usa 'Guardar datos'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo cargar: {ex.Message}");
            }
            Consola.Pausa();
        }

        private static void RestoreDefaults(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("5.3) Restaurar datos predefinidos");
            if (Consola.Confirmar("Se perderán los cambios no guardados. ¿Continuar?"))
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
    }
}
