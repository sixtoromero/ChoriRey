using AdsPublisher.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdsPublisher.InfraStructure.Interface
{
    public interface ICategoriasPorMicroEmpresasRepository
    {
        Task<IEnumerable<CategoriasPorMicroEmpresas>> GetAllAsync(int ID);
    }
}