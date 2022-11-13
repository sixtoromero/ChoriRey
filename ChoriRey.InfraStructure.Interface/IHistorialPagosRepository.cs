using AdsPublisher.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.InfraStructure.Interface
{
    public interface IHistorialPagosRepository
    {
        Task<bool> InsertAsync(Historial_Pagos model);
        Task<bool> UpdateAsync(Historial_Pagos model);
        Task<bool> DeleteAsync(int ID);
        Task<Historial_Pagos> GetAsync(int ID);
        Task<IEnumerable<Historial_Pagos>> GetAllAsync(int ID);
    }
}
