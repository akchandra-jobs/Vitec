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
    /// Controller responsible for managing component_x_supplier related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting component_x_supplier information.
    /// </remarks>
    [Route("api/component_x_supplier")]
    [Authorize]
    public class COMPONENT_X_SUPPLIERController : BaseApiController
    {
        private readonly ICOMPONENT_X_SUPPLIERService _cOMPONENT_X_SUPPLIERService;

        /// <summary>
        /// Initializes a new instance of the COMPONENT_X_SUPPLIERController class with the specified context.
        /// </summary>
        /// <param name="icomponent_x_supplierservice">The icomponent_x_supplierservice to be used by the controller.</param>
        public COMPONENT_X_SUPPLIERController(ICOMPONENT_X_SUPPLIERService icomponent_x_supplierservice)
        {
            _cOMPONENT_X_SUPPLIERService = icomponent_x_supplierservice;
        }

        /// <summary>Adds a new component_x_supplier</summary>
        /// <param name="model">The component_x_supplier data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("COMPONENT_X_SUPPLIER", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] COMPONENT_X_SUPPLIER model)
        {
            var id = await _cOMPONENT_X_SUPPLIERService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of component_x_suppliers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of component_x_suppliers</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("COMPONENT_X_SUPPLIER", Entitlements.Read)]
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

            var result = await _cOMPONENT_X_SUPPLIERService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific component_x_supplier by its primary key</summary>
        /// <param name="id">The primary key of the component_x_supplier</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The component_x_supplier data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("COMPONENT_X_SUPPLIER", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _cOMPONENT_X_SUPPLIERService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific component_x_supplier by its primary key</summary>
        /// <param name="id">The primary key of the component_x_supplier</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("COMPONENT_X_SUPPLIER", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _cOMPONENT_X_SUPPLIERService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific component_x_supplier by its primary key</summary>
        /// <param name="id">The primary key of the component_x_supplier</param>
        /// <param name="updatedEntity">The component_x_supplier data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("COMPONENT_X_SUPPLIER", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] COMPONENT_X_SUPPLIER updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _cOMPONENT_X_SUPPLIERService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific component_x_supplier by its primary key</summary>
        /// <param name="id">The primary key of the component_x_supplier</param>
        /// <param name="updatedEntity">The component_x_supplier data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("COMPONENT_X_SUPPLIER", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<COMPONENT_X_SUPPLIER> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _cOMPONENT_X_SUPPLIERService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}