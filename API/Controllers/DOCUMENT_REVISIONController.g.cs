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
    /// Controller responsible for managing document_revision related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting document_revision information.
    /// </remarks>
    [Route("api/document_revision")]
    [Authorize]
    public class DOCUMENT_REVISIONController : BaseApiController
    {
        private readonly IDOCUMENT_REVISIONService _dOCUMENT_REVISIONService;

        /// <summary>
        /// Initializes a new instance of the DOCUMENT_REVISIONController class with the specified context.
        /// </summary>
        /// <param name="idocument_revisionservice">The idocument_revisionservice to be used by the controller.</param>
        public DOCUMENT_REVISIONController(IDOCUMENT_REVISIONService idocument_revisionservice)
        {
            _dOCUMENT_REVISIONService = idocument_revisionservice;
        }

        /// <summary>Adds a new document_revision</summary>
        /// <param name="model">The document_revision data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("DOCUMENT_REVISION", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] DOCUMENT_REVISION model)
        {
            var id = await _dOCUMENT_REVISIONService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of document_revisions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of document_revisions</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DOCUMENT_REVISION", Entitlements.Read)]
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

            var result = await _dOCUMENT_REVISIONService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific document_revision by its primary key</summary>
        /// <param name="id">The primary key of the document_revision</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The document_revision data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("DOCUMENT_REVISION", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _dOCUMENT_REVISIONService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific document_revision by its primary key</summary>
        /// <param name="id">The primary key of the document_revision</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("DOCUMENT_REVISION", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _dOCUMENT_REVISIONService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific document_revision by its primary key</summary>
        /// <param name="id">The primary key of the document_revision</param>
        /// <param name="updatedEntity">The document_revision data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DOCUMENT_REVISION", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] DOCUMENT_REVISION updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _dOCUMENT_REVISIONService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific document_revision by its primary key</summary>
        /// <param name="id">The primary key of the document_revision</param>
        /// <param name="updatedEntity">The document_revision data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("DOCUMENT_REVISION", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<DOCUMENT_REVISION> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _dOCUMENT_REVISIONService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}