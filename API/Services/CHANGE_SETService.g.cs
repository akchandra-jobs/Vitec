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
    /// The change_setService responsible for managing change_set related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting change_set information.
    /// </remarks>
    public interface ICHANGE_SETService
    {
        /// <summary>Retrieves a specific change_set by its primary key</summary>
        /// <param name="id">The primary key of the change_set</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The change_set data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of change_sets based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of change_sets</returns>
        Task<List<CHANGE_SET>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new change_set</summary>
        /// <param name="model">The change_set data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(CHANGE_SET model);

        /// <summary>Updates a specific change_set by its primary key</summary>
        /// <param name="id">The primary key of the change_set</param>
        /// <param name="updatedEntity">The change_set data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, CHANGE_SET updatedEntity);

        /// <summary>Updates a specific change_set by its primary key</summary>
        /// <param name="id">The primary key of the change_set</param>
        /// <param name="updatedEntity">The change_set data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<CHANGE_SET> updatedEntity);

        /// <summary>Deletes a specific change_set by its primary key</summary>
        /// <param name="id">The primary key of the change_set</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The change_setService responsible for managing change_set related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting change_set information.
    /// </remarks>
    public class CHANGE_SETService : ICHANGE_SETService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the CHANGE_SET class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public CHANGE_SETService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific change_set by its primary key</summary>
        /// <param name="id">The primary key of the change_set</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The change_set data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.CHANGE_SET.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER"];
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

        /// <summary>Retrieves a list of change_sets based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of change_sets</returns>/// <exception cref="Exception"></exception>
        public async Task<List<CHANGE_SET>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetCHANGE_SET(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new change_set</summary>
        /// <param name="model">The change_set data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(CHANGE_SET model)
        {
            model.GUID = await CreateCHANGE_SET(model);
            return model.GUID;
        }

        /// <summary>Updates a specific change_set by its primary key</summary>
        /// <param name="id">The primary key of the change_set</param>
        /// <param name="updatedEntity">The change_set data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, CHANGE_SET updatedEntity)
        {
            await UpdateCHANGE_SET(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific change_set by its primary key</summary>
        /// <param name="id">The primary key of the change_set</param>
        /// <param name="updatedEntity">The change_set data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<CHANGE_SET> updatedEntity)
        {
            await PatchCHANGE_SET(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific change_set by its primary key</summary>
        /// <param name="id">The primary key of the change_set</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteCHANGE_SET(id);
            return true;
        }
        #region
        private async Task<List<CHANGE_SET>> GetCHANGE_SET(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CHANGE_SET.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CHANGE_SET>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CHANGE_SET), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CHANGE_SET, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateCHANGE_SET(CHANGE_SET model)
        {
            _dbContext.CHANGE_SET.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateCHANGE_SET(Guid id, CHANGE_SET updatedEntity)
        {
            _dbContext.CHANGE_SET.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteCHANGE_SET(Guid id)
        {
            var entityData = _dbContext.CHANGE_SET.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CHANGE_SET.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchCHANGE_SET(Guid id, JsonPatchDocument<CHANGE_SET> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CHANGE_SET.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CHANGE_SET.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}