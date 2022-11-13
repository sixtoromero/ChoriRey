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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public CategoriaRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Categorias>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetCategorias";
                var parameters = new DynamicParameters();
                var result = await connection.QueryAsync<Categorias>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
