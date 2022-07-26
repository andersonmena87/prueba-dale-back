using ApiPruebaTecnica.Business.Interfaces;
using ApiPruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaTecnica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteBL _bussines;

        public ClienteController(IClienteBL bussines)
        {
            _bussines = bussines;
        }

        /// <summary>
        ///  Obtiene el listado de clientes
        /// </summary>
        /// <returns>Listado de clientes</returns>
        /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al consultar los clientes</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<List<ClienteModel>> GetAll()
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
        /// Adiciona un nuevo cliente
        /// </summary>
        /// <param name="cliente">Objeto con la informaci�n del cliente que se crear�</param>
        /// <returns>valor que indica si el registro se realizo de forma exitosa</returns>
        /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al adicionar un cliente</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<bool> Post(ClienteModel cliente)
        {
            return _bussines.Insert(cliente);
        }

        /// <summary>
        /// Actualiza el la informaci�n de un cliente.
        /// </summary>
        /// <param name="cliente">objeto que contiene la informaci�n actualizada</param>
        /// <returns>valor que indica si el registr� se actualiz� correctamente.</returns>
        ///  /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al actualizar un cliente</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult<bool> Put(ClienteModel cliente)
        {
            return _bussines.Update(cliente);
        }

        /// <summary>
        /// Elimina cliente por id.
        /// </summary>
        /// <param name="id">objeto que contiene la informaci�n actualizada</param>
        /// <returns>valor que indica si el registr� se elimin� correctamente.</returns>
        ///  /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al eliminar un cliente</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("/Cliente/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _bussines.Delete(id);
        }
    }
}