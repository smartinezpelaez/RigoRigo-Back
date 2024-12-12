using Microsoft.EntityFrameworkCore;
using RigoRigoTienda.DataAccess.Context;
using RigoRigoTienda.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RigoRigoTienda.DataAccess.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly RigoRigoTiendaBdContext _context;

        public ProductoRepository(RigoRigoTiendaBdContext context)
        {
            _context = context;
        }

        public async Task<List<Productos>> GetAllAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Productos> GetByIdAsync(int productoId)
        {
            return await _context.Productos.FindAsync(productoId);
        }

        public async Task AddAsync(Productos producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Productos producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productoId)
        {
            var producto = await _context.Productos.FindAsync(productoId);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
