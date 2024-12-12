namespace RigoRigoTienda.BL.DTOs
{
    public class DetallePedidoDTO
    {
        public int DetallePedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
