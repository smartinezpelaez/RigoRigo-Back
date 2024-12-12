using System.Collections.Generic;



public partial class Productos
    {
        public Productos()
        {
            DetallePedido = new HashSet<DetallePedido>();
        }

        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
    }
