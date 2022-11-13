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
    public class ParametrosRepository : IParametrosRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ParametrosRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Parametros model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspParametrosInsert";
                var parameters = new DynamicParameters();                
                parameters.Add("IDClase", model.IDClase);
                parameters.Add("Descripcion", model.Descripcion);

                //Persistir la info en la bd
                var result = connection.QuerySingle<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> UpdateAsync(Parametros model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspParametrosUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("IDParametro", model.IDParametro);
                parameters.Add("IDClase", model.IDClase);
                parameters.Add("Descripcion", model.Descripcion);

                //Persistir la info en la bd
                var result = connection.QuerySingle<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDelParametros";
                var parameters = new DynamicParameters();

                parameters.Add("IDParametro", ID);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;

            }
        }

        public async Task<Parametros> GetAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetParametrosByID";
                var parameters = new DynamicParameters();

                parameters.Add("IDParametro", ID);

                var result = await connection.QuerySingleAsync<Parametros>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Parametros>> GetAllAsync(int ID)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "UspGetParametros";
                    var parameters = new DynamicParameters();

                    parameters.Add("IDClase", ID);

                    var result = await connection.QueryAsync<Parametros>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

    }
}
