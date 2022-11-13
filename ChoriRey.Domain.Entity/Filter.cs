using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Domain.Entity
{
    public class Filter
    {
        public int IDCategoria { get; set; }
        public string[] IDSubCategoria { get; set; }
        public string Direccion { get; set; }
        public string Microempresa { get; set; }
    }
}
