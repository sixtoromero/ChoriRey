using AdsPublisher.Domain.Entity;
using System.Threading.Tasks;

namespace AdsPublisher.Domain.Interface
{
    public interface IDescriptionDynamicDomain
    {
        Task<string> GetDescription(DescriptionDynamic iDynamic);
    }
}
