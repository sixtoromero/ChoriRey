using AdsPublisher.Application.DTO;
using AdsPublisher.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Application.Interface
{
    public interface IParametrosApplication
    {
        Task<Response<bool>> InsertAsync(ParametrosDTO modelDto);
        Task<Response<bool>> UpdateAsync(ParametrosDTO modelDto);
        Task<Response<bool>> DeleteAsync(int ID);
        Task<Response<ParametrosDTO>> GetAsync(int ID);
        Task<Response<IEnumerable<ParametrosDTO>>> GetAllAsync(int ID);
    }
}
