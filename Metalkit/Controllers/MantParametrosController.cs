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
    public class MantParametrosController : Controller
    {
        private MetalkitEntities db = new MetalkitEntities();

        // GET: MantParametros
        public ActionResult Index()
        {
            return View(db.Parametro.ToList());
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
            var query = ParametroBLL.ObtenerQueryPrincipal(filtro, sortColumn, sortColumnDir, searchValue);
            if (searchValue != "")
            {
                query = query.Where(d => d.Descripcion.Contains(searchValue));
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
                Descripcion = a.Descripcion,
                Valor = a.Valor
            }).ToList();

            return Json(new { draw = draw, recordsFiltered = totalRecords, recordsTotal = totalRecords, data = dataSalida }, JsonRequestBehavior.AllowGet);

        }

        // GET: MantParametros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parametro parametro = db.Parametro.Find(id);
            if (parametro == null)
            {
                return HttpNotFound();
            }
            return View(parametro);
        }

        // GET: MantParametros/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: MantParametros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Valor,Vigente")] Parametro parametro)
        {
            if (ModelState.IsValid)
            {
                ParametroBLL.Guardar(parametro);
                //db.Parametro.Add(parametro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            Mensajeria.SetMensaje("Parametro creado con exito", Mensajeria.TiposMensajes.Exito);
            return View(parametro);
        }

        // GET: MantParametros/Edit/5
        public ActionResult Edit(int id)
        {
            Parametro parametro = ParametroBLL.Traer(id);
            //Parametro parametro = db.Parametro.Find(id);
            if (parametro == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", parametro);
        }

        // POST: MantParametros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Valor,Vigente")] Parametro parametro)
        {
            if (ModelState.IsValid)
            {
                ParametroBLL.Guardar(parametro);
                //db.Entry(parametro).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parametro);
        }

        // GET: MantParametros/Delete/5
        public ActionResult Delete(int id)
        {
            Parametro parametro = ParametroBLL.Traer(id);

            if (parametro == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", parametro);
        }

        // POST: MantParametros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parametro parametro = ParametroBLL.Traer(id);
            ParametroBLL.Eliminar(parametro);

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
