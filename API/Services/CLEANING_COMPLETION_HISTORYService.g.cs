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
    /// The cleaning_completion_historyService responsible for managing cleaning_completion_history related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cleaning_completion_history information.
    /// </remarks>
    public interface ICLEANING_COMPLETION_HISTORYService
    {
        /// <summary>Retrieves a specific cleaning_completion_history by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_completion_history</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The cleaning_completion_history data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of cleaning_completion_historys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cleaning_completion_historys</returns>
        Task<List<CLEANING_COMPLETION_HISTORY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new cleaning_completion_history</summary>
        /// <param name="model">The cleaning_completion_history data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(CLEANING_COMPLETION_HISTORY model);

        /// <summary>Updates a specific cleaning_completion_history by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_completion_history</param>
        /// <param name="updatedEntity">The cleaning_completion_history data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, CLEANING_COMPLETION_HISTORY updatedEntity);

        /// <summary>Updates a specific cleaning_completion_history by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_completion_history</param>
        /// <param name="updatedEntity">The cleaning_completion_history data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<CLEANING_COMPLETION_HISTORY> updatedEntity);

        /// <summary>Deletes a specific cleaning_completion_history by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_completion_history</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The cleaning_completion_historyService responsible for managing cleaning_completion_history related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cleaning_completion_history information.
    /// </remarks>
    public class CLEANING_COMPLETION_HISTORYService : ICLEANING_COMPLETION_HISTORYService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the CLEANING_COMPLETION_HISTORY class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public CLEANING_COMPLETION_HISTORYService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific cleaning_completion_history by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_completion_history</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The cleaning_completion_history data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.CLEANING_COMPLETION_HISTORY.AsQueryable();
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

        /// <summary>Retrieves a list of cleaning_completion_historys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cleaning_completion_historys</returns>/// <exception cref="Exception"></exception>
        public async Task<List<CLEANING_COMPLETION_HISTORY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetCLEANING_COMPLETION_HISTORY(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new cleaning_completion_history</summary>
        /// <param name="model">The cleaning_completion_history data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(CLEANING_COMPLETION_HISTORY model)
        {
            model.GUID = await CreateCLEANING_COMPLETION_HISTORY(model);
            return model.GUID;
        }

        /// <summary>Updates a specific cleaning_completion_history by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_completion_history</param>
        /// <param name="updatedEntity">The cleaning_completion_history data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, CLEANING_COMPLETION_HISTORY updatedEntity)
        {
            await UpdateCLEANING_COMPLETION_HISTORY(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific cleaning_completion_history by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_completion_history</param>
        /// <param name="updatedEntity">The cleaning_completion_history data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<CLEANING_COMPLETION_HISTORY> updatedEntity)
        {
            await PatchCLEANING_COMPLETION_HISTORY(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific cleaning_completion_history by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_completion_history</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteCLEANING_COMPLETION_HISTORY(id);
            return true;
        }
        #region
        private async Task<List<CLEANING_COMPLETION_HISTORY>> GetCLEANING_COMPLETION_HISTORY(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CLEANING_COMPLETION_HISTORY.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CLEANING_COMPLETION_HISTORY>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CLEANING_COMPLETION_HISTORY), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CLEANING_COMPLETION_HISTORY, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateCLEANING_COMPLETION_HISTORY(CLEANING_COMPLETION_HISTORY model)
        {
            _dbContext.CLEANING_COMPLETION_HISTORY.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateCLEANING_COMPLETION_HISTORY(Guid id, CLEANING_COMPLETION_HISTORY updatedEntity)
        {
            _dbContext.CLEANING_COMPLETION_HISTORY.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteCLEANING_COMPLETION_HISTORY(Guid id)
        {
            var entityData = _dbContext.CLEANING_COMPLETION_HISTORY.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CLEANING_COMPLETION_HISTORY.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchCLEANING_COMPLETION_HISTORY(Guid id, JsonPatchDocument<CLEANING_COMPLETION_HISTORY> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CLEANING_COMPLETION_HISTORY.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CLEANING_COMPLETION_HISTORY.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}