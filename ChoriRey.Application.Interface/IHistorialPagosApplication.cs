using AdsPublisher.Application.DTO;
using AdsPublisher.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Application.Interface
{
    public interface IHistorialPagosApplication
    {
        Task<Response<bool>> InsertAsync(Historial_PagosDTO modelDto);
        Task<Response<bool>> UpdateAsync(Historial_PagosDTO modelDto);
        Task<Response<bool>> DeleteAsync(int ID);
        Task<Response<Historial_PagosDTO>> GetAsync(int ID);
        Task<Response<IEnumerable<Historial_PagosDTO>>> GetAllAsync(int ID);
    }
}
