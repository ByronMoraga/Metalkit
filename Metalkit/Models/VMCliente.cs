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
        public int Id { get; set; }
        public Nullable<int> Rut { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public Nullable<int> IdComuna { get; set; }
        public string Giro { get; set; }
        public string NombreContacto { get; set; }
        public string ApellidoContacto { get; set; }
        public string CorreoContacto { get; set; }
        public string TelefonoContacto { get; set; }
    }
}