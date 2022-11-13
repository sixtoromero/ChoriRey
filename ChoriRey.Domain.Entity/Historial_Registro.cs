using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Domain.Entity
{
    public class Historial_Registro
    {
        public int IDHistorialReg { get; set; }
        public int IDMicroEmpresa { get; set; }
        public int IDUsuario { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
