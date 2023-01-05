using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Metalkit.Models
{
    public class VMProducto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Superficie { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Nullable<int> Valor { get; set; }
        public byte[] Imagen { get; set; }

    }
}
