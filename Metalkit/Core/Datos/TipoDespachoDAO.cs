using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class TipoDespachoDAO: DbContext
    {
        //private MetalkitEntities _dbContext;
        private MetalkitEntities _dbContext = new MetalkitEntities();
        public TipoDespachoDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<TipoDespacho> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<TipoDespacho> query = (from a in _dbContext.TipoDespacho select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal TipoDespacho Traer(int id)
        {

            var entidad = (TipoDespacho)null;

            var query = from ent in _dbContext.TipoDespacho
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<TipoDespacho> TraerTodos()
        {
            var lista = new List<TipoDespacho>();

            var query = from ent in _dbContext.TipoDespacho
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(TipoDespacho data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.TipoDespacho.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(TipoDespacho data) 
        {
            var guardado = false;
            try
            {
                _dbContext.TipoDespacho.Remove(data);
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