using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Metalkit.Models
{
    public class VMParametro
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Valor { get; set; }
        public List<SubParametro> ParamNvl2 { get; set; }

    }
}
