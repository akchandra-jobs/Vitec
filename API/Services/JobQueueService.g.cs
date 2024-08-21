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
    /// The jobqueueService responsible for managing jobqueue related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting jobqueue information.
    /// </remarks>
    public interface IJobQueueService
    {
        /// <summary>Retrieves a specific jobqueue by its primary key</summary>
        /// <param name="id">The primary key of the jobqueue</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The jobqueue data</returns>
        Task<dynamic> GetById(int id, string fields);

        /// <summary>Retrieves a list of jobqueues based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of jobqueues</returns>
        Task<List<JobQueue>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new jobqueue</summary>
        /// <param name="model">The jobqueue data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<int> Create(JobQueue model);

        /// <summary>Updates a specific jobqueue by its primary key</summary>
        /// <param name="id">The primary key of the jobqueue</param>
        /// <param name="updatedEntity">The jobqueue data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(int id, JobQueue updatedEntity);

        /// <summary>Updates a specific jobqueue by its primary key</summary>
        /// <param name="id">The primary key of the jobqueue</param>
        /// <param name="updatedEntity">The jobqueue data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(int id, JsonPatchDocument<JobQueue> updatedEntity);

        /// <summary>Deletes a specific jobqueue by its primary key</summary>
        /// <param name="id">The primary key of the jobqueue</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(int id);
    }

    /// <summary>
    /// The jobqueueService responsible for managing jobqueue related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting jobqueue information.
    /// </remarks>
    public class JobQueueService : IJobQueueService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the JobQueue class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public JobQueueService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific jobqueue by its primary key</summary>
        /// <param name="id">The primary key of the jobqueue</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The jobqueue data</returns>
        public async Task<dynamic> GetById(int id, string fields)
        {
            var query = _dbContext.JobQueue.AsQueryable();
            List<string> allfields = new List<string>();
            if (!string.IsNullOrEmpty(fields))
            {
                allfields.AddRange(fields.Split(","));
                fields = $"Id,{fields}";
            }
            else
            {
                fields = "Id";
            }

            string[] navigationProperties = [];
            foreach (var navigationProperty in navigationProperties)
            {
                if (allfields.Any(field => field.StartsWith(navigationProperty + ".", StringComparison.OrdinalIgnoreCase)))
                {
                    query = query.Include(navigationProperty);
                }
            }

            query = query.Where(entity => entity.Id == id);
            return _mapper.MapToFields(await query.FirstOrDefaultAsync(),fields);
        }

        /// <summary>Retrieves a list of jobqueues based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of jobqueues</returns>/// <exception cref="Exception"></exception>
        public async Task<List<JobQueue>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetJobQueue(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new jobqueue</summary>
        /// <param name="model">The jobqueue data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<int> Create(JobQueue model)
        {
            model.Id = await CreateJobQueue(model);
            return model.Id;
        }

        /// <summary>Updates a specific jobqueue by its primary key</summary>
        /// <param name="id">The primary key of the jobqueue</param>
        /// <param name="updatedEntity">The jobqueue data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(int id, JobQueue updatedEntity)
        {
            await UpdateJobQueue(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific jobqueue by its primary key</summary>
        /// <param name="id">The primary key of the jobqueue</param>
        /// <param name="updatedEntity">The jobqueue data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(int id, JsonPatchDocument<JobQueue> updatedEntity)
        {
            await PatchJobQueue(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific jobqueue by its primary key</summary>
        /// <param name="id">The primary key of the jobqueue</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(int id)
        {
            await DeleteJobQueue(id);
            return true;
        }
        #region
        private async Task<List<JobQueue>> GetJobQueue(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.JobQueue.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<JobQueue>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(JobQueue), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<JobQueue, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<int> CreateJobQueue(JobQueue model)
        {
            _dbContext.JobQueue.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        private async Task UpdateJobQueue(int id, JobQueue updatedEntity)
        {
            _dbContext.JobQueue.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteJobQueue(int id)
        {
            var entityData = _dbContext.JobQueue.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.JobQueue.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchJobQueue(int id, JsonPatchDocument<JobQueue> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.JobQueue.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.JobQueue.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}