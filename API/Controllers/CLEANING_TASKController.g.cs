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
    /// Controller responsible for managing cleaning_task related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting cleaning_task information.
    /// </remarks>
    [Route("api/cleaning_task")]
    [Authorize]
    public class CLEANING_TASKController : BaseApiController
    {
        private readonly ICLEANING_TASKService _cLEANING_TASKService;

        /// <summary>
        /// Initializes a new instance of the CLEANING_TASKController class with the specified context.
        /// </summary>
        /// <param name="icleaning_taskservice">The icleaning_taskservice to be used by the controller.</param>
        public CLEANING_TASKController(ICLEANING_TASKService icleaning_taskservice)
        {
            _cLEANING_TASKService = icleaning_taskservice;
        }

        /// <summary>Adds a new cleaning_task</summary>
        /// <param name="model">The cleaning_task data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CLEANING_TASK", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] CLEANING_TASK model)
        {
            var id = await _cLEANING_TASKService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of cleaning_tasks based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cleaning_tasks</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CLEANING_TASK", Entitlements.Read)]
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

            var result = await _cLEANING_TASKService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific cleaning_task by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_task</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The cleaning_task data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CLEANING_TASK", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _cLEANING_TASKService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific cleaning_task by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_task</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("CLEANING_TASK", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _cLEANING_TASKService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific cleaning_task by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_task</param>
        /// <param name="updatedEntity">The cleaning_task data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CLEANING_TASK", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] CLEANING_TASK updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _cLEANING_TASKService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific cleaning_task by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_task</param>
        /// <param name="updatedEntity">The cleaning_task data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CLEANING_TASK", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<CLEANING_TASK> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _cLEANING_TASKService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}