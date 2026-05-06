using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.Shared.GetPedido_DTOs
{
    public class GetPedidoDTO
    {
        public DateTime FechaYHora { get; set; }
        public List<GetRenglonDTO> Renglones { get; set; }
    }
}
