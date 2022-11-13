using AdsPublisher.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.InfraStructure.Interface
{
    public interface IHistorialRegistroRepository
    {
        Task<bool> InsertAsync(Historial_Registro model);
        Task<IEnumerable<Historial_Registro>> GetAllAsync(int ID);
    }
}
