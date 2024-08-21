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
    /// Controller responsible for managing two_factor_token related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting two_factor_token information.
    /// </remarks>
    [Route("api/two_factor_token")]
    [Authorize]
    public class TWO_FACTOR_TOKENController : BaseApiController
    {
        private readonly ITWO_FACTOR_TOKENService _tWO_FACTOR_TOKENService;

        /// <summary>
        /// Initializes a new instance of the TWO_FACTOR_TOKENController class with the specified context.
        /// </summary>
        /// <param name="itwo_factor_tokenservice">The itwo_factor_tokenservice to be used by the controller.</param>
        public TWO_FACTOR_TOKENController(ITWO_FACTOR_TOKENService itwo_factor_tokenservice)
        {
            _tWO_FACTOR_TOKENService = itwo_factor_tokenservice;
        }

        /// <summary>Adds a new two_factor_token</summary>
        /// <param name="model">The two_factor_token data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("TWO_FACTOR_TOKEN", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] TWO_FACTOR_TOKEN model)
        {
            var id = await _tWO_FACTOR_TOKENService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of two_factor_tokens based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of two_factor_tokens</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("TWO_FACTOR_TOKEN", Entitlements.Read)]
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

            var result = await _tWO_FACTOR_TOKENService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific two_factor_token by its primary key</summary>
        /// <param name="id">The primary key of the two_factor_token</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The two_factor_token data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("TWO_FACTOR_TOKEN", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _tWO_FACTOR_TOKENService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific two_factor_token by its primary key</summary>
        /// <param name="id">The primary key of the two_factor_token</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("TWO_FACTOR_TOKEN", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _tWO_FACTOR_TOKENService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific two_factor_token by its primary key</summary>
        /// <param name="id">The primary key of the two_factor_token</param>
        /// <param name="updatedEntity">The two_factor_token data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("TWO_FACTOR_TOKEN", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] TWO_FACTOR_TOKEN updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _tWO_FACTOR_TOKENService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific two_factor_token by its primary key</summary>
        /// <param name="id">The primary key of the two_factor_token</param>
        /// <param name="updatedEntity">The two_factor_token data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("TWO_FACTOR_TOKEN", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<TWO_FACTOR_TOKEN> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _tWO_FACTOR_TOKENService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}