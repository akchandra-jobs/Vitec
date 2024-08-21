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
    /// Controller responsible for managing area_x_entity related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting area_x_entity information.
    /// </remarks>
    [Route("api/area_x_entity")]
    [Authorize]
    public class AREA_X_ENTITYController : BaseApiController
    {
        private readonly IAREA_X_ENTITYService _aREA_X_ENTITYService;

        /// <summary>
        /// Initializes a new instance of the AREA_X_ENTITYController class with the specified context.
        /// </summary>
        /// <param name="iarea_x_entityservice">The iarea_x_entityservice to be used by the controller.</param>
        public AREA_X_ENTITYController(IAREA_X_ENTITYService iarea_x_entityservice)
        {
            _aREA_X_ENTITYService = iarea_x_entityservice;
        }

        /// <summary>Adds a new area_x_entity</summary>
        /// <param name="model">The area_x_entity data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("AREA_X_ENTITY", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] AREA_X_ENTITY model)
        {
            var id = await _aREA_X_ENTITYService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of area_x_entitys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of area_x_entitys</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("AREA_X_ENTITY", Entitlements.Read)]
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

            var result = await _aREA_X_ENTITYService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific area_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the area_x_entity</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The area_x_entity data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("AREA_X_ENTITY", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _aREA_X_ENTITYService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific area_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the area_x_entity</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("AREA_X_ENTITY", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _aREA_X_ENTITYService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific area_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the area_x_entity</param>
        /// <param name="updatedEntity">The area_x_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("AREA_X_ENTITY", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] AREA_X_ENTITY updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _aREA_X_ENTITYService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific area_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the area_x_entity</param>
        /// <param name="updatedEntity">The area_x_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("AREA_X_ENTITY", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<AREA_X_ENTITY> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _aREA_X_ENTITYService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}