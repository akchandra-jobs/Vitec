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
    /// Controller responsible for managing estate_category related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting estate_category information.
    /// </remarks>
    [Route("api/estate_category")]
    [Authorize]
    public class ESTATE_CATEGORYController : BaseApiController
    {
        private readonly IESTATE_CATEGORYService _eSTATE_CATEGORYService;

        /// <summary>
        /// Initializes a new instance of the ESTATE_CATEGORYController class with the specified context.
        /// </summary>
        /// <param name="iestate_categoryservice">The iestate_categoryservice to be used by the controller.</param>
        public ESTATE_CATEGORYController(IESTATE_CATEGORYService iestate_categoryservice)
        {
            _eSTATE_CATEGORYService = iestate_categoryservice;
        }

        /// <summary>Adds a new estate_category</summary>
        /// <param name="model">The estate_category data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ESTATE_CATEGORY", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] ESTATE_CATEGORY model)
        {
            var id = await _eSTATE_CATEGORYService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of estate_categorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of estate_categorys</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ESTATE_CATEGORY", Entitlements.Read)]
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

            var result = await _eSTATE_CATEGORYService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific estate_category by its primary key</summary>
        /// <param name="id">The primary key of the estate_category</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The estate_category data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ESTATE_CATEGORY", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _eSTATE_CATEGORYService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific estate_category by its primary key</summary>
        /// <param name="id">The primary key of the estate_category</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("ESTATE_CATEGORY", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _eSTATE_CATEGORYService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific estate_category by its primary key</summary>
        /// <param name="id">The primary key of the estate_category</param>
        /// <param name="updatedEntity">The estate_category data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ESTATE_CATEGORY", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] ESTATE_CATEGORY updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _eSTATE_CATEGORYService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific estate_category by its primary key</summary>
        /// <param name="id">The primary key of the estate_category</param>
        /// <param name="updatedEntity">The estate_category data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ESTATE_CATEGORY", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<ESTATE_CATEGORY> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _eSTATE_CATEGORYService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}