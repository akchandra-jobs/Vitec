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
    /// Controller responsible for managing video_binary related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting video_binary information.
    /// </remarks>
    [Route("api/video_binary")]
    [Authorize]
    public class VIDEO_BINARYController : BaseApiController
    {
        private readonly IVIDEO_BINARYService _vIDEO_BINARYService;

        /// <summary>
        /// Initializes a new instance of the VIDEO_BINARYController class with the specified context.
        /// </summary>
        /// <param name="ivideo_binaryservice">The ivideo_binaryservice to be used by the controller.</param>
        public VIDEO_BINARYController(IVIDEO_BINARYService ivideo_binaryservice)
        {
            _vIDEO_BINARYService = ivideo_binaryservice;
        }

        /// <summary>Adds a new video_binary</summary>
        /// <param name="model">The video_binary data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("VIDEO_BINARY", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] VIDEO_BINARY model)
        {
            var id = await _vIDEO_BINARYService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of video_binarys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of video_binarys</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("VIDEO_BINARY", Entitlements.Read)]
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

            var result = await _vIDEO_BINARYService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific video_binary by its primary key</summary>
        /// <param name="id">The primary key of the video_binary</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The video_binary data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("VIDEO_BINARY", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _vIDEO_BINARYService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific video_binary by its primary key</summary>
        /// <param name="id">The primary key of the video_binary</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("VIDEO_BINARY", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _vIDEO_BINARYService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific video_binary by its primary key</summary>
        /// <param name="id">The primary key of the video_binary</param>
        /// <param name="updatedEntity">The video_binary data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("VIDEO_BINARY", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] VIDEO_BINARY updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _vIDEO_BINARYService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific video_binary by its primary key</summary>
        /// <param name="id">The primary key of the video_binary</param>
        /// <param name="updatedEntity">The video_binary data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("VIDEO_BINARY", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<VIDEO_BINARY> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _vIDEO_BINARYService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}