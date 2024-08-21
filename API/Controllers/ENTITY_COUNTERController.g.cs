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
    /// Controller responsible for managing entity_counter related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting entity_counter information.
    /// </remarks>
    [Route("api/entity_counter")]
    [Authorize]
    public class ENTITY_COUNTERController : BaseApiController
    {
        private readonly IENTITY_COUNTERService _eNTITY_COUNTERService;

        /// <summary>
        /// Initializes a new instance of the ENTITY_COUNTERController class with the specified context.
        /// </summary>
        /// <param name="ientity_counterservice">The ientity_counterservice to be used by the controller.</param>
        public ENTITY_COUNTERController(IENTITY_COUNTERService ientity_counterservice)
        {
            _eNTITY_COUNTERService = ientity_counterservice;
        }

        /// <summary>Adds a new entity_counter</summary>
        /// <param name="model">The entity_counter data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_COUNTER", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] ENTITY_COUNTER model)
        {
            var id = await _eNTITY_COUNTERService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of entity_counters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of entity_counters</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_COUNTER", Entitlements.Read)]
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

            var result = await _eNTITY_COUNTERService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific entity_counter by its primary key</summary>
        /// <param name="id">The primary key of the entity_counter</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The entity_counter data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_COUNTER", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _eNTITY_COUNTERService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific entity_counter by its primary key</summary>
        /// <param name="id">The primary key of the entity_counter</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("ENTITY_COUNTER", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _eNTITY_COUNTERService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific entity_counter by its primary key</summary>
        /// <param name="id">The primary key of the entity_counter</param>
        /// <param name="updatedEntity">The entity_counter data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_COUNTER", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] ENTITY_COUNTER updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _eNTITY_COUNTERService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific entity_counter by its primary key</summary>
        /// <param name="id">The primary key of the entity_counter</param>
        /// <param name="updatedEntity">The entity_counter data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_COUNTER", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<ENTITY_COUNTER> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _eNTITY_COUNTERService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}