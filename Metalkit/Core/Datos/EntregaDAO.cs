using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class EntregaDAO: DbContext
    {
        //private MetalkitEntities _dbContext;
        private MetalkitEntities _dbContext = new MetalkitEntities();
        public EntregaDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Entrega> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Entrega> query = (from a in _dbContext.Entrega select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Entrega Traer(int id)
        {

            var entidad = (Entrega)null;

            var query = from ent in _dbContext.Entrega
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }
        internal List<Entrega> TraerTodos()
        {
            var lista = new List<Entrega>();

            var query = from ent in _dbContext.Entrega
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(Entrega data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Entrega.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Entrega data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Entrega.Remove(data);
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