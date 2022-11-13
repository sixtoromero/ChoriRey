using AdsPublisher.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Domain.Interface
{
    public interface IMicroEmpresasDomain
    {
        Task<bool> InsertAsync(MicroEmpresas model);
        Task<bool> UpdateAsync(MicroEmpresas model);
        Task<bool> DeleteAsync(int IDMicroEmpresa);
        Task<MicroEmpresas> GetAsync(int IDMicroEmpresa);
        Task<IEnumerable<MicroEmpresas>> GetAllAsync(int IDCliente);
        Task<IEnumerable<MicroEmpresas>> GetFilterAsync(Filter ifilter);
        Task<bool> SetPagosCulminados();
    }
}
