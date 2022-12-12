using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class CotizacionBLL
    {
        private static CotizacionDAO _objDAO = new CotizacionDAO();
        public static IQueryable<Cotizacion> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Cotizacion Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Cotizacion> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(Cotizacion obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Cotizacion obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}