using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.Shared.CrearPedido_DTOs
{
    public class ProductoSolicitadoDTO
    {
        public required int ID { get; set; }
        public required string Nombre { get; set; }
        public bool EsComun { get; set; }
    }
}
