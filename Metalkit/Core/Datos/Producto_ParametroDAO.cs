using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class Producto_ParametroDAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public Producto_ParametroDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Producto_Parametro> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Producto_Parametro> query = (from a in _dbContext.Producto_Parametro select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Producto_Parametro Traer(int id)
        {
            var entidad = (Producto_Parametro)null;

            var query = from ent in _dbContext.Producto_Parametro
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<Producto_Parametro> TraerTodos()
        {
            var lista = new List<Producto_Parametro>();

            var query = from ent in _dbContext.Producto_Parametro
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(Producto_Parametro data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Producto_Parametro.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Producto_Parametro data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Producto_Parametro.Remove(data);
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