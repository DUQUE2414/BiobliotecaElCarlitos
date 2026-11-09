namespace BibliotecaElCarlitos.models
{
    public class Prestamo
    {
        public string IdPrestamo { get; set; }
        public string IsbnLibro { get; set; }
        public string DocumentoUsuario { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public EstadoPrestamo Estado { get; set; } = EstadoPrestamo.Activo;

        public Prestamo()
        {
            Estado = EstadoPrestamo.Activo;
            FechaDevolucion = null;
        }

        public Prestamo(string idPrestamo, string isbnLibro, string documentoUsuario, DateTime fechaPrestamo)
        {
            IdPrestamo = idPrestamo;
            IsbnLibro = isbnLibro;
            DocumentoUsuario = documentoUsuario;
            FechaPrestamo = fechaPrestamo;

            FechaDevolucion = null;
            Estado = EstadoPrestamo.Activo;
        }


        public int DiasTranscurridos()
        {
            DateTime fechaFin = FechaDevolucion ?? DateTime.Now;
            return (int)(fechaFin - FechaPrestamo).TotalDays;
        }

        public bool EstaVencido()
        {
            if (Estado == EstadoPrestamo.Devuelto) return false;
            return (DateTime.Now - FechaPrestamo).TotalDays > 14;
        }

        public string ResumenCorto()
        {
            return $"Préstamo #{IdPrestamo} | Libro: {IsbnLibro} | Usuario: {DocumentoUsuario} | Estado: {Estado}";
        }

        public string DetalleCompleto()
        {
            string fechaDevStr = FechaDevolucion.HasValue ? FechaDevolucion.Value.ToShortDateString() : "Pendiente de devolución";

            return $"""
        ========================================
                 DETALLE DE PRÉSTAMO           
        ========================================
        ID Préstamo        : {IdPrestamo}
        ISBN Libro         : {IsbnLibro}
        Documento Usuario  : {DocumentoUsuario}
        Fecha Préstamo     : {FechaPrestamo:dd/MM/yyyy}
        Fecha Devolución   : {fechaDevStr}
        Estado             : {Estado}
        ¿Está vencido?     : {(EstaVencido() ? "SÍ" : "NO")}
        Días transcurridos : {DiasTranscurridos()} días
        ========================================
        """;
        }
    }
}