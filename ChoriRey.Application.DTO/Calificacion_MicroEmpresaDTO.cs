using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Application.DTO
{
    public class Calificacion_MicroEmpresaDTO
    {
        public int IDCalificacion { get; set; }
        public int? Puntuacion { get; set; }
        public string Comentario { get; set; }
        public int? IDMicroEmpresa { get; set; }
    }
}
