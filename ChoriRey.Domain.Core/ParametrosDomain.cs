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
    public class ParametrosDomain : IParametrosDomain
    {
        private readonly IParametrosRepository _Repository;
        public IConfiguration Configuration { get; }

        public ParametrosDomain(IParametrosRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<bool> InsertAsync(Parametros model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(Parametros model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            return await _Repository.DeleteAsync(ID);
        }

        public async Task<Parametros> GetAsync(int ID)
        {
            return await _Repository.GetAsync(ID);
        }

        public async Task<IEnumerable<Parametros>> GetAllAsync(int ID)
        {
            return await _Repository.GetAllAsync(ID);
        }

    }

}
