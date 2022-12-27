using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class EstadoOTDAO: DbContext
    {
        //private MetalkitEntities _dbContext;
        private MetalkitEntities _dbContext = new MetalkitEntities();
        public EstadoOTDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<EstadoOT> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<EstadoOT> query = (from a in _dbContext.EstadoOT select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal EstadoOT Traer(int id)
        {

            var entidad = (EstadoOT)null;

            var query = from ent in _dbContext.EstadoOT
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }
        internal List<EstadoOT> TraerTodos()
        {
            var lista = new List<EstadoOT>();

            var query = from ent in _dbContext.EstadoOT
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(EstadoOT data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.EstadoOT.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(EstadoOT data) 
        {
            var guardado = false;
            try
            {
                _dbContext.EstadoOT.Remove(data);
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