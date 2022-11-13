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
    public class PQRSRepository : IPQRSRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public PQRSRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(PQRS model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspPQRSInsert";
                var parameters = new DynamicParameters();
                parameters.Add("IDParametro", model.IDParametro);
                parameters.Add("Asunto", model.Asunto);
                parameters.Add("Descripcion", model.Descripcion);
                parameters.Add("IDCliente", model.IDCliente);

                //Persistir la info en la bd
                var result = connection.QuerySingle<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> UpdateAsync(PQRS model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspPQRSUpdate";
                var parameters = new DynamicParameters();
                
                parameters.Add("IDPQRS", model.IDPQRS);
                parameters.Add("IDParametro", model.IDParametro);
                parameters.Add("IDParametro", model.IDParametro);
                parameters.Add("Asunto", model.Asunto);
                parameters.Add("Descripcion", model.Descripcion);
                parameters.Add("IDCliente", model.IDCliente);

                //Persistir la info en la bd
                var result = connection.QuerySingle<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> DeleteAsync(int IDPQRS)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDelPQRS";
                var parameters = new DynamicParameters();

                parameters.Add("IDPQRS", IDPQRS);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;

            }
        }

        public async Task<PQRS> GetAsync(int IDPQRS)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetPQRSByID";
                var parameters = new DynamicParameters();

                parameters.Add("IDPQRS", IDPQRS);

                var result = await connection.QuerySingleAsync<PQRS>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<PQRS>> GetAllAsync(int IDCliente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspGetPQRS";
                var parameters = new DynamicParameters();

                parameters.Add("IDCliente", IDCliente);

                var result = await connection.QueryAsync<PQRS>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
