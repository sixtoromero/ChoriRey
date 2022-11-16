using ChoriRey.Domain.Entity;
using ChoriRey.Domain.Interface;
using ChoriRey.InfraStructure.Interface;
using ChoriRey.Transversal.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoriRey.Domain.Core
{
    public class UsuariosDomain : IUsuariosDomain
    {
        private readonly IUsuariosRepository _Repository;
        public IConfiguration Configuration { get; }

        public UsuariosDomain(IUsuariosRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<bool> InsertAsync(Usuarios model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(Usuarios model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int IDFacturas)
        {
            return await _Repository.DeleteAsync(IDFacturas);
        }

        public async Task<Usuarios> GetAsync(int IdUsuario)
        {
            return await _Repository.GetAsync(IdUsuario);
        }

        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<Usuarios> GetLoginAsync(Usuarios model)
        {
            return await _Repository.GetLoginAsync(model);
        }

    }
}
