using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.Shared.CrearPedido_DTOs
{
    public class CrearRenglonDTO
    {
        public int Cantidad { get; set; }

        public ProductoEnPedidoDTO? Producto { get; set; }
    }
}
