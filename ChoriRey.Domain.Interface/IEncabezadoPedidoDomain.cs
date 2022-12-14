using ChoriRey.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoriRey.Domain.Interface
{
    public interface IEncabezadoPedidoDomain
    {
        Task<bool> GenerarPedidoAsync(EncabezadoPedido model);
    }
}
