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
    /// Controller responsible for managing medical_region related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting medical_region information.
    /// </remarks>
    [Route("api/medical_region")]
    [Authorize]
    public class MEDICAL_REGIONController : BaseApiController
    {
        private readonly IMEDICAL_REGIONService _mEDICAL_REGIONService;

        /// <summary>
        /// Initializes a new instance of the MEDICAL_REGIONController class with the specified context.
        /// </summary>
        /// <param name="imedical_regionservice">The imedical_regionservice to be used by the controller.</param>
        public MEDICAL_REGIONController(IMEDICAL_REGIONService imedical_regionservice)
        {
            _mEDICAL_REGIONService = imedical_regionservice;
        }

        /// <summary>Adds a new medical_region</summary>
        /// <param name="model">The medical_region data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("MEDICAL_REGION", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] MEDICAL_REGION model)
        {
            var id = await _mEDICAL_REGIONService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of medical_regions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medical_regions</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("MEDICAL_REGION", Entitlements.Read)]
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

            var result = await _mEDICAL_REGIONService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific medical_region by its primary key</summary>
        /// <param name="id">The primary key of the medical_region</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The medical_region data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("MEDICAL_REGION", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _mEDICAL_REGIONService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific medical_region by its primary key</summary>
        /// <param name="id">The primary key of the medical_region</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("MEDICAL_REGION", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _mEDICAL_REGIONService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific medical_region by its primary key</summary>
        /// <param name="id">The primary key of the medical_region</param>
        /// <param name="updatedEntity">The medical_region data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("MEDICAL_REGION", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] MEDICAL_REGION updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _mEDICAL_REGIONService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific medical_region by its primary key</summary>
        /// <param name="id">The primary key of the medical_region</param>
        /// <param name="updatedEntity">The medical_region data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("MEDICAL_REGION", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<MEDICAL_REGION> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _mEDICAL_REGIONService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}