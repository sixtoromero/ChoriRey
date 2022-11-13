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
    public class CategoriaApplication : ICategoriaApplication
    {
        private readonly ICategoriaDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CategoriaApplication> _logger;

        public CategoriaApplication(ICategoriaDomain _Domain, IMapper mapper, IAppLogger<CategoriaApplication> logger)
        {
            this._Domain = _Domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<CategoriasDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CategoriasDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<CategoriasDTO>>(resp);
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
