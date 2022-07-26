using ApiPruebaTecnica.Business.Interfaces;
using ApiPruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaTecnica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoBL _bussines;

        public ProductoController(IProductoBL bussines)
        {
            _bussines = bussines;
        }

        /// <summary>
        ///  Obtiene el listado de productos
        /// </summary>
        /// <returns>Listado de productos</returns>
        /// <response code="200">Operación finalizada exitosamente</response>
        /// <response code="500">Se presentó un error interno al consultar los productos</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<List<ProductoModel>> GetAll()
        {
            try
            {
                return await _bussines.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adiciona un nuevo producto
        /// </summary>
        /// <param name="producto">Objeto con la información del producto que se creará</param>
        /// <returns>valor que indica si el registro se realizo de forma exitosa</returns>
        /// <response code="200">Operación finalizada exitosamente</response>
        /// <response code="500">Se presentó un error interno al adicionar un producto</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<bool> Post(ProductoModel producto)
        {
            return _bussines.Insert(producto);
        }

        /// <summary>
        /// Actualiza el la información de un producto.
        /// </summary>
        /// <param name="producto">objeto que contiene la información actualizada</param>
        /// <returns>valor que indica si el registró se actualizó correctamente.</returns>
        ///  /// <response code="200">Operación finalizada exitosamente</response>
        /// <response code="500">Se presentó un error interno al actualizar un producto</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult<bool> Put(ProductoModel producto)
        {
            return _bussines.Update(producto);
        }

        /// <summary>
        /// Elimina producto por id.
        /// </summary>
        /// <param name="id">objeto que contiene la información actualizada</param>
        /// <returns>valor que indica si el registró se eliminó correctamente.</returns>
        ///  /// <response code="200">Operación finalizada exitosamente</response>
        /// <response code="500">Se presentó un error interno al eliminar un producto</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("/Producto/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _bussines.Delete(id);
        }
    }
}