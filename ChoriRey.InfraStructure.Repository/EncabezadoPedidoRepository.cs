using ChoriRey.Domain.Entity;
using ChoriRey.InfraStructure.Interface;
using ChoriRey.Transversal.Common;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ChoriRey.InfraStructure.Repository
{
    public class EncabezadoPedidoRepository : IEncabezadoPedidoRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public EncabezadoPedidoRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> GenerarPedidoAsync(EncabezadoPedido model)
        {
            var jsonDetalle = JsonConvert.SerializeObject(model.Pedidos);

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspProductosInsert";
                var parameters = new DynamicParameters();

                parameters.Add("IdCliente", model.Encabezado.IdCliente);
                parameters.Add("Total", model.Encabezado.Total);
                parameters.Add("IVA", model.Encabezado.IVA);
                parameters.Add("SubTotal", model.Encabezado.SubTotal);
                parameters.Add("Estado", model.Encabezado.Estado);
                parameters.Add("EsFactura", model.Encabezado.EsFactura);
                parameters.Add("Observacion", model.Encabezado.Observacion);
                parameters.Add("IdUsuario", model.Encabezado.IdUsuario);
                parameters.Add("JsonDetalle", jsonDetalle);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }
    }
}
