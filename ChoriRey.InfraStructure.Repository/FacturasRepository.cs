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

    public class FacturasRepository : IFacturasRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public FacturasRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Facturas model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspFacturasInsert";
                var parameters = new DynamicParameters();
                parameters.Add("IDCliente", model.IDCliente);
                parameters.Add("IDPlan", model.IDPlan);
                parameters.Add("Valor_Plan_Actual", model.Valor_Plan_Actual);                

                //Persistir la info en la bd
                var result = connection.QuerySingle<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> UpdateAsync(Facturas model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspFacturasUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("IDCliente", model.IDCliente);
                parameters.Add("IDPlan", model.IDPlan);
                parameters.Add("Valor_Plan_Actual", model.Valor_Plan_Actual);

                //Persistir la info en la bd
                var result = connection.QuerySingle<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDelFacturas";
                var parameters = new DynamicParameters();

                parameters.Add("IDFacturas", ID);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;

            }
        }

        public async Task<Facturas> GetAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetFacturasByID";
                var parameters = new DynamicParameters();

                parameters.Add("IDCliente", ID);

                var result = await connection.QuerySingleAsync<Facturas>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Facturas>> GetAllAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetFacturasByID";
                var parameters = new DynamicParameters();

                parameters.Add("IDCliente", ID);

                var result = await connection.QueryAsync<Facturas>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
