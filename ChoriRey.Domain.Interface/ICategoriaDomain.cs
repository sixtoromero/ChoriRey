using AdsPublisher.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Domain.Interface
{
    public interface ICategoriaDomain
    {
        Task<IEnumerable<Categorias>> GetAllAsync();
    }
}
