using System;
using BibliotecaElCarlitos.Services;

namespace BibliotecaElCarlitos.Menus
{
    public static class MenuReportes
    {
        public static void ShowSearchReportsMenu(ContextoBiblioteca biblioteca)
        {
            string? opcion;
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

                opcion = Console.ReadLine()?.Trim();

                switch (opcion)
                {
                    case "1": SearchBook(biblioteca); break;
                    case "2": SearchUser(biblioteca); break;
                    case "3": ReportSummary(biblioteca); break;
                    case "0": break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Consola.Pausa();
                        break;
                }
            } while (opcion != "0");
        }

        private static void SearchBook(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("4.1) Buscar libro");
            string criterio = Consola.LeerTexto("Ingrese ISBN, título o autor a buscar: ");
            var resultados = biblioteca.Libros.BuscarLibros(criterio);

            Console.WriteLine($"\nCoincidencias para '{criterio}': {resultados.Count}");
            foreach (var l in resultados)
                Console.WriteLine($"  * {l.DetalleCompleto()}");
            Consola.Pausa();
        }

        private static void SearchUser(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("4.2) Buscar usuario");
            string criterio = Consola.LeerTexto("Ingrese documento o nombre del usuario: ");
            var resultados = biblioteca.Usuarios.BuscarUsuarios(criterio);

            Console.WriteLine($"\nCoincidencias para '{criterio}': {resultados.Count}");
            foreach (var u in resultados)
                Console.WriteLine($"  * {u.DetalleCompleto()}");
            Consola.Pausa();
        }

        private static void ReportSummary(ContextoBiblioteca biblioteca)
        {
            Consola.Titulo("4.3) Reporte general");

            Console.WriteLine("LIBROS");
            Console.WriteLine($"  Total: {biblioteca.Libros.ObtenerTotalLibros()} | Disponibles: {biblioteca.Libros.ObtenerLibrosDisponibles()} | Prestados: {biblioteca.Libros.ObtenerLibrosPrestados()}");

            Console.WriteLine("\nUSUARIOS");
            Console.WriteLine($"  Total: {biblioteca.Usuarios.ObtenerTotalUsuarios()} | Activos: {biblioteca.Usuarios.ObtenerUsuariosActivos()} | Inactivos: {biblioteca.Usuarios.ObtenerUsuariosInactivos()}");

            Console.WriteLine("\nPRÉSTAMOS");
            Console.WriteLine($"  Total: {biblioteca.Prestamos.ObtenerTotalPrestamos()} | Activos: {biblioteca.Prestamos.ObtenerPrestamosActivos()} | Devueltos: {biblioteca.Prestamos.ObtenerPrestamosDevueltos()} | Vencidos: {biblioteca.Prestamos.ObtenerPrestamosVencidos()}");
            Console.WriteLine($"  Promedio de días de préstamo: {biblioteca.Prestamos.ObtenerPromedioDiasPrestamo():0.0}");

            Consola.Pausa();
        }
    }
}
