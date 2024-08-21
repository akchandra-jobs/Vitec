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
    /// Controller responsible for managing supplier_line_of_business related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting supplier_line_of_business information.
    /// </remarks>
    [Route("api/supplier_line_of_business")]
    [Authorize]
    public class SUPPLIER_LINE_OF_BUSINESSController : BaseApiController
    {
        private readonly ISUPPLIER_LINE_OF_BUSINESSService _sUPPLIER_LINE_OF_BUSINESSService;

        /// <summary>
        /// Initializes a new instance of the SUPPLIER_LINE_OF_BUSINESSController class with the specified context.
        /// </summary>
        /// <param name="isupplier_line_of_businessservice">The isupplier_line_of_businessservice to be used by the controller.</param>
        public SUPPLIER_LINE_OF_BUSINESSController(ISUPPLIER_LINE_OF_BUSINESSService isupplier_line_of_businessservice)
        {
            _sUPPLIER_LINE_OF_BUSINESSService = isupplier_line_of_businessservice;
        }

        /// <summary>Adds a new supplier_line_of_business</summary>
        /// <param name="model">The supplier_line_of_business data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("SUPPLIER_LINE_OF_BUSINESS", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] SUPPLIER_LINE_OF_BUSINESS model)
        {
            var id = await _sUPPLIER_LINE_OF_BUSINESSService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of supplier_line_of_businesss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of supplier_line_of_businesss</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("SUPPLIER_LINE_OF_BUSINESS", Entitlements.Read)]
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

            var result = await _sUPPLIER_LINE_OF_BUSINESSService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific supplier_line_of_business by its primary key</summary>
        /// <param name="id">The primary key of the supplier_line_of_business</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The supplier_line_of_business data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("SUPPLIER_LINE_OF_BUSINESS", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _sUPPLIER_LINE_OF_BUSINESSService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific supplier_line_of_business by its primary key</summary>
        /// <param name="id">The primary key of the supplier_line_of_business</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("SUPPLIER_LINE_OF_BUSINESS", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _sUPPLIER_LINE_OF_BUSINESSService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific supplier_line_of_business by its primary key</summary>
        /// <param name="id">The primary key of the supplier_line_of_business</param>
        /// <param name="updatedEntity">The supplier_line_of_business data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("SUPPLIER_LINE_OF_BUSINESS", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] SUPPLIER_LINE_OF_BUSINESS updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _sUPPLIER_LINE_OF_BUSINESSService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific supplier_line_of_business by its primary key</summary>
        /// <param name="id">The primary key of the supplier_line_of_business</param>
        /// <param name="updatedEntity">The supplier_line_of_business data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("SUPPLIER_LINE_OF_BUSINESS", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<SUPPLIER_LINE_OF_BUSINESS> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _sUPPLIER_LINE_OF_BUSINESSService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}