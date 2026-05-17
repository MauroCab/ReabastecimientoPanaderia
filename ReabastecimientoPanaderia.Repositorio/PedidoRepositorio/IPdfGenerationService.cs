using ReabastecimientoPanaderia.Shared.CrearPedido_DTOs;

namespace ReabastecimientoPanaderia.Repositorio.PedidoRepositorio
{
    public interface IPdfGenerationService
    {
        Task<byte[]> GenerarPdfPedidoAsync(CrearPedidoDTO pedido);
    }
}