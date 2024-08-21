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
    /// Controller responsible for managing standard_text related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting standard_text information.
    /// </remarks>
    [Route("api/standard_text")]
    [Authorize]
    public class STANDARD_TEXTController : BaseApiController
    {
        private readonly ISTANDARD_TEXTService _sTANDARD_TEXTService;

        /// <summary>
        /// Initializes a new instance of the STANDARD_TEXTController class with the specified context.
        /// </summary>
        /// <param name="istandard_textservice">The istandard_textservice to be used by the controller.</param>
        public STANDARD_TEXTController(ISTANDARD_TEXTService istandard_textservice)
        {
            _sTANDARD_TEXTService = istandard_textservice;
        }

        /// <summary>Adds a new standard_text</summary>
        /// <param name="model">The standard_text data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("STANDARD_TEXT", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] STANDARD_TEXT model)
        {
            var id = await _sTANDARD_TEXTService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of standard_texts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of standard_texts</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("STANDARD_TEXT", Entitlements.Read)]
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

            var result = await _sTANDARD_TEXTService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific standard_text by its primary key</summary>
        /// <param name="id">The primary key of the standard_text</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The standard_text data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("STANDARD_TEXT", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _sTANDARD_TEXTService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific standard_text by its primary key</summary>
        /// <param name="id">The primary key of the standard_text</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("STANDARD_TEXT", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _sTANDARD_TEXTService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific standard_text by its primary key</summary>
        /// <param name="id">The primary key of the standard_text</param>
        /// <param name="updatedEntity">The standard_text data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("STANDARD_TEXT", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] STANDARD_TEXT updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _sTANDARD_TEXTService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific standard_text by its primary key</summary>
        /// <param name="id">The primary key of the standard_text</param>
        /// <param name="updatedEntity">The standard_text data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("STANDARD_TEXT", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<STANDARD_TEXT> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _sTANDARD_TEXTService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}