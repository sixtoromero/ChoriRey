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
    public class CategoriasPorMicroEmpresasRepository : ICategoriasPorMicroEmpresasRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public CategoriasPorMicroEmpresasRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<CategoriasPorMicroEmpresas>> GetAllAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetSubCategoriasById";
                var parameters = new DynamicParameters();
                parameters.Add("IDMicroEmpresa", ID);
                var result = await connection.QueryAsync<CategoriasPorMicroEmpresas>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
