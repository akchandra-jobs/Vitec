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
    /// Controller responsible for managing custom_function_x_data_owner related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting custom_function_x_data_owner information.
    /// </remarks>
    [Route("api/custom_function_x_data_owner")]
    [Authorize]
    public class CUSTOM_FUNCTION_X_DATA_OWNERController : BaseApiController
    {
        private readonly ICUSTOM_FUNCTION_X_DATA_OWNERService _cUSTOM_FUNCTION_X_DATA_OWNERService;

        /// <summary>
        /// Initializes a new instance of the CUSTOM_FUNCTION_X_DATA_OWNERController class with the specified context.
        /// </summary>
        /// <param name="icustom_function_x_data_ownerservice">The icustom_function_x_data_ownerservice to be used by the controller.</param>
        public CUSTOM_FUNCTION_X_DATA_OWNERController(ICUSTOM_FUNCTION_X_DATA_OWNERService icustom_function_x_data_ownerservice)
        {
            _cUSTOM_FUNCTION_X_DATA_OWNERService = icustom_function_x_data_ownerservice;
        }

        /// <summary>Adds a new custom_function_x_data_owner</summary>
        /// <param name="model">The custom_function_x_data_owner data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOM_FUNCTION_X_DATA_OWNER", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] CUSTOM_FUNCTION_X_DATA_OWNER model)
        {
            var id = await _cUSTOM_FUNCTION_X_DATA_OWNERService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of custom_function_x_data_owners based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of custom_function_x_data_owners</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOM_FUNCTION_X_DATA_OWNER", Entitlements.Read)]
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

            var result = await _cUSTOM_FUNCTION_X_DATA_OWNERService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific custom_function_x_data_owner by its primary key</summary>
        /// <param name="id">The primary key of the custom_function_x_data_owner</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The custom_function_x_data_owner data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOM_FUNCTION_X_DATA_OWNER", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _cUSTOM_FUNCTION_X_DATA_OWNERService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific custom_function_x_data_owner by its primary key</summary>
        /// <param name="id">The primary key of the custom_function_x_data_owner</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("CUSTOM_FUNCTION_X_DATA_OWNER", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _cUSTOM_FUNCTION_X_DATA_OWNERService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific custom_function_x_data_owner by its primary key</summary>
        /// <param name="id">The primary key of the custom_function_x_data_owner</param>
        /// <param name="updatedEntity">The custom_function_x_data_owner data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOM_FUNCTION_X_DATA_OWNER", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] CUSTOM_FUNCTION_X_DATA_OWNER updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _cUSTOM_FUNCTION_X_DATA_OWNERService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific custom_function_x_data_owner by its primary key</summary>
        /// <param name="id">The primary key of the custom_function_x_data_owner</param>
        /// <param name="updatedEntity">The custom_function_x_data_owner data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CUSTOM_FUNCTION_X_DATA_OWNER", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<CUSTOM_FUNCTION_X_DATA_OWNER> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _cUSTOM_FUNCTION_X_DATA_OWNERService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}