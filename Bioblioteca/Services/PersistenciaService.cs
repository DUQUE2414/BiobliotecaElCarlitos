using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using BibliotecaElCarlitos.models;

namespace BibliotecaElCarlitos.Services
{
    public class DatosBiblioteca
    {
        public List<Libro> Libros { get; set; } = new List<Libro>();
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
    }

    public static class PersistenciaService
    {
        public static string RutaArchivo { get; } =
            Path.Combine(Directory.GetCurrentDirectory(), "biblioteca_datos.json");

        private static readonly JsonSerializerOptions Opciones = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public static void Guardar(ContextoBiblioteca biblioteca)
        {
            var datos = new DatosBiblioteca
            {
                Libros = biblioteca.Libros.ObtenerTodos(),
                Usuarios = biblioteca.Usuarios.ObtenerTodos(),
                Prestamos = biblioteca.Prestamos.ObtenerTodos()
            };

            File.WriteAllText(RutaArchivo, JsonSerializer.Serialize(datos, Opciones));
        }

        public static bool Cargar(ContextoBiblioteca biblioteca)
        {
            if (!File.Exists(RutaArchivo)) return false;

            var datos = JsonSerializer.Deserialize<DatosBiblioteca>(File.ReadAllText(RutaArchivo));
            if (datos == null) return false;

            biblioteca.Libros.ReemplazarTodos(datos.Libros);
            biblioteca.Usuarios.ReemplazarTodos(datos.Usuarios);
            biblioteca.Prestamos.ReemplazarTodos(datos.Prestamos);

            int maxIsbn = datos.Libros
                .Select(l => int.TryParse(l.Isbn, out int n) ? n : 0)
                .DefaultIfEmpty(100)
                .Max();

            Libro.SincronizarContador(Math.Max(100, maxIsbn));
            return true;
        }
    }
}