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
    public class HistorialRegistroDomain : IHistorialRegistroDomain
    {
        private readonly IHistorialRegistroRepository _Repository;
        public IConfiguration Configuration { get; }

        public HistorialRegistroDomain(IHistorialRegistroRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<bool> InsertAsync(Historial_Registro model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<IEnumerable<Historial_Registro>> GetAllAsync(int ID)
        {
            return await _Repository.GetAllAsync(ID);
        }

    }
}
