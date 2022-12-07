using Kybernan.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Kybernan.Core.Datos
{
    public class T007_ProveedorDAO : DbContext
    {
        private A0DigitalEntities _dbContext;

        public T007_ProveedorDAO()
        {
            if (_dbContext == null)
                _dbContext = new A0DigitalEntities();
        }

        internal T007_Proveedor Traer(int Id)
        {
            var entidad = (T007_Proveedor)null;

            var query = from provedor in _dbContext.T007_Proveedor
                        where provedor.Id == Id
                        select provedor;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<T007_Proveedor> TraerTodos()
        {
            var lista = new List<T007_Proveedor>();

            var query = from provedor in _dbContext.T007_Proveedor
                            //(!perfil.HasValue | usuario.Perfil == perfil) && (!area.HasValue | usuario.Area == area)
                        select provedor;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(T007_Proveedor data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.T007_Proveedor.Any(o => o.Id == data.Id))
                {
                    _dbContext.Entry(data).State = EntityState.Modified;
                }
                else
                {
                    _dbContext.Entry(data).State = EntityState.Added;
                }
                var contador = _dbContext.SaveChanges();
                guardado = contador > 0;
            }
            catch (Exception)
            {
            }
            return guardado;
        }
    }
}
