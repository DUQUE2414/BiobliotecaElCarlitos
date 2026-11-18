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

        // 4. Ordenar préstamos por fecha de préstamo (análogo a fecha límite)
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
    }
}