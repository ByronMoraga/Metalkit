using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class ParametroNivel2BLL
    {
        private static ParametroNivel2DAO _objDAO = new ParametroNivel2DAO();
        public static IQueryable<ParametroNivel2> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static ParametroNivel2 Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<ParametroNivel2> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(ParametroNivel2 obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(ParametroNivel2 obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}