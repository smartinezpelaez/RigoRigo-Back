using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RigoRigoTienda.DataAccess.Interfaces
{
    public interface IStoreProceduresService
    {
        
        Task<int> AgregarPedidoAsync(string cedulaCliente, string direccionEntrega, DateTime? fecha = null);

        Task AgregarDetallePedidoAsync(int pedidoId, int productoId, int cantidad);

        Task<List<Pedidos>> ObtenerPedidosAsync();

        Task<List<DetallePedido>> ObtenerDetallePedidoAsync(int pedidoId);

        Task<List<Productos>> ObtenerProductosAsync();
    }
}
