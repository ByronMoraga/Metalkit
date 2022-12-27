using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class TipoClienteDAO: DbContext
    {
        //private MetalkitEntities _dbContext;
        private MetalkitEntities _dbContext = new MetalkitEntities();
        public TipoClienteDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<TipoCliente> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<TipoCliente> query = (from a in _dbContext.TipoCliente select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal TipoCliente Traer(int id)
        {

            var entidad = (TipoCliente)null;

            var query = from ent in _dbContext.TipoCliente
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }
      

        internal List<TipoCliente> TraerTodos()
        {
            var lista = new List<TipoCliente>();

            var query = from ent in _dbContext.TipoCliente
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(TipoCliente data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.TipoCliente.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(TipoCliente data) 
        {
            var guardado = false;
            try
            {
                _dbContext.TipoCliente.Remove(data);
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