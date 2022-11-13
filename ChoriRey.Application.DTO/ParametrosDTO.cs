using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Application.DTO
{
    public class ParametrosDTO
    {
        public int IDParametro { get; set; }
        public int IDClase { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
