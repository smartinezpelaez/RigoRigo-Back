using System;
using System.Collections.Generic;



    public partial class Pedidos
    {
        public Pedidos()
        {
            DetallePedido = new HashSet<DetallePedido>();
        }

        public int PedidoId { get; set; }
        public string CedulaCliente { get; set; }
        public string DireccionEntrega { get; set; }
        public DateTime Fecha { get; set; }

        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
    }

