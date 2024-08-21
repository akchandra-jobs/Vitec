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
    /// Controller responsible for managing operational_message related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting operational_message information.
    /// </remarks>
    [Route("api/operational_message")]
    [Authorize]
    public class OPERATIONAL_MESSAGEController : BaseApiController
    {
        private readonly IOPERATIONAL_MESSAGEService _oPERATIONAL_MESSAGEService;

        /// <summary>
        /// Initializes a new instance of the OPERATIONAL_MESSAGEController class with the specified context.
        /// </summary>
        /// <param name="ioperational_messageservice">The ioperational_messageservice to be used by the controller.</param>
        public OPERATIONAL_MESSAGEController(IOPERATIONAL_MESSAGEService ioperational_messageservice)
        {
            _oPERATIONAL_MESSAGEService = ioperational_messageservice;
        }

        /// <summary>Adds a new operational_message</summary>
        /// <param name="model">The operational_message data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("OPERATIONAL_MESSAGE", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] OPERATIONAL_MESSAGE model)
        {
            var id = await _oPERATIONAL_MESSAGEService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of operational_messages based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of operational_messages</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("OPERATIONAL_MESSAGE", Entitlements.Read)]
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

            var result = await _oPERATIONAL_MESSAGEService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific operational_message by its primary key</summary>
        /// <param name="id">The primary key of the operational_message</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The operational_message data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("OPERATIONAL_MESSAGE", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _oPERATIONAL_MESSAGEService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific operational_message by its primary key</summary>
        /// <param name="id">The primary key of the operational_message</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("OPERATIONAL_MESSAGE", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _oPERATIONAL_MESSAGEService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific operational_message by its primary key</summary>
        /// <param name="id">The primary key of the operational_message</param>
        /// <param name="updatedEntity">The operational_message data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("OPERATIONAL_MESSAGE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] OPERATIONAL_MESSAGE updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _oPERATIONAL_MESSAGEService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific operational_message by its primary key</summary>
        /// <param name="id">The primary key of the operational_message</param>
        /// <param name="updatedEntity">The operational_message data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("OPERATIONAL_MESSAGE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<OPERATIONAL_MESSAGE> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _oPERATIONAL_MESSAGEService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}