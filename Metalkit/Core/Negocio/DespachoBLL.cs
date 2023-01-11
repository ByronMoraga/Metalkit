using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class DespachoBLL
    {
        private static DespachoDAO _objDAO = new DespachoDAO();
        public static IQueryable<Despacho> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Despacho Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Despacho> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }
        public static bool Guardar(Despacho obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Despacho obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}