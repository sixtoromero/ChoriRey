using System;
using System.Collections.Generic;
using System.Text;

namespace ChoriRey.Domain.Entity
{
    public class EncabezadoPedido
    {
        public Encabezados Encabezado { get; set; }
        public IEnumerable<Pedidos> Pedidos { get; set; }
    }
}
