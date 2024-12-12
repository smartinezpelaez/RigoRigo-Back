using System;
using System.Collections.Generic;

namespace RigoRigoTienda.BL.DTOs
{
    public class PedidoDTO
    {
        public int PedidoId { get; set; }
        public string CedulaCliente { get; set; }
        public string DireccionEntrega { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetallePedidoDTO> DetallePedido { get; set; }
    }
}
