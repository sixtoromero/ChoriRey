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
    public class SubCategoriasRepository : ISubCategoriasRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public SubCategoriasRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<SubCategoria>> GetAllAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                
                var query = "UspgetSubCategorias";
                var parameters = new DynamicParameters();

                parameters.Add("IDCategoria", ID);

                var result = await connection.QueryAsync<SubCategoria>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
