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
    public class CategoriasPorMicroEmpresasDomain : ICategoriasPorMicroEmpresasDomain
    {
        private readonly ICategoriasPorMicroEmpresasRepository _Repository;
        public IConfiguration Configuration { get; }

        public CategoriasPorMicroEmpresasDomain(ICategoriasPorMicroEmpresasRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<IEnumerable<CategoriasPorMicroEmpresas>> GetAllAsync(int ID)
        {
            return await _Repository.GetAllAsync(ID);
        }

    }
}
