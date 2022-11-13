using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Domain.Entity
{
    public class Planes
    {
        public int IDPlan { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Detalle { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool Estado { get; set; }
        public int NroMeses { get; set; }

    }
}
