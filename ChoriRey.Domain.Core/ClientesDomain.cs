using ChoriRey.Domain.Entity;
using ChoriRey.Domain.Interface;
using ChoriRey.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoriRey.Domain.Core
{
    public class ClientesDomain : IClientesDomain
    {
        private readonly IClientesRepository _Repository;
        public IConfiguration Configuration { get; }

        public ClientesDomain(IClientesRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<bool> InsertAsync(Clientes model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(Clientes model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int IDFacturas)
        {
            return await _Repository.DeleteAsync(IDFacturas);
        }

        public async Task<Clientes> GetAsync(int IdCliente)
        {
            return await _Repository.GetAsync(IdCliente);
        }

        public async Task<IEnumerable<Clientes>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }
    }
}
