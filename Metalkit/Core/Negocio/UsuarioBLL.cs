using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class UsuarioBLL
    {
        private static UsuarioDAO _objDAO = new UsuarioDAO();
        public static IQueryable<Usuario> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Usuario Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Usuario> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(Usuario obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Usuario obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}