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
    /// The custom_functionService responsible for managing custom_function related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting custom_function information.
    /// </remarks>
    public interface ICUSTOM_FUNCTIONService
    {
        /// <summary>Retrieves a specific custom_function by its primary key</summary>
        /// <param name="id">The primary key of the custom_function</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The custom_function data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of custom_functions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of custom_functions</returns>
        Task<List<CUSTOM_FUNCTION>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new custom_function</summary>
        /// <param name="model">The custom_function data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(CUSTOM_FUNCTION model);

        /// <summary>Updates a specific custom_function by its primary key</summary>
        /// <param name="id">The primary key of the custom_function</param>
        /// <param name="updatedEntity">The custom_function data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, CUSTOM_FUNCTION updatedEntity);

        /// <summary>Updates a specific custom_function by its primary key</summary>
        /// <param name="id">The primary key of the custom_function</param>
        /// <param name="updatedEntity">The custom_function data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<CUSTOM_FUNCTION> updatedEntity);

        /// <summary>Deletes a specific custom_function by its primary key</summary>
        /// <param name="id">The primary key of the custom_function</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The custom_functionService responsible for managing custom_function related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting custom_function information.
    /// </remarks>
    public class CUSTOM_FUNCTIONService : ICUSTOM_FUNCTIONService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the CUSTOM_FUNCTION class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public CUSTOM_FUNCTIONService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific custom_function by its primary key</summary>
        /// <param name="id">The primary key of the custom_function</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The custom_function data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.CUSTOM_FUNCTION.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of custom_functions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of custom_functions</returns>/// <exception cref="Exception"></exception>
        public async Task<List<CUSTOM_FUNCTION>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetCUSTOM_FUNCTION(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new custom_function</summary>
        /// <param name="model">The custom_function data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(CUSTOM_FUNCTION model)
        {
            model.GUID = await CreateCUSTOM_FUNCTION(model);
            return model.GUID;
        }

        /// <summary>Updates a specific custom_function by its primary key</summary>
        /// <param name="id">The primary key of the custom_function</param>
        /// <param name="updatedEntity">The custom_function data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, CUSTOM_FUNCTION updatedEntity)
        {
            await UpdateCUSTOM_FUNCTION(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific custom_function by its primary key</summary>
        /// <param name="id">The primary key of the custom_function</param>
        /// <param name="updatedEntity">The custom_function data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<CUSTOM_FUNCTION> updatedEntity)
        {
            await PatchCUSTOM_FUNCTION(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific custom_function by its primary key</summary>
        /// <param name="id">The primary key of the custom_function</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteCUSTOM_FUNCTION(id);
            return true;
        }
        #region
        private async Task<List<CUSTOM_FUNCTION>> GetCUSTOM_FUNCTION(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CUSTOM_FUNCTION.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CUSTOM_FUNCTION>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CUSTOM_FUNCTION), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CUSTOM_FUNCTION, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateCUSTOM_FUNCTION(CUSTOM_FUNCTION model)
        {
            _dbContext.CUSTOM_FUNCTION.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateCUSTOM_FUNCTION(Guid id, CUSTOM_FUNCTION updatedEntity)
        {
            _dbContext.CUSTOM_FUNCTION.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteCUSTOM_FUNCTION(Guid id)
        {
            var entityData = _dbContext.CUSTOM_FUNCTION.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CUSTOM_FUNCTION.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchCUSTOM_FUNCTION(Guid id, JsonPatchDocument<CUSTOM_FUNCTION> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CUSTOM_FUNCTION.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CUSTOM_FUNCTION.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}