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
    /// Controller responsible for managing work_order_invoice_item related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting work_order_invoice_item information.
    /// </remarks>
    [Route("api/work_order_invoice_item")]
    [Authorize]
    public class WORK_ORDER_INVOICE_ITEMController : BaseApiController
    {
        private readonly IWORK_ORDER_INVOICE_ITEMService _wORK_ORDER_INVOICE_ITEMService;

        /// <summary>
        /// Initializes a new instance of the WORK_ORDER_INVOICE_ITEMController class with the specified context.
        /// </summary>
        /// <param name="iwork_order_invoice_itemservice">The iwork_order_invoice_itemservice to be used by the controller.</param>
        public WORK_ORDER_INVOICE_ITEMController(IWORK_ORDER_INVOICE_ITEMService iwork_order_invoice_itemservice)
        {
            _wORK_ORDER_INVOICE_ITEMService = iwork_order_invoice_itemservice;
        }

        /// <summary>Adds a new work_order_invoice_item</summary>
        /// <param name="model">The work_order_invoice_item data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("WORK_ORDER_INVOICE_ITEM", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] WORK_ORDER_INVOICE_ITEM model)
        {
            var id = await _wORK_ORDER_INVOICE_ITEMService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of work_order_invoice_items based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of work_order_invoice_items</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("WORK_ORDER_INVOICE_ITEM", Entitlements.Read)]
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

            var result = await _wORK_ORDER_INVOICE_ITEMService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific work_order_invoice_item by its primary key</summary>
        /// <param name="id">The primary key of the work_order_invoice_item</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The work_order_invoice_item data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("WORK_ORDER_INVOICE_ITEM", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _wORK_ORDER_INVOICE_ITEMService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific work_order_invoice_item by its primary key</summary>
        /// <param name="id">The primary key of the work_order_invoice_item</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("WORK_ORDER_INVOICE_ITEM", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _wORK_ORDER_INVOICE_ITEMService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific work_order_invoice_item by its primary key</summary>
        /// <param name="id">The primary key of the work_order_invoice_item</param>
        /// <param name="updatedEntity">The work_order_invoice_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("WORK_ORDER_INVOICE_ITEM", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] WORK_ORDER_INVOICE_ITEM updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _wORK_ORDER_INVOICE_ITEMService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific work_order_invoice_item by its primary key</summary>
        /// <param name="id">The primary key of the work_order_invoice_item</param>
        /// <param name="updatedEntity">The work_order_invoice_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("WORK_ORDER_INVOICE_ITEM", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<WORK_ORDER_INVOICE_ITEM> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _wORK_ORDER_INVOICE_ITEMService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}