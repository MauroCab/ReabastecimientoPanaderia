using ReabastecimientoPanaderia.DB.Data.Entities;
using ReabastecimientoPanaderia.Repositorio.Repositorio;

namespace ReabastecimientoPanaderia.Repositorio.ProductoRepositorio
{
    public interface IProductoRepositorio : IRepositorio<Producto>
    {
        Task<List<Producto>> Get();
        Task<Producto?> GetById(int id);
    }
}