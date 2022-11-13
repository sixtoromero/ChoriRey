using AdsPublisher.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.InfraStructure.Interface
{
    public interface IClientesRepository
    {
        Task<bool> InsertAsync(Clientes cliente);
        Task<bool> UpdateAsync(Clientes cliente);
        Task<bool> DeleteAsync(int? IDCliente);
        Task<Clientes> GetAsync(int? IDCliente);
        Task<IEnumerable<Clientes>> GetAllAsync();
        Task<bool> SetActivation(string Correo);
        Task<Clientes> GetLoginAsync(string Correo, string Password);
    }
}
