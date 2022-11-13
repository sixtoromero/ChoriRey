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
    public class CategoriasPorMicroEmpresasApplication : ICategoriasPorMicroEmpresasApplication
    {
        private readonly ICategoriasPorMicroEmpresasDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CategoriasPorMicroEmpresasApplication> _logger;

        public CategoriasPorMicroEmpresasApplication(ICategoriasPorMicroEmpresasDomain _Domain, IMapper mapper, IAppLogger<CategoriasPorMicroEmpresasApplication> logger)
        {
            this._Domain = _Domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<CategoriasPorMicroEmpresasDTO>>> GetAllAsync(int ID)
        {
            var response = new Response<IEnumerable<CategoriasPorMicroEmpresasDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync(ID);

                response.Data = _mapper.Map<IEnumerable<CategoriasPorMicroEmpresasDTO>>(resp);
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
