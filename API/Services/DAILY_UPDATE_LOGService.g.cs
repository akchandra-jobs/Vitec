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
    /// The daily_update_logService responsible for managing daily_update_log related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting daily_update_log information.
    /// </remarks>
    public interface IDAILY_UPDATE_LOGService
    {
        /// <summary>Retrieves a specific daily_update_log by its primary key</summary>
        /// <param name="id">The primary key of the daily_update_log</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The daily_update_log data</returns>
        Task<dynamic> GetById(int id, string fields);

        /// <summary>Retrieves a list of daily_update_logs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of daily_update_logs</returns>
        Task<List<DAILY_UPDATE_LOG>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new daily_update_log</summary>
        /// <param name="model">The daily_update_log data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<int> Create(DAILY_UPDATE_LOG model);

        /// <summary>Updates a specific daily_update_log by its primary key</summary>
        /// <param name="id">The primary key of the daily_update_log</param>
        /// <param name="updatedEntity">The daily_update_log data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(int id, DAILY_UPDATE_LOG updatedEntity);

        /// <summary>Updates a specific daily_update_log by its primary key</summary>
        /// <param name="id">The primary key of the daily_update_log</param>
        /// <param name="updatedEntity">The daily_update_log data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(int id, JsonPatchDocument<DAILY_UPDATE_LOG> updatedEntity);

        /// <summary>Deletes a specific daily_update_log by its primary key</summary>
        /// <param name="id">The primary key of the daily_update_log</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(int id);
    }

    /// <summary>
    /// The daily_update_logService responsible for managing daily_update_log related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting daily_update_log information.
    /// </remarks>
    public class DAILY_UPDATE_LOGService : IDAILY_UPDATE_LOGService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the DAILY_UPDATE_LOG class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public DAILY_UPDATE_LOGService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific daily_update_log by its primary key</summary>
        /// <param name="id">The primary key of the daily_update_log</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The daily_update_log data</returns>
        public async Task<dynamic> GetById(int id, string fields)
        {
            var query = _dbContext.DAILY_UPDATE_LOG.AsQueryable();
            List<string> allfields = new List<string>();
            if (!string.IsNullOrEmpty(fields))
            {
                allfields.AddRange(fields.Split(","));
                fields = $"ID,{fields}";
            }
            else
            {
                fields = "ID";
            }

            string[] navigationProperties = [];
            foreach (var navigationProperty in navigationProperties)
            {
                if (allfields.Any(field => field.StartsWith(navigationProperty + ".", StringComparison.OrdinalIgnoreCase)))
                {
                    query = query.Include(navigationProperty);
                }
            }

            query = query.Where(entity => entity.ID == id);
            return _mapper.MapToFields(await query.FirstOrDefaultAsync(),fields);
        }

        /// <summary>Retrieves a list of daily_update_logs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of daily_update_logs</returns>/// <exception cref="Exception"></exception>
        public async Task<List<DAILY_UPDATE_LOG>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetDAILY_UPDATE_LOG(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new daily_update_log</summary>
        /// <param name="model">The daily_update_log data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<int> Create(DAILY_UPDATE_LOG model)
        {
            model.ID = await CreateDAILY_UPDATE_LOG(model);
            return model.ID;
        }

        /// <summary>Updates a specific daily_update_log by its primary key</summary>
        /// <param name="id">The primary key of the daily_update_log</param>
        /// <param name="updatedEntity">The daily_update_log data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(int id, DAILY_UPDATE_LOG updatedEntity)
        {
            await UpdateDAILY_UPDATE_LOG(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific daily_update_log by its primary key</summary>
        /// <param name="id">The primary key of the daily_update_log</param>
        /// <param name="updatedEntity">The daily_update_log data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(int id, JsonPatchDocument<DAILY_UPDATE_LOG> updatedEntity)
        {
            await PatchDAILY_UPDATE_LOG(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific daily_update_log by its primary key</summary>
        /// <param name="id">The primary key of the daily_update_log</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(int id)
        {
            await DeleteDAILY_UPDATE_LOG(id);
            return true;
        }
        #region
        private async Task<List<DAILY_UPDATE_LOG>> GetDAILY_UPDATE_LOG(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DAILY_UPDATE_LOG.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DAILY_UPDATE_LOG>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DAILY_UPDATE_LOG), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DAILY_UPDATE_LOG, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<int> CreateDAILY_UPDATE_LOG(DAILY_UPDATE_LOG model)
        {
            _dbContext.DAILY_UPDATE_LOG.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.ID;
        }

        private async Task UpdateDAILY_UPDATE_LOG(int id, DAILY_UPDATE_LOG updatedEntity)
        {
            _dbContext.DAILY_UPDATE_LOG.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteDAILY_UPDATE_LOG(int id)
        {
            var entityData = _dbContext.DAILY_UPDATE_LOG.FirstOrDefault(entity => entity.ID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DAILY_UPDATE_LOG.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchDAILY_UPDATE_LOG(int id, JsonPatchDocument<DAILY_UPDATE_LOG> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DAILY_UPDATE_LOG.FirstOrDefault(t => t.ID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DAILY_UPDATE_LOG.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}