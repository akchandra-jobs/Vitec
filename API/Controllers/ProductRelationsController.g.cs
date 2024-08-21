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
    /// Controller responsible for managing productrelations related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting productrelations information.
    /// </remarks>
    [Route("api/productrelations")]
    [Authorize]
    public class ProductRelationsController : BaseApiController
    {
        private readonly IProductRelationsService _productRelationsService;

        /// <summary>
        /// Initializes a new instance of the ProductRelationsController class with the specified context.
        /// </summary>
        /// <param name="iproductrelationsservice">The iproductrelationsservice to be used by the controller.</param>
        public ProductRelationsController(IProductRelationsService iproductrelationsservice)
        {
            _productRelationsService = iproductrelationsservice;
        }

        /// <summary>Adds a new productrelations</summary>
        /// <param name="model">The productrelations data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ProductRelations", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] ProductRelations model)
        {
            var id = await _productRelationsService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of productrelationss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productrelationss</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ProductRelations", Entitlements.Read)]
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

            var result = await _productRelationsService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific productrelations by its primary key</summary>
        /// <param name="id">The primary key of the productrelations</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The productrelations data</returns>
        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("ProductRelations", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Int64 id, string fields = null)
        {
            var result = await _productRelationsService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific productrelations by its primary key</summary>
        /// <param name="id">The primary key of the productrelations</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:long}")]
        [UserAuthorize("ProductRelations", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Int64 id)
        {
            var status = await _productRelationsService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific productrelations by its primary key</summary>
        /// <param name="id">The primary key of the productrelations</param>
        /// <param name="updatedEntity">The productrelations data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ProductRelations", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Int64 id, [FromBody] ProductRelations updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            var status = await _productRelationsService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific productrelations by its primary key</summary>
        /// <param name="id">The primary key of the productrelations</param>
        /// <param name="updatedEntity">The productrelations data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("ProductRelations", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Int64 id, [FromBody] JsonPatchDocument<ProductRelations> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _productRelationsService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}