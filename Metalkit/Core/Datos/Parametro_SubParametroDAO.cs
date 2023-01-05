using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class Parametro_SubParametroDAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public Parametro_SubParametroDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Parametro_SubParametro> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Parametro_SubParametro> query = (from a in _dbContext.Parametro_SubParametro select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Parametro_SubParametro Traer(int id)
        {
            var entidad = (Parametro_SubParametro)null;

            var query = from ent in _dbContext.Parametro_SubParametro
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<Parametro_SubParametro> TraerTodos()
        {
            var lista = new List<Parametro_SubParametro>();

            var query = from ent in _dbContext.Parametro_SubParametro
                        select ent;
            lista = query.ToList();
            return lista;
        }
        internal List<Parametro_SubParametro> TraerPorParametro(int id)
        {
            var lista = new List<Parametro_SubParametro>();

            var query = from ent in _dbContext.Parametro_SubParametro
                        where ent.IdParametro == id
                        select ent;
            lista = query.ToList();
            return lista;
        }
        internal bool Guardar(Parametro_SubParametro data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Parametro_SubParametro.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Parametro_SubParametro data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Parametro_SubParametro.Remove(data);
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