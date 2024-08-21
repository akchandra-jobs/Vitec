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
    /// Controller responsible for managing duty_log_event related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting duty_log_event information.
    /// </remarks>
    [Route("api/duty_log_event")]
    [Authorize]
    public class DUTY_LOG_EVENTController : BaseApiController
    {
        private readonly IDUTY_LOG_EVENTService _dUTY_LOG_EVENTService;

        /// <summary>
        /// Initializes a new instance of the DUTY_LOG_EVENTController class with the specified context.
        /// </summary>
        /// <param name="iduty_log_eventservice">The iduty_log_eventservice to be used by the controller.</param>
        public DUTY_LOG_EVENTController(IDUTY_LOG_EVENTService iduty_log_eventservice)
        {
            _dUTY_LOG_EVENTService = iduty_log_eventservice;
        }

        /// <summary>Adds a new duty_log_event</summary>
        /// <param name="model">The duty_log_event data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("DUTY_LOG_EVENT", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] DUTY_LOG_EVENT model)
        {
            var id = await _dUTY_LOG_EVENTService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of duty_log_events based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of duty_log_events</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DUTY_LOG_EVENT", Entitlements.Read)]
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

            var result = await _dUTY_LOG_EVENTService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific duty_log_event by its primary key</summary>
        /// <param name="id">The primary key of the duty_log_event</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The duty_log_event data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("DUTY_LOG_EVENT", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _dUTY_LOG_EVENTService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific duty_log_event by its primary key</summary>
        /// <param name="id">The primary key of the duty_log_event</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("DUTY_LOG_EVENT", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _dUTY_LOG_EVENTService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific duty_log_event by its primary key</summary>
        /// <param name="id">The primary key of the duty_log_event</param>
        /// <param name="updatedEntity">The duty_log_event data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DUTY_LOG_EVENT", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] DUTY_LOG_EVENT updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _dUTY_LOG_EVENTService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific duty_log_event by its primary key</summary>
        /// <param name="id">The primary key of the duty_log_event</param>
        /// <param name="updatedEntity">The duty_log_event data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DUTY_LOG_EVENT", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<DUTY_LOG_EVENT> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _dUTY_LOG_EVENTService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}