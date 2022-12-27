using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class EntregaBLL
    {
        private static EntregaDAO _objDAO = new EntregaDAO();
        public static IQueryable<Entrega> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Entrega Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Entrega> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }
        public static bool Guardar(Entrega obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Entrega obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}