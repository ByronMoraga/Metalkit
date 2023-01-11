using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class TipoDespachoBLL
    {
        private static TipoDespachoDAO _objDAO = new TipoDespachoDAO();
        public static IQueryable<TipoDespacho> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static TipoDespacho Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<TipoDespacho> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }
      
        public static bool Guardar(TipoDespacho obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(TipoDespacho obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}