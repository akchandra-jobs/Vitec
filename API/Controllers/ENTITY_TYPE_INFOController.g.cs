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
    /// Controller responsible for managing entity_type_info related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting entity_type_info information.
    /// </remarks>
    [Route("api/entity_type_info")]
    [Authorize]
    public class ENTITY_TYPE_INFOController : BaseApiController
    {
        private readonly IENTITY_TYPE_INFOService _eNTITY_TYPE_INFOService;

        /// <summary>
        /// Initializes a new instance of the ENTITY_TYPE_INFOController class with the specified context.
        /// </summary>
        /// <param name="ientity_type_infoservice">The ientity_type_infoservice to be used by the controller.</param>
        public ENTITY_TYPE_INFOController(IENTITY_TYPE_INFOService ientity_type_infoservice)
        {
            _eNTITY_TYPE_INFOService = ientity_type_infoservice;
        }

        /// <summary>Adds a new entity_type_info</summary>
        /// <param name="model">The entity_type_info data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_TYPE_INFO", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] ENTITY_TYPE_INFO model)
        {
            var id = await _eNTITY_TYPE_INFOService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of entity_type_infos based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of entity_type_infos</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_TYPE_INFO", Entitlements.Read)]
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

            var result = await _eNTITY_TYPE_INFOService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific entity_type_info by its primary key</summary>
        /// <param name="id">The primary key of the entity_type_info</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The entity_type_info data</returns>
        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_TYPE_INFO", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Int64 id, string fields = null)
        {
            var result = await _eNTITY_TYPE_INFOService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific entity_type_info by its primary key</summary>
        /// <param name="id">The primary key of the entity_type_info</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:long}")]
        [UserAuthorize("ENTITY_TYPE_INFO", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Int64 id)
        {
            var status = await _eNTITY_TYPE_INFOService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific entity_type_info by its primary key</summary>
        /// <param name="id">The primary key of the entity_type_info</param>
        /// <param name="updatedEntity">The entity_type_info data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_TYPE_INFO", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Int64 id, [FromBody] ENTITY_TYPE_INFO updatedEntity)
        {
            if (id != updatedEntity.MODULE)
            {
                return BadRequest("Mismatched MODULE");
            }

            var status = await _eNTITY_TYPE_INFOService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific entity_type_info by its primary key</summary>
        /// <param name="id">The primary key of the entity_type_info</param>
        /// <param name="updatedEntity">The entity_type_info data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_TYPE_INFO", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Int64 id, [FromBody] JsonPatchDocument<ENTITY_TYPE_INFO> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _eNTITY_TYPE_INFOService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}