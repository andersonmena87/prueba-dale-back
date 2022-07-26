using ApiPruebaTecnica.Business.Interfaces;
using ApiPruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaTecnica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class VentaController : ControllerBase
    {
        private readonly IVentaBL _bussines;

        public VentaController(IVentaBL bussines)
        {
            _bussines = bussines;
        }

        /// <summary>
        ///  Obtiene el listado de ventas
        /// </summary>
        /// <returns>Listado de ventas</returns>
        /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al consultar los ventas</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<List<VentaModel>> GetAll()
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
        /// Adiciona un nuevo venta
        /// </summary>
        /// <param name="venta">Objeto con la informaci�n del venta que se crear�</param>
        /// <returns>valor que indica si el registro se realizo de forma exitosa</returns>
        /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al adicionar un venta</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<bool> Post(VentaModel venta)
        {
            return _bussines.Insert(venta);
        }

        /// <summary>
        /// Actualiza el la informaci�n de un venta.
        /// </summary>
        /// <param name="venta">objeto que contiene la informaci�n actualizada</param>
        /// <returns>valor que indica si el registr� se actualiz� correctamente.</returns>
        ///  /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al actualizar un venta</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult<bool> Put(VentaModel venta)
        {
            return _bussines.Update(venta);
        }

        /// <summary>
        /// Elimina venta por id.
        /// </summary>
        /// <param name="id">objeto que contiene la informaci�n actualizada</param>
        /// <returns>valor que indica si el registr� se elimin� correctamente.</returns>
        ///  /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al eliminar un venta</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("/venta/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _bussines.Delete(id);
        }
    }
}