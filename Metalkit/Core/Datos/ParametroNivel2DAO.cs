using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class ParametroNivel2DAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public ParametroNivel2DAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<ParametroNivel2> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<ParametroNivel2> query = (from a in _dbContext.ParametroNivel2 select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal ParametroNivel2 Traer(int id)
        {
            var entidad = (ParametroNivel2)null;

            var query = from ent in _dbContext.ParametroNivel2
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<ParametroNivel2> TraerTodos()
        {
            var lista = new List<ParametroNivel2>();

            var query = from ent in _dbContext.ParametroNivel2
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(ParametroNivel2 data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.ParametroNivel2.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(ParametroNivel2 data) 
        {
            var guardado = false;
            try
            {
                _dbContext.ParametroNivel2.Remove(data);
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