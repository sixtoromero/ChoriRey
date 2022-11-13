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
    public class ClientesApplication : IClientesApplication
    {
        private readonly IClientesDomain _clientesDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ClientesApplication> _logger;

        public ClientesApplication(IClientesDomain clientesDomain, IMapper mapper, IAppLogger<ClientesApplication> logger)
        {
            _clientesDomain = clientesDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> InsertAsync(ClientesDTO clienteDto)
        {
            var response = new Response<bool>();
            try
            {
                var clase = _mapper.Map<Clientes>(clienteDto);
                response.Data = await _clientesDomain.InsertAsync(clase);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<Response<bool>> UpdateAsync(ClientesDTO clienteDto)
        {
            var response = new Response<bool>();
            try
            {
                var clase = _mapper.Map<Clientes>(clienteDto);
                response.Data = await _clientesDomain.UpdateAsync(clase);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<Response<bool>> DeleteAsync(int? IDCliente)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _clientesDomain.DeleteAsync(IDCliente);
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
        public async Task<Response<ClientesDTO>> GetAsync(int? IDCliente)
        {
            var response = new Response<ClientesDTO>();
            try
            {
                var clase = await _clientesDomain.GetAsync(IDCliente);

                response.Data = _mapper.Map<ClientesDTO>(clase);
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
        public async Task<Response<IEnumerable<ClientesDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ClientesDTO>>();
            try
            {
                var clases = await _clientesDomain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<ClientesDTO>>(clases);
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
        public async Task<Response<bool>> SetActivation(string Correo)
        {
            var response = new Response<bool>();
            try
            {                
                response.Data = await _clientesDomain.SetActivation(Correo);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Activación Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<ClientesDTO>> GetLoginAsync(string Correo, string Password)
        {
            var response = new Response<ClientesDTO>();
            try
            {
                var clase = await _clientesDomain.GetLoginAsync(Correo, Password);

                response.Data = _mapper.Map<ClientesDTO>(clase);
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

        public async Task<Response<bool>> SendMailAsync(ClientesDTO clienteDto)
        {
            var response = new Response<bool>();
            try
            {
                var model = _mapper.Map<Clientes>(clienteDto);
                response.Data = await _clientesDomain.SendMailAsync(model);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Correo enviado exitosamente!";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
