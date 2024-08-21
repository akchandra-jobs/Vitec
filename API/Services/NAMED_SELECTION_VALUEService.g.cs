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
    /// The named_selection_valueService responsible for managing named_selection_value related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting named_selection_value information.
    /// </remarks>
    public interface INAMED_SELECTION_VALUEService
    {
        /// <summary>Retrieves a specific named_selection_value by its primary key</summary>
        /// <param name="id">The primary key of the named_selection_value</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The named_selection_value data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of named_selection_values based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of named_selection_values</returns>
        Task<List<NAMED_SELECTION_VALUE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new named_selection_value</summary>
        /// <param name="model">The named_selection_value data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(NAMED_SELECTION_VALUE model);

        /// <summary>Updates a specific named_selection_value by its primary key</summary>
        /// <param name="id">The primary key of the named_selection_value</param>
        /// <param name="updatedEntity">The named_selection_value data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, NAMED_SELECTION_VALUE updatedEntity);

        /// <summary>Updates a specific named_selection_value by its primary key</summary>
        /// <param name="id">The primary key of the named_selection_value</param>
        /// <param name="updatedEntity">The named_selection_value data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<NAMED_SELECTION_VALUE> updatedEntity);

        /// <summary>Deletes a specific named_selection_value by its primary key</summary>
        /// <param name="id">The primary key of the named_selection_value</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The named_selection_valueService responsible for managing named_selection_value related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting named_selection_value information.
    /// </remarks>
    public class NAMED_SELECTION_VALUEService : INAMED_SELECTION_VALUEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the NAMED_SELECTION_VALUE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public NAMED_SELECTION_VALUEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific named_selection_value by its primary key</summary>
        /// <param name="id">The primary key of the named_selection_value</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The named_selection_value data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.NAMED_SELECTION_VALUE.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_NAMED_SELECTION_NAMED_SELECTION"];
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

        /// <summary>Retrieves a list of named_selection_values based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of named_selection_values</returns>/// <exception cref="Exception"></exception>
        public async Task<List<NAMED_SELECTION_VALUE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetNAMED_SELECTION_VALUE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new named_selection_value</summary>
        /// <param name="model">The named_selection_value data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(NAMED_SELECTION_VALUE model)
        {
            model.GUID = await CreateNAMED_SELECTION_VALUE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific named_selection_value by its primary key</summary>
        /// <param name="id">The primary key of the named_selection_value</param>
        /// <param name="updatedEntity">The named_selection_value data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, NAMED_SELECTION_VALUE updatedEntity)
        {
            await UpdateNAMED_SELECTION_VALUE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific named_selection_value by its primary key</summary>
        /// <param name="id">The primary key of the named_selection_value</param>
        /// <param name="updatedEntity">The named_selection_value data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<NAMED_SELECTION_VALUE> updatedEntity)
        {
            await PatchNAMED_SELECTION_VALUE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific named_selection_value by its primary key</summary>
        /// <param name="id">The primary key of the named_selection_value</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteNAMED_SELECTION_VALUE(id);
            return true;
        }
        #region
        private async Task<List<NAMED_SELECTION_VALUE>> GetNAMED_SELECTION_VALUE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.NAMED_SELECTION_VALUE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<NAMED_SELECTION_VALUE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(NAMED_SELECTION_VALUE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<NAMED_SELECTION_VALUE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateNAMED_SELECTION_VALUE(NAMED_SELECTION_VALUE model)
        {
            _dbContext.NAMED_SELECTION_VALUE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateNAMED_SELECTION_VALUE(Guid id, NAMED_SELECTION_VALUE updatedEntity)
        {
            _dbContext.NAMED_SELECTION_VALUE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteNAMED_SELECTION_VALUE(Guid id)
        {
            var entityData = _dbContext.NAMED_SELECTION_VALUE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.NAMED_SELECTION_VALUE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchNAMED_SELECTION_VALUE(Guid id, JsonPatchDocument<NAMED_SELECTION_VALUE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.NAMED_SELECTION_VALUE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.NAMED_SELECTION_VALUE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}