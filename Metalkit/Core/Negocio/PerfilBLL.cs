using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class PerfilBLL
    {
        private static PerfilDAO _objDAO = new PerfilDAO();
        public static IQueryable<Perfil> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Perfil Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Perfil> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }
        public static bool Guardar(Perfil obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Perfil obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}