using AdsPublisher.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.InfraStructure.Interface
{
    public interface IFacturasRepository
    {
        Task<bool> InsertAsync(Facturas model);
        Task<bool> UpdateAsync(Facturas model);
        Task<bool> DeleteAsync(int ID);
        Task<Facturas> GetAsync(int ID);
        Task<IEnumerable<Facturas>> GetAllAsync(int ID);
    }
}
