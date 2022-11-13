using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Application.DTO
{
    public class SubCategoriaDTO
    {
        public int IDSubCategoria { get; set; }
        public int? IDCategoria { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
