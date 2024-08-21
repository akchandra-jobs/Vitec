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
    /// Controller responsible for managing contract_adjustment related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting contract_adjustment information.
    /// </remarks>
    [Route("api/contract_adjustment")]
    [Authorize]
    public class CONTRACT_ADJUSTMENTController : BaseApiController
    {
        private readonly ICONTRACT_ADJUSTMENTService _cONTRACT_ADJUSTMENTService;

        /// <summary>
        /// Initializes a new instance of the CONTRACT_ADJUSTMENTController class with the specified context.
        /// </summary>
        /// <param name="icontract_adjustmentservice">The icontract_adjustmentservice to be used by the controller.</param>
        public CONTRACT_ADJUSTMENTController(ICONTRACT_ADJUSTMENTService icontract_adjustmentservice)
        {
            _cONTRACT_ADJUSTMENTService = icontract_adjustmentservice;
        }

        /// <summary>Adds a new contract_adjustment</summary>
        /// <param name="model">The contract_adjustment data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CONTRACT_ADJUSTMENT", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] CONTRACT_ADJUSTMENT model)
        {
            var id = await _cONTRACT_ADJUSTMENTService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of contract_adjustments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of contract_adjustments</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CONTRACT_ADJUSTMENT", Entitlements.Read)]
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

            var result = await _cONTRACT_ADJUSTMENTService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific contract_adjustment by its primary key</summary>
        /// <param name="id">The primary key of the contract_adjustment</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The contract_adjustment data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CONTRACT_ADJUSTMENT", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _cONTRACT_ADJUSTMENTService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific contract_adjustment by its primary key</summary>
        /// <param name="id">The primary key of the contract_adjustment</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("CONTRACT_ADJUSTMENT", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _cONTRACT_ADJUSTMENTService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific contract_adjustment by its primary key</summary>
        /// <param name="id">The primary key of the contract_adjustment</param>
        /// <param name="updatedEntity">The contract_adjustment data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CONTRACT_ADJUSTMENT", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] CONTRACT_ADJUSTMENT updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _cONTRACT_ADJUSTMENTService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific contract_adjustment by its primary key</summary>
        /// <param name="id">The primary key of the contract_adjustment</param>
        /// <param name="updatedEntity">The contract_adjustment data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CONTRACT_ADJUSTMENT", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<CONTRACT_ADJUSTMENT> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _cONTRACT_ADJUSTMENTService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}