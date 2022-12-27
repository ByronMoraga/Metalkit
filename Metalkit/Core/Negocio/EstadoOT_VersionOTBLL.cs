using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class EstadoOT_VersionOTBLL
    {
        private static EstadoOT_VersionOTDAO _objDAO = new EstadoOT_VersionOTDAO();
        public static IQueryable<EstadoOT_VersionOT> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static EstadoOT_VersionOT Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<EstadoOT_VersionOT> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(EstadoOT_VersionOT obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(EstadoOT_VersionOT obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}