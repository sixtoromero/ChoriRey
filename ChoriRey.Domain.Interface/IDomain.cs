using ChoriRey.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoriRey.Domain.Interface
{
    public interface IDomain<T>
    {
        Task<bool> InsertAsync(T model);
        Task<bool> UpdateAsync(T model);
        Task<bool> DeleteAsync(int ID);
        Task<T> GetAsync(int ID);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
