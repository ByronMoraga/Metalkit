using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class TipoParametroBLL
    {
        private static TipoParametroDAO _objDAO = new TipoParametroDAO();
        public static IQueryable<TipoParametro> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static TipoParametro Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<TipoParametro> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }
      
        public static bool Guardar(TipoParametro obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(TipoParametro obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}