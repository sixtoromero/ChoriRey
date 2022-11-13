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
    public class DescriptionDynamicDomain : IDescriptionDynamicDomain
    {
        private readonly IDescriptionDynamicRepository _Repository;
        public IConfiguration Configuration { get; }

        public DescriptionDynamicDomain(IDescriptionDynamicRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<string> GetDescription(DescriptionDynamic model)
        {
            return await _Repository.GetDescription(model);
        }

    }
}
