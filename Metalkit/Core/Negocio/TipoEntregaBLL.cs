using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class TipoEntregaBLL
    {
        private static TipoEntregaDAO _objDAO = new TipoEntregaDAO();
        public static IQueryable<TipoEntrega> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static TipoEntrega Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<TipoEntrega> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }
      
        public static bool Guardar(TipoEntrega obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(TipoEntrega obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}