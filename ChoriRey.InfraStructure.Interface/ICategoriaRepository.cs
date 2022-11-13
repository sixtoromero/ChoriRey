using AdsPublisher.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdsPublisher.InfraStructure.Interface
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categorias>> GetAllAsync();
    }
}
