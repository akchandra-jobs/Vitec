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
    /// Controller responsible for managing api_request_log related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting api_request_log information.
    /// </remarks>
    [Route("api/api_request_log")]
    [Authorize]
    public class API_REQUEST_LOGController : BaseApiController
    {
        private readonly IAPI_REQUEST_LOGService _aPI_REQUEST_LOGService;

        /// <summary>
        /// Initializes a new instance of the API_REQUEST_LOGController class with the specified context.
        /// </summary>
        /// <param name="iapi_request_logservice">The iapi_request_logservice to be used by the controller.</param>
        public API_REQUEST_LOGController(IAPI_REQUEST_LOGService iapi_request_logservice)
        {
            _aPI_REQUEST_LOGService = iapi_request_logservice;
        }

        /// <summary>Adds a new api_request_log</summary>
        /// <param name="model">The api_request_log data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("API_REQUEST_LOG", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] API_REQUEST_LOG model)
        {
            var id = await _aPI_REQUEST_LOGService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of api_request_logs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of api_request_logs</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("API_REQUEST_LOG", Entitlements.Read)]
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

            var result = await _aPI_REQUEST_LOGService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific api_request_log by its primary key</summary>
        /// <param name="id">The primary key of the api_request_log</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The api_request_log data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("API_REQUEST_LOG", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _aPI_REQUEST_LOGService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific api_request_log by its primary key</summary>
        /// <param name="id">The primary key of the api_request_log</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("API_REQUEST_LOG", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _aPI_REQUEST_LOGService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific api_request_log by its primary key</summary>
        /// <param name="id">The primary key of the api_request_log</param>
        /// <param name="updatedEntity">The api_request_log data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("API_REQUEST_LOG", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] API_REQUEST_LOG updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _aPI_REQUEST_LOGService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific api_request_log by its primary key</summary>
        /// <param name="id">The primary key of the api_request_log</param>
        /// <param name="updatedEntity">The api_request_log data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("API_REQUEST_LOG", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<API_REQUEST_LOG> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _aPI_REQUEST_LOGService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}