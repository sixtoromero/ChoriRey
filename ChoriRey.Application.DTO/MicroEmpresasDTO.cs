using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Application.DTO
{
    public class MicroEmpresasDTO
    {
        public int IDMicroEmpresa { get; set; }
        public int IDCliente { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Fax { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int IDCategoria { get; set; }
        public int IDPlan { get; set; }
        //public string SubCategorias { get; set; }
        public string[] SubCategorias { get; set; }
    }
}
