using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Application.DTO
{
    public class FilterDTO
    {
        public int IDCategoria { get; set; }
        public string[] IDSubCategoria { get; set; }
        public string Direccion { get; set; }
        public string Microempresa { get; set; }
    }
}
