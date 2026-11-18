using System;
using BibliotecaElCarlitos.models;
using BibliotecaElCarlitos.Services;

namespace BibliotecaElCarlitos.Services
{
    public static class PruebaKpis
    {
        public static void EjecutarSimulacionKpis()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("    DEMOSTRACIÓN DE KPIS Y SERVICIOS    ");
            Console.WriteLine("========================================\n");

            // 1. Inicialización de los servicios
            LibroService libroService = new LibroService();
            UsuarioService usuarioService = new UsuarioService();
            PrestamoService prestamoService = new PrestamoService();

            // 2. Inyección de datos de prueba (Libros)
            Libro libro1 = new Libro("978-0307474728", "Cien Años de Soledad", "Novela", 1967);
            Libro libro2 = new Libro("978-0142437209", "Don Quijote de la Mancha", "Clásico", 1605);
            libroService.AgregarLibro(libro1);
            libroService.AgregarLibro(libro2);

            // 3. Inyección de datos de prueba (Usuarios)
            Usuario usuario1 = new Usuario("100123", "Carlos Pérez", "3001234567");
            Usuario usuario2 = new Usuario("100456", "Ana Gómez", "3109876543");
            usuarioService.AgregarUsuario(usuario1);
            usuarioService.AgregarUsuario(usuario2);

            // 4. Inyección de datos de prueba (Préstamos)
            Prestamo prestamo1 = new Prestamo("P-001", libro1.Isbn, usuario1.Documento, usuario1.Nombre, DateTime.Now.AddDays(-15));
            prestamoService.AgregarPrestamo(prestamo1);

            // 5. Visualización de KPIs en consola
            Console.WriteLine("--- KPI'S DE LIBROS ---");
            Console.WriteLine($"- Total de libros registrados : {libroService.ObtenerTotalLibros()}");
            Console.WriteLine($"- Libros disponibles          : {libroService.ObtenerLibrosDisponibles()}");
            Console.WriteLine($"- Libros prestados            : {libroService.ObtenerLibrosPrestados()}\n");

            Console.WriteLine("--- KPI'S DE USUARIOS ---");
            Console.WriteLine($"- Total de usuarios           : {usuarioService.ObtenerTotalUsuarios()}");
            Console.WriteLine($"- Usuarios activos            : {usuarioService.ObtenerUsuariosActivos()}");
            Console.WriteLine($"- Usuarios inactivos          : {usuarioService.ObtenerUsuariosInactivos()}\n");

            Console.WriteLine("--- KPI'S DE PRÉSTAMOS ---");
            Console.WriteLine($"- Total de préstamos          : {prestamoService.ObtenerTotalPrestamos()}");
            Console.WriteLine($"- Préstamos activos           : {prestamoService.ObtenerPrestamosActivos()}");
            Console.WriteLine($"- Préstamos vencidos (>14d)   : {prestamoService.ObtenerPrestamosVencidos()}");
            Console.WriteLine($"- Promedio días de préstamo   : {prestamoService.ObtenerPromedioDiasPrestamo():0.0} días\n");

            // 6. Demostración y explicación de Array vs List (Requisito Obligatorio)
            MostrarComparacionArrayVsList();

            Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        private static void MostrarComparacionArrayVsList()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("  COMPARACIÓN TÉCNICA: ARRAY VS LIST    ");
            Console.WriteLine("========================================");
            
            // Ejemplo con Array tradicional
            Libro[] arrayLibros = new Libro[1]; // Tamaño estricto de 1
            arrayLibros[0] = new Libro("ISBN-1", "Libro A", "Autor A", 2020);
            // arrayLibros[1] = new Libro(...); 
            // ERROR: Si intentamos asignar en el índice 1, arroja IndexOutOfRangeException porque el Array es de tamaño fijo.

            // Ejemplo con List<T> Dinámica
            List<Libro> listaLibros = new List<Libro>(); // Tamaño dinámico
            listaLibros.Add(new Libro("ISBN-1", "Libro A", "Autor A", 2020));
            listaLibros.Add(new Libro("ISBN-2", "Libro B", "Autor B", 2021)); 
            // ÉXITO: La lista crece automáticamente en memoria cada vez que usamos .Add().

            Console.WriteLine("1. ARRAY:");
            Console.WriteLine("   - Posee un tamaño FIJO definido al instanciarse.");
            Console.WriteLine("   - No se pueden añadir nuevos elementos si se llena el límite.");
            Console.WriteLine("\n2. LIST<T> (Lista Dinámica):");
            Console.WriteLine("   - Su tamaño es DINÁMICO y se expande o reduce automáticamente.");
            Console.WriteLine($"   - Elementos actuales en la List de prueba: {listaLibros.Count}");
            Console.WriteLine("   - Contiene métodos integrados muy potentes como .Where(), .OrderBy(), .Remove(), etc.");
            Console.WriteLine("========================================");
        }
    }
}