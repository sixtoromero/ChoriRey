using AdsPublisher.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Domain.Interface
{
    public interface IClientesDomain
    {
        Task<bool> InsertAsync(Clientes cliente);
        Task<bool> UpdateAsync(Clientes cliente);
        Task<bool> DeleteAsync(int? IDCliente);
        Task<Clientes> GetAsync(int? IDCliente);
        Task<IEnumerable<Clientes>> GetAllAsync();
        Task<bool> SetActivation(string Correo);
        Task<Clientes> GetLoginAsync(string Correo, string Password);
        Task<bool> SendMailAsync(Clientes cliente);
        Task<bool> SendEmailInfoPago(Clientes user);

    }
}
