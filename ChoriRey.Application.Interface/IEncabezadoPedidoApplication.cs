using ChoriRey.Application.DTO;
using ChoriRey.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoriRey.Application.Interface
{
    public interface IEncabezadoPedidoApplication
    {
        Task<Response<bool>> GenerarPedidoAsync(EncabezadoPedidoDTO modelDto);
    }
}
