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
    public class HistorialPagosRepository : IHistorialPagosRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public HistorialPagosRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Historial_Pagos model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspHistorialPagosInsert";

                var parameters = new DynamicParameters();
                parameters.Add("IDFactura", model.IDFactura);
                parameters.Add("Valor_Pago", model.Valor_Pago);
                parameters.Add("NroMeses", model.NroMeses);

                //Persistir la info en la bd
                var result = connection.QuerySingle<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> UpdateAsync(Historial_Pagos model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspHistorialPagosUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("IDHistorialPago", model.IDHistorialPago);
                parameters.Add("IDFactura", model.IDFactura);
                parameters.Add("Valor_Pago", model.Valor_Pago);
                parameters.Add("NroMeses", model.NroMeses);

                //Persistir la info en la bd
                var result = connection.QuerySingle<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDelHistorial_Pagos";
                var parameters = new DynamicParameters();

                parameters.Add("IDHistorial_Pagos", ID);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;

            }
        }

        public async Task<Historial_Pagos> GetAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetHistorialPagosByID";
                var parameters = new DynamicParameters();

                parameters.Add("IDCliente", ID);

                var result = await connection.QuerySingleAsync<Historial_Pagos>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Historial_Pagos>> GetAllAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetHistorialPagosByID";
                var parameters = new DynamicParameters();

                parameters.Add("IDCliente", ID);

                var result = await connection.QueryAsync<Historial_Pagos>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
