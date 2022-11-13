using AdsPublisher.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdsPublisher.InfraStructure.Interface
{
    public interface ISubCategoriasRepository
    {
        Task<IEnumerable<SubCategoria>> GetAllAsync(int ID);
    }
}
