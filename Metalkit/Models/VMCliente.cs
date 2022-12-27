using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metalkit.Models
{
    public class VMCliente
    {
        public VMCliente()
        {
            this.RegionList = new SelectList(new List<string>());
            this.ComunaList = new SelectList(new List<string>() { "Sin Datos" });
        }
        public int Id { get; set; }
        [DisplayName("Rut")]
        public Nullable<int> Rut { get; set; }
        public string Dv { get; set; }
        [DisplayName("Razon Social")]
        public string RazonSocial { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        [DisplayName("Giro")]
        public string Giro { get; set; }
        [DisplayName("Nombre")]
        public string NombreContacto { get; set; }
        public string ApellidoContacto { get; set; }
        [DisplayName("Correo")]
        public string CorreoContacto { get; set; }
        [DisplayName("Telefono")]
        public string TelefonoContacto { get; set; }

        [DisplayName("Region")]
        public SelectList RegionList { get; set; }
        [DisplayName("Comuna")]
        public SelectList ComunaList { get; set; }
        public List<int> ComunaSelected{ get; set; }
    }
}