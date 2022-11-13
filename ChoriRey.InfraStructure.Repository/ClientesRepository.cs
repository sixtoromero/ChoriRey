using AdsPublisher.Domain.Entity;
using AdsPublisher.InfraStructure.Interface;
using AdsPublisher.Transversal.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace AdsPublisher.InfraStructure.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ClientesRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Clientes> GetLoginAsync(string Correo, string Password)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspGetLogin";
                var parameters = new DynamicParameters();
                parameters.Add("Usuario", Correo);
                parameters.Add("Password", Password);

                var result = await connection.QuerySingleAsync<Clientes>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;

            }
        }

        public async Task<bool> InsertAsync(Clientes cliente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspClientesInsert";
                var parameters = new DynamicParameters();

                parameters.Add("Nombres", cliente.Nombres);
                parameters.Add("Apellidos", cliente.Apellidos);
                parameters.Add("Sexo", cliente.Sexo);                
                parameters.Add("FechaCumpleanos", cliente.FechaCumpleanos);
                parameters.Add("Correo", cliente.Correo);
                parameters.Add("Password", cliente.Password);

                //Persistir la info en la bd
                var result = connection.QuerySingle<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> UpdateAsync(Clientes cliente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                string query = string.Empty;
                var parameters = new DynamicParameters();
                
                if (cliente.Password != null && cliente.Password != string.Empty)
                {
                    query = "uspClientesUpdate";

                    parameters.Add("IDCliente", cliente.IDCliente);
                    parameters.Add("Nombres", cliente.Nombres);
                    parameters.Add("Apellidos", cliente.Apellidos);
                    parameters.Add("Sexo", cliente.Sexo);
                    parameters.Add("FechaCumpleanos", cliente.FechaCumpleanos);
                    parameters.Add("Correo", cliente.Correo);
                    parameters.Add("Password", cliente.Password);
                    parameters.Add("Foto", cliente.Foto);
                } 
                else
                {
                    query = "uspClientesInfoUpdate";

                    parameters.Add("IDCliente", cliente.IDCliente);
                    parameters.Add("Nombres", cliente.Nombres);
                    parameters.Add("Apellidos", cliente.Apellidos);
                    parameters.Add("Sexo", cliente.Sexo);
                    parameters.Add("FechaCumpleanos", cliente.FechaCumpleanos);                    
                }

                

                //Persistir la info en la bd
                var result = connection.QuerySingle<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> DeleteAsync(int? IDCliente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDelCliente";
                var parameters = new DynamicParameters();

                parameters.Add("IDCliente", IDCliente);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;

            }
        }

        public async Task<Clientes> GetAsync(int? IDCliente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "getClientesByID";
                var parameters = new DynamicParameters();

                parameters.Add("IDCliente", IDCliente);

                var result = await connection.QuerySingleAsync<Clientes>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Clientes>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "getClientes";

                var result = await connection.QueryAsync<Clientes>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<bool> SetActivation(string Correo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspSetActivate";
                var parameters = new DynamicParameters();

                parameters.Add("Correo", Correo);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }

}
