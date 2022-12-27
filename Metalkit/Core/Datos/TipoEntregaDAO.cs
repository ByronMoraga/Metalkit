using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class TipoEntregaDAO: DbContext
    {
        //private MetalkitEntities _dbContext;
        private MetalkitEntities _dbContext = new MetalkitEntities();
        public TipoEntregaDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<TipoEntrega> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<TipoEntrega> query = (from a in _dbContext.TipoEntrega select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal TipoEntrega Traer(int id)
        {

            var entidad = (TipoEntrega)null;

            var query = from ent in _dbContext.TipoEntrega
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<TipoEntrega> TraerTodos()
        {
            var lista = new List<TipoEntrega>();

            var query = from ent in _dbContext.TipoEntrega
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(TipoEntrega data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.TipoEntrega.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(TipoEntrega data) 
        {
            var guardado = false;
            try
            {
                _dbContext.TipoEntrega.Remove(data);
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