using ChoriRey.Domain.Entity;
using ChoriRey.Domain.Interface;
using ChoriRey.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoriRey.Domain.Core
{
    public class EncabezadoPedidoDomain : IEncabezadoPedidoDomain
    {
        private readonly IEncabezadoPedidoRepository _Repository;
        public IConfiguration Configuration { get; }

        public EncabezadoPedidoDomain(IEncabezadoPedidoRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<bool> GenerarPedidoAsync(EncabezadoPedido model)
        {
            return await _Repository.GenerarPedidoAsync(model);
        }
    }
}
