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
    /// Controller responsible for managing lease_follow_up related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting lease_follow_up information.
    /// </remarks>
    [Route("api/lease_follow_up")]
    [Authorize]
    public class LEASE_FOLLOW_UPController : BaseApiController
    {
        private readonly ILEASE_FOLLOW_UPService _lEASE_FOLLOW_UPService;

        /// <summary>
        /// Initializes a new instance of the LEASE_FOLLOW_UPController class with the specified context.
        /// </summary>
        /// <param name="ilease_follow_upservice">The ilease_follow_upservice to be used by the controller.</param>
        public LEASE_FOLLOW_UPController(ILEASE_FOLLOW_UPService ilease_follow_upservice)
        {
            _lEASE_FOLLOW_UPService = ilease_follow_upservice;
        }

        /// <summary>Adds a new lease_follow_up</summary>
        /// <param name="model">The lease_follow_up data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("LEASE_FOLLOW_UP", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] LEASE_FOLLOW_UP model)
        {
            var id = await _lEASE_FOLLOW_UPService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of lease_follow_ups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of lease_follow_ups</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("LEASE_FOLLOW_UP", Entitlements.Read)]
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

            var result = await _lEASE_FOLLOW_UPService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific lease_follow_up by its primary key</summary>
        /// <param name="id">The primary key of the lease_follow_up</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The lease_follow_up data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("LEASE_FOLLOW_UP", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _lEASE_FOLLOW_UPService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific lease_follow_up by its primary key</summary>
        /// <param name="id">The primary key of the lease_follow_up</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("LEASE_FOLLOW_UP", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _lEASE_FOLLOW_UPService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific lease_follow_up by its primary key</summary>
        /// <param name="id">The primary key of the lease_follow_up</param>
        /// <param name="updatedEntity">The lease_follow_up data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("LEASE_FOLLOW_UP", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] LEASE_FOLLOW_UP updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _lEASE_FOLLOW_UPService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific lease_follow_up by its primary key</summary>
        /// <param name="id">The primary key of the lease_follow_up</param>
        /// <param name="updatedEntity">The lease_follow_up data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("LEASE_FOLLOW_UP", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<LEASE_FOLLOW_UP> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _lEASE_FOLLOW_UPService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}