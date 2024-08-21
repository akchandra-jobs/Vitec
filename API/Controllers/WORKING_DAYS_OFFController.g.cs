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
    /// Controller responsible for managing working_days_off related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting working_days_off information.
    /// </remarks>
    [Route("api/working_days_off")]
    [Authorize]
    public class WORKING_DAYS_OFFController : BaseApiController
    {
        private readonly IWORKING_DAYS_OFFService _wORKING_DAYS_OFFService;

        /// <summary>
        /// Initializes a new instance of the WORKING_DAYS_OFFController class with the specified context.
        /// </summary>
        /// <param name="iworking_days_offservice">The iworking_days_offservice to be used by the controller.</param>
        public WORKING_DAYS_OFFController(IWORKING_DAYS_OFFService iworking_days_offservice)
        {
            _wORKING_DAYS_OFFService = iworking_days_offservice;
        }

        /// <summary>Adds a new working_days_off</summary>
        /// <param name="model">The working_days_off data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("WORKING_DAYS_OFF", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] WORKING_DAYS_OFF model)
        {
            var id = await _wORKING_DAYS_OFFService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of working_days_offs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of working_days_offs</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("WORKING_DAYS_OFF", Entitlements.Read)]
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

            var result = await _wORKING_DAYS_OFFService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific working_days_off by its primary key</summary>
        /// <param name="id">The primary key of the working_days_off</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The working_days_off data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("WORKING_DAYS_OFF", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _wORKING_DAYS_OFFService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific working_days_off by its primary key</summary>
        /// <param name="id">The primary key of the working_days_off</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("WORKING_DAYS_OFF", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _wORKING_DAYS_OFFService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific working_days_off by its primary key</summary>
        /// <param name="id">The primary key of the working_days_off</param>
        /// <param name="updatedEntity">The working_days_off data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("WORKING_DAYS_OFF", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] WORKING_DAYS_OFF updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _wORKING_DAYS_OFFService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific working_days_off by its primary key</summary>
        /// <param name="id">The primary key of the working_days_off</param>
        /// <param name="updatedEntity">The working_days_off data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("WORKING_DAYS_OFF", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<WORKING_DAYS_OFF> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _wORKING_DAYS_OFFService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}