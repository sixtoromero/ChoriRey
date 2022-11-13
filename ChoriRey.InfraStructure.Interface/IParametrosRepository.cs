using AdsPublisher.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.InfraStructure.Interface
{
    public interface IParametrosRepository
    {
        Task<bool> InsertAsync(Parametros model);
        Task<bool> UpdateAsync(Parametros model);
        Task<bool> DeleteAsync(int ID);
        Task<Parametros> GetAsync(int ID);
        Task<IEnumerable<Parametros>> GetAllAsync(int ID);
    }
}
