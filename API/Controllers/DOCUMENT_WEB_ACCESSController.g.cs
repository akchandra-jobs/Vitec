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
    /// Controller responsible for managing document_web_access related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting document_web_access information.
    /// </remarks>
    [Route("api/document_web_access")]
    [Authorize]
    public class DOCUMENT_WEB_ACCESSController : BaseApiController
    {
        private readonly IDOCUMENT_WEB_ACCESSService _dOCUMENT_WEB_ACCESSService;

        /// <summary>
        /// Initializes a new instance of the DOCUMENT_WEB_ACCESSController class with the specified context.
        /// </summary>
        /// <param name="idocument_web_accessservice">The idocument_web_accessservice to be used by the controller.</param>
        public DOCUMENT_WEB_ACCESSController(IDOCUMENT_WEB_ACCESSService idocument_web_accessservice)
        {
            _dOCUMENT_WEB_ACCESSService = idocument_web_accessservice;
        }

        /// <summary>Adds a new document_web_access</summary>
        /// <param name="model">The document_web_access data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("DOCUMENT_WEB_ACCESS", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] DOCUMENT_WEB_ACCESS model)
        {
            var id = await _dOCUMENT_WEB_ACCESSService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of document_web_accesss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of document_web_accesss</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DOCUMENT_WEB_ACCESS", Entitlements.Read)]
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

            var result = await _dOCUMENT_WEB_ACCESSService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific document_web_access by its primary key</summary>
        /// <param name="id">The primary key of the document_web_access</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The document_web_access data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("DOCUMENT_WEB_ACCESS", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _dOCUMENT_WEB_ACCESSService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific document_web_access by its primary key</summary>
        /// <param name="id">The primary key of the document_web_access</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("DOCUMENT_WEB_ACCESS", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _dOCUMENT_WEB_ACCESSService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific document_web_access by its primary key</summary>
        /// <param name="id">The primary key of the document_web_access</param>
        /// <param name="updatedEntity">The document_web_access data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DOCUMENT_WEB_ACCESS", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] DOCUMENT_WEB_ACCESS updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _dOCUMENT_WEB_ACCESSService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific document_web_access by its primary key</summary>
        /// <param name="id">The primary key of the document_web_access</param>
        /// <param name="updatedEntity">The document_web_access data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DOCUMENT_WEB_ACCESS", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<DOCUMENT_WEB_ACCESS> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _dOCUMENT_WEB_ACCESSService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}