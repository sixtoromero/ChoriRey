using AdsPublisher.Domain.Entity;
using AdsPublisher.Domain.Interface;
using AdsPublisher.InfraStructure.Interface;
using AdsPublisher.Transversal.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Domain.Core
{
    public class FacturasDomain : IFacturasDomain
    {
        private readonly IFacturasRepository _Repository;
        public IConfiguration Configuration { get; }

        public FacturasDomain(IFacturasRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<bool> InsertAsync(Facturas model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(Facturas model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int IDFacturas)
        {
            return await _Repository.DeleteAsync(IDFacturas);
        }

        public async Task<Facturas> GetAsync(int IDFacturas)
        {
            return await _Repository.GetAsync(IDFacturas);
        }

        public async Task<IEnumerable<Facturas>> GetAllAsync(int ID)
        {
            return await _Repository.GetAllAsync(ID);
        }


    }
}
