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
    /// Controller responsible for managing server1 related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting server1 information.
    /// </remarks>
    [Route("api/server1")]
    [Authorize]
    public class Server1Controller : BaseApiController
    {
        private readonly IServer1Service _server1Service;

        /// <summary>
        /// Initializes a new instance of the Server1Controller class with the specified context.
        /// </summary>
        /// <param name="iserver1service">The iserver1service to be used by the controller.</param>
        public Server1Controller(IServer1Service iserver1service)
        {
            _server1Service = iserver1service;
        }

        /// <summary>Adds a new server1</summary>
        /// <param name="model">The server1 data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("Server1", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] Server1 model)
        {
            var id = await _server1Service.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of server1s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of server1s</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("Server1", Entitlements.Read)]
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

            var result = await _server1Service.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific server1 by its primary key</summary>
        /// <param name="id">The primary key of the server1</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The server1 data</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("Server1", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] string id, string fields = null)
        {
            var result = await _server1Service.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific server1 by its primary key</summary>
        /// <param name="id">The primary key of the server1</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id}")]
        [UserAuthorize("Server1", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] string id)
        {
            var status = await _server1Service.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific server1 by its primary key</summary>
        /// <param name="id">The primary key of the server1</param>
        /// <param name="updatedEntity">The server1 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("Server1", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(string id, [FromBody] Server1 updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            var status = await _server1Service.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific server1 by its primary key</summary>
        /// <param name="id">The primary key of the server1</param>
        /// <param name="updatedEntity">The server1 data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("Server1", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(string id, [FromBody] JsonPatchDocument<Server1> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _server1Service.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}