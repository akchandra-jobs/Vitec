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
    /// Controller responsible for managing equipment_operating_hour_type related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting equipment_operating_hour_type information.
    /// </remarks>
    [Route("api/equipment_operating_hour_type")]
    [Authorize]
    public class EQUIPMENT_OPERATING_HOUR_TYPEController : BaseApiController
    {
        private readonly IEQUIPMENT_OPERATING_HOUR_TYPEService _eQUIPMENT_OPERATING_HOUR_TYPEService;

        /// <summary>
        /// Initializes a new instance of the EQUIPMENT_OPERATING_HOUR_TYPEController class with the specified context.
        /// </summary>
        /// <param name="iequipment_operating_hour_typeservice">The iequipment_operating_hour_typeservice to be used by the controller.</param>
        public EQUIPMENT_OPERATING_HOUR_TYPEController(IEQUIPMENT_OPERATING_HOUR_TYPEService iequipment_operating_hour_typeservice)
        {
            _eQUIPMENT_OPERATING_HOUR_TYPEService = iequipment_operating_hour_typeservice;
        }

        /// <summary>Adds a new equipment_operating_hour_type</summary>
        /// <param name="model">The equipment_operating_hour_type data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("EQUIPMENT_OPERATING_HOUR_TYPE", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] EQUIPMENT_OPERATING_HOUR_TYPE model)
        {
            var id = await _eQUIPMENT_OPERATING_HOUR_TYPEService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of equipment_operating_hour_types based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of equipment_operating_hour_types</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("EQUIPMENT_OPERATING_HOUR_TYPE", Entitlements.Read)]
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

            var result = await _eQUIPMENT_OPERATING_HOUR_TYPEService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific equipment_operating_hour_type by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hour_type</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The equipment_operating_hour_type data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("EQUIPMENT_OPERATING_HOUR_TYPE", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _eQUIPMENT_OPERATING_HOUR_TYPEService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific equipment_operating_hour_type by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hour_type</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("EQUIPMENT_OPERATING_HOUR_TYPE", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _eQUIPMENT_OPERATING_HOUR_TYPEService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific equipment_operating_hour_type by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hour_type</param>
        /// <param name="updatedEntity">The equipment_operating_hour_type data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("EQUIPMENT_OPERATING_HOUR_TYPE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] EQUIPMENT_OPERATING_HOUR_TYPE updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _eQUIPMENT_OPERATING_HOUR_TYPEService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific equipment_operating_hour_type by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hour_type</param>
        /// <param name="updatedEntity">The equipment_operating_hour_type data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("EQUIPMENT_OPERATING_HOUR_TYPE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<EQUIPMENT_OPERATING_HOUR_TYPE> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _eQUIPMENT_OPERATING_HOUR_TYPEService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}