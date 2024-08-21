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
    /// The relationshipService responsible for managing relationship related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting relationship information.
    /// </remarks>
    public interface IRELATIONSHIPService
    {
        /// <summary>Retrieves a specific relationship by its primary key</summary>
        /// <param name="id">The primary key of the relationship</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The relationship data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of relationships based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of relationships</returns>
        Task<List<RELATIONSHIP>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new relationship</summary>
        /// <param name="model">The relationship data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(RELATIONSHIP model);

        /// <summary>Updates a specific relationship by its primary key</summary>
        /// <param name="id">The primary key of the relationship</param>
        /// <param name="updatedEntity">The relationship data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, RELATIONSHIP updatedEntity);

        /// <summary>Updates a specific relationship by its primary key</summary>
        /// <param name="id">The primary key of the relationship</param>
        /// <param name="updatedEntity">The relationship data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<RELATIONSHIP> updatedEntity);

        /// <summary>Deletes a specific relationship by its primary key</summary>
        /// <param name="id">The primary key of the relationship</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The relationshipService responsible for managing relationship related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting relationship information.
    /// </remarks>
    public class RELATIONSHIPService : IRELATIONSHIPService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the RELATIONSHIP class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public RELATIONSHIPService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific relationship by its primary key</summary>
        /// <param name="id">The primary key of the relationship</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The relationship data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.RELATIONSHIP.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_RELATIONSHIP_TYPE_RELATIONSHIP_TYPE"];
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

        /// <summary>Retrieves a list of relationships based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of relationships</returns>/// <exception cref="Exception"></exception>
        public async Task<List<RELATIONSHIP>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetRELATIONSHIP(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new relationship</summary>
        /// <param name="model">The relationship data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(RELATIONSHIP model)
        {
            model.GUID = await CreateRELATIONSHIP(model);
            return model.GUID;
        }

        /// <summary>Updates a specific relationship by its primary key</summary>
        /// <param name="id">The primary key of the relationship</param>
        /// <param name="updatedEntity">The relationship data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, RELATIONSHIP updatedEntity)
        {
            await UpdateRELATIONSHIP(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific relationship by its primary key</summary>
        /// <param name="id">The primary key of the relationship</param>
        /// <param name="updatedEntity">The relationship data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<RELATIONSHIP> updatedEntity)
        {
            await PatchRELATIONSHIP(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific relationship by its primary key</summary>
        /// <param name="id">The primary key of the relationship</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteRELATIONSHIP(id);
            return true;
        }
        #region
        private async Task<List<RELATIONSHIP>> GetRELATIONSHIP(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.RELATIONSHIP.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<RELATIONSHIP>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(RELATIONSHIP), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<RELATIONSHIP, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateRELATIONSHIP(RELATIONSHIP model)
        {
            _dbContext.RELATIONSHIP.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateRELATIONSHIP(Guid id, RELATIONSHIP updatedEntity)
        {
            _dbContext.RELATIONSHIP.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteRELATIONSHIP(Guid id)
        {
            var entityData = _dbContext.RELATIONSHIP.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.RELATIONSHIP.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchRELATIONSHIP(Guid id, JsonPatchDocument<RELATIONSHIP> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.RELATIONSHIP.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.RELATIONSHIP.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}