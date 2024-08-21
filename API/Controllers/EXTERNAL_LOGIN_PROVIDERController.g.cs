using Microsoft.AspNetCore.Mvc;
using Vitec.Models;
using Vitec.Services;
using Vitec.Entities;
using Vitec.Filter;
using Vitec.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Task = System.Threading.Tasks.Task;
using Vitec.Authorization;

namespace Vitec.Controllers
{
    /// <summary>
    /// Controller responsible for managing external_login_provider related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting external_login_provider information.
    /// </remarks>
    [Route("api/external_login_provider")]
    [Authorize]
    public class EXTERNAL_LOGIN_PROVIDERController : BaseApiController
    {
        private readonly IEXTERNAL_LOGIN_PROVIDERService _eXTERNAL_LOGIN_PROVIDERService;

        /// <summary>
        /// Initializes a new instance of the EXTERNAL_LOGIN_PROVIDERController class with the specified context.
        /// </summary>
        /// <param name="iexternal_login_providerservice">The iexternal_login_providerservice to be used by the controller.</param>
        public EXTERNAL_LOGIN_PROVIDERController(IEXTERNAL_LOGIN_PROVIDERService iexternal_login_providerservice)
        {
            _eXTERNAL_LOGIN_PROVIDERService = iexternal_login_providerservice;
        }

        /// <summary>Adds a new external_login_provider</summary>
        /// <param name="model">The external_login_provider data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("EXTERNAL_LOGIN_PROVIDER", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] EXTERNAL_LOGIN_PROVIDER model)
        {
            var id = await _eXTERNAL_LOGIN_PROVIDERService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of external_login_providers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of external_login_providers</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("EXTERNAL_LOGIN_PROVIDER", Entitlements.Read)]
        public async Task<IActionResult> Get([FromQuery] string filters, string searchTerm, int pageNumber = 1, int pageSize = 10, string sortField = null, string sortOrder = "asc")
        {
            List<FilterCriteria> filterCriteria = null;
            if (pageSize < 1)
            {
                return BadRequest("Page size invalid.");
            }

            if (pageNumber < 1)
            {
                return BadRequest("Page mumber invalid.");
            }

            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var result = await _eXTERNAL_LOGIN_PROVIDERService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific external_login_provider by its primary key</summary>
        /// <param name="id">The primary key of the external_login_provider</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The external_login_provider data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("EXTERNAL_LOGIN_PROVIDER", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _eXTERNAL_LOGIN_PROVIDERService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific external_login_provider by its primary key</summary>
        /// <param name="id">The primary key of the external_login_provider</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("EXTERNAL_LOGIN_PROVIDER", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _eXTERNAL_LOGIN_PROVIDERService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific external_login_provider by its primary key</summary>
        /// <param name="id">The primary key of the external_login_provider</param>
        /// <param name="updatedEntity">The external_login_provider data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("EXTERNAL_LOGIN_PROVIDER", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] EXTERNAL_LOGIN_PROVIDER updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _eXTERNAL_LOGIN_PROVIDERService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific external_login_provider by its primary key</summary>
        /// <param name="id">The primary key of the external_login_provider</param>
        /// <param name="updatedEntity">The external_login_provider data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("EXTERNAL_LOGIN_PROVIDER", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<EXTERNAL_LOGIN_PROVIDER> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _eXTERNAL_LOGIN_PROVIDERService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}