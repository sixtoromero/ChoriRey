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
    public class HistorialRegistroRepository : IHistorialRegistroRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public HistorialRegistroRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Historial_Registro model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspHistorialRegistroInsert";

                var parameters = new DynamicParameters();
                parameters.Add("IDMicroempresa", model.IDMicroEmpresa);
                parameters.Add("Descripcion", model.Descripcion);
                parameters.Add("IDUsuario", model.IDUsuario);


                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<IEnumerable<Historial_Registro>> GetAllAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetHistorialRegistrosByID";
                var parameters = new DynamicParameters();

                parameters.Add("IDUsuario", ID);

                var result = await connection.QueryAsync<Historial_Registro>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
