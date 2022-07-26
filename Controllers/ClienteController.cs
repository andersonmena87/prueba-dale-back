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
        /// <response code="200">Operación finalizada exitosamente</response>
        /// <response code="500">Se presentó un error interno al consultar los clientes</response>
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
        /// <param name="cliente">Objeto con la información del cliente que se creará</param>
        /// <returns>valor que indica si el registro se realizo de forma exitosa</returns>
        /// <response code="200">Operación finalizada exitosamente</response>
        /// <response code="500">Se presentó un error interno al adicionar un cliente</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<bool> Post(ClienteModel cliente)
        {
            return _bussines.Insert(cliente);
        }

        /// <summary>
        /// Actualiza el la información de un cliente.
        /// </summary>
        /// <param name="cliente">objeto que contiene la información actualizada</param>
        /// <returns>valor que indica si el registró se actualizó correctamente.</returns>
        ///  /// <response code="200">Operación finalizada exitosamente</response>
        /// <response code="500">Se presentó un error interno al actualizar un cliente</response>        
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
        /// <param name="id">objeto que contiene la información actualizada</param>
        /// <returns>valor que indica si el registró se eliminó correctamente.</returns>
        ///  /// <response code="200">Operación finalizada exitosamente</response>
        /// <response code="500">Se presentó un error interno al eliminar un cliente</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("/Cliente/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _bussines.Delete(id);
        }
    }
}