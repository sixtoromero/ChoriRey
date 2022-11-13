using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Application.DTO
{
    public class PerfilesDTO
    {
        public int IDPerfil { get; set; }
        public string Descripcion { get; set; }
        public int? IDRol { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
