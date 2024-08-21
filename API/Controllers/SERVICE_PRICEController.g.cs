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
    /// Controller responsible for managing service_price related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting service_price information.
    /// </remarks>
    [Route("api/service_price")]
    [Authorize]
    public class SERVICE_PRICEController : BaseApiController
    {
        private readonly ISERVICE_PRICEService _sERVICE_PRICEService;

        /// <summary>
        /// Initializes a new instance of the SERVICE_PRICEController class with the specified context.
        /// </summary>
        /// <param name="iservice_priceservice">The iservice_priceservice to be used by the controller.</param>
        public SERVICE_PRICEController(ISERVICE_PRICEService iservice_priceservice)
        {
            _sERVICE_PRICEService = iservice_priceservice;
        }

        /// <summary>Adds a new service_price</summary>
        /// <param name="model">The service_price data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("SERVICE_PRICE", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] SERVICE_PRICE model)
        {
            var id = await _sERVICE_PRICEService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of service_prices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of service_prices</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("SERVICE_PRICE", Entitlements.Read)]
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

            var result = await _sERVICE_PRICEService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific service_price by its primary key</summary>
        /// <param name="id">The primary key of the service_price</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The service_price data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("SERVICE_PRICE", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _sERVICE_PRICEService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific service_price by its primary key</summary>
        /// <param name="id">The primary key of the service_price</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("SERVICE_PRICE", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _sERVICE_PRICEService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific service_price by its primary key</summary>
        /// <param name="id">The primary key of the service_price</param>
        /// <param name="updatedEntity">The service_price data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("SERVICE_PRICE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] SERVICE_PRICE updatedEntity)
        {
            if (id != updatedEntity.GUID)
            {
                return BadRequest("Mismatched GUID");
            }

            var status = await _sERVICE_PRICEService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific service_price by its primary key</summary>
        /// <param name="id">The primary key of the service_price</param>
        /// <param name="updatedEntity">The service_price data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("SERVICE_PRICE", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<SERVICE_PRICE> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _sERVICE_PRICEService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}