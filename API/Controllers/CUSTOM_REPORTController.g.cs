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
    /// Controller responsible for managing custom_report related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting custom_report information.
    /// </remarks>
    [Route("api/custom_report")]
    [Authorize]
    public class CUSTOM_REPORTController : BaseApiController
    {
        private readonly ICUSTOM_REPORTService _cUSTOM_REPORTService;

        /// <summary>
        /// Initializes a new instance of the CUSTOM_REPORTController class with the specified context.
        /// </summary>
        /// <param name="icustom_reportservice">The icustom_reportservice to be used by the controller.</param>
        public CUSTOM_REPORTController(ICUSTOM_REPORTService icustom_reportservice)
        {
            _cUSTOM_REPORTService = icustom_reportservice;
        }

        /// <summary>Adds a new custom_report</summary>
        /// <param name="model">The custom_report data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOM_REPORT", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] CUSTOM_REPORT model)
        {
            var id = await _cUSTOM_REPORTService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of custom_reports based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of custom_reports</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOM_REPORT", Entitlements.Read)]
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

            var result = await _cUSTOM_REPORTService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific custom_report by its primary key</summary>
        /// <param name="id">The primary key of the custom_report</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The custom_report data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOM_REPORT", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _cUSTOM_REPORTService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific custom_report by its primary key</summary>
        /// <param name="id">The primary key of the custom_report</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("CUSTOM_REPORT", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _cUSTOM_REPORTService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific custom_report by its primary key</summary>
        /// <param name="id">The primary key of the custom_report</param>
        /// <param name="updatedEntity">The custom_report data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOM_REPORT", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] CUSTOM_REPORT updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _cUSTOM_REPORTService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific custom_report by its primary key</summary>
        /// <param name="id">The primary key of the custom_report</param>
        /// <param name="updatedEntity">The custom_report data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOM_REPORT", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<CUSTOM_REPORT> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _cUSTOM_REPORTService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}