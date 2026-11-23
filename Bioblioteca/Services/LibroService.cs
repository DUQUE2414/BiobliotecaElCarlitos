using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaElCarlitos.models;

namespace BibliotecaElCarlitos.Services
{
    public class LibroService
    {
        // Colección dinámica requerida
        private List<Libro> libros = new List<Libro>();

        // 1. Agregar libro
        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        // 2. Obtener todos los libros
        public List<Libro> ObtenerTodos()
        {
            return libros;
        }

        // 3. Buscar libro por ISBN, Título o Autor
        public List<Libro> BuscarLibros(string criterio)
        {
            return libros.Where(l =>
                l.Isbn.Equals(criterio, StringComparison.OrdinalIgnoreCase) ||
                l.TituloLibro.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                l.Autor.Contains(criterio, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        // 4. Ordenar libros por Título o Año
        public List<Libro> OrdenarPorTitulo()
        {
            return libros.OrderBy(l => l.TituloLibro).ToList();
        }

        public List<Libro> OrdenarPorAnio()
        {
            return libros.OrderBy(l => l.AnioPublicacion).ToList();
        }

        // 5. KPIs y Estadísticas obligatorias
        public int ObtenerTotalLibros()
        {
            return libros.Count;
        }

        public int ObtenerLibrosDisponibles()
        {
            return libros.Count(l => l.EstaDisponible);
        }

        public int ObtenerLibrosPrestados()
        {
            return libros.Count(l => !l.EstaDisponible);
        }

        public bool EliminarLibroPorIsbn(string isbn)
        {
            var libro = libros.FirstOrDefault(l => l.Isbn.Equals(isbn, StringComparison.OrdinalIgnoreCase));
            if (libro == null) return false;
            return libros.Remove(libro);
        }
    }
}