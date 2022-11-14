using ChoriRey.Transversal.Common;
using ChoriRey.InfraStructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using ChoriRey.Domain.Entity;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace ChoriRey.InfraStructure.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UsuariosRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Usuarios model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUsuariosInsert";
                var parameters = new DynamicParameters();                
                parameters.Add("Usuario", model.Usuario);
                parameters.Add("Clave", model.Clave);
                parameters.Add("Nombres", model.Nombres);
                parameters.Add("Apellidos", model.Apellidos);
                parameters.Add("Correo", model.Correo);
                parameters.Add("Direccion", model.Direccion);
                parameters.Add("Estado", model.Estado);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }
        public async Task<bool> UpdateAsync(Usuarios model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUsuariosUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", model.IdUsuario);
                parameters.Add("Usuario", model.Usuario);
                parameters.Add("Clave", model.Clave);
                parameters.Add("Nombres", model.Nombres);
                parameters.Add("Apellidos", model.Apellidos);
                parameters.Add("Correo", model.Correo);
                parameters.Add("Direccion", model.Direccion);
                parameters.Add("Estado", model.Estado);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDelUsuarios";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", ID);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;

            }
        }

        public async Task<Usuarios> GetAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetUsuariosByID";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", ID);

                var result = await connection.QuerySingleAsync<Usuarios>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetUsuarios";

                var result = await connection.QueryAsync<Usuarios>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
