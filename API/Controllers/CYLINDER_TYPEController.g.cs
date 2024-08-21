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
    /// Controller responsible for managing cylinder_type related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting cylinder_type information.
    /// </remarks>
    [Route("api/cylinder_type")]
    [Authorize]
    public class CYLINDER_TYPEController : BaseApiController
    {
        private readonly ICYLINDER_TYPEService _cYLINDER_TYPEService;

        /// <summary>
        /// Initializes a new instance of the CYLINDER_TYPEController class with the specified context.
        /// </summary>
        /// <param name="icylinder_typeservice">The icylinder_typeservice to be used by the controller.</param>
        public CYLINDER_TYPEController(ICYLINDER_TYPEService icylinder_typeservice)
        {
            _cYLINDER_TYPEService = icylinder_typeservice;
        }

        /// <summary>Adds a new cylinder_type</summary>
        /// <param name="model">The cylinder_type data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CYLINDER_TYPE", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] CYLINDER_TYPE model)
        {
            var id = await _cYLINDER_TYPEService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of cylinder_types based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cylinder_types</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CYLINDER_TYPE", Entitlements.Read)]
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

            var result = await _cYLINDER_TYPEService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific cylinder_type by its primary key</summary>
        /// <param name="id">The primary key of the cylinder_type</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The cylinder_type data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CYLINDER_TYPE", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _cYLINDER_TYPEService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific cylinder_type by its primary key</summary>
        /// <param name="id">The primary key of the cylinder_type</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("CYLINDER_TYPE", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _cYLINDER_TYPEService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific cylinder_type by its primary key</summary>
        /// <param name="id">The primary key of the cylinder_type</param>
        /// <param name="updatedEntity">The cylinder_type data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CYLINDER_TYPE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] CYLINDER_TYPE updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _cYLINDER_TYPEService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific cylinder_type by its primary key</summary>
        /// <param name="id">The primary key of the cylinder_type</param>
        /// <param name="updatedEntity">The cylinder_type data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CYLINDER_TYPE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<CYLINDER_TYPE> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _cYLINDER_TYPEService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}