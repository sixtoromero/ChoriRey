using ChoriRey.Domain.Entity;
using ChoriRey.InfraStructure.Interface;
using ChoriRey.Transversal.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ChoriRey.InfraStructure.Repository
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ProductosRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Productos model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspProductosInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CodProducto", model.CodProducto);
                parameters.Add("NombreProducto", model.NombreProducto);
                parameters.Add("CodigoBarras", model.CodigoBarras);
                parameters.Add("Porcentaje_IVA", model.Porcentaje_IVA);
                parameters.Add("Precio_Unitario", model.Precio_Unitario);
                parameters.Add("Estado", model.Estado);
                parameters.Add("IdUsuario", model.IdUsuario);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> UpdateAsync(Productos model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspProductosUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("IdProducto", model.IdProducto);
                parameters.Add("CodProducto", model.CodProducto);
                parameters.Add("NombreProducto", model.NombreProducto);
                parameters.Add("CodigoBarras", model.CodigoBarras);
                parameters.Add("Porcentaje_IVA", model.Porcentaje_IVA);
                parameters.Add("Precio_Unitario", model.Precio_Unitario);
                parameters.Add("Estado", model.Estado);
                parameters.Add("IdUsuario", model.IdUsuario);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDelProductos";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", ID);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;

            }
        }

        public async Task<Productos> GetAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetProductosByID";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", ID);

                var result = await connection.QuerySingleAsync<Productos>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Productos>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetProductos";

                var result = await connection.QueryAsync<Productos>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
