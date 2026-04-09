using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReabastecimientoPanaderia.DB.Data.Entities
{
    /// <summary>
    /// Un pedido es la solicitud de reabastecimiento que luego se guardará como PDF.
    /// Un pedido contiene varios renglones y cada uno de estos referencia a un producto existente y la cantidad solicitada del mismo.
    /// </summary>
    public class Pedido : EntityBase
    {
        /// <summary>
        /// Dia y hora en que se realizó el pedido.
        /// </summary>
        [Required(ErrorMessage = "La fecha y la hora son obligatorias")]
        public DateTime FechaYHora { get; set; }

        /// <summary>
        /// Lista de renglones que componen el pedido. Cada renglón representa un producto específico que se desea reabastecer, junto con la cantidad solicitada de ese producto.
        /// </summary>
        public List<Renglon> Renglones { get; set; } = new List<Renglon>();
    }
}
