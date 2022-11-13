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
    public class DescriptionDynamicRepository : IDescriptionDynamicRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public DescriptionDynamicRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> GetDescription(DescriptionDynamic iDynamic)
        {
            var query = "SELECT " + iDynamic.GetFieldName + " FROM " + iDynamic.TableName + " WHERE " + iDynamic.Filter + " = " + iDynamic.Value;
            using (var connection = _connectionFactory.GetConnection)
            {
                var result = connection.QueryFirstOrDefault<string>(query, param: null, commandType: CommandType.Text);
                return result;
            }
        }

    }
}
