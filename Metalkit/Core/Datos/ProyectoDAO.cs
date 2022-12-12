using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class ProyectoDAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public ProyectoDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<TipoProyecto> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<TipoProyecto> query = (from a in _dbContext.TipoProyecto select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal TipoProyecto Traer(int id)
        {
            var entidad = (TipoProyecto)null;

            var query = from ent in _dbContext.TipoProyecto
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<TipoProyecto> TraerTodos()
        {
            var lista = new List<TipoProyecto>();

            var query = from ent in _dbContext.TipoProyecto
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(TipoProyecto data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.TipoProyecto.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(TipoProyecto data) 
        {
            var guardado = false;
            try
            {
                _dbContext.TipoProyecto.Remove(data);
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