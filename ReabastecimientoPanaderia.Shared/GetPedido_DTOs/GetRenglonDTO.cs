using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.Shared.GetPedido_DTOs
{
    public class GetRenglonDTO
    {
        public int CantidadSolicitada { get; set; }
        public string? NombreProductoSolicitado { get; set; }
    }
}
