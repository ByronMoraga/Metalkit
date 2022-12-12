using Kybernan.Core.Datos;
using Kybernan.Core.Entidad;
using Kybernan.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kybernan.Core.Negocio
{
    public class UsuarioBLL
    {
        private static T011_VehiculoDAO _objDAO = new T011_VehiculoDAO();

        public static T011_Vehiculo Traer(int Id)
        {
            return _objDAO.Traer(Id);
        }

        public static List<T011_Vehiculo> TraerTodos()
        {
            return _objDAO.TraerTodos();
        }

        public static bool Guardar(T011_Vehiculo obj)
        {
            return _objDAO.Guardar(obj);
        }
        
        //public static List<T011_Vehiculo> ListadoVehiculosPorArriendo(int id)
        //{
        //    return _objDAO.ListadoVehiculosPorArriendo(id);
        //}
        public static bool ExistePatente(string patente, int idArriendo)
        {
             return _objDAO.ExistePatente(patente, idArriendo);
        }

        public static List<T017_RegistroVehiculo> ListaVehiculoPorRegistro(int id)
        {
            return _objDAO.ListaVehiculoRegistro(id);
        }
        public static List<VMFicha> ListaFichaPatentes(int id)
        {
            return _objDAO.ListaFichaPatentes(id);
        }
        //public List<T011_Vehiculo> ListaFichaPatentes(int id)
        //{
        //    T011_VehiculoDAO objDAO = new T011_VehiculoDAO();
        //    return objDAO.ListaFichaPatentes(id);
        //}

    }
}
