using ApiPruebaTecnica.Business.Interfaces;
using ApiPruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaTecnica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class RolController : ControllerBase
    {
        private readonly IRolBL _bussines;

        public RolController(IRolBL bussines)
        {
            _bussines = bussines;
        }

        /// <summary>
        ///  Obtiene el listado de roles
        /// </summary>
        /// <returns>Listado de roles</returns>
        /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al consultar los roles</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<List<RolModel>> GetAll()
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
        /// Adiciona un nuevo rol
        /// </summary>
        /// <param name="rol">Objeto con la informaci�n del rol que se crear�</param>
        /// <returns>valor que indica si el registro se realizo de forma exitosa</returns>
        /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al adicionar un rol</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<bool> Post(RolModel rol)
        {
            return _bussines.Insert(rol);
        }

        /// <summary>
        /// Actualiza el la informaci�n de un rol.
        /// </summary>
        /// <param name="rol">objeto que contiene la informaci�n actualizada</param>
        /// <returns>valor que indica si el registr� se actualiz� correctamente.</returns>
        ///  /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al actualizar un rol</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult<bool> Put(RolModel rol)
        {
            return _bussines.Update(rol);
        }
        
        /// <summary>
        /// Elimina rol por id.
        /// </summary>
        /// <param name="id">objeto que contiene la informaci�n actualizada</param>
        /// <returns>valor que indica si el registr� se elimin� correctamente.</returns>
        ///  /// <response code="200">Operaci�n finalizada exitosamente</response>
        /// <response code="500">Se present� un error interno al eliminar un rol</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("/Rol/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _bussines.Delete(id);
        }
    }
}