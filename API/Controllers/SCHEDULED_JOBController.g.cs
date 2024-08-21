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
    /// Controller responsible for managing scheduled_job related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting scheduled_job information.
    /// </remarks>
    [Route("api/scheduled_job")]
    [Authorize]
    public class SCHEDULED_JOBController : BaseApiController
    {
        private readonly ISCHEDULED_JOBService _sCHEDULED_JOBService;

        /// <summary>
        /// Initializes a new instance of the SCHEDULED_JOBController class with the specified context.
        /// </summary>
        /// <param name="ischeduled_jobservice">The ischeduled_jobservice to be used by the controller.</param>
        public SCHEDULED_JOBController(ISCHEDULED_JOBService ischeduled_jobservice)
        {
            _sCHEDULED_JOBService = ischeduled_jobservice;
        }

        /// <summary>Adds a new scheduled_job</summary>
        /// <param name="model">The scheduled_job data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("SCHEDULED_JOB", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] SCHEDULED_JOB model)
        {
            var id = await _sCHEDULED_JOBService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of scheduled_jobs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of scheduled_jobs</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("SCHEDULED_JOB", Entitlements.Read)]
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

            var result = await _sCHEDULED_JOBService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific scheduled_job by its primary key</summary>
        /// <param name="id">The primary key of the scheduled_job</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The scheduled_job data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("SCHEDULED_JOB", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _sCHEDULED_JOBService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific scheduled_job by its primary key</summary>
        /// <param name="id">The primary key of the scheduled_job</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("SCHEDULED_JOB", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _sCHEDULED_JOBService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific scheduled_job by its primary key</summary>
        /// <param name="id">The primary key of the scheduled_job</param>
        /// <param name="updatedEntity">The scheduled_job data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("SCHEDULED_JOB", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] SCHEDULED_JOB updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _sCHEDULED_JOBService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific scheduled_job by its primary key</summary>
        /// <param name="id">The primary key of the scheduled_job</param>
        /// <param name="updatedEntity">The scheduled_job data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("SCHEDULED_JOB", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<SCHEDULED_JOB> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _sCHEDULED_JOBService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}