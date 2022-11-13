using AdsPublisher.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Domain.Interface
{
    public interface IPQRSDomain
    {
        Task<bool> InsertAsync(PQRS model);
        Task<bool> UpdateAsync(PQRS model);
        Task<bool> DeleteAsync(int IDPQRS);
        Task<PQRS> GetAsync(int IDPQRS);
        Task<IEnumerable<PQRS>> GetAllAsync(int IDCliente);
    }
}
