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
    public class FormulariosController : Controller
    {
        private MetalkitEntities db = new MetalkitEntities();

        // GET: CotizacionEstandar
        public ActionResult Index()
        {

            List<TipoProyecto> tipoProyecto = TipoProyectoBLL.TraerTodos();
            List<Region> region = RegionBLL.TraerTodos();
            List<Comuna> comuna = new List<Comuna>();

            ViewBag.itipoproyecto = new SelectList(tipoProyecto, "Id", "Tipo");
            ViewBag.iregion = new SelectList(region, "Id", "Nombre");
            ViewBag.icomuna = new SelectList(comuna, "Id", "Nombre");

            return View();

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
            var query = ProductoBLL.ObtenerQueryPrincipal(filtro, sortColumn, sortColumnDir, searchValue);
            List<Producto> listado = query.ToList();
            if (!string.IsNullOrEmpty(filtro))
            {
                listado = listado.Where(d => d.Id == int.Parse(filtro)).ToList();
            }

            // Aca se colocan solamente los atributos que seran mostrados en la tabla. Ej: id y valor
            var dataSalida = listado.Select(a => new
            {
                id = a.Id,
                codigo = a.Codigo,
                descripcion = a.Descripcion,
                superficie = a.Superficie,
                valor = a.Valor,
            }).ToList();

            return Json(new { draw = draw, recordsFiltered = totalRecords, recordsTotal = totalRecords, data = dataSalida }, JsonRequestBehavior.AllowGet);

        }

        // GET: CotizacionEstandar/Create
        public ActionResult CreateCliente()
        {
            List<TipoProyecto> tipoProyecto = TipoProyectoBLL.TraerTodos();
            List<Region> region = RegionBLL.TraerTodos();
            List<Comuna> comuna = new List<Comuna>();

            ViewBag.itipoproyecto = new SelectList(tipoProyecto, "Id", "Tipo");
            ViewBag.iregion = new SelectList(region, "Id", "Nombre");
            ViewBag.icomuna = new SelectList(comuna, "Id", "Nombre");

            return PartialView("_CreateCliente");
        }
        public ActionResult CreateEstandar()
        {
            List<Region> region = RegionBLL.TraerTodos();
            List<Comuna> comuna = new List<Comuna>();
           
            ViewBag.iregionEnvio = new SelectList(region, "Id", "Nombre");
            ViewBag.icomunaEnvio = new SelectList(comuna, "Id", "Nombre");

            List<Producto> proyecto = ProductoBLL.TraerTodos();
            //ViewBag.iproyecto = new SelectList(proyecto, "Id", "Descripcion");

            return PartialView("_CotizacionEstandar");
        }
        public ActionResult CreatePersonalizada()
        {
            //ViewBag.iproyecto = new SelectList(proyecto, "Id", "Descripcion");

            return PartialView("_CotizacionPersonalizada");
        }

        // POST: CotizacionEstandar/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEstandar(FormCollection form)
        {
            Cliente cliente = new Cliente();
            Cotizacion cotizacion = new Cotizacion();
            Despacho despacho = new Despacho();
            EstadoOT estado = new EstadoOT();
            Parametro_SubParametro parametro_subparametro;
            Producto_Parametro producto_Parametro;
            List<SubParametro> listSubParam = new List<SubParametro>();
            try
            {
                cliente = ClienteBLL.TraerPorRut(Utilidades.RutSinDV(form["tbRutBusqueda"]));
                foreach (var item in listSubParam)
                {
                    Parametro_SubParametroBLL.Guardar(parametro_subparametro = new Parametro_SubParametro()
                    {
                        IdParametro = 1,
                        IdSubParametro = item.Id
                    });
                    Producto_ParametroBLL.Guardar(producto_Parametro = new Producto_Parametro()
                    {
                        Id = 1,
                        IdProducto = int.Parse(form["iproducto"]),
                        IdParametro = parametro_subparametro.Id
                    });
                }


                cotizacion.IdTipoProyecto = 1;

            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCliente(FormCollection form)
        {
            Cliente cliente = new Cliente();
            bool success = false;
            string message = "";
            try
            {
                cliente = ClienteBLL.TraerPorRut(Utilidades.RutSinDV(form["tbRutBusqueda"]));
                cliente.Rut = Utilidades.RutSinDV(form["tbRutBusqueda"]);
                cliente.Dv = Utilidades.DV(form["tbRutBusqueda"]);
                cliente.RazonSocial = form["tbRazonSocial"];
                cliente.Direccion = form["tbDireccion"];
                cliente.IdComuna = Convert.ToByte(form["icomuna"]);
                cliente.Giro = form["tbGiro"];
                cliente.NombreContacto = form["tbNombre"];
                cliente.ApellidoContacto = form["tbApellido"];
                cliente.CorreoContacto = form["tbCorreo"];
                cliente.TelefonoContacto = form["tbTelefono"];

                ClienteBLL.Guardar(cliente);
                message = "Registro almacenado Correctamente";
                success = true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                success = false;
            }

            return PartialView("_CreateCliente", cliente);

            //return new JsonResult { Data = new { success, message } };

        }
        // GET: CotizacionEstandar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion proyecto = db.Cotizacion.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: CotizacionEstandar/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdProducto,IdEntrega,IdTipoProyecto")] Cotizacion proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("CotizacionEstandar", proyecto);
        }

        // GET: CotizacionEstandar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion proyecto = db.Cotizacion.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: CotizacionEstandar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cotizacion proyecto = db.Cotizacion.Find(id);
            db.Cotizacion.Remove(proyecto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult GetProductosDetalle(int id)
        {
            var listaTeo = db.Parametro
              //.Where(x => x.Id == id)
              .Select(a => new
              {
                  id = a.Id,
                  descripcion = a.Descripcion,
                  valor = a.Valor,

              });
            return Json(listaTeo);
        }
        public ActionResult MostrarProyecto(int id)
        {
            var obj = TipoProyectoBLL.TraerTodos();

            if (id == 1)
            {
                return Content("CotizacionEstandar");

            }
            else
            {
                return Content("CotizacionPersonalizada");

            }
        }
        [HttpPost]
        public JsonResult CargarComunas(int id)
        {
            var obj = ComunaBLL.TraerTodos().Where(a => a.IdRegion == id);

            IEnumerable<SelectListItem> listado = obj.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nombre.ToString()
            }).ToList();
            return Json(listado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Continuar(string rut)
        {
            try
            {
                int numeroRut = Utilidades.RutSinDV(rut);

                var data = ClienteBLL.TraerPorRut(numeroRut);
                if (data != null)
                {

                    var salida = new
                    {
                        Id = data.Id,
                        Rut = data.Rut + data.Dv,
                        RazonSocial = data.RazonSocial,
                        Direccion = data.Direccion,
                        IdRegion = (int)ComunaBLL.Traer((int)data.IdComuna).IdRegion,
                        IdComuna = (int)data.IdComuna,
                        Giro = data.Giro,
                        NombreContacto = data.NombreContacto,
                        ApellidoContacto = data.ApellidoContacto,
                        CorreoContacto = data.CorreoContacto,
                        TelefonoContacto = data.TelefonoContacto
                    };

                    return new JsonResult { Data = salida, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

                }
                else
                {

                    var salida = "";
                    return new JsonResult { Data = salida, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (Exception)
            {
                var salida = "";
                return new JsonResult { Data = salida, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpGet]
        public ActionResult GrillaParametros()
        {
            List<Parametro> listaParametros = ParametroBLL.TraerTodos();
            List<VMParametro> listaVMParametro = new List<VMParametro>();
            foreach (var item in listaParametros)
            {
                VMParametro vm = new VMParametro();
                vm.Id = item.Id;
                vm.Descripcion = item.Descripcion;
                vm.Valor = item.Valor;
                vm.Total_SubParametros = SubParametroBLL.TraerPorParametro(item.Id).Count;
                vm.Total_SubParametros_guardados = Parametro_SubParametroBLL.TraerPorParametro(item.Id).Count;
                listaVMParametro.Add(vm);
            }

            return View("_GrillaParametros", listaVMParametro);
        }
        [HttpPost]
        public ActionResult GrillaSubParametros(int idParametro, string[] arrid)
        {
            //Session["IdsSubParametros"] = arrid;

            foreach (var item in arrid)
            {
                string idTr = item.Replace("[", "").Replace("\"", "").Replace("]", "");

                Parametro_SubParametro dato = new Parametro_SubParametro();
                dato.IdParametro = idParametro;
                dato.IdSubParametro = int.Parse(idTr);
                Parametro_SubParametroBLL.Guardar(dato);
            }
            //var listado_subParametros = SubParametroBLL.TraerTodos();
            //foreach (var item in lista_VMSubParametros)
            //{
            //    Parametro_SubParametro dato = new Parametro_SubParametro();
            //    dato.IdParametro = item.Id;
            //    dato.IdSubParametro = item.Id;
            //}

            //return PartialView("_GrillaSubParametros", lista_VMSubParametros);
            return PartialView("_GrillaSubParametros");
        }
        [HttpGet]
        public ActionResult GrillaSubParametros(int id)
        {
            var listado_subParametros = SubParametroBLL.TraerTodos();
            List<VMSubParametro> lista_VMSubParametros = new List<VMSubParametro>();
            List<Parametro_SubParametro> lista_Parametro_SubParametros = new List<Parametro_SubParametro>();
            lista_Parametro_SubParametros = Parametro_SubParametroBLL.TraerPorParametro(id);
            foreach (var item in listado_subParametros)
            {
                VMSubParametro dato = new VMSubParametro();
                dato.Id = item.Id;
                dato.IdParametro = item.IdParametro;
                dato.Descripcion = item.Descripcion;
                dato.Valor = item.Valor;
                dato.Seleccionado = false;
                foreach (var item2 in lista_Parametro_SubParametros)
                {
                    if (item2.IdSubParametro==item.Id)
                    {
                        dato.Seleccionado = true;
                    }
                }
                lista_VMSubParametros.Add(dato);
            }
            ViewBag.IdParametro = id;

            return PartialView("_GrillaSubParametros", lista_VMSubParametros);
        }
        public ActionResult GrillaProductos(int id=0)
        {
            List<VMProducto> listaProductosVM = new List<VMProducto>();

            List<Producto> listaProductos = new List<Producto>();
            
            listaProductos = ProductoBLL.TraerTodos();
            
            foreach (var item in listaProductos)
            {
                VMProducto vm = new VMProducto();
                vm.Id = item.Id;
                vm.Codigo = item.Codigo;
                vm.Descripcion = item.Descripcion;
                vm.Superficie = item.Superficie;
                vm.Valor = item.Valor;
                vm.Imagen = item.Imagen;
                listaProductosVM.Add(vm);

            }
            return PartialView("_GrillaProducto", listaProductosVM);
        }
        public PartialViewResult GrillaProductoSeleccionado(int id = 0)
        {
            List<VMProducto> listaProductosVM = new List<VMProducto>();
            List<Producto> listaProductos = new List<Producto>();

            if (id != 0) { }
            listaProductos = db.Producto.Where(a => a.Id == id).ToList();

            foreach (var item in listaProductos)
            {
                VMProducto vm = new VMProducto();
                vm.Id = item.Id;
                vm.Codigo = item.Codigo;
                vm.Descripcion = item.Descripcion;
                vm.Superficie = item.Superficie;
                vm.Valor = item.Valor;
                vm.Imagen = item.Imagen;
                listaProductosVM.Add(vm);

            }
            return PartialView("_GrillaProductoSeleccionado", listaProductosVM);
        }

        [HttpPost]
        public JsonResult GetAreasForCompany(int id)
        {
            var listaTeo = db.Parametro
                .Select(a => new
                {
                    id = a.Id,
                    descripcion = a.Descripcion,
                    valor = a.Valor
                });
            return Json(listaTeo);
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
