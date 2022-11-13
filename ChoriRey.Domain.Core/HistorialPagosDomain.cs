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

    public class HistorialPagosDomain : IHistorialPagosDomain
    {
        private readonly IHistorialPagosRepository _Repository;
        public IConfiguration Configuration { get; }

        public HistorialPagosDomain(IHistorialPagosRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<bool> InsertAsync(Historial_Pagos model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(Historial_Pagos model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int IDHistorial_Pagos)
        {
            return await _Repository.DeleteAsync(IDHistorial_Pagos);
        }

        public async Task<Historial_Pagos> GetAsync(int IDHistorial_Pagos)
        {
            return await _Repository.GetAsync(IDHistorial_Pagos);
        }

        public async Task<IEnumerable<Historial_Pagos>> GetAllAsync(int ID)
        {
            return await _Repository.GetAllAsync(ID);
        }

    }
}
