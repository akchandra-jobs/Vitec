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
    /// Controller responsible for managing set related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting set information.
    /// </remarks>
    [Route("api/set")]
    [Authorize]
    public class SetController : BaseApiController
    {
        private readonly ISetService _setService;

        /// <summary>
        /// Initializes a new instance of the SetController class with the specified context.
        /// </summary>
        /// <param name="isetservice">The isetservice to be used by the controller.</param>
        public SetController(ISetService isetservice)
        {
            _setService = isetservice;
        }

        /// <summary>Adds a new set</summary>
        /// <param name="model">The set data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("Set", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] Entities.Set model)
        {
            var id = await _setService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of sets based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of sets</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("Set", Entitlements.Read)]
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

            var result = await _setService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific set by its primary key</summary>
        /// <param name="id">The primary key of the set</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The set data</returns>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("Set", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] int id, string fields = null)
        {
            var result = await _setService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific set by its primary key</summary>
        /// <param name="id">The primary key of the set</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:int}")]
        [UserAuthorize("Set", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var status = await _setService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific set by its primary key</summary>
        /// <param name="id">The primary key of the set</param>
        /// <param name="updatedEntity">The set data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("Set", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(int id, [FromBody] Entities.Set updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            var status = await _setService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific set by its primary key</summary>
        /// <param name="id">The primary key of the set</param>
        /// <param name="updatedEntity">The set data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("Set", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(int id, [FromBody] JsonPatchDocument<Entities.Set> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _setService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}