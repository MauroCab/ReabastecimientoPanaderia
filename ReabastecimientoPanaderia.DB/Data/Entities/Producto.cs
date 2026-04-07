using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.DB.Data.Entities
{
    public class Producto : EntityBase
    {
        /// <summary>
        /// Nombre del producto, por ejemplo: "Pan de Molde", "Croissant", etc.
        /// </summary>
        public required string Nombre { get; set; }

        /// <summary>
        /// Booleano que indica si el producto es de compra común, como si fuese un atributo de "favoritos" o "frecuentes".
        /// Esto puede ayudar a priorizar ciertos productos en la aplicación.
        /// Por predeterminado es falso, es el usuario final quien determina 
        /// cuáles productos son comunes para su negocio.
        /// </summary>
        public bool EsComun { get; set; } = false;

        /// <summary>
        /// Obtiene o establece el identificador único del tipo de producto.
        /// </summary>
        public int TipoProductoID { get; set; }
        public required TipoProducto TipoProducto { get; set; }
    }
}
