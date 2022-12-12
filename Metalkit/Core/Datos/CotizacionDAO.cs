using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class CotizacionDAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public CotizacionDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Cotizacion> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Cotizacion> query = (from a in _dbContext.Cotizacion select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Cotizacion Traer(int id)
        {
            var entidad = (Cotizacion)null;

            var query = from ent in _dbContext.Cotizacion
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<Cotizacion> TraerTodos()
        {
            var lista = new List<Cotizacion>();

            var query = from ent in _dbContext.Cotizacion
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(Cotizacion data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Cotizacion.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Cotizacion data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Cotizacion.Remove(data);
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