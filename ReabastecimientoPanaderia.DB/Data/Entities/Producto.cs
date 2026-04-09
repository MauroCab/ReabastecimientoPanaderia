using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReabastecimientoPanaderia.DB.Data.Entities
{
    public class Producto : EntityBase
    {
        /// <summary>
        /// Nombre del producto, por ejemplo: "Pan de Molde", "Croissant", etc.
        /// </summary>
        [Required(ErrorMessage = "El nombre de producto es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre debe tener mas de 100 caracteres)")]
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
        [Required(ErrorMessage = "El tipo de producto es obligatorio")]
        public int TipoProductoID { get; set; }
        public required TipoProducto TipoProducto { get; set; }
    }
}
