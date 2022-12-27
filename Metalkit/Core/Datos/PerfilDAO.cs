using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class PerfilDAO: DbContext
    {
        //private MetalkitEntities _dbContext;
        private MetalkitEntities _dbContext = new MetalkitEntities();
        public PerfilDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Perfil> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Perfil> query = (from a in _dbContext.Perfil select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Perfil Traer(int id)
        {

            var entidad = (Perfil)null;

            var query = from ent in _dbContext.Perfil
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }
       

        internal List<Perfil> TraerTodos()
        {
            var lista = new List<Perfil>();

            var query = from ent in _dbContext.Perfil
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(Perfil data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Perfil.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Perfil data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Perfil.Remove(data);
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