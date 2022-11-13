using AdsPublisher.Application.DTO;
using AdsPublisher.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Application.Interface
{
    public interface IClientesApplication
    {
        Task<Response<bool>> InsertAsync(ClientesDTO clienteDto);
        Task<Response<bool>> UpdateAsync(ClientesDTO clienteDto);
        Task<Response<bool>> DeleteAsync(int? IDCliente);
        Task<Response<ClientesDTO>> GetAsync(int? IDCliente);
        Task<Response<IEnumerable<ClientesDTO>>> GetAllAsync();
        Task<Response<bool>> SetActivation(string Correo);
        Task<Response<ClientesDTO>> GetLoginAsync(string Correo, string Password);
        Task<Response<bool>> SendMailAsync(ClientesDTO cliente);        
    }
}
