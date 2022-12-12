using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class TipoProyectoBLL
    {
        private static TipoProyectoDAO _objDAO = new TipoProyectoDAO();
        public static IQueryable<TipoProyecto> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static TipoProyecto Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<TipoProyecto> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(TipoProyecto obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(TipoProyecto obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}