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
    /// The jobparameterService responsible for managing jobparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting jobparameter information.
    /// </remarks>
    public interface IJobParameterService
    {
        /// <summary>Retrieves a specific jobparameter by its primary key</summary>
        /// <param name="id">The primary key of the jobparameter</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The jobparameter data</returns>
        Task<dynamic> GetById(int id, string fields);

        /// <summary>Retrieves a list of jobparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of jobparameters</returns>
        Task<List<JobParameter>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new jobparameter</summary>
        /// <param name="model">The jobparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<int> Create(JobParameter model);

        /// <summary>Updates a specific jobparameter by its primary key</summary>
        /// <param name="id">The primary key of the jobparameter</param>
        /// <param name="updatedEntity">The jobparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(int id, JobParameter updatedEntity);

        /// <summary>Updates a specific jobparameter by its primary key</summary>
        /// <param name="id">The primary key of the jobparameter</param>
        /// <param name="updatedEntity">The jobparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(int id, JsonPatchDocument<JobParameter> updatedEntity);

        /// <summary>Deletes a specific jobparameter by its primary key</summary>
        /// <param name="id">The primary key of the jobparameter</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(int id);
    }

    /// <summary>
    /// The jobparameterService responsible for managing jobparameter related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting jobparameter information.
    /// </remarks>
    public class JobParameterService : IJobParameterService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the JobParameter class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public JobParameterService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific jobparameter by its primary key</summary>
        /// <param name="id">The primary key of the jobparameter</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The jobparameter data</returns>
        public async Task<dynamic> GetById(int id, string fields)
        {
            var query = _dbContext.JobParameter.AsQueryable();
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

            string[] navigationProperties = ["JobId_Job"];
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

        /// <summary>Retrieves a list of jobparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of jobparameters</returns>/// <exception cref="Exception"></exception>
        public async Task<List<JobParameter>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetJobParameter(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new jobparameter</summary>
        /// <param name="model">The jobparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<int> Create(JobParameter model)
        {
            model.Id = await CreateJobParameter(model);
            return model.Id;
        }

        /// <summary>Updates a specific jobparameter by its primary key</summary>
        /// <param name="id">The primary key of the jobparameter</param>
        /// <param name="updatedEntity">The jobparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(int id, JobParameter updatedEntity)
        {
            await UpdateJobParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific jobparameter by its primary key</summary>
        /// <param name="id">The primary key of the jobparameter</param>
        /// <param name="updatedEntity">The jobparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(int id, JsonPatchDocument<JobParameter> updatedEntity)
        {
            await PatchJobParameter(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific jobparameter by its primary key</summary>
        /// <param name="id">The primary key of the jobparameter</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(int id)
        {
            await DeleteJobParameter(id);
            return true;
        }
        #region
        private async Task<List<JobParameter>> GetJobParameter(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.JobParameter.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<JobParameter>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(JobParameter), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<JobParameter, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<int> CreateJobParameter(JobParameter model)
        {
            _dbContext.JobParameter.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        private async Task UpdateJobParameter(int id, JobParameter updatedEntity)
        {
            _dbContext.JobParameter.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteJobParameter(int id)
        {
            var entityData = _dbContext.JobParameter.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.JobParameter.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchJobParameter(int id, JsonPatchDocument<JobParameter> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.JobParameter.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.JobParameter.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}