using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class VersionOTDAO: DbContext
    {
        //private MetalkitEntities _dbContext;
        private MetalkitEntities _dbContext = new MetalkitEntities();
        public VersionOTDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<VersionOT> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<VersionOT> query = (from a in _dbContext.VersionOT select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal VersionOT Traer(int id)
        {

            var entidad = (VersionOT)null;

            var query = from ent in _dbContext.VersionOT
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }
     
        internal List<VersionOT> TraerTodos()
        {
            var lista = new List<VersionOT>();

            var query = from ent in _dbContext.VersionOT
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(VersionOT data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.VersionOT.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(VersionOT data) 
        {
            var guardado = false;
            try
            {
                _dbContext.VersionOT.Remove(data);
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