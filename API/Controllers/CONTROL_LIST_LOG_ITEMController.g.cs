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
    /// Controller responsible for managing control_list_log_item related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting control_list_log_item information.
    /// </remarks>
    [Route("api/control_list_log_item")]
    [Authorize]
    public class CONTROL_LIST_LOG_ITEMController : BaseApiController
    {
        private readonly ICONTROL_LIST_LOG_ITEMService _cONTROL_LIST_LOG_ITEMService;

        /// <summary>
        /// Initializes a new instance of the CONTROL_LIST_LOG_ITEMController class with the specified context.
        /// </summary>
        /// <param name="icontrol_list_log_itemservice">The icontrol_list_log_itemservice to be used by the controller.</param>
        public CONTROL_LIST_LOG_ITEMController(ICONTROL_LIST_LOG_ITEMService icontrol_list_log_itemservice)
        {
            _cONTROL_LIST_LOG_ITEMService = icontrol_list_log_itemservice;
        }

        /// <summary>Adds a new control_list_log_item</summary>
        /// <param name="model">The control_list_log_item data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CONTROL_LIST_LOG_ITEM", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] CONTROL_LIST_LOG_ITEM model)
        {
            var id = await _cONTROL_LIST_LOG_ITEMService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of control_list_log_items based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of control_list_log_items</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CONTROL_LIST_LOG_ITEM", Entitlements.Read)]
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

            var result = await _cONTROL_LIST_LOG_ITEMService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific control_list_log_item by its primary key</summary>
        /// <param name="id">The primary key of the control_list_log_item</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The control_list_log_item data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CONTROL_LIST_LOG_ITEM", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _cONTROL_LIST_LOG_ITEMService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific control_list_log_item by its primary key</summary>
        /// <param name="id">The primary key of the control_list_log_item</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("CONTROL_LIST_LOG_ITEM", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _cONTROL_LIST_LOG_ITEMService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific control_list_log_item by its primary key</summary>
        /// <param name="id">The primary key of the control_list_log_item</param>
        /// <param name="updatedEntity">The control_list_log_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CONTROL_LIST_LOG_ITEM", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] CONTROL_LIST_LOG_ITEM updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _cONTROL_LIST_LOG_ITEMService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific control_list_log_item by its primary key</summary>
        /// <param name="id">The primary key of the control_list_log_item</param>
        /// <param name="updatedEntity">The control_list_log_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CONTROL_LIST_LOG_ITEM", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<CONTROL_LIST_LOG_ITEM> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _cONTROL_LIST_LOG_ITEMService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}