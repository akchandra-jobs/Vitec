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
    /// The articleService responsible for managing article related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting article information.
    /// </remarks>
    public interface IARTICLEService
    {
        /// <summary>Retrieves a specific article by its primary key</summary>
        /// <param name="id">The primary key of the article</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The article data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of articles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of articles</returns>
        Task<List<ARTICLE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new article</summary>
        /// <param name="model">The article data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(ARTICLE model);

        /// <summary>Updates a specific article by its primary key</summary>
        /// <param name="id">The primary key of the article</param>
        /// <param name="updatedEntity">The article data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, ARTICLE updatedEntity);

        /// <summary>Updates a specific article by its primary key</summary>
        /// <param name="id">The primary key of the article</param>
        /// <param name="updatedEntity">The article data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<ARTICLE> updatedEntity);

        /// <summary>Deletes a specific article by its primary key</summary>
        /// <param name="id">The primary key of the article</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The articleService responsible for managing article related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting article information.
    /// </remarks>
    public class ARTICLEService : IARTICLEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the ARTICLE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ARTICLEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific article by its primary key</summary>
        /// <param name="id">The primary key of the article</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The article data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.ARTICLE.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_DEPARTMENT_DEPARTMENT","GUID_ACCOUNTING0_ACCOUNTING","GUID_ACCOUNTING1_ACCOUNTING","GUID_ACCOUNTING2_ACCOUNTING","GUID_ACCOUNTING3_ACCOUNTING","GUID_ACCOUNTING4_ACCOUNTING","GUID_ACCOUNT_ACCOUNT","GUID_COST_CENTER_COST_CENTER","GUID_SERVICE_SERVICE"];
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

        /// <summary>Retrieves a list of articles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of articles</returns>/// <exception cref="Exception"></exception>
        public async Task<List<ARTICLE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetARTICLE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new article</summary>
        /// <param name="model">The article data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(ARTICLE model)
        {
            model.GUID = await CreateARTICLE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific article by its primary key</summary>
        /// <param name="id">The primary key of the article</param>
        /// <param name="updatedEntity">The article data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, ARTICLE updatedEntity)
        {
            await UpdateARTICLE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific article by its primary key</summary>
        /// <param name="id">The primary key of the article</param>
        /// <param name="updatedEntity">The article data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<ARTICLE> updatedEntity)
        {
            await PatchARTICLE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific article by its primary key</summary>
        /// <param name="id">The primary key of the article</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteARTICLE(id);
            return true;
        }
        #region
        private async Task<List<ARTICLE>> GetARTICLE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ARTICLE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ARTICLE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ARTICLE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ARTICLE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateARTICLE(ARTICLE model)
        {
            _dbContext.ARTICLE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateARTICLE(Guid id, ARTICLE updatedEntity)
        {
            _dbContext.ARTICLE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteARTICLE(Guid id)
        {
            var entityData = _dbContext.ARTICLE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ARTICLE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchARTICLE(Guid id, JsonPatchDocument<ARTICLE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ARTICLE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ARTICLE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}