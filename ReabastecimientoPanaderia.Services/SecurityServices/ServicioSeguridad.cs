using ReabastecimientoPanaderia.Shared.ObjetosSeguridad;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.Services.SecurityServices
{
    public class ServicioSeguridad : IServicioSeguridad
    {
        //public ServicioSeguridad(AppDbContext<ApplicationUser> context,
        //                         UserManager<ApplicationUser> userManager, 
        //                         IHttpContextAccessor httpContextAccessor, 
        //                         IAuthorizationService authorizationService
        //{

        //}
        public Task<ResultadoOperacionSeguridad> HacerAdmin(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<UsuarioDTO>> ObtenerUsuarios(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ResultadoOperacionSeguridad> RemoverAdmin(string email)
        {
            throw new NotImplementedException();
        }
    }
}
