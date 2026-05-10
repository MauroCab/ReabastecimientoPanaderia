using ReabastecimientoPanaderia.Shared.CrearPedido_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanadería.Services.DataModels
{
    public class PedidoActual
    {
        public List<CrearRenglonDTO> Renglones { get; set; } = new();

        public void AgregarProducto(ProductoSolicitadoDTO producto, int cantidad)
        {
            var renglonExistente = Renglones.FirstOrDefault(r => r.ProductoSolicitado.ID == producto.ID);

            if (renglonExistente != null)
            {
                renglonExistente.CantidadSolicitada += cantidad;
            }
            else
            {
                Renglones.Add(new CrearRenglonDTO
                {
                    ProductoSolicitado = producto,
                    CantidadSolicitada = cantidad
                });
            }
        }

        public void RemoverProducto(int productoId)
        {
            var renglon = Renglones.FirstOrDefault(r => r.ProductoSolicitado.ID == productoId);
            if (renglon != null)
                Renglones.Remove(renglon);
        }
    }
}
