using AdsPublisher.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Domain.Interface
{
    public interface IPlanesDomain
    {
        Task<bool> InsertAsync(Planes model);
        Task<bool> UpdateAsync(Planes model);
        Task<bool> DeleteAsync(int ID);
        Task<Planes> GetAsync(int ID);
        Task<IEnumerable<Planes>> GetAllAsync();
    }
}
