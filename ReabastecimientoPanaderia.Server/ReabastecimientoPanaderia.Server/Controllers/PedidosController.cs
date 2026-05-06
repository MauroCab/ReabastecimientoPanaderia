using Microsoft.AspNetCore.Mvc;
using ReabastecimientoPanaderia.Repositorio.PedidoRepositorio;
using ReabastecimientoPanaderia.Shared.GetPedido_DTOs;
using ReabastecimientoPanaderia.Shared.CrearPedido_DTOs;
using ReabastecimientoPanaderia.DB.Data.Entities;

namespace ReabastecimientoPanaderia.Server.Controllers
{
    [ApiController]
    [Route("api/Pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepositorio _repositorio;
        public PedidosController(IPedidoRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        #region Get y GetById

        [HttpGet]
        public async Task<ActionResult<List<GetPedidoDTO>>> Get()
        {
            return await _repositorio.Get();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetPedidoDTO>> Get(int id)
        {
            var pedido = await _repositorio.GetById(id);

            if (pedido == null)
                return NotFound();

            return pedido;
        }

        #endregion

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CrearPedidoDTO entidadDTO)
        {
            bool pedidoEstaVacio = entidadDTO == null || entidadDTO.Renglones == null || !entidadDTO.Renglones.Any();

            if (pedidoEstaVacio)
            {
                return BadRequest("El pedido debe contener al menos un renglón.");
            }

            try
            {
                var nuevoPedido = new Pedido()
                {
                    FechaYHora = DateTime.Now
                };

                var nuevosRenglones = entidadDTO.Renglones.Select(r => new Renglon
                {
                    CantidadSolicitada = r.CantidadSolicitada,
                    ProductoSolicitadoID = r.ProductoSolicitado.ID
                }).ToList();

                var pedidoCreado = await _repositorio.AddPedidoConRenglones(nuevoPedido, nuevosRenglones);
            }
            catch
            {
            }
            return 5;
        }

    }
}
