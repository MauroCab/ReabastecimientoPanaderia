using ReabastecimientoPanaderia.DB.Data;

namespace ReabastecimientoPanaderia.Repositorio.Repositorio
{
    public interface IRepositorio<Entidad> where Entidad : class, IEntityBase
    {
        Task<List<Entidad>> Select();
        Task<Entidad> SelectById(int id);
        Task<bool> Existe(int id);
        Task<int> Insert(Entidad entidad);
        Task<bool> Delete(int id);

    }
}