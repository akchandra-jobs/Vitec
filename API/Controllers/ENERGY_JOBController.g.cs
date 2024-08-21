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
    /// Controller responsible for managing energy_job related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting energy_job information.
    /// </remarks>
    [Route("api/energy_job")]
    [Authorize]
    public class ENERGY_JOBController : BaseApiController
    {
        private readonly IENERGY_JOBService _eNERGY_JOBService;

        /// <summary>
        /// Initializes a new instance of the ENERGY_JOBController class with the specified context.
        /// </summary>
        /// <param name="ienergy_jobservice">The ienergy_jobservice to be used by the controller.</param>
        public ENERGY_JOBController(IENERGY_JOBService ienergy_jobservice)
        {
            _eNERGY_JOBService = ienergy_jobservice;
        }

        /// <summary>Adds a new energy_job</summary>
        /// <param name="model">The energy_job data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ENERGY_JOB", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] ENERGY_JOB model)
        {
            var id = await _eNERGY_JOBService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of energy_jobs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of energy_jobs</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENERGY_JOB", Entitlements.Read)]
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

            var result = await _eNERGY_JOBService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific energy_job by its primary key</summary>
        /// <param name="id">The primary key of the energy_job</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The energy_job data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ENERGY_JOB", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _eNERGY_JOBService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific energy_job by its primary key</summary>
        /// <param name="id">The primary key of the energy_job</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("ENERGY_JOB", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _eNERGY_JOBService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific energy_job by its primary key</summary>
        /// <param name="id">The primary key of the energy_job</param>
        /// <param name="updatedEntity">The energy_job data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENERGY_JOB", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] ENERGY_JOB updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _eNERGY_JOBService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific energy_job by its primary key</summary>
        /// <param name="id">The primary key of the energy_job</param>
        /// <param name="updatedEntity">The energy_job data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENERGY_JOB", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<ENERGY_JOB> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _eNERGY_JOBService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}