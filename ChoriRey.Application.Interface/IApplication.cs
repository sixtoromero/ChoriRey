using ChoriRey.Application.DTO;
using ChoriRey.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoriRey.Application.Interface
{
    public interface IApplication<T>
    {
        Task<Response<bool>> InsertAsync(T modelDto);
        Task<Response<bool>> UpdateAsync(T modelDto);
        Task<Response<bool>> DeleteAsync(int ID);
        Task<Response<T>> GetAsync(int ID);
        Task<Response<IEnumerable<T>>> GetAllAsync();
    }
}
