using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class ProductoBLL
    {
        private static ProductoDAO _objDAO = new ProductoDAO();
        public static IQueryable<Producto> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Producto Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Producto> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(Producto obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Producto obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}