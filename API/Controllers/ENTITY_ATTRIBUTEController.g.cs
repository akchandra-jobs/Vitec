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
    /// Controller responsible for managing entity_attribute related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting entity_attribute information.
    /// </remarks>
    [Route("api/entity_attribute")]
    [Authorize]
    public class ENTITY_ATTRIBUTEController : BaseApiController
    {
        private readonly IENTITY_ATTRIBUTEService _eNTITY_ATTRIBUTEService;

        /// <summary>
        /// Initializes a new instance of the ENTITY_ATTRIBUTEController class with the specified context.
        /// </summary>
        /// <param name="ientity_attributeservice">The ientity_attributeservice to be used by the controller.</param>
        public ENTITY_ATTRIBUTEController(IENTITY_ATTRIBUTEService ientity_attributeservice)
        {
            _eNTITY_ATTRIBUTEService = ientity_attributeservice;
        }

        /// <summary>Adds a new entity_attribute</summary>
        /// <param name="model">The entity_attribute data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_ATTRIBUTE", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] ENTITY_ATTRIBUTE model)
        {
            var id = await _eNTITY_ATTRIBUTEService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of entity_attributes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of entity_attributes</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_ATTRIBUTE", Entitlements.Read)]
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

            var result = await _eNTITY_ATTRIBUTEService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific entity_attribute by its primary key</summary>
        /// <param name="id">The primary key of the entity_attribute</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The entity_attribute data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_ATTRIBUTE", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _eNTITY_ATTRIBUTEService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific entity_attribute by its primary key</summary>
        /// <param name="id">The primary key of the entity_attribute</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("ENTITY_ATTRIBUTE", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _eNTITY_ATTRIBUTEService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific entity_attribute by its primary key</summary>
        /// <param name="id">The primary key of the entity_attribute</param>
        /// <param name="updatedEntity">The entity_attribute data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_ATTRIBUTE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] ENTITY_ATTRIBUTE updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _eNTITY_ATTRIBUTEService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific entity_attribute by its primary key</summary>
        /// <param name="id">The primary key of the entity_attribute</param>
        /// <param name="updatedEntity">The entity_attribute data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENTITY_ATTRIBUTE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<ENTITY_ATTRIBUTE> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _eNTITY_ATTRIBUTEService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}