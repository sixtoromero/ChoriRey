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
    public class DescriptionDynamicApplication : IDescriptionDynamicApplication
    {
        private readonly IDescriptionDynamicDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<DescriptionDynamicApplication> _logger;

        public DescriptionDynamicApplication(IDescriptionDynamicDomain _Domain, IMapper mapper, IAppLogger<DescriptionDynamicApplication> logger)
        {
            this._Domain = _Domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> GetDescription(DescriptionDynamicDTO modelDto)
        {
            var response = new Response<string>();
            try
            {
                var resp = _mapper.Map<DescriptionDynamic>(modelDto);
                response.Data = await _Domain.GetDescription(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Data = string.Empty;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
