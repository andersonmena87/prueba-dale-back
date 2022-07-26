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
        /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al consultar los productos</response>
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
        /// <param name="producto">Objeto con la informaci�n del producto que se crear�</param>
        /// <returns>valor que indica si el registro se realizo de forma exitosa</returns>
        /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al adicionar un producto</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<bool> Post(ProductoModel producto)
        {
            return _bussines.Insert(producto);
        }

        /// <summary>
        /// Actualiza el la informaci�n de un producto.
        /// </summary>
        /// <param name="producto">objeto que contiene la informaci�n actualizada</param>
        /// <returns>valor que indica si el registr� se actualiz� correctamente.</returns>
        ///  /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al actualizar un producto</response>        
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
        /// <param name="id">objeto que contiene la informaci�n actualizada</param>
        /// <returns>valor que indica si el registr� se elimin� correctamente.</returns>
        ///  /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al eliminar un producto</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("/Producto/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _bussines.Delete(id);
        }
    }
}