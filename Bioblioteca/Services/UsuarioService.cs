using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaElCarlitos.models;

namespace BibliotecaElCarlitos.Services
{
    public class UsuarioService
    {
        private List<Usuario> usuarios = new List<Usuario>();

        // 1. Agregar usuario
        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        // 2. Obtener todos los usuarios
        public List<Usuario> ObtenerTodos()
        {
            return usuarios;
        }

        // 3. Buscar usuario por documento o nombre
        public List<Usuario> BuscarUsuarios(string criterio)
        {
            return usuarios.Where(u =>
                u.Documento.Equals(criterio, StringComparison.OrdinalIgnoreCase) ||
                u.Nombre.Contains(criterio, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        public Usuario? BuscarPorDocumento(string documento)
        {
            return usuarios.FirstOrDefault(u => u.Documento.Equals(documento, StringComparison.OrdinalIgnoreCase));
        }

        // 4. Ordenar usuarios por nombre
        public List<Usuario> OrdenarPorNombre()
        {
            return usuarios.OrderBy(u => u.Nombre).ToList();
        }

        // 5. KPIs de Usuarios
        public int ObtenerTotalUsuarios()
        {
            return usuarios.Count;
        }

        public int ObtenerUsuariosActivos()
        {
            return usuarios.Count(u => u.EstaActivo);
        }

        public int ObtenerUsuariosInactivos()
        {
            return usuarios.Count(u => !u.EstaActivo);
        }

        // 6. Actualizar
        public bool ActualizarUsuario(string documento, string nombre, string contacto, bool estaActivo)
        {
            var usuario = BuscarPorDocumento(documento);
            if (usuario == null) return false;
            usuario.Nombre = nombre;
            usuario.Contacto = contacto;
            usuario.EstaActivo = estaActivo;
            return true;
        }

        // 7. Eliminar
        public bool EliminarUsuarioPorDocumento(string documento)
        {
            var usuario = BuscarPorDocumento(documento);
            if (usuario == null) return false;
            return usuarios.Remove(usuario);
        }

        // 8. Reemplazar toda la colección
        public void ReemplazarTodos(IEnumerable<Usuario> nuevos)
        {
            var copia = nuevos.ToList();
            usuarios.Clear();
            usuarios.AddRange(copia);
        }
    }
}
