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
    /// The log_performanceService responsible for managing log_performance related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting log_performance information.
    /// </remarks>
    public interface ILOG_PERFORMANCEService
    {
        /// <summary>Retrieves a specific log_performance by its primary key</summary>
        /// <param name="id">The primary key of the log_performance</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The log_performance data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of log_performances based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of log_performances</returns>
        Task<List<LOG_PERFORMANCE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new log_performance</summary>
        /// <param name="model">The log_performance data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(LOG_PERFORMANCE model);

        /// <summary>Updates a specific log_performance by its primary key</summary>
        /// <param name="id">The primary key of the log_performance</param>
        /// <param name="updatedEntity">The log_performance data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, LOG_PERFORMANCE updatedEntity);

        /// <summary>Updates a specific log_performance by its primary key</summary>
        /// <param name="id">The primary key of the log_performance</param>
        /// <param name="updatedEntity">The log_performance data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<LOG_PERFORMANCE> updatedEntity);

        /// <summary>Deletes a specific log_performance by its primary key</summary>
        /// <param name="id">The primary key of the log_performance</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The log_performanceService responsible for managing log_performance related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting log_performance information.
    /// </remarks>
    public class LOG_PERFORMANCEService : ILOG_PERFORMANCEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the LOG_PERFORMANCE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public LOG_PERFORMANCEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific log_performance by its primary key</summary>
        /// <param name="id">The primary key of the log_performance</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The log_performance data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.LOG_PERFORMANCE.AsQueryable();
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

            string[] navigationProperties = [];
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

        /// <summary>Retrieves a list of log_performances based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of log_performances</returns>/// <exception cref="Exception"></exception>
        public async Task<List<LOG_PERFORMANCE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetLOG_PERFORMANCE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new log_performance</summary>
        /// <param name="model">The log_performance data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(LOG_PERFORMANCE model)
        {
            model.GUID = await CreateLOG_PERFORMANCE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific log_performance by its primary key</summary>
        /// <param name="id">The primary key of the log_performance</param>
        /// <param name="updatedEntity">The log_performance data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, LOG_PERFORMANCE updatedEntity)
        {
            await UpdateLOG_PERFORMANCE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific log_performance by its primary key</summary>
        /// <param name="id">The primary key of the log_performance</param>
        /// <param name="updatedEntity">The log_performance data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<LOG_PERFORMANCE> updatedEntity)
        {
            await PatchLOG_PERFORMANCE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific log_performance by its primary key</summary>
        /// <param name="id">The primary key of the log_performance</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteLOG_PERFORMANCE(id);
            return true;
        }
        #region
        private async Task<List<LOG_PERFORMANCE>> GetLOG_PERFORMANCE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.LOG_PERFORMANCE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<LOG_PERFORMANCE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(LOG_PERFORMANCE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<LOG_PERFORMANCE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateLOG_PERFORMANCE(LOG_PERFORMANCE model)
        {
            _dbContext.LOG_PERFORMANCE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateLOG_PERFORMANCE(Guid id, LOG_PERFORMANCE updatedEntity)
        {
            _dbContext.LOG_PERFORMANCE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteLOG_PERFORMANCE(Guid id)
        {
            var entityData = _dbContext.LOG_PERFORMANCE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.LOG_PERFORMANCE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchLOG_PERFORMANCE(Guid id, JsonPatchDocument<LOG_PERFORMANCE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.LOG_PERFORMANCE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.LOG_PERFORMANCE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}