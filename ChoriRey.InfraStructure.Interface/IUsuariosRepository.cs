using ChoriRey.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoriRey.InfraStructure.Interface
{
    public interface IUsuariosRepository
    {
        Task<bool> InsertAsync(Usuarios model);
        Task<bool> UpdateAsync(Usuarios model);
        Task<bool> DeleteAsync(int ID);
        Task<Usuarios> GetAsync(int ID);
        Task<IEnumerable<Usuarios>> GetAllAsync();
    }
}
