using AdsPublisher.Application.DTO;
using AdsPublisher.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Application.Interface
{
    public interface IFacturasApplication
    {
        Task<Response<bool>> InsertAsync(FacturasDTO modelDto);
        Task<Response<bool>> UpdateAsync(FacturasDTO modelDto);
        Task<Response<bool>> DeleteAsync(int ID);
        Task<Response<FacturasDTO>> GetAsync(int ID);
        Task<Response<IEnumerable<FacturasDTO>>> GetAllAsync(int ID);
    }
}
