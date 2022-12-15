using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class Parametro_ParametroNvl2BLL
    {
        private static Parametro_ParametroNvl2DAO _objDAO = new Parametro_ParametroNvl2DAO();
        public static IQueryable<Parametro_ParametroNvl2> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Parametro_ParametroNvl2 Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Parametro_ParametroNvl2> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(Parametro_ParametroNvl2 obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Parametro_ParametroNvl2 obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}