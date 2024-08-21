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
    /// Controller responsible for managing organization_section related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting organization_section information.
    /// </remarks>
    [Route("api/organization_section")]
    [Authorize]
    public class ORGANIZATION_SECTIONController : BaseApiController
    {
        private readonly IORGANIZATION_SECTIONService _oRGANIZATION_SECTIONService;

        /// <summary>
        /// Initializes a new instance of the ORGANIZATION_SECTIONController class with the specified context.
        /// </summary>
        /// <param name="iorganization_sectionservice">The iorganization_sectionservice to be used by the controller.</param>
        public ORGANIZATION_SECTIONController(IORGANIZATION_SECTIONService iorganization_sectionservice)
        {
            _oRGANIZATION_SECTIONService = iorganization_sectionservice;
        }

        /// <summary>Adds a new organization_section</summary>
        /// <param name="model">The organization_section data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ORGANIZATION_SECTION", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] ORGANIZATION_SECTION model)
        {
            var id = await _oRGANIZATION_SECTIONService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of organization_sections based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of organization_sections</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ORGANIZATION_SECTION", Entitlements.Read)]
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

            var result = await _oRGANIZATION_SECTIONService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific organization_section by its primary key</summary>
        /// <param name="id">The primary key of the organization_section</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The organization_section data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ORGANIZATION_SECTION", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _oRGANIZATION_SECTIONService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific organization_section by its primary key</summary>
        /// <param name="id">The primary key of the organization_section</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("ORGANIZATION_SECTION", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _oRGANIZATION_SECTIONService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific organization_section by its primary key</summary>
        /// <param name="id">The primary key of the organization_section</param>
        /// <param name="updatedEntity">The organization_section data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ORGANIZATION_SECTION", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] ORGANIZATION_SECTION updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _oRGANIZATION_SECTIONService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific organization_section by its primary key</summary>
        /// <param name="id">The primary key of the organization_section</param>
        /// <param name="updatedEntity">The organization_section data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ORGANIZATION_SECTION", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<ORGANIZATION_SECTION> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _oRGANIZATION_SECTIONService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}