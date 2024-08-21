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
    /// The two_factor_tokenService responsible for managing two_factor_token related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting two_factor_token information.
    /// </remarks>
    public interface ITWO_FACTOR_TOKENService
    {
        /// <summary>Retrieves a specific two_factor_token by its primary key</summary>
        /// <param name="id">The primary key of the two_factor_token</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The two_factor_token data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of two_factor_tokens based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of two_factor_tokens</returns>
        Task<List<TWO_FACTOR_TOKEN>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new two_factor_token</summary>
        /// <param name="model">The two_factor_token data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(TWO_FACTOR_TOKEN model);

        /// <summary>Updates a specific two_factor_token by its primary key</summary>
        /// <param name="id">The primary key of the two_factor_token</param>
        /// <param name="updatedEntity">The two_factor_token data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, TWO_FACTOR_TOKEN updatedEntity);

        /// <summary>Updates a specific two_factor_token by its primary key</summary>
        /// <param name="id">The primary key of the two_factor_token</param>
        /// <param name="updatedEntity">The two_factor_token data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<TWO_FACTOR_TOKEN> updatedEntity);

        /// <summary>Deletes a specific two_factor_token by its primary key</summary>
        /// <param name="id">The primary key of the two_factor_token</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The two_factor_tokenService responsible for managing two_factor_token related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting two_factor_token information.
    /// </remarks>
    public class TWO_FACTOR_TOKENService : ITWO_FACTOR_TOKENService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the TWO_FACTOR_TOKEN class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public TWO_FACTOR_TOKENService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific two_factor_token by its primary key</summary>
        /// <param name="id">The primary key of the two_factor_token</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The two_factor_token data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.TWO_FACTOR_TOKEN.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_USR","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of two_factor_tokens based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of two_factor_tokens</returns>/// <exception cref="Exception"></exception>
        public async Task<List<TWO_FACTOR_TOKEN>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetTWO_FACTOR_TOKEN(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new two_factor_token</summary>
        /// <param name="model">The two_factor_token data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(TWO_FACTOR_TOKEN model)
        {
            model.GUID = await CreateTWO_FACTOR_TOKEN(model);
            return model.GUID;
        }

        /// <summary>Updates a specific two_factor_token by its primary key</summary>
        /// <param name="id">The primary key of the two_factor_token</param>
        /// <param name="updatedEntity">The two_factor_token data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, TWO_FACTOR_TOKEN updatedEntity)
        {
            await UpdateTWO_FACTOR_TOKEN(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific two_factor_token by its primary key</summary>
        /// <param name="id">The primary key of the two_factor_token</param>
        /// <param name="updatedEntity">The two_factor_token data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<TWO_FACTOR_TOKEN> updatedEntity)
        {
            await PatchTWO_FACTOR_TOKEN(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific two_factor_token by its primary key</summary>
        /// <param name="id">The primary key of the two_factor_token</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteTWO_FACTOR_TOKEN(id);
            return true;
        }
        #region
        private async Task<List<TWO_FACTOR_TOKEN>> GetTWO_FACTOR_TOKEN(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TWO_FACTOR_TOKEN.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TWO_FACTOR_TOKEN>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TWO_FACTOR_TOKEN), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TWO_FACTOR_TOKEN, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateTWO_FACTOR_TOKEN(TWO_FACTOR_TOKEN model)
        {
            _dbContext.TWO_FACTOR_TOKEN.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateTWO_FACTOR_TOKEN(Guid id, TWO_FACTOR_TOKEN updatedEntity)
        {
            _dbContext.TWO_FACTOR_TOKEN.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteTWO_FACTOR_TOKEN(Guid id)
        {
            var entityData = _dbContext.TWO_FACTOR_TOKEN.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TWO_FACTOR_TOKEN.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchTWO_FACTOR_TOKEN(Guid id, JsonPatchDocument<TWO_FACTOR_TOKEN> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TWO_FACTOR_TOKEN.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TWO_FACTOR_TOKEN.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}