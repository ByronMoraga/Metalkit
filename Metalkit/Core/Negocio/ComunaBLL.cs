using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class ComunaBLL
    {
        private static ComunaDAO _objDAO = new ComunaDAO();
        public static IQueryable<Comuna> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Comuna Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Comuna> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(Comuna obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Comuna obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}