using AdsPublisher.Application.DTO;
using AdsPublisher.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.Application.Interface
{
    public interface ICategoriaApplication
    {
        Task<Response<IEnumerable<CategoriasDTO>>> GetAllAsync();
    }

}
