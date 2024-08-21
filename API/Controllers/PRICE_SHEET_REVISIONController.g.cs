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
    /// Controller responsible for managing price_sheet_revision related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting price_sheet_revision information.
    /// </remarks>
    [Route("api/price_sheet_revision")]
    [Authorize]
    public class PRICE_SHEET_REVISIONController : BaseApiController
    {
        private readonly IPRICE_SHEET_REVISIONService _pRICE_SHEET_REVISIONService;

        /// <summary>
        /// Initializes a new instance of the PRICE_SHEET_REVISIONController class with the specified context.
        /// </summary>
        /// <param name="iprice_sheet_revisionservice">The iprice_sheet_revisionservice to be used by the controller.</param>
        public PRICE_SHEET_REVISIONController(IPRICE_SHEET_REVISIONService iprice_sheet_revisionservice)
        {
            _pRICE_SHEET_REVISIONService = iprice_sheet_revisionservice;
        }

        /// <summary>Adds a new price_sheet_revision</summary>
        /// <param name="model">The price_sheet_revision data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("PRICE_SHEET_REVISION", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] PRICE_SHEET_REVISION model)
        {
            var id = await _pRICE_SHEET_REVISIONService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of price_sheet_revisions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of price_sheet_revisions</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("PRICE_SHEET_REVISION", Entitlements.Read)]
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

            var result = await _pRICE_SHEET_REVISIONService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific price_sheet_revision by its primary key</summary>
        /// <param name="id">The primary key of the price_sheet_revision</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The price_sheet_revision data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("PRICE_SHEET_REVISION", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _pRICE_SHEET_REVISIONService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific price_sheet_revision by its primary key</summary>
        /// <param name="id">The primary key of the price_sheet_revision</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("PRICE_SHEET_REVISION", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _pRICE_SHEET_REVISIONService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific price_sheet_revision by its primary key</summary>
        /// <param name="id">The primary key of the price_sheet_revision</param>
        /// <param name="updatedEntity">The price_sheet_revision data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("PRICE_SHEET_REVISION", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] PRICE_SHEET_REVISION updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _pRICE_SHEET_REVISIONService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific price_sheet_revision by its primary key</summary>
        /// <param name="id">The primary key of the price_sheet_revision</param>
        /// <param name="updatedEntity">The price_sheet_revision data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("PRICE_SHEET_REVISION", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<PRICE_SHEET_REVISION> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _pRICE_SHEET_REVISIONService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}