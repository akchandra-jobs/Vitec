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
    /// The api_request_logService responsible for managing api_request_log related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting api_request_log information.
    /// </remarks>
    public interface IAPI_REQUEST_LOGService
    {
        /// <summary>Retrieves a specific api_request_log by its primary key</summary>
        /// <param name="id">The primary key of the api_request_log</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The api_request_log data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of api_request_logs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of api_request_logs</returns>
        Task<List<API_REQUEST_LOG>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new api_request_log</summary>
        /// <param name="model">The api_request_log data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(API_REQUEST_LOG model);

        /// <summary>Updates a specific api_request_log by its primary key</summary>
        /// <param name="id">The primary key of the api_request_log</param>
        /// <param name="updatedEntity">The api_request_log data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, API_REQUEST_LOG updatedEntity);

        /// <summary>Updates a specific api_request_log by its primary key</summary>
        /// <param name="id">The primary key of the api_request_log</param>
        /// <param name="updatedEntity">The api_request_log data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<API_REQUEST_LOG> updatedEntity);

        /// <summary>Deletes a specific api_request_log by its primary key</summary>
        /// <param name="id">The primary key of the api_request_log</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The api_request_logService responsible for managing api_request_log related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting api_request_log information.
    /// </remarks>
    public class API_REQUEST_LOGService : IAPI_REQUEST_LOGService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the API_REQUEST_LOG class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public API_REQUEST_LOGService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific api_request_log by its primary key</summary>
        /// <param name="id">The primary key of the api_request_log</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The api_request_log data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.API_REQUEST_LOG.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_ENTITY_TASK_ENTITY_TASK","GUID_SCHEDULED_JOB_SCHEDULED_JOB"];
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

        /// <summary>Retrieves a list of api_request_logs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of api_request_logs</returns>/// <exception cref="Exception"></exception>
        public async Task<List<API_REQUEST_LOG>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetAPI_REQUEST_LOG(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new api_request_log</summary>
        /// <param name="model">The api_request_log data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(API_REQUEST_LOG model)
        {
            model.GUID = await CreateAPI_REQUEST_LOG(model);
            return model.GUID;
        }

        /// <summary>Updates a specific api_request_log by its primary key</summary>
        /// <param name="id">The primary key of the api_request_log</param>
        /// <param name="updatedEntity">The api_request_log data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, API_REQUEST_LOG updatedEntity)
        {
            await UpdateAPI_REQUEST_LOG(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific api_request_log by its primary key</summary>
        /// <param name="id">The primary key of the api_request_log</param>
        /// <param name="updatedEntity">The api_request_log data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<API_REQUEST_LOG> updatedEntity)
        {
            await PatchAPI_REQUEST_LOG(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific api_request_log by its primary key</summary>
        /// <param name="id">The primary key of the api_request_log</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteAPI_REQUEST_LOG(id);
            return true;
        }
        #region
        private async Task<List<API_REQUEST_LOG>> GetAPI_REQUEST_LOG(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.API_REQUEST_LOG.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<API_REQUEST_LOG>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(API_REQUEST_LOG), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<API_REQUEST_LOG, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateAPI_REQUEST_LOG(API_REQUEST_LOG model)
        {
            _dbContext.API_REQUEST_LOG.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateAPI_REQUEST_LOG(Guid id, API_REQUEST_LOG updatedEntity)
        {
            _dbContext.API_REQUEST_LOG.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteAPI_REQUEST_LOG(Guid id)
        {
            var entityData = _dbContext.API_REQUEST_LOG.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.API_REQUEST_LOG.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchAPI_REQUEST_LOG(Guid id, JsonPatchDocument<API_REQUEST_LOG> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.API_REQUEST_LOG.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.API_REQUEST_LOG.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}