using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaElCarlitos.models;

namespace BibliotecaElCarlitos.Services
{
    public class PrestamoService
    {
        private List<Prestamo> prestamos = new List<Prestamo>();

        // 1. Agregar préstamo
        public void AgregarPrestamo(Prestamo prestamo)
        {
            prestamos.Add(prestamo);
        }

        // 2. Obtener todos los préstamos
        public List<Prestamo> ObtenerTodos()
        {
            return prestamos;
        }

        // 3. Buscar préstamo por ID o Estado
        public List<Prestamo> BuscarPorId(string id)
        {
            return prestamos.Where(p => p.IdPrestamo.Equals(id, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Prestamo? ObtenerPorId(string id)
        {
            return prestamos.FirstOrDefault(p => p.IdPrestamo.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
        {
            return prestamos.Where(p => p.Estado == estado).ToList();
        }

        // 4. Ordenar préstamos por fecha de préstamo
        public List<Prestamo> OrdenarPorFecha()
        {
            return prestamos.OrderBy(p => p.FechaPrestamo).ToList();
        }

        // 5. KPIs y Estadísticas de Préstamos
        public int ObtenerTotalPrestamos()
        {
            return prestamos.Count;
        }

        public int ObtenerPrestamosActivos()
        {
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Activo);
        }

        public int ObtenerPrestamosDevueltos()
        {
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto);
        }

        public int ObtenerPrestamosVencidos()
        {
            return prestamos.Count(p => p.EstaVencido());
        }

        public double ObtenerPromedioDiasPrestamo()
        {
            if (prestamos.Count == 0) return 0;
            return prestamos.Average(p => p.DiasTranscurridos());
        }

        // 6. Generar un ID nuevo: P-001, P-002, ...
        public string GenerarNuevoId()
        {
            int max = prestamos
                .Select(p => int.TryParse(p.IdPrestamo.Replace("P-", ""), out int n) ? n : 0)
                .DefaultIfEmpty(0)
                .Max();
            return $"P-{max + 1:000}";
        }

        // 7. Registrar devolución (el menú se encarga de liberar el libro)
        public bool RegistrarDevolucion(string idPrestamo)
        {
            var prestamo = ObtenerPorId(idPrestamo);
            if (prestamo == null || prestamo.Estado == EstadoPrestamo.Devuelto) return false;
            prestamo.Estado = EstadoPrestamo.Devuelto;
            prestamo.FechaDevolucion = DateTime.Now;
            return true;
        }

        // 8. Eliminar
        public bool EliminarPrestamoPorId(string idPrestamo)
        {
            var prestamo = ObtenerPorId(idPrestamo);
            if (prestamo == null) return false;
            return prestamos.Remove(prestamo);
        }

        // 9. Reemplazar toda la colección
        public void ReemplazarTodos(IEnumerable<Prestamo> nuevos)
        {
            var copia = nuevos.ToList();
            prestamos.Clear();
            prestamos.AddRange(copia);
        }
    }
}
