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
    public class PlanesRepository : IPlanesRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public PlanesRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Planes model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspPlanesInsert";
                var parameters = new DynamicParameters();
                parameters.Add("Titulo", model.Titulo);
                parameters.Add("Descripcion", model.Descripcion);
                parameters.Add("Precio", model.Precio);
                parameters.Add("Detalle", model.Detalle);
                parameters.Add("Estado", model.Estado);

                //Persistir la info en la bd
                var result = connection.QuerySingle<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> UpdateAsync(Planes model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspPlanesUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("IDPlan", model.IDPlan);
                parameters.Add("Titulo", model.Titulo);
                parameters.Add("Descripcion", model.Descripcion);
                parameters.Add("Precio", model.Precio);
                parameters.Add("Detalle", model.Detalle);
                parameters.Add("Estado", model.Estado);

                //Persistir la info en la bd
                var result = connection.QuerySingle<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDelPlanes";
                var parameters = new DynamicParameters();

                parameters.Add("IDPlanes", ID);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;

            }
        }

        public async Task<Planes> GetAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetPlanesByID";
                var parameters = new DynamicParameters();

                parameters.Add("IDPlan", ID);

                var result = await connection.QuerySingleAsync<Planes>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Planes>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetPlanes";
                var parameters = new DynamicParameters();
                var result = await connection.QueryAsync<Planes>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
