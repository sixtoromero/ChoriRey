using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Domain.Entity
{
    public class Historial_Pagos
    {
        public int IDHistorialPago { get; set; }
        public int? IDFactura { get; set; }
        public decimal Valor_Pago { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaCulminacion { get; set; }
        public bool Estado { get; set; }

        /*Propiedes de Planes*/
        public int IDPlan { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int NroMeses { get; set; }

    }
}
