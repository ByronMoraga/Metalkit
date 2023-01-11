using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class DespachoDAO: DbContext
    {
        //private MetalkitEntities _dbContext;
        private MetalkitEntities _dbContext = new MetalkitEntities();
        public DespachoDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Despacho> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Despacho> query = (from a in _dbContext.Despacho select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Despacho Traer(int id)
        {

            var entidad = (Despacho)null;

            var query = from ent in _dbContext.Despacho
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }
        internal List<Despacho> TraerTodos()
        {
            var lista = new List<Despacho>();

            var query = from ent in _dbContext.Despacho
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(Despacho data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Despacho.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Despacho data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Despacho.Remove(data);
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