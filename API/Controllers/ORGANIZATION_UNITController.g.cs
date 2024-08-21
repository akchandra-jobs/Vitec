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
    /// Controller responsible for managing organization_unit related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting organization_unit information.
    /// </remarks>
    [Route("api/organization_unit")]
    [Authorize]
    public class ORGANIZATION_UNITController : BaseApiController
    {
        private readonly IORGANIZATION_UNITService _oRGANIZATION_UNITService;

        /// <summary>
        /// Initializes a new instance of the ORGANIZATION_UNITController class with the specified context.
        /// </summary>
        /// <param name="iorganization_unitservice">The iorganization_unitservice to be used by the controller.</param>
        public ORGANIZATION_UNITController(IORGANIZATION_UNITService iorganization_unitservice)
        {
            _oRGANIZATION_UNITService = iorganization_unitservice;
        }

        /// <summary>Adds a new organization_unit</summary>
        /// <param name="model">The organization_unit data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ORGANIZATION_UNIT", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] ORGANIZATION_UNIT model)
        {
            var id = await _oRGANIZATION_UNITService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of organization_units based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of organization_units</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ORGANIZATION_UNIT", Entitlements.Read)]
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

            var result = await _oRGANIZATION_UNITService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific organization_unit by its primary key</summary>
        /// <param name="id">The primary key of the organization_unit</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The organization_unit data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ORGANIZATION_UNIT", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _oRGANIZATION_UNITService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific organization_unit by its primary key</summary>
        /// <param name="id">The primary key of the organization_unit</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("ORGANIZATION_UNIT", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _oRGANIZATION_UNITService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific organization_unit by its primary key</summary>
        /// <param name="id">The primary key of the organization_unit</param>
        /// <param name="updatedEntity">The organization_unit data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ORGANIZATION_UNIT", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] ORGANIZATION_UNIT updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _oRGANIZATION_UNITService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific organization_unit by its primary key</summary>
        /// <param name="id">The primary key of the organization_unit</param>
        /// <param name="updatedEntity">The organization_unit data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ORGANIZATION_UNIT", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<ORGANIZATION_UNIT> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _oRGANIZATION_UNITService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}