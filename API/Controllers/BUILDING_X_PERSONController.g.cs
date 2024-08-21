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
    /// Controller responsible for managing building_x_person related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting building_x_person information.
    /// </remarks>
    [Route("api/building_x_person")]
    [Authorize]
    public class BUILDING_X_PERSONController : BaseApiController
    {
        private readonly IBUILDING_X_PERSONService _bUILDING_X_PERSONService;

        /// <summary>
        /// Initializes a new instance of the BUILDING_X_PERSONController class with the specified context.
        /// </summary>
        /// <param name="ibuilding_x_personservice">The ibuilding_x_personservice to be used by the controller.</param>
        public BUILDING_X_PERSONController(IBUILDING_X_PERSONService ibuilding_x_personservice)
        {
            _bUILDING_X_PERSONService = ibuilding_x_personservice;
        }

        /// <summary>Adds a new building_x_person</summary>
        /// <param name="model">The building_x_person data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("BUILDING_X_PERSON", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] BUILDING_X_PERSON model)
        {
            var id = await _bUILDING_X_PERSONService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of building_x_persons based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of building_x_persons</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("BUILDING_X_PERSON", Entitlements.Read)]
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

            var result = await _bUILDING_X_PERSONService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific building_x_person by its primary key</summary>
        /// <param name="id">The primary key of the building_x_person</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The building_x_person data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("BUILDING_X_PERSON", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _bUILDING_X_PERSONService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific building_x_person by its primary key</summary>
        /// <param name="id">The primary key of the building_x_person</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("BUILDING_X_PERSON", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _bUILDING_X_PERSONService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific building_x_person by its primary key</summary>
        /// <param name="id">The primary key of the building_x_person</param>
        /// <param name="updatedEntity">The building_x_person data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("BUILDING_X_PERSON", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] BUILDING_X_PERSON updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _bUILDING_X_PERSONService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific building_x_person by its primary key</summary>
        /// <param name="id">The primary key of the building_x_person</param>
        /// <param name="updatedEntity">The building_x_person data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("BUILDING_X_PERSON", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<BUILDING_X_PERSON> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _bUILDING_X_PERSONService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}