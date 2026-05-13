using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.Shared.ObjetosSeguridad
{
    /// <summary>
    /// Represents the state of a record in the system.
    /// </summary>
    /// <remarks>This enumeration is used to indicate the current status of a record, 
    /// such as whether it is
    /// active, inactive, or deleted.</remarks>
    public enum EnumEstadoRegistro
    {
        activo = 1,
        inactivo = 2,
        borrado = 3,
        EnGrabacion = 4
    }
    public enum ResultadoOperacionSeguridad
    {
        Exitoso = 1,
        Fallido = 2,
        NoEncontrado = 3,
        SinPermiso = 4
    }
}
