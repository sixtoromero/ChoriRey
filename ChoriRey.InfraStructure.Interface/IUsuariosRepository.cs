using ChoriRey.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoriRey.InfraStructure.Interface
{
    public interface IUsuariosRepository : IRepository<Usuarios>
    {
        Task<Usuarios> GetLoginAsync(Usuarios model);
    }
}
