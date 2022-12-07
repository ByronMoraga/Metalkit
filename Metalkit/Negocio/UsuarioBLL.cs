using Metalkit.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Negocio
{
    public class UsuarioBLL
    {
        private static UsuarioDAO _objDAO = new UsuarioDAO();
        public static IQueryable<Usuario> obtenerParametro(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.obtenerParametro(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Usuario Traer(int Id)
        {
            return _objDAO.Traer(Id);
        }

        public static List<Usuario> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(Usuario obj)
        {
            return _objDAO.Guardar(obj);
        }

    }
}