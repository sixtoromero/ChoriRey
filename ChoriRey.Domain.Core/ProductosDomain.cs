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
    public class ProductosDomain : IProductosDomain
    {
        private readonly IProductosRepository _Repository;
        public IConfiguration Configuration { get; }

        public ProductosDomain(IProductosRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<bool> InsertAsync(Productos model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(Productos model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int IDFacturas)
        {
            return await _Repository.DeleteAsync(IDFacturas);
        }

        public async Task<Productos> GetAsync(int IdUsuario)
        {
            return await _Repository.GetAsync(IdUsuario);
        }

        public async Task<IEnumerable<Productos>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }
    }
}
