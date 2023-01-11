using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class Prod_Param_subparamBLL
    {
        private static Prod_Param_subparamDAO _objDAO = new Prod_Param_subparamDAO();
        public static IQueryable<Prod_Param_subparam> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Prod_Param_subparam Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Prod_Param_subparam> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(Prod_Param_subparam obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Prod_Param_subparam obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}