using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Domain.Entity
{
    public class Calificacion_MicroEmpresa
    {
        public int IDCalificacion { get; set; }
        public int? Puntuacion { get; set; }
        public string Comentario { get; set; }
        public int? IDMicroEmpresa { get; set; }
    }
}
