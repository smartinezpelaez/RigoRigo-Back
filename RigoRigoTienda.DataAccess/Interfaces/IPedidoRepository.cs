using System.Collections.Generic;
using System.Threading.Tasks;

namespace RigoRigoTienda.DataAccess.Interfaces
{
    public interface IPedidoRepository
    {
        Task<List<Pedidos>> GetAllAsync();
        Task<Pedidos> GetByIdAsync(int pedidoId);
        Task AddAsync(Pedidos pedido);
        Task UpdateAsync(Pedidos pedido);
        Task DeleteAsync(int pedidoId);
    }
}
