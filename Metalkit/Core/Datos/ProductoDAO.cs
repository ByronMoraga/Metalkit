using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class ProductoDAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public ProductoDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Producto> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Producto> query = (from a in _dbContext.Producto select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Producto Traer(int id)
        {
            var entidad = (Producto)null;

            var query = from ent in _dbContext.Producto
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<Producto> TraerTodos()
        {
            var lista = new List<Producto>();

            var query = from ent in _dbContext.Producto
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(Producto data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Producto.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Producto data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Producto.Remove(data);
                _dbContext.SaveChanges();
                var contador = _dbContext.SaveChanges();
                guardado = contador > 0;
            }
            catch (Exception)
            {
                return false;
            }
            return guardado;
        }
    }
}