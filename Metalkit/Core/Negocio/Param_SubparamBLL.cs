using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class Param_SubparamBLL
    {
        private static Param_SubparamDAO _objDAO = new Param_SubparamDAO();
        public static IQueryable<Param_Subparam> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Param_Subparam Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Param_Subparam> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }
        public static List<Param_Subparam> TraerPorParametro(int id)
        {
            return _objDAO.TraerPorParametro(id);
        }

        public static bool Guardar(Param_Subparam obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Param_Subparam obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}