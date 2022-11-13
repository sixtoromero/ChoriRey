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
    public class SubCategoriasApplication : ISubCategoriasApplication
    {
        private readonly ISubCategoriasDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<SubCategoriasApplication> _logger;

        public SubCategoriasApplication(ISubCategoriasDomain _Domain, IMapper mapper, IAppLogger<SubCategoriasApplication> logger)
        {
            this._Domain = _Domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<SubCategoriaDTO>>> GetAllAsync(int ID)
        {
            var response = new Response<IEnumerable<SubCategoriaDTO>>();

            try
            {
                var resp = await _Domain.GetAllAsync(ID);

                response.Data = _mapper.Map<IEnumerable<SubCategoriaDTO>>(resp);
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
