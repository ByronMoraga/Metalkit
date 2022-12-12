using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class UsuarioDAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public UsuarioDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Usuario> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Usuario> query = (from a in _dbContext.Usuario select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Usuario Traer(int id)
        {
            var entidad = (Usuario)null;

            var query = from ent in _dbContext.Usuario
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<Usuario> TraerTodos()
        {
            var lista = new List<Usuario>();

            var query = from ent in _dbContext.Usuario
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(Usuario data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Usuario.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Usuario data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Usuario.Remove(data);
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