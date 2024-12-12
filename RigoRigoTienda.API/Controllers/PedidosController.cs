using Microsoft.AspNetCore.Mvc;
using RigoRigoTienda.BL.DTOs;
using RigoRigoTienda.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RigoRigoTienda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

       
        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<PedidoDTO>>> GetAll()
        {
            var pedidos = await _pedidoService.GetAllAsync();
            if (pedidos == null || pedidos.Count == 0)
            {
                return NotFound("No se encontraron pedidos.");
            }
            return Ok(pedidos);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDTO>> GetById(int id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            if (pedido == null)
            {
                return NotFound($"No se encontró el pedido con ID {id}.");
            }
            return Ok(pedido);
        }

        
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PedidoDTO pedidoDTO)
        {
            if (pedidoDTO == null)
            {
                return BadRequest("El pedido es inválido.");
            }

            await _pedidoService.AddAsync(pedidoDTO);
            return CreatedAtAction(nameof(GetById), new { id = pedidoDTO.PedidoId }, pedidoDTO);
        }

       
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PedidoDTO pedidoDTO)
        {
            if (pedidoDTO == null || id != pedidoDTO.PedidoId)
            {
                return BadRequest("Los datos del pedido no son válidos.");
            }

            await _pedidoService.UpdateAsync(id, pedidoDTO);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            if (pedido == null)
            {
                return NotFound($"No se encontró el pedido con ID {id}.");
            }

            await _pedidoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
