using AdsPublisher.Application.DTO;
using AdsPublisher.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Application.Interface
{
    public interface IMicroEmpresasApplication
    {
        Task<Response<bool>> InsertAsync(MicroEmpresasDTO modelDto);
        Task<Response<bool>> UpdateAsync(MicroEmpresasDTO modelDto);
        Task<Response<bool>> DeleteAsync(int IDMicroEmpresa);
        Task<Response<MicroEmpresasDTO>> GetAsync(int IDMicroEmpresa);
        Task<Response<IEnumerable<MicroEmpresasDTO>>> GetAllAsync(int IDCliente);
        Task<Response<IEnumerable<MicroEmpresasDTO>>> GetFilterAsync(FilterDTO ifilter);
        Task<Response<bool>> SetPagosCulminados();
    }
}
