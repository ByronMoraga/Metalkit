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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MetalkitEntities : DbContext
    {
        public MetalkitEntities()
            : base("name=MetalkitEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Comuna> Comuna { get; set; }
        public virtual DbSet<Cotizacion> Cotizacion { get; set; }
        public virtual DbSet<Despacho> Despacho { get; set; }
        public virtual DbSet<EstadoOT> EstadoOT { get; set; }
        public virtual DbSet<EstadoOT_VersionOT> EstadoOT_VersionOT { get; set; }
        public virtual DbSet<Param_Subparam> Param_Subparam { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Prod_Param_subparam> Prod_Param_subparam { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<SubParametro> SubParametro { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoCliente> TipoCliente { get; set; }
        public virtual DbSet<TipoDespacho> TipoDespacho { get; set; }
        public virtual DbSet<TipoParametro> TipoParametro { get; set; }
        public virtual DbSet<TipoProyecto> TipoProyecto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<VersionOT> VersionOT { get; set; }
    }
}
