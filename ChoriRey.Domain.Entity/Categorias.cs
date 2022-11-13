using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Domain.Entity
{
    public class Categorias
    {
        public int IDCategoria { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
