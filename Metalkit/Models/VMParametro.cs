using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Metalkit.Models
{
    public class VMParametro
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int? Valor { get; set; }
        public int Total_SubParametros{ get; set; }
        public int Total_SubParametros_guardados { get; set; }

    }
}
