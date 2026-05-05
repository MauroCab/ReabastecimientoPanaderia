using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.Shared.CrearPedido_DTOs
{
    public class ProductoEnPedidoDTO
    {
        public required int Id { get; set; }
        public required string Nombre { get; set; }
        public bool EsComun { get; set; }
    }
}
