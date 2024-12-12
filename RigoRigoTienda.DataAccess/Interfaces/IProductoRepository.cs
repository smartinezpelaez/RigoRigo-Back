using System.Collections.Generic;
using System.Threading.Tasks;

namespace RigoRigoTienda.DataAccess.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<Productos>> GetAllAsync();
        Task<Productos> GetByIdAsync(int productoId);
        Task AddAsync(Productos producto);
        Task UpdateAsync(Productos producto);
        Task DeleteAsync(int productoId);
    }
}
