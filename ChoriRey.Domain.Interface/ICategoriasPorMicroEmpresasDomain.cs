using AdsPublisher.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Domain.Interface
{
    public interface ICategoriasPorMicroEmpresasDomain
    {
        Task<IEnumerable<CategoriasPorMicroEmpresas>> GetAllAsync(int ID);
    }
}
