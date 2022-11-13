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
    public class MicroEmpresasDomain : IMicroEmpresasDomain
    {
        private readonly IMicroEmpresasRepository _microempresaRepository;
        public IConfiguration Configuration { get; }

        public MicroEmpresasDomain(IMicroEmpresasRepository microempresaRepository, IConfiguration _configuration)
        {
            _microempresaRepository = microempresaRepository;
            Configuration = _configuration;
        }

        public async Task<bool> InsertAsync(MicroEmpresas model)
        {
            return await _microempresaRepository.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(MicroEmpresas model)
        {
            return await _microempresaRepository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int IDMicroEmpresa)
        {
            return await _microempresaRepository.DeleteAsync(IDMicroEmpresa);
        }

        public async Task<MicroEmpresas> GetAsync(int IDMicroEmpresa)
        {
            return await _microempresaRepository.GetAsync(IDMicroEmpresa);
        }

        public async Task<IEnumerable<MicroEmpresas>> GetAllAsync(int IDCliente)
        {
            return await _microempresaRepository.GetAllAsync(IDCliente);
        }

        public async Task<IEnumerable<MicroEmpresas>> GetFilterAsync(Filter ifilter)
        {
            return await _microempresaRepository.GetFilterAsync(ifilter);
        }

        public async Task<bool> SetPagosCulminados()
        {
            return await _microempresaRepository.SetPagosCulminados();
        }

    }
}
