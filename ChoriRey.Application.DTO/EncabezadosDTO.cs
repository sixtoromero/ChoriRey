using System;
using System.Collections.Generic;
using System.Text;

namespace ChoriRey.Application.DTO
{
    public class EncabezadosDTO
    {
        public int IdEncabezado { get; set; }
        public int IdCliente { get; set; }
        public decimal Total { get; set; }
        public decimal IVA { get; set; }
        public int SubTotal { get; set; }
        public bool Estado { get; set; }
        public bool EsFactura { get; set; }
        public string Observacion { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int IdUsuario { get; set; }
    }
}
