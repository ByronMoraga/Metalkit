using Metalkit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Metalkit.Datos
{
    public class UsuarioDAO: DbContext
    {
        private MetalkitEntities _dbContext;

        public UsuarioDAO()
        {
            if (_dbContext == null)
                _dbContext = new MetalkitEntities();
        }
        internal IQueryable<Usuario> obtenerParametro(string filtro, string sortColumn, string sortCulumnDir, string searchValue)
        {
            IQueryable<Usuario> v = (from a in _dbContext.Usuario select a);

            try
            {
                ////Filtros
                //if (!string.IsNullOrEmpty(filtro))
                //{
                //    v = v.Where(a => a.ALCParametros_TipoSensometrico_id.ToString().Contains(filtro));
                //}
                ////shorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortCulumnDir)))
                //{
                //    v = v.OrderBy(sortColumn + " " + sortCulumnDir);
                //}
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    v = v.Where(a => a.CODIGO == searchValue || a.VALOR.ToString() == searchValue || a.ALCParametros_TipoSensometrico.TIPO_PARAMETRO == searchValue);
                //}
                //v = v.Include(x => x.ALCParametros_TipoSensometrico);
            }
            catch (Exception)
            {

                throw;
            }


            return v;
        }
        internal Usuario Traer(int Id)
        {
            var entidad = (Usuario)null;

            var query = from provedor in _dbContext.Usuario
                        where provedor.Id == Id
                        select provedor;

            entidad = query.FirstOrDefault();

            return entidad;
        }

        internal List<Usuario> TraerTodos()
        {
            var lista = new List<Usuario>();

            var query = from provedor in _dbContext.Usuario
                            //(!perfil.HasValue | usuario.Perfil == perfil) && (!area.HasValue | usuario.Area == area)
                        select provedor;
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
    }
}