using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Metalkit.Models;
using Metalkit.Core.Negocio;
using Proyecto.Utilitarios;
using System.Linq.Dynamic;

namespace Metalkit.Controllers
{
    public class MantUsuariosController : Controller
    {
        private MetalkitEntities db = new MetalkitEntities();

        // GET: MantUsuarios
        public ActionResult Index()
        {
            return View(db.Usuario.ToList());
        }

        public ActionResult ObtenerConsultas(string filtro = "")
        {
            //get Start(paging start index) and length(page size for paging)
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            //Get Sort columns value
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int totalRecords = 0;

            //busquedaPaginada(int? idArea, int? IdCentroCosto, string rutPersona, string folio, string sortColumn = "", string sortColumnDir = "")
            var query = UsuarioBLL.ObtenerQueryPrincipal(filtro, sortColumn, sortColumnDir, searchValue);
            if (searchValue!="")
            {
                query = query.Where(d => d.Nombre.Contains(searchValue));
            }
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                query = query.OrderBy(sortColumn + " " + sortColumnDir);
            }
            totalRecords = query.Count();
            var listado = query.Skip(skip).Take(pageSize).ToList();

            // Aca se colocan solamente los atributos que seran mostrados en la tabla. Ej: id y valor
            var dataSalida = listado.Select(a => new
            {
                Id = a.Id,
                Rut = a.Rut,
                Nombre = a.Nombre,
                ApellidoPaterno = a.ApellidoPaterno,
                ApellidoMaterno = a.ApellidoMaterno,
                Correo = a.Correo,
                idPerfil = a.idPerfil,
                Estado = a.Estado
            }).ToList();

            return Json(new { draw = draw, recordsFiltered = totalRecords, recordsTotal = totalRecords, data = dataSalida }, JsonRequestBehavior.AllowGet);

        }

        // GET: MantUsuarios/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: MantUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rut,Nombre,ApellidoPaterno,ApellidoMaterno,Correo,Contraseña,idPerfil,Estado")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                UsuarioBLL.Guardar(usuario);
                //db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            Mensajeria.SetMensaje("Usuario creado con exito", Mensajeria.TiposMensajes.Exito);
            return View(usuario);
        }

        // GET: MantUsuarios/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario usuario = UsuarioBLL.Traer(id);
            //Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit",usuario);
        }

        // POST: MantUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rut,Nombre,ApellidoPaterno,ApellidoMaterno,Correo,Contraseña,idPerfil,Estado")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                UsuarioBLL.Guardar(usuario);
                //db.Entry(usuario).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: MantUsuarios/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario usuario = UsuarioBLL.Traer(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete",usuario);
        }

        // POST: MantUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = UsuarioBLL.Traer(id);
            UsuarioBLL.Eliminar(usuario);
           
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
