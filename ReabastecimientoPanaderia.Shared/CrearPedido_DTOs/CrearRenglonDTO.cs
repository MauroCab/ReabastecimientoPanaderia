using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.Shared.CrearPedido_DTOs
{
    public class CrearRenglonDTO
    {
        public int CantidadSolicitada { get; set; }

        public ProductoSolicitadoDTO? ProductoSolicitado { get; set; }
    }
}
