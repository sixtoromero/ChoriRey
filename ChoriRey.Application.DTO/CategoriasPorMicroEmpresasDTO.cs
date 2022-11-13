using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Application.DTO
{
    public class CategoriasPorMicroEmpresasDTO
    {
        public int IDCatMicroEmpresa { get; set; }
        public int IDCategoria { get; set; }
        public int IDSubCategoria { get; set; }
        public int IDMicroEmpresa { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Descripcion { get; set; }

    }
}
