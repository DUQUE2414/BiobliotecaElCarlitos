namespace BibliotecaElCarlitos.models
{

    class Libro
    {
        private static int ContadorIsbn = 100;
        public string Isbn { get; set; }
        public string TituloLibro { get; set; }

        public string Autor { get; set; }

        public string Categoria { get; set; }

        public ushort AnioPublicacion { get; set; }

        public bool EstaDisponible { get; set; } = true;


        //Constructor Vacio
        public Libro()
        {
            EstaDisponible = true;
        }

        public Libro(string tituloLibro, string autor, string categoria, ushort anioPublicacion)
        {
            ContadorIsbn++;
            Isbn = ContadorIsbn.ToString();
            TituloLibro = tituloLibro;
            Autor = autor;
            Categoria = categoria;
            AnioPublicacion = anioPublicacion;
            EstaDisponible = true;
        }

        public string ResumenCorto()
        {
            return $"ISBN: {Isbn} | Titulo: {TituloLibro} | Autor: {Autor}";
        }

        public string DetalleCompleto()
        {
            string estadoLibro = EstaDisponible ? "Disponible" : "Prestado";
            return $"Libro -> ISBN: {Isbn} | Titulo: {TituloLibro} | Autor: {Autor} | Categoria: {Categoria}, Año: {AnioPublicacion} | Estado: {estadoLibro}";
        }

        public override string ToString()
        {
            return ResumenCorto();
        }

    }
}