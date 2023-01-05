using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Metalkit.Models
{
    public class VMSubParametro
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        [DisplayFormat(DataFormatString="{0:C}")]
        public int? Valor { get; set; }
        public int? IdParametro { get; set; }
        public bool Seleccionado { get; set; }

    }
}
