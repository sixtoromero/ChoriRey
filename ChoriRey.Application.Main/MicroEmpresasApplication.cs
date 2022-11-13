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
    public class MicroEmpresasApplication : IMicroEmpresasApplication
    {
        private readonly IMicroEmpresasDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<MicroEmpresasApplication> _logger;

        public MicroEmpresasApplication(IMicroEmpresasDomain _Domain, IMapper mapper, IAppLogger<MicroEmpresasApplication> logger)
        {
            this._Domain = _Domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> InsertAsync(MicroEmpresasDTO modelDto)
        {
            var response = new Response<bool>();
            try
            {
                var clase = _mapper.Map<MicroEmpresas>(modelDto);
                response.Data = await _Domain.InsertAsync(clase);
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

        public async Task<Response<bool>> UpdateAsync(MicroEmpresasDTO modelDto)
        {
            var response = new Response<bool>();
            try
            {
                var clase = _mapper.Map<MicroEmpresas>(modelDto);
                response.Data = await _Domain.UpdateAsync(clase);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int ID)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _Domain.DeleteAsync(ID);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<MicroEmpresasDTO>> GetAsync(int ID)
        {
            var response = new Response<MicroEmpresasDTO>();
            try
            {
                var result = await _Domain.GetAsync(ID);

                response.Data = _mapper.Map<MicroEmpresasDTO>(result);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<IEnumerable<MicroEmpresasDTO>>> GetAllAsync(int IDCliente)
        {
            var response = new Response<IEnumerable<MicroEmpresasDTO>>();
            try
            {
                var clases = await _Domain.GetAllAsync(IDCliente);

                response.Data = _mapper.Map<IEnumerable<MicroEmpresasDTO>>(clases);
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

        public async Task<Response<IEnumerable<MicroEmpresasDTO>>> GetFilterAsync(FilterDTO ifilter)
        {
            var response = new Response<IEnumerable<MicroEmpresasDTO>>();
            try
            {
                var model = _mapper.Map<Filter>(ifilter);

                var resp = await _Domain.GetFilterAsync(model);
                response.Data = _mapper.Map<IEnumerable<MicroEmpresasDTO>>(resp);
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

        public async Task<Response<bool>> SetPagosCulminados()
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _Domain.SetPagosCulminados();
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Tarea ejecutada exitosamente";
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
