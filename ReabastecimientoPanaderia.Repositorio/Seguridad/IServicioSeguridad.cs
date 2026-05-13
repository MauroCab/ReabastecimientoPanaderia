using ReabastecimientoPanaderia.Shared.ObjetosSeguridad;

namespace ReabastecimientoPanaderia.Repositorio.Seguridad
{
    public interface IServicioSeguridad
    {
        Task<ResultadoOperacionSeguridad> HacerAdmin(string email);
        Task<List<UsuarioDTO>> ObtenerUsuarios(string email);
        Task<ResultadoOperacionSeguridad> RemoverAdmin(string email);
    }
}