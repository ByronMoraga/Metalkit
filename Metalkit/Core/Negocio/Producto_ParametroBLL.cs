using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class Producto_ParametroBLL
    {
        private static Producto_ParametroDAO _objDAO = new Producto_ParametroDAO();
        public static IQueryable<Producto_Parametro> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Producto_Parametro Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Producto_Parametro> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(Producto_Parametro obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Producto_Parametro obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}