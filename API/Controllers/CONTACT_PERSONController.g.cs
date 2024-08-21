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
    /// Controller responsible for managing contact_person related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting contact_person information.
    /// </remarks>
    [Route("api/contact_person")]
    [Authorize]
    public class CONTACT_PERSONController : BaseApiController
    {
        private readonly ICONTACT_PERSONService _cONTACT_PERSONService;

        /// <summary>
        /// Initializes a new instance of the CONTACT_PERSONController class with the specified context.
        /// </summary>
        /// <param name="icontact_personservice">The icontact_personservice to be used by the controller.</param>
        public CONTACT_PERSONController(ICONTACT_PERSONService icontact_personservice)
        {
            _cONTACT_PERSONService = icontact_personservice;
        }

        /// <summary>Adds a new contact_person</summary>
        /// <param name="model">The contact_person data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CONTACT_PERSON", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] CONTACT_PERSON model)
        {
            var id = await _cONTACT_PERSONService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of contact_persons based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of contact_persons</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CONTACT_PERSON", Entitlements.Read)]
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

            var result = await _cONTACT_PERSONService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific contact_person by its primary key</summary>
        /// <param name="id">The primary key of the contact_person</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The contact_person data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("CONTACT_PERSON", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _cONTACT_PERSONService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific contact_person by its primary key</summary>
        /// <param name="id">The primary key of the contact_person</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("CONTACT_PERSON", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _cONTACT_PERSONService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific contact_person by its primary key</summary>
        /// <param name="id">The primary key of the contact_person</param>
        /// <param name="updatedEntity">The contact_person data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CONTACT_PERSON", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] CONTACT_PERSON updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _cONTACT_PERSONService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific contact_person by its primary key</summary>
        /// <param name="id">The primary key of the contact_person</param>
        /// <param name="updatedEntity">The contact_person data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("CONTACT_PERSON", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<CONTACT_PERSON> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _cONTACT_PERSONService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}