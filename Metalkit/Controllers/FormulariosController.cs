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
using Newtonsoft.Json;
using System.Web.Configuration;
using System.Web.Script.Serialization;

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
        public ActionResult CotizacionEstandar()
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
            bool respuesta = false;
            string mensaje = "";
            int idProducto = 0;
            Cliente cliente = new Cliente();
            Cotizacion cotizacion = new Cotizacion();
            Despacho despacho = new Despacho();
            EstadoOT estado = new EstadoOT();
            Producto producto = new Producto();
            Parametro parametro = new Parametro();
            SubParametro subparametro = new SubParametro();
            Param_Subparam parametro_subparametro = new Param_Subparam();
            Prod_Param_subparam producto_Parametro = new Prod_Param_subparam();
            try
            {
                cliente = ClienteBLL.TraerPorRut(Utilidades.RutSinDV(Session["rut"].ToString()));
                var regionEnvio = form["iRegionEnvio"];
                idProducto = int.Parse(form["iIdProducto"]);
                var listaVM_Parametros = (string[])new JavaScriptSerializer().Deserialize(form["iparametros"], typeof(string[]));
                var listaVM_SubParametros = (List<VMSubParametro>)new JavaScriptSerializer().Deserialize(form["isubparametros"], typeof(List<VMSubParametro>));

                DespachoBLL.Guardar(despacho = new Despacho()
                {
                    Direccion = form["iDireccionEnvio"],
                    FechaDespacho = DateTime.Parse(form["iFechaEntrega"]),
                    IdTipoDespacho = form["iTipoEntrega"] == "option1"?1:2,
                    IdComuna = int.Parse(form["iComunaEnvio"])
                });
                CotizacionBLL.Guardar(cotizacion = new Cotizacion()
                {
                    IdDespacho = despacho.Id,
                    IdTipoProyecto = 1,
                    IdCliente = cliente.Id
                });
                foreach (var p in listaVM_Parametros)
                {

                    foreach (var sp in listaVM_SubParametros)
                    {
                        Param_SubparamBLL.Guardar(parametro_subparametro = new Param_Subparam()
                        {
                            IdParametro = int.Parse(p),
                            IdSubParametro = sp.Id
                        });

                        Prod_Param_subparamBLL.Guardar(producto_Parametro = new Prod_Param_subparam()
                        {
                            IdProducto = idProducto,
                            IdParametro_SubParametro = parametro_subparametro.Id,
                            IdCotizacion = cotizacion.Id
                        });
                    }

                    
                }
                mensaje = "Correcto";
                respuesta = true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
                //throw;
            }
            //Mensajeria.SetMensaje("Datos Almacenados exitosamente.", Mensajeria.TiposMensajes.Error);
            //return View("Index");
            return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarCliente(Cliente objeto)
        {
            Cliente cliente = new Cliente();
            bool respuesta = false;
            string mensaje = "";
            try
            {

                Cliente oProducto = new Cliente();


                ClienteBLL.Guardar(objeto);
                mensaje = "Registro almacenado Correctamente";
                respuesta = true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }
            ViewBag.iIdCliente = objeto.Id;
            return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
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
        public ActionResult MostrarProyecto(int tipoProyecto, string rut)
        {
            var obj = TipoProyectoBLL.TraerTodos();

            if (tipoProyecto == 1)
            {
                return Content("CotizacionEstandar");

            }
            else
            {
                return Content("CotizacionPersonalizada");

            }
        }
        [HttpPost]
        //public JsonResult CargarComunas(int id, string rut)
        //{
        //    var obj = ComunaBLL.TraerTodos().Where(a => a.IdRegion == id);
        //    List<SelectListItem> listado = new List<SelectListItem>();

        //    foreach (var p in obj)
        //    {
        //        SelectListItem objItem = new SelectListItem();
        //        objItem.Text = p.Nombre.ToString();
        //        objItem.Value = p.Id.ToString();
        //        objItem.Selected = false;

        //        if (p.Id== ClienteBLL.TraerPorRut(Utilidades.RutSinDV(rut)).IdComuna)
        //        {
        //            objItem.Selected = true;
        //        }
        //        listado.Add(objItem);
        //    }



        //    return Json(new { Error = false, Resultados = listado, }, JsonRequestBehavior.AllowGet);

        //}
        public JsonResult CargarComunas(int id)
        {
            var obj = ComunaBLL.TraerTodos().Where(a => a.IdRegion == id);

            IEnumerable<SelectListItem> listado = obj.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nombre.ToString()
            }).ToList();
            return Json(new { Error = false, Resultados = listado, }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Continuar(string rut)
        {
            Session["rut"] = rut;
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
            List<Parametro> listaParametros = ParametroBLL.TraerTodos().Where(a=>a.IdTipoParametro==1).ToList();
            List<VMParametro> listaVMParametro = new List<VMParametro>();
            foreach (var item in listaParametros)
            {
                VMParametro vm = new VMParametro();
                vm.Id = item.Id;
                vm.Descripcion = item.Descripcion;
                vm.Valor = item.Valor;
                vm.Total_SubParametros = SubParametroBLL.TraerPorParametro(item.Id).Count;
                vm.Total_SubParametros_guardados = Param_SubparamBLL.TraerPorParametro(item.Id).Count;
                listaVMParametro.Add(vm);
            }

            return View("_GrillaParametros", listaVMParametro);
        }
        public ActionResult GrillaParametrosConObj(string listado)
        {
            List<Parametro> listaParametros = ParametroBLL.TraerTodos().Where(a=>a.IdTipoParametro==1).ToList();
            List<VMParametro> listaVMParametro = new List<VMParametro>();

            Session["listadoSubParametros"] = null;
            Session["listadoSubParametros"] = listado;
            var listado_subparametros_nuevos = (List<VMSubParametro>)new JavaScriptSerializer().Deserialize(listado, typeof(List<VMSubParametro>));

            foreach (var item in listaParametros)
            {
                VMParametro vm = new VMParametro();
                vm.Id = item.Id;
                vm.Descripcion = item.Descripcion;
                vm.Valor = item.Valor;
                vm.Total_SubParametros = SubParametroBLL.TraerPorParametro(item.Id).Count;
                vm.Total_SubParametros_guardados = listado_subparametros_nuevos.Where(a=>a.IdParametro == item.Id).Count();

                listaVMParametro.Add(vm);
            }

            return View("_GrillaParametros", listaVMParametro);
        }
        [HttpGet]
        public ActionResult GrillaSubParametros(int id)
        {

            var listado_subParametros = SubParametroBLL.TraerTodos().Where(a=>a.IdParametro== id);
            List<VMSubParametro> lista_VMSubParametros = new List<VMSubParametro>();
            List<Param_Subparam> lista_Parametro_SubParametros = new List<Param_Subparam>();


            lista_Parametro_SubParametros = Param_SubparamBLL.TraerPorParametro(id);
            var listado = Session["listadoSubParametros"] as string;
            if (!string.IsNullOrEmpty(listado))
            {
                    var listado_subparametros_nuevos = (List<VMSubParametro>)new JavaScriptSerializer().Deserialize(listado, typeof(List<VMSubParametro>));

                    foreach (var item in listado_subParametros)
                    {
                        VMSubParametro dato = new VMSubParametro();
                        dato.Id = item.Id;
                        dato.IdParametro = item.IdParametro;
                        dato.Descripcion = item.Descripcion;
                        dato.Valor = item.Valor;
                        dato.Seleccionado = false;
                        foreach (var item2 in listado_subparametros_nuevos)
                        {
                            if (item2.Id == item.Id && item.IdParametro == item2.IdParametro)
                            {
                                dato.Seleccionado = true;
                            }
                        }
                        lista_VMSubParametros.Add(dato);
                    }
            }
            else
            {

                foreach (var item in listado_subParametros)
                {
                    VMSubParametro dato = new VMSubParametro();
                    dato.Id = item.Id;
                    dato.IdParametro = item.IdParametro;
                    dato.Descripcion = item.Descripcion;
                    dato.Valor = item.Valor;
                    dato.Seleccionado = false;
                    if (dato.Id == item.Id)
                    {
                        dato.Seleccionado = true;
                    }
                    lista_VMSubParametros.Add(dato);
                }

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
        //[OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public string ListadoPdf(string Filtro, string rutContribuyente = "")
        {
            //Log.Debug("listado PDF: " + Filtro + ", " + rutContribuyente);

            string sftp_TemporalDescargas = WebConfigurationManager.AppSettings["sftp_TemporalDescargas"].ToString();
            string sftp_TemporalVisualizacion = WebConfigurationManager.AppSettings["sftp_TemporalVisualizacion"].ToString();

            string nombreDocumento = "Solicitud.pdf";
            string NombreDocCompleto = rutContribuyente + '_' + Filtro + '_' + nombreDocumento;

            DateTime fechahoy = DateTime.Now;
            string CarpetaPorDia = fechahoy.ToString("yyyyMMdd");
            string temporalLocal = sftp_TemporalDescargas + CarpetaPorDia;
            string archivoLocal = temporalLocal + "\\" + NombreDocCompleto;
            string archicoPublico = sftp_TemporalVisualizacion + '/' + CarpetaPorDia + '/' + NombreDocCompleto;
            //ReportDocument rd = new ReportDocument();

            try
            {
                //if (System.IO.File.Exists(archivoLocal))
                //{
                //    Log.Debug("Antes de eliminar documentos: nomnbres");
                //    Log.Debug(NombreDocCompleto);
                //    //eliminar documentos
                //    var respuestas = UtilDocumentos.EliminaDocumentos(NombreDocCompleto);
                //    //archivo local ->archivoLocal
                //    Log.Debug("creo file, con archivo local");
                //    Log.Debug(archivoLocal);
                //    FileInfo file = new FileInfo(archivoLocal);
                //    file.Delete();
                //    Log.Debug("salgo del delete");

                //}
                //// acá vamos a tener que validar queen el sftp esté el docuemnto.
                //BOSubidaSFTP bOSubidaSFTP = new BOSubidaSFTP();
                //bool respuesta = bOSubidaSFTP.ValidaArchivoSFTP(NombreDocCompleto, 1, temporalLocal);
                //if (respuesta == false)
                //{

                //    rd.Load(Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Report"), "solicitud.rpt"));

                //    ConnectionInfo crConnInfo = new ConnectionInfo();
                //    TableLogOnInfo crLogOnInfo;

                //    SqlConnectionStringBuilder con = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["licenciasEntitiesInforme"].ConnectionString);
                //    string strUsuario = con.UserID, strContrasena = con.Password, strServidor = con.DataSource, strBaseDatos = con.InitialCatalog;

                //    rd.SetDatabaseLogon(strUsuario, strContrasena, strServidor, strBaseDatos);

                //    Table crTable2 = rd.Database.Tables[0];
                //    crConnInfo.ServerName = strServidor;
                //    crConnInfo.DatabaseName = strBaseDatos;
                //    crConnInfo.UserID = strUsuario;
                //    crConnInfo.Password = strContrasena;
                //    crLogOnInfo = crTable2.LogOnInfo;
                //    crLogOnInfo.ConnectionInfo = crConnInfo;
                //    crTable2.ApplyLogOnInfo(crLogOnInfo);

                //    rd.SetParameterValue("@idMaestro", Filtro);


                //    Response.Buffer = false;
                //    Response.ClearContent();
                //    Response.ClearHeaders();

                //    if (!Directory.Exists(temporalLocal))
                //    {
                //        Directory.CreateDirectory(temporalLocal);
                //    }
                //    Log.Debug("pdf");

                //    rd.ExportToDisk(ExportFormatType.PortableDocFormat, archivoLocal);
                //    Log.Debug("sftp");
                //    bOSubidaSFTP.SubidaSFTP(NombreDocCompleto, 1, temporalLocal);
                //    Log.Debug("fin");
                //}
            }
            catch (Exception ex)
            {

                Mensajeria.SetMensaje("No se ha generado el Informe.", Mensajeria.TiposMensajes.Error);
            }

            return archicoPublico;
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
