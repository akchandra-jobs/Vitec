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
    /// Controller responsible for managing follow_up related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting follow_up information.
    /// </remarks>
    [Route("api/follow_up")]
    [Authorize]
    public class FOLLOW_UPController : BaseApiController
    {
        private readonly IFOLLOW_UPService _fOLLOW_UPService;

        /// <summary>
        /// Initializes a new instance of the FOLLOW_UPController class with the specified context.
        /// </summary>
        /// <param name="ifollow_upservice">The ifollow_upservice to be used by the controller.</param>
        public FOLLOW_UPController(IFOLLOW_UPService ifollow_upservice)
        {
            _fOLLOW_UPService = ifollow_upservice;
        }

        /// <summary>Adds a new follow_up</summary>
        /// <param name="model">The follow_up data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("FOLLOW_UP", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] FOLLOW_UP model)
        {
            var id = await _fOLLOW_UPService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of follow_ups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of follow_ups</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("FOLLOW_UP", Entitlements.Read)]
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

            var result = await _fOLLOW_UPService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific follow_up by its primary key</summary>
        /// <param name="id">The primary key of the follow_up</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The follow_up data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("FOLLOW_UP", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _fOLLOW_UPService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific follow_up by its primary key</summary>
        /// <param name="id">The primary key of the follow_up</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("FOLLOW_UP", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _fOLLOW_UPService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific follow_up by its primary key</summary>
        /// <param name="id">The primary key of the follow_up</param>
        /// <param name="updatedEntity">The follow_up data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("FOLLOW_UP", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] FOLLOW_UP updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _fOLLOW_UPService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific follow_up by its primary key</summary>
        /// <param name="id">The primary key of the follow_up</param>
        /// <param name="updatedEntity">The follow_up data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("FOLLOW_UP", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<FOLLOW_UP> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _fOLLOW_UPService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}