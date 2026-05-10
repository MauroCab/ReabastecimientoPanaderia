using ReabastecimientoPanaderia.Services.DataModels;
using ReabastecimientoPanaderia.Shared.CrearPedido_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.Services.UtilityServices
{
    public class PedidoService
    {
        public PedidoActual Pedido { get; private set; } = new();

        public event Action? OnCambio;

        public void AgregarAlPedido(ProductoSolicitadoDTO producto, int cantidad)
        {
            Pedido.AgregarProducto(producto, cantidad);
            OnCambio?.Invoke();
        }

        public void RemoverDelPedido(int productoId)
        {
            Pedido.RemoverProducto(productoId);
            OnCambio?.Invoke();
        }

        public void LimpiarPedido()
        {
            Pedido.Renglones.Clear();
            OnCambio?.Invoke();
        }
    }
}

