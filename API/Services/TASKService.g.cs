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
    /// The taskService responsible for managing task related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting task information.
    /// </remarks>
    public interface ITASKService
    {
        /// <summary>Retrieves a specific task by its primary key</summary>
        /// <param name="id">The primary key of the task</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The task data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of tasks based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tasks</returns>
        Task<List<Entities.TASK>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new task</summary>
        /// <param name="model">The task data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(Entities.TASK model);

        /// <summary>Updates a specific task by its primary key</summary>
        /// <param name="id">The primary key of the task</param>
        /// <param name="updatedEntity">The task data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, Entities.TASK updatedEntity);

        /// <summary>Updates a specific task by its primary key</summary>
        /// <param name="id">The primary key of the task</param>
        /// <param name="updatedEntity">The task data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<Entities.TASK> updatedEntity);

        /// <summary>Deletes a specific task by its primary key</summary>
        /// <param name="id">The primary key of the task</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The taskService responsible for managing task related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting task information.
    /// </remarks>
    public class TASKService : ITASKService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the TASK class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public TASKService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific task by its primary key</summary>
        /// <param name="id">The primary key of the task</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The task data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.TASK.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_PARENT_TASK_TASK"];
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

        /// <summary>Retrieves a list of tasks based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of tasks</returns>/// <exception cref="Exception"></exception>
        public async Task<List<Entities.TASK>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetTASK(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new task</summary>
        /// <param name="model">The task data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(Entities.TASK model)
        {
            model.GUID = await CreateTASK(model);
            return model.GUID;
        }

        /// <summary>Updates a specific task by its primary key</summary>
        /// <param name="id">The primary key of the task</param>
        /// <param name="updatedEntity">The task data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, Entities.TASK updatedEntity)
        {
            await UpdateTASK(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific task by its primary key</summary>
        /// <param name="id">The primary key of the task</param>
        /// <param name="updatedEntity">The task data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<Entities.TASK> updatedEntity)
        {
            await PatchTASK(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific task by its primary key</summary>
        /// <param name="id">The primary key of the task</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteTASK(id);
            return true;
        }
        #region
        private async Task<List<Entities.TASK>> GetTASK(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TASK.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Entities.TASK>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Entities.TASK), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Entities.TASK, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateTASK(Entities.TASK model)
        {
            _dbContext.TASK.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateTASK(Guid id, Entities.TASK updatedEntity)
        {
            _dbContext.TASK.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteTASK(Guid id)
        {
            var entityData = _dbContext.TASK.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TASK.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchTASK(Guid id, JsonPatchDocument<Entities.TASK> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TASK.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TASK.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}