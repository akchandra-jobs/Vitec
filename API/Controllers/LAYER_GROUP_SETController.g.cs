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
    /// Controller responsible for managing layer_group_set related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting layer_group_set information.
    /// </remarks>
    [Route("api/layer_group_set")]
    [Authorize]
    public class LAYER_GROUP_SETController : BaseApiController
    {
        private readonly ILAYER_GROUP_SETService _lAYER_GROUP_SETService;

        /// <summary>
        /// Initializes a new instance of the LAYER_GROUP_SETController class with the specified context.
        /// </summary>
        /// <param name="ilayer_group_setservice">The ilayer_group_setservice to be used by the controller.</param>
        public LAYER_GROUP_SETController(ILAYER_GROUP_SETService ilayer_group_setservice)
        {
            _lAYER_GROUP_SETService = ilayer_group_setservice;
        }

        /// <summary>Adds a new layer_group_set</summary>
        /// <param name="model">The layer_group_set data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("LAYER_GROUP_SET", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] LAYER_GROUP_SET model)
        {
            var id = await _lAYER_GROUP_SETService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of layer_group_sets based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of layer_group_sets</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("LAYER_GROUP_SET", Entitlements.Read)]
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

            var result = await _lAYER_GROUP_SETService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific layer_group_set by its primary key</summary>
        /// <param name="id">The primary key of the layer_group_set</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The layer_group_set data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("LAYER_GROUP_SET", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _lAYER_GROUP_SETService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific layer_group_set by its primary key</summary>
        /// <param name="id">The primary key of the layer_group_set</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("LAYER_GROUP_SET", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _lAYER_GROUP_SETService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific layer_group_set by its primary key</summary>
        /// <param name="id">The primary key of the layer_group_set</param>
        /// <param name="updatedEntity">The layer_group_set data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("LAYER_GROUP_SET", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] LAYER_GROUP_SET updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _lAYER_GROUP_SETService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific layer_group_set by its primary key</summary>
        /// <param name="id">The primary key of the layer_group_set</param>
        /// <param name="updatedEntity">The layer_group_set data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("LAYER_GROUP_SET", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<LAYER_GROUP_SET> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _lAYER_GROUP_SETService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}