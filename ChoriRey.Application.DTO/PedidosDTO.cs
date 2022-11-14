using System;
using System.Collections.Generic;
using System.Text;

namespace ChoriRey.Application.DTO
{
    public class PedidosDTO
    {
        public int IdPedido { get; set; }
        public int IdEncabezado { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IVA { get; set; }
        public decimal TOTAL { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int IdUsuario { get; set; }
    }
}
