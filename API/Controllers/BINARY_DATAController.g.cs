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
    /// Controller responsible for managing binary_data related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting binary_data information.
    /// </remarks>
    [Route("api/binary_data")]
    [Authorize]
    public class BINARY_DATAController : BaseApiController
    {
        private readonly IBINARY_DATAService _bINARY_DATAService;

        /// <summary>
        /// Initializes a new instance of the BINARY_DATAController class with the specified context.
        /// </summary>
        /// <param name="ibinary_dataservice">The ibinary_dataservice to be used by the controller.</param>
        public BINARY_DATAController(IBINARY_DATAService ibinary_dataservice)
        {
            _bINARY_DATAService = ibinary_dataservice;
        }

        /// <summary>Adds a new binary_data</summary>
        /// <param name="model">The binary_data data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("BINARY_DATA", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] BINARY_DATA model)
        {
            var id = await _bINARY_DATAService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of binary_datas based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of binary_datas</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("BINARY_DATA", Entitlements.Read)]
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

            var result = await _bINARY_DATAService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific binary_data by its primary key</summary>
        /// <param name="id">The primary key of the binary_data</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The binary_data data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("BINARY_DATA", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _bINARY_DATAService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific binary_data by its primary key</summary>
        /// <param name="id">The primary key of the binary_data</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("BINARY_DATA", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _bINARY_DATAService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific binary_data by its primary key</summary>
        /// <param name="id">The primary key of the binary_data</param>
        /// <param name="updatedEntity">The binary_data data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("BINARY_DATA", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] BINARY_DATA updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _bINARY_DATAService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific binary_data by its primary key</summary>
        /// <param name="id">The primary key of the binary_data</param>
        /// <param name="updatedEntity">The binary_data data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("BINARY_DATA", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<BINARY_DATA> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _bINARY_DATAService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}