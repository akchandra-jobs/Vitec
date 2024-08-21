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
    /// Controller responsible for managing entity_mail_list related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting entity_mail_list information.
    /// </remarks>
    [Route("api/entity_mail_list")]
    [Authorize]
    public class ENTITY_MAIL_LISTController : BaseApiController
    {
        private readonly IENTITY_MAIL_LISTService _eNTITY_MAIL_LISTService;

        /// <summary>
        /// Initializes a new instance of the ENTITY_MAIL_LISTController class with the specified context.
        /// </summary>
        /// <param name="ientity_mail_listservice">The ientity_mail_listservice to be used by the controller.</param>
        public ENTITY_MAIL_LISTController(IENTITY_MAIL_LISTService ientity_mail_listservice)
        {
            _eNTITY_MAIL_LISTService = ientity_mail_listservice;
        }

        /// <summary>Adds a new entity_mail_list</summary>
        /// <param name="model">The entity_mail_list data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_MAIL_LIST", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] ENTITY_MAIL_LIST model)
        {
            var id = await _eNTITY_MAIL_LISTService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of entity_mail_lists based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of entity_mail_lists</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_MAIL_LIST", Entitlements.Read)]
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

            var result = await _eNTITY_MAIL_LISTService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific entity_mail_list by its primary key</summary>
        /// <param name="id">The primary key of the entity_mail_list</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The entity_mail_list data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_MAIL_LIST", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _eNTITY_MAIL_LISTService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific entity_mail_list by its primary key</summary>
        /// <param name="id">The primary key of the entity_mail_list</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("ENTITY_MAIL_LIST", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _eNTITY_MAIL_LISTService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific entity_mail_list by its primary key</summary>
        /// <param name="id">The primary key of the entity_mail_list</param>
        /// <param name="updatedEntity">The entity_mail_list data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_MAIL_LIST", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] ENTITY_MAIL_LIST updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _eNTITY_MAIL_LISTService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific entity_mail_list by its primary key</summary>
        /// <param name="id">The primary key of the entity_mail_list</param>
        /// <param name="updatedEntity">The entity_mail_list data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_MAIL_LIST", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<ENTITY_MAIL_LIST> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _eNTITY_MAIL_LISTService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}