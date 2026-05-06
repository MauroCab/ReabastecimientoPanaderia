using ReabastecimientoPanaderia.DB.Data.Entities;
using ReabastecimientoPanaderia.Repositorio.Repositorio;
using ReabastecimientoPanaderia.Shared.GetPedido_DTOs;

namespace ReabastecimientoPanaderia.Repositorio.PedidoRepositorio
{
    public interface IPedidoRepositorio : IRepositorio<Pedido>
    {
        Task<Pedido> AddPedidoConRenglones(Pedido pedido, List<Renglon> renglones);
        Task<List<GetPedidoDTO>> Get();
        Task<GetPedidoDTO> GetById(int id);
    }
}