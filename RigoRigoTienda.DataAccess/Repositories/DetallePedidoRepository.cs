using Microsoft.EntityFrameworkCore;
using RigoRigoTienda.DataAccess.Context;
using RigoRigoTienda.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RigoRigoTienda.DataAccess.Repositories
{
    public class DetallePedidoRepository : IDetallePedidoRepository
    {
        private readonly RigoRigoTiendaBdContext _context;

        public DetallePedidoRepository(RigoRigoTiendaBdContext context)
        {
            _context = context;
        }

        public async Task<List<DetallePedido>> GetAllAsync()
        {
            return await _context.DetallePedido.ToListAsync();
        }

        public async Task<DetallePedido> GetByIdAsync(int detallePedidoId)
        {
            return await _context.DetallePedido.FindAsync(detallePedidoId);
        }

        public async Task AddAsync(DetallePedido detallePedido)
        {
            await _context.DetallePedido.AddAsync(detallePedido);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DetallePedido detallePedido)
        {
            _context.DetallePedido.Update(detallePedido);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int detallePedidoId)
        {
            var detallePedido = await _context.DetallePedido.FindAsync(detallePedidoId);
            if (detallePedido != null)
            {
                _context.DetallePedido.Remove(detallePedido);
                await _context.SaveChangesAsync();
            }
        }
    }
}
