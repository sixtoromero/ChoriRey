using AdsPublisher.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.InfraStructure.Interface
{
    public interface IDescriptionDynamicRepository
    {
        Task<string> GetDescription(DescriptionDynamic iDynamic);
    }
}
