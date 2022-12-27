using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class SubParametroBLL
    {
        private static SubParametroDAO _objDAO = new SubParametroDAO();
        public static IQueryable<SubParametro> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static SubParametro Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<SubParametro> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(SubParametro obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(SubParametro obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}