using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class ParametroBLL
    {
        private static ParametroDAO _objDAO = new ParametroDAO();
        public static IQueryable<Parametro> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Parametro Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Parametro> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(Parametro obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Parametro obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}