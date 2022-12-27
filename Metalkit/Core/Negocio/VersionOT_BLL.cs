using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class VersionOTBLL
    {
        private static VersionOTDAO _objDAO = new VersionOTDAO();
        public static IQueryable<VersionOT> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static VersionOT Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<VersionOT> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }
       
        public static bool Guardar(VersionOT obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(VersionOT obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}