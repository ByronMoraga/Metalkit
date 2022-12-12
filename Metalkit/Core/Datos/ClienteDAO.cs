using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Core.Datos
{
    public class ClienteDAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public ClienteDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Cliente> ObtenerQueryPrincipal(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Cliente> query = (from a in _dbContext.Cliente select a);

            try
            {
             
            }
            catch (Exception)
            {

                throw;
            }


            return query;
        }
        internal Cliente Traer(int id)
        {
            var entidad = (Cliente)null;

            var query = from ent in _dbContext.Cliente
                        where ent.Id == id
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }
        internal Cliente TraerPorRut(int rut)
        {
            var entidad = (Cliente)null;

            var query = from ent in _dbContext.Cliente
                        where ent.Rut == rut
                        select ent;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<Cliente> TraerTodos()
        {
            var lista = new List<Cliente>();

            var query = from ent in _dbContext.Cliente
                        select ent;
            lista = query.ToList();
            return lista;
        }

        internal bool Guardar(Cliente data)
        {
            var guardado = false;

            try
            {
                if (_dbContext.Cliente.Any(o => o.Id == data.Id))
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
        internal bool Eliminar(Cliente data) 
        {
            var guardado = false;
            try
            {
                _dbContext.Cliente.Remove(data);
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