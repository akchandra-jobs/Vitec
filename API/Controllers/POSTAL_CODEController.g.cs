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
    /// Controller responsible for managing postal_code related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting postal_code information.
    /// </remarks>
    [Route("api/postal_code")]
    [Authorize]
    public class POSTAL_CODEController : BaseApiController
    {
        private readonly IPOSTAL_CODEService _pOSTAL_CODEService;

        /// <summary>
        /// Initializes a new instance of the POSTAL_CODEController class with the specified context.
        /// </summary>
        /// <param name="ipostal_codeservice">The ipostal_codeservice to be used by the controller.</param>
        public POSTAL_CODEController(IPOSTAL_CODEService ipostal_codeservice)
        {
            _pOSTAL_CODEService = ipostal_codeservice;
        }

        /// <summary>Adds a new postal_code</summary>
        /// <param name="model">The postal_code data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("POSTAL_CODE", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] POSTAL_CODE model)
        {
            var id = await _pOSTAL_CODEService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of postal_codes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of postal_codes</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("POSTAL_CODE", Entitlements.Read)]
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

            var result = await _pOSTAL_CODEService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific postal_code by its primary key</summary>
        /// <param name="id">The primary key of the postal_code</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The postal_code data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("POSTAL_CODE", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _pOSTAL_CODEService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific postal_code by its primary key</summary>
        /// <param name="id">The primary key of the postal_code</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("POSTAL_CODE", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _pOSTAL_CODEService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific postal_code by its primary key</summary>
        /// <param name="id">The primary key of the postal_code</param>
        /// <param name="updatedEntity">The postal_code data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("POSTAL_CODE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] POSTAL_CODE updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _pOSTAL_CODEService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific postal_code by its primary key</summary>
        /// <param name="id">The primary key of the postal_code</param>
        /// <param name="updatedEntity">The postal_code data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("POSTAL_CODE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<POSTAL_CODE> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _pOSTAL_CODEService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}