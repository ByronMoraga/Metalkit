using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class TipoClienteBLL
    {
        private static TipoClienteDAO _objDAO = new TipoClienteDAO();
        public static IQueryable<TipoCliente> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static TipoCliente Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<TipoCliente> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }
       

        public static bool Guardar(TipoCliente obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(TipoCliente obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}