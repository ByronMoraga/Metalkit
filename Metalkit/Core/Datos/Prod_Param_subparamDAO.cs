using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class Prod_Param_subparamDAO : DbContext
    {
        private MetalkitEntities _dbContext;

        public Prod_Param_subparamDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Prod_Param_subparam> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Prod_Param_subparam> query = (from a in _dbContext.Prod_Param_subparam select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Prod_Param_subparam Traer(int id)
        {
            var entidad = (Prod_Param_subparam)null;

            var query = from ent in _dbContext.Prod_Param_subparam
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<Prod_Param_subparam> TraerTodos()
        {
            var lista = new List<Prod_Param_subparam>();

            var query = from ent in _dbContext.Prod_Param_subparam
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(Prod_Param_subparam data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Prod_Param_subparam.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Prod_Param_subparam data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Prod_Param_subparam.Remove(data);
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