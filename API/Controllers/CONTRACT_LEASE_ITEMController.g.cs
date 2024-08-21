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
    /// Controller responsible for managing contract_lease_item related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting contract_lease_item information.
    /// </remarks>
    [Route("api/contract_lease_item")]
    [Authorize]
    public class CONTRACT_LEASE_ITEMController : BaseApiController
    {
        private readonly ICONTRACT_LEASE_ITEMService _cONTRACT_LEASE_ITEMService;

        /// <summary>
        /// Initializes a new instance of the CONTRACT_LEASE_ITEMController class with the specified context.
        /// </summary>
        /// <param name="icontract_lease_itemservice">The icontract_lease_itemservice to be used by the controller.</param>
        public CONTRACT_LEASE_ITEMController(ICONTRACT_LEASE_ITEMService icontract_lease_itemservice)
        {
            _cONTRACT_LEASE_ITEMService = icontract_lease_itemservice;
        }

        /// <summary>Adds a new contract_lease_item</summary>
        /// <param name="model">The contract_lease_item data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CONTRACT_LEASE_ITEM", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] CONTRACT_LEASE_ITEM model)
        {
            var id = await _cONTRACT_LEASE_ITEMService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of contract_lease_items based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of contract_lease_items</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CONTRACT_LEASE_ITEM", Entitlements.Read)]
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

            var result = await _cONTRACT_LEASE_ITEMService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific contract_lease_item by its primary key</summary>
        /// <param name="id">The primary key of the contract_lease_item</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The contract_lease_item data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CONTRACT_LEASE_ITEM", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _cONTRACT_LEASE_ITEMService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific contract_lease_item by its primary key</summary>
        /// <param name="id">The primary key of the contract_lease_item</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("CONTRACT_LEASE_ITEM", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _cONTRACT_LEASE_ITEMService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific contract_lease_item by its primary key</summary>
        /// <param name="id">The primary key of the contract_lease_item</param>
        /// <param name="updatedEntity">The contract_lease_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CONTRACT_LEASE_ITEM", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] CONTRACT_LEASE_ITEM updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _cONTRACT_LEASE_ITEMService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific contract_lease_item by its primary key</summary>
        /// <param name="id">The primary key of the contract_lease_item</param>
        /// <param name="updatedEntity">The contract_lease_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CONTRACT_LEASE_ITEM", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<CONTRACT_LEASE_ITEM> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _cONTRACT_LEASE_ITEMService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}