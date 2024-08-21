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
    /// Controller responsible for managing payment_order related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting payment_order information.
    /// </remarks>
    [Route("api/payment_order")]
    [Authorize]
    public class PAYMENT_ORDERController : BaseApiController
    {
        private readonly IPAYMENT_ORDERService _pAYMENT_ORDERService;

        /// <summary>
        /// Initializes a new instance of the PAYMENT_ORDERController class with the specified context.
        /// </summary>
        /// <param name="ipayment_orderservice">The ipayment_orderservice to be used by the controller.</param>
        public PAYMENT_ORDERController(IPAYMENT_ORDERService ipayment_orderservice)
        {
            _pAYMENT_ORDERService = ipayment_orderservice;
        }

        /// <summary>Adds a new payment_order</summary>
        /// <param name="model">The payment_order data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("PAYMENT_ORDER", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] PAYMENT_ORDER model)
        {
            var id = await _pAYMENT_ORDERService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of payment_orders based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of payment_orders</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("PAYMENT_ORDER", Entitlements.Read)]
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

            var result = await _pAYMENT_ORDERService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific payment_order by its primary key</summary>
        /// <param name="id">The primary key of the payment_order</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The payment_order data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("PAYMENT_ORDER", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _pAYMENT_ORDERService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific payment_order by its primary key</summary>
        /// <param name="id">The primary key of the payment_order</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("PAYMENT_ORDER", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _pAYMENT_ORDERService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific payment_order by its primary key</summary>
        /// <param name="id">The primary key of the payment_order</param>
        /// <param name="updatedEntity">The payment_order data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("PAYMENT_ORDER", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] PAYMENT_ORDER updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _pAYMENT_ORDERService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific payment_order by its primary key</summary>
        /// <param name="id">The primary key of the payment_order</param>
        /// <param name="updatedEntity">The payment_order data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("PAYMENT_ORDER", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<PAYMENT_ORDER> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _pAYMENT_ORDERService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}