using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class Parametro_ParametroNvl2DAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public Parametro_ParametroNvl2DAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Parametro_ParametroNvl2> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Parametro_ParametroNvl2> query = (from a in _dbContext.Parametro_ParametroNvl2 select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Parametro_ParametroNvl2 Traer(int id)
        {
            var entidad = (Parametro_ParametroNvl2)null;

            var query = from ent in _dbContext.Parametro_ParametroNvl2
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<Parametro_ParametroNvl2> TraerTodos()
        {
            var lista = new List<Parametro_ParametroNvl2>();

            var query = from ent in _dbContext.Parametro_ParametroNvl2
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(Parametro_ParametroNvl2 data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Parametro_ParametroNvl2.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Parametro_ParametroNvl2 data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Parametro_ParametroNvl2.Remove(data);
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