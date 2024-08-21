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
    /// The energy_periodic_taskService responsible for managing energy_periodic_task related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting energy_periodic_task information.
    /// </remarks>
    public interface IENERGY_PERIODIC_TASKService
    {
        /// <summary>Retrieves a specific energy_periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the energy_periodic_task</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The energy_periodic_task data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of energy_periodic_tasks based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of energy_periodic_tasks</returns>
        Task<List<ENERGY_PERIODIC_TASK>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new energy_periodic_task</summary>
        /// <param name="model">The energy_periodic_task data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(ENERGY_PERIODIC_TASK model);

        /// <summary>Updates a specific energy_periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the energy_periodic_task</param>
        /// <param name="updatedEntity">The energy_periodic_task data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, ENERGY_PERIODIC_TASK updatedEntity);

        /// <summary>Updates a specific energy_periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the energy_periodic_task</param>
        /// <param name="updatedEntity">The energy_periodic_task data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<ENERGY_PERIODIC_TASK> updatedEntity);

        /// <summary>Deletes a specific energy_periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the energy_periodic_task</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The energy_periodic_taskService responsible for managing energy_periodic_task related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting energy_periodic_task information.
    /// </remarks>
    public class ENERGY_PERIODIC_TASKService : IENERGY_PERIODIC_TASKService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the ENERGY_PERIODIC_TASK class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ENERGY_PERIODIC_TASKService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific energy_periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the energy_periodic_task</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The energy_periodic_task data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.ENERGY_PERIODIC_TASK.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_USER_ENDED_BY_USR","GUID_ENERGY_BLOCK_ENERGY_BLOCK","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of energy_periodic_tasks based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of energy_periodic_tasks</returns>/// <exception cref="Exception"></exception>
        public async Task<List<ENERGY_PERIODIC_TASK>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetENERGY_PERIODIC_TASK(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new energy_periodic_task</summary>
        /// <param name="model">The energy_periodic_task data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(ENERGY_PERIODIC_TASK model)
        {
            model.GUID = await CreateENERGY_PERIODIC_TASK(model);
            return model.GUID;
        }

        /// <summary>Updates a specific energy_periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the energy_periodic_task</param>
        /// <param name="updatedEntity">The energy_periodic_task data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, ENERGY_PERIODIC_TASK updatedEntity)
        {
            await UpdateENERGY_PERIODIC_TASK(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific energy_periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the energy_periodic_task</param>
        /// <param name="updatedEntity">The energy_periodic_task data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<ENERGY_PERIODIC_TASK> updatedEntity)
        {
            await PatchENERGY_PERIODIC_TASK(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific energy_periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the energy_periodic_task</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteENERGY_PERIODIC_TASK(id);
            return true;
        }
        #region
        private async Task<List<ENERGY_PERIODIC_TASK>> GetENERGY_PERIODIC_TASK(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ENERGY_PERIODIC_TASK.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ENERGY_PERIODIC_TASK>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ENERGY_PERIODIC_TASK), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ENERGY_PERIODIC_TASK, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateENERGY_PERIODIC_TASK(ENERGY_PERIODIC_TASK model)
        {
            _dbContext.ENERGY_PERIODIC_TASK.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateENERGY_PERIODIC_TASK(Guid id, ENERGY_PERIODIC_TASK updatedEntity)
        {
            _dbContext.ENERGY_PERIODIC_TASK.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteENERGY_PERIODIC_TASK(Guid id)
        {
            var entityData = _dbContext.ENERGY_PERIODIC_TASK.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ENERGY_PERIODIC_TASK.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchENERGY_PERIODIC_TASK(Guid id, JsonPatchDocument<ENERGY_PERIODIC_TASK> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ENERGY_PERIODIC_TASK.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ENERGY_PERIODIC_TASK.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}