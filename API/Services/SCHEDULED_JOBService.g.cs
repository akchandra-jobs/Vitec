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
    /// The scheduled_jobService responsible for managing scheduled_job related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting scheduled_job information.
    /// </remarks>
    public interface ISCHEDULED_JOBService
    {
        /// <summary>Retrieves a specific scheduled_job by its primary key</summary>
        /// <param name="id">The primary key of the scheduled_job</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The scheduled_job data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of scheduled_jobs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of scheduled_jobs</returns>
        Task<List<SCHEDULED_JOB>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new scheduled_job</summary>
        /// <param name="model">The scheduled_job data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(SCHEDULED_JOB model);

        /// <summary>Updates a specific scheduled_job by its primary key</summary>
        /// <param name="id">The primary key of the scheduled_job</param>
        /// <param name="updatedEntity">The scheduled_job data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, SCHEDULED_JOB updatedEntity);

        /// <summary>Updates a specific scheduled_job by its primary key</summary>
        /// <param name="id">The primary key of the scheduled_job</param>
        /// <param name="updatedEntity">The scheduled_job data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<SCHEDULED_JOB> updatedEntity);

        /// <summary>Deletes a specific scheduled_job by its primary key</summary>
        /// <param name="id">The primary key of the scheduled_job</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The scheduled_jobService responsible for managing scheduled_job related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting scheduled_job information.
    /// </remarks>
    public class SCHEDULED_JOBService : ISCHEDULED_JOBService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the SCHEDULED_JOB class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public SCHEDULED_JOBService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific scheduled_job by its primary key</summary>
        /// <param name="id">The primary key of the scheduled_job</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The scheduled_job data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.SCHEDULED_JOB.AsQueryable();
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

        /// <summary>Retrieves a list of scheduled_jobs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of scheduled_jobs</returns>/// <exception cref="Exception"></exception>
        public async Task<List<SCHEDULED_JOB>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetSCHEDULED_JOB(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new scheduled_job</summary>
        /// <param name="model">The scheduled_job data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(SCHEDULED_JOB model)
        {
            model.GUID = await CreateSCHEDULED_JOB(model);
            return model.GUID;
        }

        /// <summary>Updates a specific scheduled_job by its primary key</summary>
        /// <param name="id">The primary key of the scheduled_job</param>
        /// <param name="updatedEntity">The scheduled_job data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, SCHEDULED_JOB updatedEntity)
        {
            await UpdateSCHEDULED_JOB(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific scheduled_job by its primary key</summary>
        /// <param name="id">The primary key of the scheduled_job</param>
        /// <param name="updatedEntity">The scheduled_job data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<SCHEDULED_JOB> updatedEntity)
        {
            await PatchSCHEDULED_JOB(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific scheduled_job by its primary key</summary>
        /// <param name="id">The primary key of the scheduled_job</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteSCHEDULED_JOB(id);
            return true;
        }
        #region
        private async Task<List<SCHEDULED_JOB>> GetSCHEDULED_JOB(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SCHEDULED_JOB.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SCHEDULED_JOB>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SCHEDULED_JOB), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SCHEDULED_JOB, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateSCHEDULED_JOB(SCHEDULED_JOB model)
        {
            _dbContext.SCHEDULED_JOB.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateSCHEDULED_JOB(Guid id, SCHEDULED_JOB updatedEntity)
        {
            _dbContext.SCHEDULED_JOB.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteSCHEDULED_JOB(Guid id)
        {
            var entityData = _dbContext.SCHEDULED_JOB.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SCHEDULED_JOB.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchSCHEDULED_JOB(Guid id, JsonPatchDocument<SCHEDULED_JOB> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SCHEDULED_JOB.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SCHEDULED_JOB.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}