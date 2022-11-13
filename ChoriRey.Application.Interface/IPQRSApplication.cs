using AdsPublisher.Application.DTO;
using AdsPublisher.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Application.Interface
{
    public interface IPQRSApplication
    {
        Task<Response<bool>> InsertAsync(PQRSDTO modelDto);
        Task<Response<bool>> UpdateAsync(PQRSDTO modelDto);
        Task<Response<bool>> DeleteAsync(int IDPQRS);
        Task<Response<PQRSDTO>> GetAsync(int IDPQRS);
        Task<Response<IEnumerable<PQRSDTO>>> GetAllAsync(int IDCliente);
    }
}
