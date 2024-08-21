using Vitec.Models;
using Vitec.Data;
using Vitec.Filter;
using Vitec.Entities;
using Vitec.Logger;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using Task = System.Threading.Tasks.Task;

namespace Vitec.Services
{
    /// <summary>
    /// The price_sheet_category_priceService responsible for managing price_sheet_category_price related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting price_sheet_category_price information.
    /// </remarks>
    public interface IPRICE_SHEET_CATEGORY_PRICEService
    {
        /// <summary>Retrieves a specific price_sheet_category_price by its primary key</summary>
        /// <param name="id">The primary key of the price_sheet_category_price</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The price_sheet_category_price data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of price_sheet_category_prices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of price_sheet_category_prices</returns>
        Task<List<PRICE_SHEET_CATEGORY_PRICE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new price_sheet_category_price</summary>
        /// <param name="model">The price_sheet_category_price data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PRICE_SHEET_CATEGORY_PRICE model);

        /// <summary>Updates a specific price_sheet_category_price by its primary key</summary>
        /// <param name="id">The primary key of the price_sheet_category_price</param>
        /// <param name="updatedEntity">The price_sheet_category_price data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PRICE_SHEET_CATEGORY_PRICE updatedEntity);

        /// <summary>Updates a specific price_sheet_category_price by its primary key</summary>
        /// <param name="id">The primary key of the price_sheet_category_price</param>
        /// <param name="updatedEntity">The price_sheet_category_price data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PRICE_SHEET_CATEGORY_PRICE> updatedEntity);

        /// <summary>Deletes a specific price_sheet_category_price by its primary key</summary>
        /// <param name="id">The primary key of the price_sheet_category_price</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The price_sheet_category_priceService responsible for managing price_sheet_category_price related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting price_sheet_category_price information.
    /// </remarks>
    public class PRICE_SHEET_CATEGORY_PRICEService : IPRICE_SHEET_CATEGORY_PRICEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PRICE_SHEET_CATEGORY_PRICE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PRICE_SHEET_CATEGORY_PRICEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific price_sheet_category_price by its primary key</summary>
        /// <param name="id">The primary key of the price_sheet_category_price</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The price_sheet_category_price data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PRICE_SHEET_CATEGORY_PRICE.AsQueryable();
            List<string> allfields = new List<string>();
            if (!string.IsNullOrEmpty(fields))
            {
                allfields.AddRange(fields.Split(","));
                fields = $"GUID,{fields}";
            }
            else
            {
                fields = "GUID";
            }

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_PRICE_SHEET_REVISION_PRICE_SHEET_REVISION","GUID_AREA_CATEGORY_AREA_CATEGORY"];
            foreach (var navigationProperty in navigationProperties)
            {
                if (allfields.Any(field => field.StartsWith(navigationProperty + ".", StringComparison.OrdinalIgnoreCase)))
                {
                    query = query.Include(navigationProperty);
                }
            }

            query = query.Where(entity => entity.GUID == id);
            return _mapper.MapToFields(await query.FirstOrDefaultAsync(),fields);
        }

        /// <summary>Retrieves a list of price_sheet_category_prices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of price_sheet_category_prices</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PRICE_SHEET_CATEGORY_PRICE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPRICE_SHEET_CATEGORY_PRICE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new price_sheet_category_price</summary>
        /// <param name="model">The price_sheet_category_price data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PRICE_SHEET_CATEGORY_PRICE model)
        {
            model.GUID = await CreatePRICE_SHEET_CATEGORY_PRICE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific price_sheet_category_price by its primary key</summary>
        /// <param name="id">The primary key of the price_sheet_category_price</param>
        /// <param name="updatedEntity">The price_sheet_category_price data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PRICE_SHEET_CATEGORY_PRICE updatedEntity)
        {
            await UpdatePRICE_SHEET_CATEGORY_PRICE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific price_sheet_category_price by its primary key</summary>
        /// <param name="id">The primary key of the price_sheet_category_price</param>
        /// <param name="updatedEntity">The price_sheet_category_price data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PRICE_SHEET_CATEGORY_PRICE> updatedEntity)
        {
            await PatchPRICE_SHEET_CATEGORY_PRICE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific price_sheet_category_price by its primary key</summary>
        /// <param name="id">The primary key of the price_sheet_category_price</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePRICE_SHEET_CATEGORY_PRICE(id);
            return true;
        }
        #region
        private async Task<List<PRICE_SHEET_CATEGORY_PRICE>> GetPRICE_SHEET_CATEGORY_PRICE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PRICE_SHEET_CATEGORY_PRICE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PRICE_SHEET_CATEGORY_PRICE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PRICE_SHEET_CATEGORY_PRICE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PRICE_SHEET_CATEGORY_PRICE, object>>(Expression.Convert(property, typeof(object)), parameter);
                if (sortOrder.Equals("asc", StringComparison.OrdinalIgnoreCase))
                {
                    result = result.OrderBy(lambda);
                }
                else if (sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    result = result.OrderByDescending(lambda);
                }
                else
                {
                    throw new ApplicationException("Invalid sort order. Use 'asc' or 'desc'");
                }
            }

            var paginatedResult = await result.Skip(skip).Take(pageSize).ToListAsync();
            return paginatedResult;
        }

        private async Task<Guid> CreatePRICE_SHEET_CATEGORY_PRICE(PRICE_SHEET_CATEGORY_PRICE model)
        {
            _dbContext.PRICE_SHEET_CATEGORY_PRICE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePRICE_SHEET_CATEGORY_PRICE(Guid id, PRICE_SHEET_CATEGORY_PRICE updatedEntity)
        {
            _dbContext.PRICE_SHEET_CATEGORY_PRICE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePRICE_SHEET_CATEGORY_PRICE(Guid id)
        {
            var entityData = _dbContext.PRICE_SHEET_CATEGORY_PRICE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PRICE_SHEET_CATEGORY_PRICE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPRICE_SHEET_CATEGORY_PRICE(Guid id, JsonPatchDocument<PRICE_SHEET_CATEGORY_PRICE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PRICE_SHEET_CATEGORY_PRICE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PRICE_SHEET_CATEGORY_PRICE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}