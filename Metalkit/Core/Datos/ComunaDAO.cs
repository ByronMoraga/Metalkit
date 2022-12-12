using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class ComunaDAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public ComunaDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Comuna> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Comuna> query = (from a in _dbContext.Comuna select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Comuna Traer(int id)
        {
            var entidad = (Comuna)null;

            var query = from ent in _dbContext.Comuna
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<Comuna> TraerTodos()
        {
            var lista = new List<Comuna>();

            var query = from ent in _dbContext.Comuna
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(Comuna data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Comuna.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Comuna data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Comuna.Remove(data);
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