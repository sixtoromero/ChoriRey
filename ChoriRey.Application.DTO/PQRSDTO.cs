using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Application.DTO
{
    public class PQRSDTO
    {
        public int IDPQRS { get; set; }
        public int IDParametro { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public int IDCliente { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string TipoPeticion { get; set; }
    }
}
