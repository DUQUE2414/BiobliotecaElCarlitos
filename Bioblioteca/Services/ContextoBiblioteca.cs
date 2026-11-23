using System;
using BibliotecaElCarlitos.models;

namespace BibliotecaElCarlitos.Services
{
    public class ContextoBiblioteca
    {
        public LibroService Libros { get; } = new LibroService();
        public UsuarioService Usuarios { get; } = new UsuarioService();
        public PrestamoService Prestamos { get; } = new PrestamoService();

        public void CargarDatosPredefinidos()
        {
            // Reinicia el contador para que los ISBN predefinidos sean 101, 102, ...
            Libro.SincronizarContador(100);

            // ----- Libros -----
            var l1 = new Libro("Cien Años de Soledad", "Gabriel García Márquez", "Novela", 1967);
            var l2 = new Libro("El Principito", "Antoine de Saint-Exupéry", "Infantil", 1943);
            var l3 = new Libro("Don Quijote de la Mancha", "Miguel de Cervantes", "Clásico", 1605);
            var l4 = new Libro("La Vorágine", "José Eustasio Rivera", "Novela", 1924);
            var l5 = new Libro("El Coronel No Tiene Quien le Escriba", "Gabriel García Márquez", "Novela", 1961);
            var l6 = new Libro("Crónica de una Muerte Anunciada", "Gabriel García Márquez", "Novela", 1981);

            // Los libros con préstamo activo quedan como "Prestado"
            l1.EstaDisponible = false;
            l2.EstaDisponible = false;

            Libros.ReemplazarTodos(new[] { l1, l2, l3, l4, l5, l6 });

            // ----- Usuarios -----
            var u1 = new Usuario("100123", "Carlos Pérez", "3001234567");
            var u2 = new Usuario("100456", "María Gómez", "3119876543");
            var u3 = new Usuario("100789", "Andrés Restrepo", "3205551234");
            var u4 = new Usuario("101012", "Laura Henao", "3157778899");
            u4.EstaActivo = false;

            Usuarios.ReemplazarTodos(new[] { u1, u2, u3, u4 });

            // ----- Préstamos -----
            var p1 = new Prestamo("P-001", l1.Isbn, u1.Documento, u1.Nombre, DateTime.Now.AddDays(-5));   // activo
            var p2 = new Prestamo("P-002", l2.Isbn, u2.Documento, u2.Nombre, DateTime.Now.AddDays(-20));  // vencido
            var p3 = new Prestamo("P-003", l4.Isbn, u3.Documento, u3.Nombre, DateTime.Now.AddDays(-30));  // devuelto
            p3.Estado = EstadoPrestamo.Devuelto;
            p3.FechaDevolucion = DateTime.Now.AddDays(-18);

            Prestamos.ReemplazarTodos(new[] { p1, p2, p3 });
        }
    }
}
