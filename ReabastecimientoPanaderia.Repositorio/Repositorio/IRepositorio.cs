using ReabastecimientoPanaderia.DB.Data;

namespace ReabastecimientoPanaderia.Repositorio.Repositorio
{
    public interface IRepositorio<E> where E : class, IEntityBase
    {
        Task<List<E>> Select();
        Task<E> SelectById(int id);
        Task<bool> Existe(int id);
        Task<int> Insert(E entidad);
        Task<bool> Delete(int id);

    }
}