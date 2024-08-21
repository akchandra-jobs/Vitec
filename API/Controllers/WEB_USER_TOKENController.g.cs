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
    /// Controller responsible for managing web_user_token related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting web_user_token information.
    /// </remarks>
    [Route("api/web_user_token")]
    [Authorize]
    public class WEB_USER_TOKENController : BaseApiController
    {
        private readonly IWEB_USER_TOKENService _wEB_USER_TOKENService;

        /// <summary>
        /// Initializes a new instance of the WEB_USER_TOKENController class with the specified context.
        /// </summary>
        /// <param name="iweb_user_tokenservice">The iweb_user_tokenservice to be used by the controller.</param>
        public WEB_USER_TOKENController(IWEB_USER_TOKENService iweb_user_tokenservice)
        {
            _wEB_USER_TOKENService = iweb_user_tokenservice;
        }

        /// <summary>Adds a new web_user_token</summary>
        /// <param name="model">The web_user_token data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("WEB_USER_TOKEN", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] WEB_USER_TOKEN model)
        {
            var id = await _wEB_USER_TOKENService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of web_user_tokens based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of web_user_tokens</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("WEB_USER_TOKEN", Entitlements.Read)]
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

            var result = await _wEB_USER_TOKENService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific web_user_token by its primary key</summary>
        /// <param name="id">The primary key of the web_user_token</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The web_user_token data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("WEB_USER_TOKEN", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _wEB_USER_TOKENService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific web_user_token by its primary key</summary>
        /// <param name="id">The primary key of the web_user_token</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("WEB_USER_TOKEN", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _wEB_USER_TOKENService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific web_user_token by its primary key</summary>
        /// <param name="id">The primary key of the web_user_token</param>
        /// <param name="updatedEntity">The web_user_token data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("WEB_USER_TOKEN", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] WEB_USER_TOKEN updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _wEB_USER_TOKENService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific web_user_token by its primary key</summary>
        /// <param name="id">The primary key of the web_user_token</param>
        /// <param name="updatedEntity">The web_user_token data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("WEB_USER_TOKEN", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<WEB_USER_TOKEN> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _wEB_USER_TOKENService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}