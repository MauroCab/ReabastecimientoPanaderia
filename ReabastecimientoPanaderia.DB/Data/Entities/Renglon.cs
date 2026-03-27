using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.DB.Data.Entities
{
    /// <summary>
    /// Esta clase representa un renglón dentro de un pedido. Cada renglón hace referencia a un producto específico que se desea reabastecer, junto con la cantidad solicitada de ese producto.
    /// </summary>
    internal class Renglon : EntityBase
    {
        /// <summary>
        /// Hace referencia a un producto solicitado en el pedido. Es decir, el producto que se desea reabastecer.
        /// </summary>
        public int ProductoSolicitadoID { get; set; }
        public required Producto ProductoSolicitado { get; set; }

        /// <summary>
        /// Cantidad solicitada del producto en cuestión. Por ejemplo, si se desea reabastecer 10 unidades de "Pan de Molde", entonces este valor sería 10.
        /// </summary>
        public int CantidadSolicitada { get; set; }

        /// <summary>
        /// Referencia al pedido al que pertenece este renglón.
        /// </summary>
        public int PedidoID { get; set; }
        public required Pedido Pedido { get; set; }
    }
}
