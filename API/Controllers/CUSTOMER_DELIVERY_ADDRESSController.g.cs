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
    /// Controller responsible for managing customer_delivery_address related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting customer_delivery_address information.
    /// </remarks>
    [Route("api/customer_delivery_address")]
    [Authorize]
    public class CUSTOMER_DELIVERY_ADDRESSController : BaseApiController
    {
        private readonly ICUSTOMER_DELIVERY_ADDRESSService _cUSTOMER_DELIVERY_ADDRESSService;

        /// <summary>
        /// Initializes a new instance of the CUSTOMER_DELIVERY_ADDRESSController class with the specified context.
        /// </summary>
        /// <param name="icustomer_delivery_addressservice">The icustomer_delivery_addressservice to be used by the controller.</param>
        public CUSTOMER_DELIVERY_ADDRESSController(ICUSTOMER_DELIVERY_ADDRESSService icustomer_delivery_addressservice)
        {
            _cUSTOMER_DELIVERY_ADDRESSService = icustomer_delivery_addressservice;
        }

        /// <summary>Adds a new customer_delivery_address</summary>
        /// <param name="model">The customer_delivery_address data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOMER_DELIVERY_ADDRESS", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] CUSTOMER_DELIVERY_ADDRESS model)
        {
            var id = await _cUSTOMER_DELIVERY_ADDRESSService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of customer_delivery_addresss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of customer_delivery_addresss</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOMER_DELIVERY_ADDRESS", Entitlements.Read)]
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

            var result = await _cUSTOMER_DELIVERY_ADDRESSService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific customer_delivery_address by its primary key</summary>
        /// <param name="id">The primary key of the customer_delivery_address</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The customer_delivery_address data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOMER_DELIVERY_ADDRESS", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _cUSTOMER_DELIVERY_ADDRESSService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific customer_delivery_address by its primary key</summary>
        /// <param name="id">The primary key of the customer_delivery_address</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("CUSTOMER_DELIVERY_ADDRESS", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _cUSTOMER_DELIVERY_ADDRESSService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific customer_delivery_address by its primary key</summary>
        /// <param name="id">The primary key of the customer_delivery_address</param>
        /// <param name="updatedEntity">The customer_delivery_address data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOMER_DELIVERY_ADDRESS", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] CUSTOMER_DELIVERY_ADDRESS updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _cUSTOMER_DELIVERY_ADDRESSService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific customer_delivery_address by its primary key</summary>
        /// <param name="id">The primary key of the customer_delivery_address</param>
        /// <param name="updatedEntity">The customer_delivery_address data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOMER_DELIVERY_ADDRESS", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<CUSTOMER_DELIVERY_ADDRESS> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _cUSTOMER_DELIVERY_ADDRESSService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}