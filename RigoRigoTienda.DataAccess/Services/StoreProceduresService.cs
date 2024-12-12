using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RigoRigoTienda.DataAccess.Context;
using RigoRigoTienda.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace RigoRigoTienda.DataAccess.Services
{
    public class StoreProceduresService : IStoreProceduresService
    {
        private readonly RigoRigoTiendaBdContext _context;

        public StoreProceduresService(RigoRigoTiendaBdContext context)
        {
            _context = context;
        }

        // Procedimiento 1: AgregarPedido
        public async Task<int> AgregarPedidoAsync(string cedulaCliente, string direccionEntrega, DateTime? fecha = null)
        {
            var fechaParam = fecha ?? DateTime.Now;
            var cedulaParam = new SqlParameter("@CedulaCliente", SqlDbType.NVarChar) { Value = cedulaCliente };
            var direccionParam = new SqlParameter("@DireccionEntrega", SqlDbType.NVarChar) { Value = direccionEntrega };
            var fechaParamDb = new SqlParameter("@Fecha", SqlDbType.DateTime) { Value = fechaParam };

            var pedidoIdParam = new SqlParameter("@PedidoId", SqlDbType.Int) { Direction = ParameterDirection.Output };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC AgregarPedido @CedulaCliente, @DireccionEntrega, @Fecha",
                cedulaParam, direccionParam, fechaParamDb);

            return (int)pedidoIdParam.Value;
        }

        // Procedimiento 2: AgregarDetallePedido
        public async Task AgregarDetallePedidoAsync(int pedidoId, int productoId, int cantidad)
        {
            var pedidoIdParam = new SqlParameter("@PedidoId", SqlDbType.Int) { Value = pedidoId };
            var productoIdParam = new SqlParameter("@ProductoId", SqlDbType.Int) { Value = productoId };
            var cantidadParam = new SqlParameter("@Cantidad", SqlDbType.Int) { Value = cantidad };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC AgregarDetallePedido @PedidoId, @ProductoId, @Cantidad",
                pedidoIdParam, productoIdParam, cantidadParam);
        }

        // Procedimiento 3: ObtenerPedidos
        public async Task<List<Pedidos>> ObtenerPedidosAsync()
        {
            var result = await _context.Pedidos.FromSqlRaw("EXEC ObtenerPedidos").ToListAsync();
            return result;
        }

        // Procedimiento 4: ObtenerDetallePedido
        public async Task<List<DetallePedido>> ObtenerDetallePedidoAsync(int pedidoId)
        {
            var pedidoIdParam = new SqlParameter("@PedidoId", SqlDbType.Int) { Value = pedidoId };
            var result = await _context.DetallePedido.FromSqlRaw(
                "EXEC ObtenerDetallePedido @PedidoId", pedidoIdParam).ToListAsync();
            return result;
        }

        // Procedimiento 5: ObtenerProductos
        public async Task<List<Productos>> ObtenerProductosAsync()
        {
            var result = await _context.Productos.FromSqlRaw("EXEC ObtenerProductos").ToListAsync();
            return result;
        }
    }
}
