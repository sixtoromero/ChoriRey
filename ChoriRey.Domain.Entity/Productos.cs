using System;
using System.Collections.Generic;
using System.Text;

namespace ChoriRey.Domain.Entity
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string CodProducto { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoBarras { get; set; }
        public int Porcentaje_IVA { get; set; }
        public decimal Precio_Unitario { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public bool Estado { get; set; }
        public int IdUsuario { get; set; }
        
    }
}
