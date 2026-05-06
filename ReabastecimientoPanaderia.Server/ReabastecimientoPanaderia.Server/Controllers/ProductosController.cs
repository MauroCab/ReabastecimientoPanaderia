using Microsoft.AspNetCore.Mvc;
using ReabastecimientoPanaderia.DB.Data.Entities;
using ReabastecimientoPanaderia.Repositorio.ProductoRepositorio;
using ReabastecimientoPanaderia.Shared.CrearProducto_DTOs;

namespace ReabastecimientoPanaderia.Server.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepositorio _repositorio;

        public ProductosController(IProductoRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        #region Get y GetById

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await _repositorio.Get();
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> GetById(int id)
        {
            var producto = await _repositorio.GetById(id);

            if (producto == null) 
                return NotFound();

            return Ok(producto);
        }

        #endregion

        #region Feature futura : Post
        //[HttpPost]
        //public async Task<ActionResult<int>> Post([FromBody] CrearProductoDTO entidadDTO)
        //{
        //    try
        //    {
        //        Producto entidad = new Producto()
        //        {
        //            Nombre = entidadDTO.Nombre
        //        };

        //        //mapper.Map<Producto>(entidadDTO);
        //        await _repositorio.Insert(entidad);
        //        return entidad.ID;
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}
        #endregion

        #region Feature futura : Delete
        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    //var existe = await repositorio.Existe(id);
        //    //if (!existe)
        //    //{
        //    //    return NotFound($"El tipo de producto {id} no existe");
        //    //}
        //    //Producto EntidadABorrar = new Producto();
        //    //EntidadABorrar.Id = id;

        //    //if (await repositorio.Delete(id))
        //    //{
        //    //    return Ok();
        //    //}
        //    //else
        //    //{
        //    //    return BadRequest();
        //    //}
        //}
        #endregion

    }
}
