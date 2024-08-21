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
    /// Controller responsible for managing aggregatedcounter related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting aggregatedcounter information.
    /// </remarks>
    [Route("api/aggregatedcounter")]
    [Authorize]
    public class AggregatedCounterController : BaseApiController
    {
        private readonly IAggregatedCounterService _aggregatedCounterService;

        /// <summary>
        /// Initializes a new instance of the AggregatedCounterController class with the specified context.
        /// </summary>
        /// <param name="iaggregatedcounterservice">The iaggregatedcounterservice to be used by the controller.</param>
        public AggregatedCounterController(IAggregatedCounterService iaggregatedcounterservice)
        {
            _aggregatedCounterService = iaggregatedcounterservice;
        }

        /// <summary>Adds a new aggregatedcounter</summary>
        /// <param name="model">The aggregatedcounter data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("AggregatedCounter", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] AggregatedCounter model)
        {
            var id = await _aggregatedCounterService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of aggregatedcounters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of aggregatedcounters</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("AggregatedCounter", Entitlements.Read)]
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

            var result = await _aggregatedCounterService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific aggregatedcounter by its primary key</summary>
        /// <param name="id">The primary key of the aggregatedcounter</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The aggregatedcounter data</returns>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("AggregatedCounter", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] int id, string fields = null)
        {
            var result = await _aggregatedCounterService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific aggregatedcounter by its primary key</summary>
        /// <param name="id">The primary key of the aggregatedcounter</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:int}")]
        [UserAuthorize("AggregatedCounter", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var status = await _aggregatedCounterService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific aggregatedcounter by its primary key</summary>
        /// <param name="id">The primary key of the aggregatedcounter</param>
        /// <param name="updatedEntity">The aggregatedcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("AggregatedCounter", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(int id, [FromBody] AggregatedCounter updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            var status = await _aggregatedCounterService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific aggregatedcounter by its primary key</summary>
        /// <param name="id">The primary key of the aggregatedcounter</param>
        /// <param name="updatedEntity">The aggregatedcounter data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("AggregatedCounter", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(int id, [FromBody] JsonPatchDocument<AggregatedCounter> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _aggregatedCounterService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}