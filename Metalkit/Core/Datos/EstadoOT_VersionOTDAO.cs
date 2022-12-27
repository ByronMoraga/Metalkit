using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class EstadoOT_VersionOTDAO: DbContext
    {
        //private MetalkitEntities _dbContext;
        private MetalkitEntities _dbContext = new MetalkitEntities();
        public EstadoOT_VersionOTDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<EstadoOT_VersionOT> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<EstadoOT_VersionOT> query = (from a in _dbContext.EstadoOT_VersionOT select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal EstadoOT_VersionOT Traer(int id)
        {

            var entidad = (EstadoOT_VersionOT)null;

            var query = from ent in _dbContext.EstadoOT_VersionOT
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }
        internal List<EstadoOT_VersionOT> TraerTodos()
        {
            var lista = new List<EstadoOT_VersionOT>();

            var query = from ent in _dbContext.EstadoOT_VersionOT
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(EstadoOT_VersionOT data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.EstadoOT_VersionOT.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(EstadoOT_VersionOT data) 
        {
            var guardado = false;
            try
            {
                _dbContext.EstadoOT_VersionOT.Remove(data);
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