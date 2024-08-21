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
    /// Controller responsible for managing user_x_user_notification related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting user_x_user_notification information.
    /// </remarks>
    [Route("api/user_x_user_notification")]
    [Authorize]
    public class USER_X_USER_NOTIFICATIONController : BaseApiController
    {
        private readonly IUSER_X_USER_NOTIFICATIONService _uSER_X_USER_NOTIFICATIONService;

        /// <summary>
        /// Initializes a new instance of the USER_X_USER_NOTIFICATIONController class with the specified context.
        /// </summary>
        /// <param name="iuser_x_user_notificationservice">The iuser_x_user_notificationservice to be used by the controller.</param>
        public USER_X_USER_NOTIFICATIONController(IUSER_X_USER_NOTIFICATIONService iuser_x_user_notificationservice)
        {
            _uSER_X_USER_NOTIFICATIONService = iuser_x_user_notificationservice;
        }

        /// <summary>Adds a new user_x_user_notification</summary>
        /// <param name="model">The user_x_user_notification data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("USER_X_USER_NOTIFICATION", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] USER_X_USER_NOTIFICATION model)
        {
            var id = await _uSER_X_USER_NOTIFICATIONService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of user_x_user_notifications based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of user_x_user_notifications</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("USER_X_USER_NOTIFICATION", Entitlements.Read)]
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

            var result = await _uSER_X_USER_NOTIFICATIONService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific user_x_user_notification by its primary key</summary>
        /// <param name="id">The primary key of the user_x_user_notification</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The user_x_user_notification data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("USER_X_USER_NOTIFICATION", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _uSER_X_USER_NOTIFICATIONService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific user_x_user_notification by its primary key</summary>
        /// <param name="id">The primary key of the user_x_user_notification</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("USER_X_USER_NOTIFICATION", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _uSER_X_USER_NOTIFICATIONService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific user_x_user_notification by its primary key</summary>
        /// <param name="id">The primary key of the user_x_user_notification</param>
        /// <param name="updatedEntity">The user_x_user_notification data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("USER_X_USER_NOTIFICATION", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] USER_X_USER_NOTIFICATION updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _uSER_X_USER_NOTIFICATIONService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific user_x_user_notification by its primary key</summary>
        /// <param name="id">The primary key of the user_x_user_notification</param>
        /// <param name="updatedEntity">The user_x_user_notification data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("USER_X_USER_NOTIFICATION", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<USER_X_USER_NOTIFICATION> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _uSER_X_USER_NOTIFICATIONService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}