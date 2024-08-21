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
    /// The service_priceService responsible for managing service_price related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting service_price information.
    /// </remarks>
    public interface ISERVICE_PRICEService
    {
        /// <summary>Retrieves a specific service_price by its primary key</summary>
        /// <param name="id">The primary key of the service_price</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The service_price data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of service_prices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of service_prices</returns>
        Task<List<SERVICE_PRICE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new service_price</summary>
        /// <param name="model">The service_price data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(SERVICE_PRICE model);

        /// <summary>Updates a specific service_price by its primary key</summary>
        /// <param name="id">The primary key of the service_price</param>
        /// <param name="updatedEntity">The service_price data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, SERVICE_PRICE updatedEntity);

        /// <summary>Updates a specific service_price by its primary key</summary>
        /// <param name="id">The primary key of the service_price</param>
        /// <param name="updatedEntity">The service_price data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<SERVICE_PRICE> updatedEntity);

        /// <summary>Deletes a specific service_price by its primary key</summary>
        /// <param name="id">The primary key of the service_price</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The service_priceService responsible for managing service_price related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting service_price information.
    /// </remarks>
    public class SERVICE_PRICEService : ISERVICE_PRICEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the SERVICE_PRICE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public SERVICE_PRICEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific service_price by its primary key</summary>
        /// <param name="id">The primary key of the service_price</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The service_price data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.SERVICE_PRICE.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_AREA_CATEGORY_AREA_CATEGORY","GUID_PRICE_SHEET_REVISION_PRICE_SHEET_REVISION","GUID_SERVICE_SERVICE","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of service_prices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of service_prices</returns>/// <exception cref="Exception"></exception>
        public async Task<List<SERVICE_PRICE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetSERVICE_PRICE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new service_price</summary>
        /// <param name="model">The service_price data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(SERVICE_PRICE model)
        {
            model.GUID = await CreateSERVICE_PRICE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific service_price by its primary key</summary>
        /// <param name="id">The primary key of the service_price</param>
        /// <param name="updatedEntity">The service_price data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, SERVICE_PRICE updatedEntity)
        {
            await UpdateSERVICE_PRICE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific service_price by its primary key</summary>
        /// <param name="id">The primary key of the service_price</param>
        /// <param name="updatedEntity">The service_price data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<SERVICE_PRICE> updatedEntity)
        {
            await PatchSERVICE_PRICE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific service_price by its primary key</summary>
        /// <param name="id">The primary key of the service_price</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteSERVICE_PRICE(id);
            return true;
        }
        #region
        private async Task<List<SERVICE_PRICE>> GetSERVICE_PRICE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SERVICE_PRICE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SERVICE_PRICE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SERVICE_PRICE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SERVICE_PRICE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateSERVICE_PRICE(SERVICE_PRICE model)
        {
            _dbContext.SERVICE_PRICE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateSERVICE_PRICE(Guid id, SERVICE_PRICE updatedEntity)
        {
            _dbContext.SERVICE_PRICE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteSERVICE_PRICE(Guid id)
        {
            var entityData = _dbContext.SERVICE_PRICE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SERVICE_PRICE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchSERVICE_PRICE(Guid id, JsonPatchDocument<SERVICE_PRICE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SERVICE_PRICE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SERVICE_PRICE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}