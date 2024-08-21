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
    /// Controller responsible for managing project_phase related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting project_phase information.
    /// </remarks>
    [Route("api/project_phase")]
    [Authorize]
    public class PROJECT_PHASEController : BaseApiController
    {
        private readonly IPROJECT_PHASEService _pROJECT_PHASEService;

        /// <summary>
        /// Initializes a new instance of the PROJECT_PHASEController class with the specified context.
        /// </summary>
        /// <param name="iproject_phaseservice">The iproject_phaseservice to be used by the controller.</param>
        public PROJECT_PHASEController(IPROJECT_PHASEService iproject_phaseservice)
        {
            _pROJECT_PHASEService = iproject_phaseservice;
        }

        /// <summary>Adds a new project_phase</summary>
        /// <param name="model">The project_phase data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("PROJECT_PHASE", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] PROJECT_PHASE model)
        {
            var id = await _pROJECT_PHASEService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of project_phases based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of project_phases</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("PROJECT_PHASE", Entitlements.Read)]
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

            var result = await _pROJECT_PHASEService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific project_phase by its primary key</summary>
        /// <param name="id">The primary key of the project_phase</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The project_phase data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("PROJECT_PHASE", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _pROJECT_PHASEService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific project_phase by its primary key</summary>
        /// <param name="id">The primary key of the project_phase</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("PROJECT_PHASE", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _pROJECT_PHASEService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific project_phase by its primary key</summary>
        /// <param name="id">The primary key of the project_phase</param>
        /// <param name="updatedEntity">The project_phase data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("PROJECT_PHASE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] PROJECT_PHASE updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _pROJECT_PHASEService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific project_phase by its primary key</summary>
        /// <param name="id">The primary key of the project_phase</param>
        /// <param name="updatedEntity">The project_phase data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("PROJECT_PHASE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<PROJECT_PHASE> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _pROJECT_PHASEService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}