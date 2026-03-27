using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReabastecimientoPanaderia.DB.Data.Entities
{
    internal class TipoProducto : EntityBase
    {
        /// <summary>
        /// Código de 3 caracteres que abrevia el nombre del tipo de producto
        /// </summary>
        [MaxLength(3)]
        public required string Codigo { get; set; }

        /// <summary>
        /// Nombre del tipo de producto, por ejemplo: "Panadería", "Pastelería", etc.
        /// </summary>
        [MaxLength(50)]
        public required string Nombre { get; set; }

        /// <summary>
        /// Lista de productos (en la tabla productos) que pertenezcan a este tipo de producto.
        /// </summary>
        public List<Producto> Productos { get; set; } = new List<Producto>();

    }
}
