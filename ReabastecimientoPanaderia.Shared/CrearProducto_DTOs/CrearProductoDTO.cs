using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReabastecimientoPanaderia.Shared.CrearProducto_DTOs
{
    public class CrearProductoDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre debe tener mas de 100 caracteres)")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El tipo de producto es obligatorio")]
        public int TProductoId { get; set; }
    }
}
