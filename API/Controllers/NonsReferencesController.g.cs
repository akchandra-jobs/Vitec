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
    /// Controller responsible for managing nonsreferences related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting nonsreferences information.
    /// </remarks>
    [Route("api/nonsreferences")]
    [Authorize]
    public class NonsReferencesController : BaseApiController
    {
        private readonly INonsReferencesService _nonsReferencesService;

        /// <summary>
        /// Initializes a new instance of the NonsReferencesController class with the specified context.
        /// </summary>
        /// <param name="inonsreferencesservice">The inonsreferencesservice to be used by the controller.</param>
        public NonsReferencesController(INonsReferencesService inonsreferencesservice)
        {
            _nonsReferencesService = inonsreferencesservice;
        }

        /// <summary>Adds a new nonsreferences</summary>
        /// <param name="model">The nonsreferences data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("NonsReferences", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] NonsReferences model)
        {
            var id = await _nonsReferencesService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of nonsreferencess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of nonsreferencess</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("NonsReferences", Entitlements.Read)]
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

            var result = await _nonsReferencesService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific nonsreferences by its primary key</summary>
        /// <param name="id">The primary key of the nonsreferences</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The nonsreferences data</returns>
        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("NonsReferences", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Int64 id, string fields = null)
        {
            var result = await _nonsReferencesService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific nonsreferences by its primary key</summary>
        /// <param name="id">The primary key of the nonsreferences</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:long}")]
        [UserAuthorize("NonsReferences", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Int64 id)
        {
            var status = await _nonsReferencesService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific nonsreferences by its primary key</summary>
        /// <param name="id">The primary key of the nonsreferences</param>
        /// <param name="updatedEntity">The nonsreferences data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("NonsReferences", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Int64 id, [FromBody] NonsReferences updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            var status = await _nonsReferencesService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific nonsreferences by its primary key</summary>
        /// <param name="id">The primary key of the nonsreferences</param>
        /// <param name="updatedEntity">The nonsreferences data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("NonsReferences", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Int64 id, [FromBody] JsonPatchDocument<NonsReferences> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _nonsReferencesService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}