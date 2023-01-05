using Metalkit.Core.Datos;
using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Negocio
{
    public class Parametro_SubParametroBLL
    {
        private static Parametro_SubParametroDAO _objDAO = new Parametro_SubParametroDAO();
        public static IQueryable<Parametro_SubParametro> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            return _objDAO.ObtenerQueryPrincipal(filtro, sortColumn, sortCulumnDir, searchValue);
        }

        public static Parametro_SubParametro Traer(int id)
        {
            return _objDAO.Traer(id);
        }

        public static List<Parametro_SubParametro> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }
        public static List<Parametro_SubParametro> TraerPorParametro(int id)
        {
            return _objDAO.TraerPorParametro(id);
        }

        public static bool Guardar(Parametro_SubParametro obj)
        {
            return _objDAO.Guardar(obj);
        }
        public static bool Eliminar(Parametro_SubParametro obj)
        {
            return _objDAO.Eliminar(obj);
        }

    }
}