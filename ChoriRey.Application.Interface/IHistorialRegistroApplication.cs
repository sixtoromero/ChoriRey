using AdsPublisher.Application.DTO;
using AdsPublisher.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Application.Interface
{
    public interface IHistorialRegistroApplication
    {
        Task<Response<bool>> InsertAsync(Historial_RegistroDTO modelDto);
        Task<Response<IEnumerable<Historial_RegistroDTO>>> GetAllAsync(int ID);
    }
}
