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
    /// Controller responsible for managing door_key_system related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting door_key_system information.
    /// </remarks>
    [Route("api/door_key_system")]
    [Authorize]
    public class DOOR_KEY_SYSTEMController : BaseApiController
    {
        private readonly IDOOR_KEY_SYSTEMService _dOOR_KEY_SYSTEMService;

        /// <summary>
        /// Initializes a new instance of the DOOR_KEY_SYSTEMController class with the specified context.
        /// </summary>
        /// <param name="idoor_key_systemservice">The idoor_key_systemservice to be used by the controller.</param>
        public DOOR_KEY_SYSTEMController(IDOOR_KEY_SYSTEMService idoor_key_systemservice)
        {
            _dOOR_KEY_SYSTEMService = idoor_key_systemservice;
        }

        /// <summary>Adds a new door_key_system</summary>
        /// <param name="model">The door_key_system data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("DOOR_KEY_SYSTEM", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] DOOR_KEY_SYSTEM model)
        {
            var id = await _dOOR_KEY_SYSTEMService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of door_key_systems based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of door_key_systems</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DOOR_KEY_SYSTEM", Entitlements.Read)]
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

            var result = await _dOOR_KEY_SYSTEMService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific door_key_system by its primary key</summary>
        /// <param name="id">The primary key of the door_key_system</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The door_key_system data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("DOOR_KEY_SYSTEM", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _dOOR_KEY_SYSTEMService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific door_key_system by its primary key</summary>
        /// <param name="id">The primary key of the door_key_system</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("DOOR_KEY_SYSTEM", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _dOOR_KEY_SYSTEMService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific door_key_system by its primary key</summary>
        /// <param name="id">The primary key of the door_key_system</param>
        /// <param name="updatedEntity">The door_key_system data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DOOR_KEY_SYSTEM", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] DOOR_KEY_SYSTEM updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _dOOR_KEY_SYSTEMService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific door_key_system by its primary key</summary>
        /// <param name="id">The primary key of the door_key_system</param>
        /// <param name="updatedEntity">The door_key_system data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DOOR_KEY_SYSTEM", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<DOOR_KEY_SYSTEM> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _dOOR_KEY_SYSTEMService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}