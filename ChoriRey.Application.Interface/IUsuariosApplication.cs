using ChoriRey.Application.DTO;
using ChoriRey.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoriRey.Application.Interface
{
    public interface IUsuariosApplication
    {
        Task<Response<bool>> InsertAsync(UsuariosDTO modelDto);
        Task<Response<bool>> UpdateAsync(UsuariosDTO modelDto);
        Task<Response<bool>> DeleteAsync(int ID);
        Task<Response<UsuariosDTO>> GetAsync(int ID);
        Task<Response<IEnumerable<UsuariosDTO>>> GetAllAsync();
    }
}
