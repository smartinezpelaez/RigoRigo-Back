public partial class DetallePedido
    {
        public int DetallePedidoId { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Pedidos Pedido { get; set; }
        public virtual Productos Producto { get; set; }
    }
