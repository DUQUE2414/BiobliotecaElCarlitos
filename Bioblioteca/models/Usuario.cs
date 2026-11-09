namespace BibliotecaElCarlitos.models
{
    public class Usuario
    {
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }

        public bool EstaActivo { get; set; } = true;

        // 2. Constructor vacío
        public Usuario()
        {
            EstaActivo = true;
        }

        public Usuario(string documento, string nombre, string contacto)
        {
            Documento = documento;
            Nombre = nombre;
            Contacto = contacto;
            EstaActivo = true; 
        }

        // 4. Métodos requeridos por la guía
        public string ResumenCorto()
        {
            return $"Doc: {Documento} | Nombre: {Nombre}";
        }

        public string DetalleCompleto()
        {
            string estadoTexto = EstaActivo ? "Activo" : "Inactivo";
            return $"Usuario -> Documento: {Documento}, Nombre: {Nombre}, Contacto: {Contacto}, Estado: {estadoTexto}";
        }
        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}