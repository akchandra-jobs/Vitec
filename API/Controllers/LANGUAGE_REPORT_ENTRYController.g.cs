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
    /// Controller responsible for managing language_report_entry related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting language_report_entry information.
    /// </remarks>
    [Route("api/language_report_entry")]
    [Authorize]
    public class LANGUAGE_REPORT_ENTRYController : BaseApiController
    {
        private readonly ILANGUAGE_REPORT_ENTRYService _lANGUAGE_REPORT_ENTRYService;

        /// <summary>
        /// Initializes a new instance of the LANGUAGE_REPORT_ENTRYController class with the specified context.
        /// </summary>
        /// <param name="ilanguage_report_entryservice">The ilanguage_report_entryservice to be used by the controller.</param>
        public LANGUAGE_REPORT_ENTRYController(ILANGUAGE_REPORT_ENTRYService ilanguage_report_entryservice)
        {
            _lANGUAGE_REPORT_ENTRYService = ilanguage_report_entryservice;
        }

        /// <summary>Adds a new language_report_entry</summary>
        /// <param name="model">The language_report_entry data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("LANGUAGE_REPORT_ENTRY", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] LANGUAGE_REPORT_ENTRY model)
        {
            var id = await _lANGUAGE_REPORT_ENTRYService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of language_report_entrys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of language_report_entrys</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("LANGUAGE_REPORT_ENTRY", Entitlements.Read)]
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

            var result = await _lANGUAGE_REPORT_ENTRYService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific language_report_entry by its primary key</summary>
        /// <param name="id">The primary key of the language_report_entry</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The language_report_entry data</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("LANGUAGE_REPORT_ENTRY", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] string id, string fields = null)
        {
            var result = await _lANGUAGE_REPORT_ENTRYService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific language_report_entry by its primary key</summary>
        /// <param name="id">The primary key of the language_report_entry</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id}")]
        [UserAuthorize("LANGUAGE_REPORT_ENTRY", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] string id)
        {
            var status = await _lANGUAGE_REPORT_ENTRYService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific language_report_entry by its primary key</summary>
        /// <param name="id">The primary key of the language_report_entry</param>
        /// <param name="updatedEntity">The language_report_entry data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("LANGUAGE_REPORT_ENTRY", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(string id, [FromBody] LANGUAGE_REPORT_ENTRY updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _lANGUAGE_REPORT_ENTRYService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific language_report_entry by its primary key</summary>
        /// <param name="id">The primary key of the language_report_entry</param>
        /// <param name="updatedEntity">The language_report_entry data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("LANGUAGE_REPORT_ENTRY", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(string id, [FromBody] JsonPatchDocument<LANGUAGE_REPORT_ENTRY> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _lANGUAGE_REPORT_ENTRYService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}