using System.Collections.Generic;
using System.Threading.Tasks;

namespace RigoRigoTienda.DataAccess.Interfaces
{
    public interface IDetallePedidoRepository
    {
        Task<List<DetallePedido>> GetAllAsync();
        Task<DetallePedido> GetByIdAsync(int detallePedidoId);
        Task AddAsync(DetallePedido detallePedido);
        Task UpdateAsync(DetallePedido detallePedido);
        Task DeleteAsync(int detallePedidoId);
    }
}
