using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class TipoParametroDAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public TipoParametroDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<TipoParametro> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<TipoParametro> query = (from a in _dbContext.TipoParametro select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal TipoParametro Traer(int id)
        {
            var entidad = (TipoParametro)null;

            var query = from ent in _dbContext.TipoParametro
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<TipoParametro> TraerTodos()
        {
            var lista = new List<TipoParametro>();

            var query = from ent in _dbContext.TipoParametro
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(TipoParametro data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.TipoParametro.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(TipoParametro data) 
        {
            var guardado = false;
            try
            {
                _dbContext.TipoParametro.Remove(data);
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