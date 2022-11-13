using AdsPublisher.Application.DTO;
using AdsPublisher.Application.Interface;
using AdsPublisher.Domain.Entity;
using AdsPublisher.Domain.Interface;
using AdsPublisher.Transversal.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Application.Main
{
    public class HistorialRegistroApplication : IHistorialRegistroApplication
    {
        private readonly IHistorialRegistroDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<HistorialRegistroApplication> _logger;

        public HistorialRegistroApplication(IHistorialRegistroDomain _Domain, IMapper mapper, IAppLogger<HistorialRegistroApplication> logger)
        {
            this._Domain = _Domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> InsertAsync(Historial_RegistroDTO modelDto)
        {
            var response = new Response<bool>();
            try
            {
                var resp = _mapper.Map<Historial_Registro>(modelDto);
                response.Data = await _Domain.InsertAsync(resp);
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

        public async Task<Response<IEnumerable<Historial_RegistroDTO>>> GetAllAsync(int ID)
        {
            var response = new Response<IEnumerable<Historial_RegistroDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync(ID);

                response.Data = _mapper.Map<IEnumerable<Historial_RegistroDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
