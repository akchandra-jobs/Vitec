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
    /// Controller responsible for managing daily_update_log related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting daily_update_log information.
    /// </remarks>
    [Route("api/daily_update_log")]
    [Authorize]
    public class DAILY_UPDATE_LOGController : BaseApiController
    {
        private readonly IDAILY_UPDATE_LOGService _dAILY_UPDATE_LOGService;

        /// <summary>
        /// Initializes a new instance of the DAILY_UPDATE_LOGController class with the specified context.
        /// </summary>
        /// <param name="idaily_update_logservice">The idaily_update_logservice to be used by the controller.</param>
        public DAILY_UPDATE_LOGController(IDAILY_UPDATE_LOGService idaily_update_logservice)
        {
            _dAILY_UPDATE_LOGService = idaily_update_logservice;
        }

        /// <summary>Adds a new daily_update_log</summary>
        /// <param name="model">The daily_update_log data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("DAILY_UPDATE_LOG", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] DAILY_UPDATE_LOG model)
        {
            var id = await _dAILY_UPDATE_LOGService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of daily_update_logs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of daily_update_logs</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DAILY_UPDATE_LOG", Entitlements.Read)]
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

            var result = await _dAILY_UPDATE_LOGService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific daily_update_log by its primary key</summary>
        /// <param name="id">The primary key of the daily_update_log</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The daily_update_log data</returns>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("DAILY_UPDATE_LOG", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] int id, string fields = null)
        {
            var result = await _dAILY_UPDATE_LOGService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific daily_update_log by its primary key</summary>
        /// <param name="id">The primary key of the daily_update_log</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:int}")]
        [UserAuthorize("DAILY_UPDATE_LOG", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var status = await _dAILY_UPDATE_LOGService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific daily_update_log by its primary key</summary>
        /// <param name="id">The primary key of the daily_update_log</param>
        /// <param name="updatedEntity">The daily_update_log data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DAILY_UPDATE_LOG", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(int id, [FromBody] DAILY_UPDATE_LOG updatedEntity)
        {
            if (id != updatedEntity.ID)
            {
                return BadRequest("Mismatched ID");
            }

            var status = await _dAILY_UPDATE_LOGService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific daily_update_log by its primary key</summary>
        /// <param name="id">The primary key of the daily_update_log</param>
        /// <param name="updatedEntity">The daily_update_log data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DAILY_UPDATE_LOG", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(int id, [FromBody] JsonPatchDocument<DAILY_UPDATE_LOG> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _dAILY_UPDATE_LOGService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}