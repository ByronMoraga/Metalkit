//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Metalkit.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VersionOT
    {
        public int Id { get; set; }
        public Nullable<int> OT { get; set; }
        public Nullable<int> IdEstadoVersion { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> IdUsuario { get; set; }
    
        public virtual EstadoOT_VersionOT EstadoOT_VersionOT { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
