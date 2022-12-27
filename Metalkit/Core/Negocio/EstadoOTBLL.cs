using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class EstadoOTBLL
    {
        private static EstadoOTDAO _objDAO = new EstadoOTDAO();
        public static IQueryable<EstadoOT> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static EstadoOT Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<EstadoOT> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }
        public static bool Guardar(EstadoOT obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(EstadoOT obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}