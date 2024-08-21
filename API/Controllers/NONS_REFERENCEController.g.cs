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
    /// Controller responsible for managing nons_reference related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting nons_reference information.
    /// </remarks>
    [Route("api/nons_reference")]
    [Authorize]
    public class NONS_REFERENCEController : BaseApiController
    {
        private readonly INONS_REFERENCEService _nONS_REFERENCEService;

        /// <summary>
        /// Initializes a new instance of the NONS_REFERENCEController class with the specified context.
        /// </summary>
        /// <param name="inons_referenceservice">The inons_referenceservice to be used by the controller.</param>
        public NONS_REFERENCEController(INONS_REFERENCEService inons_referenceservice)
        {
            _nONS_REFERENCEService = inons_referenceservice;
        }

        /// <summary>Adds a new nons_reference</summary>
        /// <param name="model">The nons_reference data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("NONS_REFERENCE", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] NONS_REFERENCE model)
        {
            var id = await _nONS_REFERENCEService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of nons_references based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of nons_references</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("NONS_REFERENCE", Entitlements.Read)]
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

            var result = await _nONS_REFERENCEService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific nons_reference by its primary key</summary>
        /// <param name="id">The primary key of the nons_reference</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The nons_reference data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("NONS_REFERENCE", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _nONS_REFERENCEService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific nons_reference by its primary key</summary>
        /// <param name="id">The primary key of the nons_reference</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("NONS_REFERENCE", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _nONS_REFERENCEService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific nons_reference by its primary key</summary>
        /// <param name="id">The primary key of the nons_reference</param>
        /// <param name="updatedEntity">The nons_reference data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("NONS_REFERENCE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] NONS_REFERENCE updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _nONS_REFERENCEService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific nons_reference by its primary key</summary>
        /// <param name="id">The primary key of the nons_reference</param>
        /// <param name="updatedEntity">The nons_reference data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("NONS_REFERENCE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<NONS_REFERENCE> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _nONS_REFERENCEService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}