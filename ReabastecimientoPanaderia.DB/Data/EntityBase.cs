using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReabastecimientoPanaderia.DB.Data
{
    public class EntityBase
    {
        [Required]
        public int ID { get; set; }
    }
}
