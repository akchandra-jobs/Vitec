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
    /// Controller responsible for managing energy_unit related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting energy_unit information.
    /// </remarks>
    [Route("api/energy_unit")]
    [Authorize]
    public class ENERGY_UNITController : BaseApiController
    {
        private readonly IENERGY_UNITService _eNERGY_UNITService;

        /// <summary>
        /// Initializes a new instance of the ENERGY_UNITController class with the specified context.
        /// </summary>
        /// <param name="ienergy_unitservice">The ienergy_unitservice to be used by the controller.</param>
        public ENERGY_UNITController(IENERGY_UNITService ienergy_unitservice)
        {
            _eNERGY_UNITService = ienergy_unitservice;
        }

        /// <summary>Adds a new energy_unit</summary>
        /// <param name="model">The energy_unit data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ENERGY_UNIT", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] ENERGY_UNIT model)
        {
            var id = await _eNERGY_UNITService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of energy_units based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of energy_units</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENERGY_UNIT", Entitlements.Read)]
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

            var result = await _eNERGY_UNITService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific energy_unit by its primary key</summary>
        /// <param name="id">The primary key of the energy_unit</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The energy_unit data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ENERGY_UNIT", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _eNERGY_UNITService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific energy_unit by its primary key</summary>
        /// <param name="id">The primary key of the energy_unit</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("ENERGY_UNIT", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _eNERGY_UNITService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific energy_unit by its primary key</summary>
        /// <param name="id">The primary key of the energy_unit</param>
        /// <param name="updatedEntity">The energy_unit data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENERGY_UNIT", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] ENERGY_UNIT updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _eNERGY_UNITService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific energy_unit by its primary key</summary>
        /// <param name="id">The primary key of the energy_unit</param>
        /// <param name="updatedEntity">The energy_unit data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ENERGY_UNIT", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<ENERGY_UNIT> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _eNERGY_UNITService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}