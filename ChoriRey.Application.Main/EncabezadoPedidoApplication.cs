using AutoMapper;
using ChoriRey.Application.DTO;
using ChoriRey.Application.Interface;
using ChoriRey.Domain.Entity;
using ChoriRey.Domain.Interface;
using ChoriRey.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoriRey.Application.Main
{
    public class EncabezadoPedidoApplication : IEncabezadoPedidoApplication
    {
        private readonly IEncabezadoPedidoDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EncabezadoPedidoApplication> _logger;

        public EncabezadoPedidoApplication(IEncabezadoPedidoDomain _Domain, IMapper mapper, IAppLogger<EncabezadoPedidoApplication> logger)
        {
            this._Domain = _Domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> GenerarPedidoAsync(EncabezadoPedidoDTO modelDTO)
        {
            var response = new Response<bool>();
            try
            {
                var resp = _mapper.Map<EncabezadoPedido>(modelDTO);
                response.Data = await _Domain.GenerarPedidoAsync(resp);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
