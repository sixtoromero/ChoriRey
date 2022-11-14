using System;
using System.Collections.Generic;
using System.Text;

namespace ChoriRey.Application.DTO
{
    public class EncabezadoPedidoDTO
    {
        public EncabezadosDTO Encabezado { get; set; }
        public IEnumerable<PedidosDTO> Pedidos { get; set; }
    }
}
