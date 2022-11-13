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
    public class CategoriaDomain : ICategoriaDomain
    {
        private readonly ICategoriaRepository _Repository;
        public IConfiguration Configuration { get; }

        public CategoriaDomain(ICategoriaRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<IEnumerable<Categorias>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

    }
}
