using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReabastecimientoPanaderia.DB.Data.Entities
{
    /// <summary>
    /// Esta clase representa un renglón dentro de un pedido. Cada renglón hace referencia a un producto específico que se desea reabastecer, junto con la cantidad solicitada de ese producto.
    /// </summary>
    public class Renglon : EntityBase
    {
        /// <summary>
        /// Hace referencia a un producto solicitado en el pedido. Es decir, el producto que se desea reabastecer.
        /// </summary>
        public int? ProductoSolicitadoID { get; set; }
        public Producto? ProductoSolicitado { get; set; }

        /// <summary>
        /// El nombre del producto solicitado
        /// </summary>
        public required string NombreProducto { get; set; }
        // Renglon guarda el nombre del producto para que en caso de
        // que el producto sea eliminado de la base de datos, se setee la clave foránea como NULL
        // pero se mantenga el nombre del producto en el pedido para conservar el historial

        /// <summary>
        /// Cantidad solicitada del producto en cuestión. Por ejemplo, si se desea reabastecer 10 unidades de "Pan de Molde", entonces este valor sería 10.
        /// </summary>
        [Required(ErrorMessage = "La cantidad del producto es obligatoria")]
        public int CantidadSolicitada { get; set; }

        /// <summary>
        /// Referencia al pedido al que pertenece este renglón.
        /// </summary>
        [Required(ErrorMessage = "El id del pedido es obligatorio")]
        public int PedidoID { get; set; }
        public required Pedido Pedido { get; set; }
    }
}
