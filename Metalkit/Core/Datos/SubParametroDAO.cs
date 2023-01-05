using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class SubParametroDAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public SubParametroDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<SubParametro> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<SubParametro> query = (from a in _dbContext.SubParametro select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal SubParametro Traer(int id)
        {
            var entidad = (SubParametro)null;

            var query = from ent in _dbContext.SubParametro
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }
        internal List<SubParametro> TraerTodos()
        {
            var lista = new List<SubParametro>();

            var query = from ent in _dbContext.SubParametro
                        select ent;
            lista = query.ToList();
            return lista;
        }
        internal List<SubParametro> TraerPorParametro(int id)
        {
            var lista = new List<SubParametro>();

            var query = from ent in _dbContext.SubParametro
                        where ent.IdParametro == id
                        select ent;
            lista = query.ToList();
            return lista;
        }
        internal bool Guardar(SubParametro data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.SubParametro.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(SubParametro data) 
        {
            var guardado = false;
            try
            {
                _dbContext.SubParametro.Remove(data);
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