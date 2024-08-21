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
    /// The jobService responsible for managing job related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting job information.
    /// </remarks>
    public interface IJobService
    {
        /// <summary>Retrieves a specific job by its primary key</summary>
        /// <param name="id">The primary key of the job</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The job data</returns>
        Task<dynamic> GetById(int id, string fields);

        /// <summary>Retrieves a list of jobs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of jobs</returns>
        Task<List<Job>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new job</summary>
        /// <param name="model">The job data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<int> Create(Job model);

        /// <summary>Updates a specific job by its primary key</summary>
        /// <param name="id">The primary key of the job</param>
        /// <param name="updatedEntity">The job data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(int id, Job updatedEntity);

        /// <summary>Updates a specific job by its primary key</summary>
        /// <param name="id">The primary key of the job</param>
        /// <param name="updatedEntity">The job data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(int id, JsonPatchDocument<Job> updatedEntity);

        /// <summary>Deletes a specific job by its primary key</summary>
        /// <param name="id">The primary key of the job</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(int id);
    }

    /// <summary>
    /// The jobService responsible for managing job related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting job information.
    /// </remarks>
    public class JobService : IJobService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the Job class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public JobService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific job by its primary key</summary>
        /// <param name="id">The primary key of the job</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The job data</returns>
        public async Task<dynamic> GetById(int id, string fields)
        {
            var query = _dbContext.Job.AsQueryable();
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

        /// <summary>Retrieves a list of jobs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of jobs</returns>/// <exception cref="Exception"></exception>
        public async Task<List<Job>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetJob(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new job</summary>
        /// <param name="model">The job data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<int> Create(Job model)
        {
            model.Id = await CreateJob(model);
            return model.Id;
        }

        /// <summary>Updates a specific job by its primary key</summary>
        /// <param name="id">The primary key of the job</param>
        /// <param name="updatedEntity">The job data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(int id, Job updatedEntity)
        {
            await UpdateJob(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific job by its primary key</summary>
        /// <param name="id">The primary key of the job</param>
        /// <param name="updatedEntity">The job data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(int id, JsonPatchDocument<Job> updatedEntity)
        {
            await PatchJob(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific job by its primary key</summary>
        /// <param name="id">The primary key of the job</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(int id)
        {
            await DeleteJob(id);
            return true;
        }
        #region
        private async Task<List<Job>> GetJob(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Job.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Job>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Job), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Job, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<int> CreateJob(Job model)
        {
            _dbContext.Job.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        private async Task UpdateJob(int id, Job updatedEntity)
        {
            _dbContext.Job.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteJob(int id)
        {
            var entityData = _dbContext.Job.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Job.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchJob(int id, JsonPatchDocument<Job> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Job.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Job.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}