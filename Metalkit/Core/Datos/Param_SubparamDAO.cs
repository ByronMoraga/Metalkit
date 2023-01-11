using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class Param_SubparamDAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public Param_SubparamDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Param_Subparam> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Param_Subparam> query = (from a in _dbContext.Param_Subparam select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Param_Subparam Traer(int id)
        {
            var entidad = (Param_Subparam)null;

            var query = from ent in _dbContext.Param_Subparam
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<Param_Subparam> TraerTodos()
        {
            var lista = new List<Param_Subparam>();

            var query = from ent in _dbContext.Param_Subparam
                        select ent;
            lista = query.ToList();
            return lista;
        }
        internal List<Param_Subparam> TraerPorParametro(int id)
        {
            var lista = new List<Param_Subparam>();

            var query = from ent in _dbContext.Param_Subparam
                        where ent.IdParametro == id
                        select ent;
            lista = query.ToList();
            return lista;
        }
        internal bool Guardar(Param_Subparam data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Param_Subparam.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Param_Subparam data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Param_Subparam.Remove(data);
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