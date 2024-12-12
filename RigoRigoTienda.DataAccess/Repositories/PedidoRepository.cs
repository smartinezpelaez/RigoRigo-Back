using Microsoft.EntityFrameworkCore;
using RigoRigoTienda.DataAccess.Context;
using RigoRigoTienda.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RigoRigoTienda.DataAccess.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly RigoRigoTiendaBdContext _context;

        public PedidoRepository(RigoRigoTiendaBdContext context)
        {
            _context = context;
        }

        public async Task<List<Pedidos>> GetAllAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedidos> GetByIdAsync(int pedidoId)
        {
            return await _context.Pedidos.FindAsync(pedidoId);
        }

        public async Task AddAsync(Pedidos pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pedidos pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int pedidoId)
        {
            var pedido = await _context.Pedidos.FindAsync(pedidoId);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }
    }
}
