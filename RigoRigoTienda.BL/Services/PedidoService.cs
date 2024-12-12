using AutoMapper;
using RigoRigoTienda.BL.DTOs;
using RigoRigoTienda.BusinessLogic.Interfaces;
using RigoRigoTienda.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RigoRigoTienda.BusinessLogic.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        
        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }
        
        public async Task<List<PedidoDTO>> GetAllAsync()
        {
            var pedidos = await _pedidoRepository.GetAllAsync();
            return _mapper.Map<List<PedidoDTO>>(pedidos);
        }
       
        public async Task<PedidoDTO> GetByIdAsync(int pedidoId)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(pedidoId);
            return pedido == null ? null : _mapper.Map<PedidoDTO>(pedido);
        }
        
        public async Task AddAsync(PedidoDTO pedidoDTO)
        {
            var pedido = _mapper.Map<Pedidos>(pedidoDTO);
            await _pedidoRepository.AddAsync(pedido);
        }
        
        public async Task UpdateAsync(int pedidoId, PedidoDTO pedidoDTO)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(pedidoId);
            if (pedido != null)
            {
                // Mapear los cambios desde el DTO
                _mapper.Map(pedidoDTO, pedido);
                await _pedidoRepository.UpdateAsync(pedido);
            }
        }
        
        public async Task DeleteAsync(int pedidoId)
        {
            await _pedidoRepository.DeleteAsync(pedidoId);
        }

        
    }

    
}
