using RigoRigoTienda.BL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RigoRigoTienda.BusinessLogic.Interfaces
{
    public interface IPedidoService
    {
        
        Task<List<PedidoDTO>> GetAllAsync();

       
        Task<PedidoDTO> GetByIdAsync(int pedidoId);

        
        Task AddAsync(PedidoDTO pedidoDTO);

        
        Task UpdateAsync(int pedidoId, PedidoDTO pedidoDTO);


        Task DeleteAsync(int pedidoId);

        
    }
}
