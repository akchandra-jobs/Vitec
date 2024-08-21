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
    /// Controller responsible for managing purchase_order_form related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting purchase_order_form information.
    /// </remarks>
    [Route("api/purchase_order_form")]
    [Authorize]
    public class PURCHASE_ORDER_FORMController : BaseApiController
    {
        private readonly IPURCHASE_ORDER_FORMService _pURCHASE_ORDER_FORMService;

        /// <summary>
        /// Initializes a new instance of the PURCHASE_ORDER_FORMController class with the specified context.
        /// </summary>
        /// <param name="ipurchase_order_formservice">The ipurchase_order_formservice to be used by the controller.</param>
        public PURCHASE_ORDER_FORMController(IPURCHASE_ORDER_FORMService ipurchase_order_formservice)
        {
            _pURCHASE_ORDER_FORMService = ipurchase_order_formservice;
        }

        /// <summary>Adds a new purchase_order_form</summary>
        /// <param name="model">The purchase_order_form data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("PURCHASE_ORDER_FORM", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] PURCHASE_ORDER_FORM model)
        {
            var id = await _pURCHASE_ORDER_FORMService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of purchase_order_forms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of purchase_order_forms</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("PURCHASE_ORDER_FORM", Entitlements.Read)]
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

            var result = await _pURCHASE_ORDER_FORMService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific purchase_order_form by its primary key</summary>
        /// <param name="id">The primary key of the purchase_order_form</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The purchase_order_form data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("PURCHASE_ORDER_FORM", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _pURCHASE_ORDER_FORMService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific purchase_order_form by its primary key</summary>
        /// <param name="id">The primary key of the purchase_order_form</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("PURCHASE_ORDER_FORM", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _pURCHASE_ORDER_FORMService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific purchase_order_form by its primary key</summary>
        /// <param name="id">The primary key of the purchase_order_form</param>
        /// <param name="updatedEntity">The purchase_order_form data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("PURCHASE_ORDER_FORM", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] PURCHASE_ORDER_FORM updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _pURCHASE_ORDER_FORMService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific purchase_order_form by its primary key</summary>
        /// <param name="id">The primary key of the purchase_order_form</param>
        /// <param name="updatedEntity">The purchase_order_form data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("PURCHASE_ORDER_FORM", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<PURCHASE_ORDER_FORM> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _pURCHASE_ORDER_FORMService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}