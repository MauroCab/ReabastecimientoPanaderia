using ReabastecimientoPanaderia.Shared.ObjetosSeguridad;

namespace ReabastecimientoPanaderia.Services.SecurityServices
{
    internal interface IServicioSeguridad
    {
        Task<ResultadoOperacionSeguridad> HacerAdmin(string email);
        Task<List<UsuarioDTO>> ObtenerUsuarios(string email);
        Task<ResultadoOperacionSeguridad> RemoverAdmin(string email);
    }
}