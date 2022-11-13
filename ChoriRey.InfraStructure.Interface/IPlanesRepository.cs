using AdsPublisher.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdsPublisher.InfraStructure.Interface
{
    public interface IPlanesRepository
    {
        Task<bool> InsertAsync(Planes model);
        Task<bool> UpdateAsync(Planes model);
        Task<bool> DeleteAsync(int ID);
        Task<Planes> GetAsync(int ID);
        Task<IEnumerable<Planes>> GetAllAsync();
    }
}
