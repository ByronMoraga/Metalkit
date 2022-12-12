using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class ClienteBLL
    {
        private static ClienteDAO _objDAO = new ClienteDAO();
        public static IQueryable<Cliente> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Cliente Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Cliente> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }
        public static Cliente TraerPorRut(int id)
        {
            return _objDAO.TraerPorRut(id);
        }

        public static bool Guardar(Cliente obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Cliente obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}