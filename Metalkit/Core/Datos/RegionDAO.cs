using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class RegionDAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public RegionDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Region> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Region> query = (from a in _dbContext.Region select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Region Traer(int id)
        {
            var entidad = (Region)null;

            var query = from ent in _dbContext.Region
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<Region> TraerTodos()
        {
            var lista = new List<Region>();

            var query = from ent in _dbContext.Region
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(Region data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Region.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Region data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Region.Remove(data);
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