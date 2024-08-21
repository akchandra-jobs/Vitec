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
    /// Controller responsible for managing video_x_entity related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting video_x_entity information.
    /// </remarks>
    [Route("api/video_x_entity")]
    [Authorize]
    public class VIDEO_X_ENTITYController : BaseApiController
    {
        private readonly IVIDEO_X_ENTITYService _vIDEO_X_ENTITYService;

        /// <summary>
        /// Initializes a new instance of the VIDEO_X_ENTITYController class with the specified context.
        /// </summary>
        /// <param name="ivideo_x_entityservice">The ivideo_x_entityservice to be used by the controller.</param>
        public VIDEO_X_ENTITYController(IVIDEO_X_ENTITYService ivideo_x_entityservice)
        {
            _vIDEO_X_ENTITYService = ivideo_x_entityservice;
        }

        /// <summary>Adds a new video_x_entity</summary>
        /// <param name="model">The video_x_entity data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("VIDEO_X_ENTITY", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] VIDEO_X_ENTITY model)
        {
            var id = await _vIDEO_X_ENTITYService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of video_x_entitys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of video_x_entitys</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("VIDEO_X_ENTITY", Entitlements.Read)]
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

            var result = await _vIDEO_X_ENTITYService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific video_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the video_x_entity</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The video_x_entity data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("VIDEO_X_ENTITY", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _vIDEO_X_ENTITYService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific video_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the video_x_entity</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("VIDEO_X_ENTITY", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _vIDEO_X_ENTITYService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific video_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the video_x_entity</param>
        /// <param name="updatedEntity">The video_x_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("VIDEO_X_ENTITY", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] VIDEO_X_ENTITY updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _vIDEO_X_ENTITYService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific video_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the video_x_entity</param>
        /// <param name="updatedEntity">The video_x_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("VIDEO_X_ENTITY", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<VIDEO_X_ENTITY> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _vIDEO_X_ENTITYService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}