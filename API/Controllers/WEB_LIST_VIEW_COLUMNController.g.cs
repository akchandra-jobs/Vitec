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
    /// Controller responsible for managing web_list_view_column related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting web_list_view_column information.
    /// </remarks>
    [Route("api/web_list_view_column")]
    [Authorize]
    public class WEB_LIST_VIEW_COLUMNController : BaseApiController
    {
        private readonly IWEB_LIST_VIEW_COLUMNService _wEB_LIST_VIEW_COLUMNService;

        /// <summary>
        /// Initializes a new instance of the WEB_LIST_VIEW_COLUMNController class with the specified context.
        /// </summary>
        /// <param name="iweb_list_view_columnservice">The iweb_list_view_columnservice to be used by the controller.</param>
        public WEB_LIST_VIEW_COLUMNController(IWEB_LIST_VIEW_COLUMNService iweb_list_view_columnservice)
        {
            _wEB_LIST_VIEW_COLUMNService = iweb_list_view_columnservice;
        }

        /// <summary>Adds a new web_list_view_column</summary>
        /// <param name="model">The web_list_view_column data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("WEB_LIST_VIEW_COLUMN", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] WEB_LIST_VIEW_COLUMN model)
        {
            var id = await _wEB_LIST_VIEW_COLUMNService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of web_list_view_columns based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of web_list_view_columns</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("WEB_LIST_VIEW_COLUMN", Entitlements.Read)]
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

            var result = await _wEB_LIST_VIEW_COLUMNService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific web_list_view_column by its primary key</summary>
        /// <param name="id">The primary key of the web_list_view_column</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The web_list_view_column data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("WEB_LIST_VIEW_COLUMN", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _wEB_LIST_VIEW_COLUMNService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific web_list_view_column by its primary key</summary>
        /// <param name="id">The primary key of the web_list_view_column</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("WEB_LIST_VIEW_COLUMN", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _wEB_LIST_VIEW_COLUMNService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific web_list_view_column by its primary key</summary>
        /// <param name="id">The primary key of the web_list_view_column</param>
        /// <param name="updatedEntity">The web_list_view_column data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("WEB_LIST_VIEW_COLUMN", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] WEB_LIST_VIEW_COLUMN updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _wEB_LIST_VIEW_COLUMNService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific web_list_view_column by its primary key</summary>
        /// <param name="id">The primary key of the web_list_view_column</param>
        /// <param name="updatedEntity">The web_list_view_column data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("WEB_LIST_VIEW_COLUMN", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<WEB_LIST_VIEW_COLUMN> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _wEB_LIST_VIEW_COLUMNService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}