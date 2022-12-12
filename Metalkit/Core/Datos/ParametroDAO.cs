using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class ParametroDAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public ParametroDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Parametro> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Parametro> query = (from a in _dbContext.Parametro select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Parametro Traer(int id)
        {
            var entidad = (Parametro)null;

            var query = from ent in _dbContext.Parametro
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<Parametro> TraerTodos()
        {
            var lista = new List<Parametro>();

            var query = from ent in _dbContext.Parametro
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(Parametro data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Parametro.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Parametro data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Parametro.Remove(data);
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