using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class RegionBLL
    {
        private static RegionDAO _objDAO = new RegionDAO();
        public static IQueryable<Region> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Region Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Region> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(Region obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Region obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}