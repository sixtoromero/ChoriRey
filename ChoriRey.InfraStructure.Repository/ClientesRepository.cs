using ChoriRey.Domain.Entity;
using ChoriRey.InfraStructure.Interface;
using ChoriRey.Transversal.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;


namespace ChoriRey.InfraStructure.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ClientesRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Clientes model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspClientesInsert";
                var parameters = new DynamicParameters();
                parameters.Add("Nombres", model.Nombres);
                parameters.Add("Apellidos", model.Apellidos);
                parameters.Add("Direccion", model.Direccion);
                parameters.Add("Telefono", model.Telefono);
                parameters.Add("Correo", model.Correo);
                parameters.Add("Estado", model.Estado);
                parameters.Add("IdUsuario", model.IdUsuario);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> UpdateAsync(Clientes model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspClientesUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("IdCliente", model.IdCliente);
                parameters.Add("Nombres", model.Nombres);
                parameters.Add("Apellidos", model.Apellidos);
                parameters.Add("Direccion", model.Direccion);
                parameters.Add("Telefono", model.Telefono);
                parameters.Add("Correo", model.Correo);
                parameters.Add("Estado", model.Estado);
                parameters.Add("IdUsuario", model.IdUsuario);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDelClientes";
                var parameters = new DynamicParameters();

                parameters.Add("IdCliente", ID);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;

            }
        }

        public async Task<Clientes> GetAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetClientesByID";
                var parameters = new DynamicParameters();

                parameters.Add("IdCliente", ID);

                var result = await connection.QuerySingleAsync<Clientes>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Clientes>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetClientes";

                var result = await connection.QueryAsync<Clientes>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
