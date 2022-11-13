using AdsPublisher.Application.DTO;
using AdsPublisher.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Application.Interface
{
    public interface IPlanesApplication
    {
        Task<Response<bool>> InsertAsync(PlanesDTO modelDto);
        Task<Response<bool>> UpdateAsync(PlanesDTO modelDto);
        Task<Response<bool>> DeleteAsync(int ID);
        Task<Response<PlanesDTO>> GetAsync(int ID);
        Task<Response<IEnumerable<PlanesDTO>>> GetAllAsync();
    }
}
