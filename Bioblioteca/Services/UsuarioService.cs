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

        public bool EliminarUsuarioPorDocumento(string documento)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Documento.Equals(documento, StringComparison.OrdinalIgnoreCase));
            if (usuario == null) return false;
            return usuarios.Remove(usuario);
        }
    }
}