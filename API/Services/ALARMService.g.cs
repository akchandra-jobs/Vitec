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
    /// The alarmService responsible for managing alarm related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting alarm information.
    /// </remarks>
    public interface IALARMService
    {
        /// <summary>Retrieves a specific alarm by its primary key</summary>
        /// <param name="id">The primary key of the alarm</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The alarm data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of alarms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of alarms</returns>
        Task<List<ALARM>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new alarm</summary>
        /// <param name="model">The alarm data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(ALARM model);

        /// <summary>Updates a specific alarm by its primary key</summary>
        /// <param name="id">The primary key of the alarm</param>
        /// <param name="updatedEntity">The alarm data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, ALARM updatedEntity);

        /// <summary>Updates a specific alarm by its primary key</summary>
        /// <param name="id">The primary key of the alarm</param>
        /// <param name="updatedEntity">The alarm data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<ALARM> updatedEntity);

        /// <summary>Deletes a specific alarm by its primary key</summary>
        /// <param name="id">The primary key of the alarm</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The alarmService responsible for managing alarm related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting alarm information.
    /// </remarks>
    public class ALARMService : IALARMService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the ALARM class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ALARMService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific alarm by its primary key</summary>
        /// <param name="id">The primary key of the alarm</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The alarm data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.ALARM.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of alarms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of alarms</returns>/// <exception cref="Exception"></exception>
        public async Task<List<ALARM>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetALARM(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new alarm</summary>
        /// <param name="model">The alarm data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(ALARM model)
        {
            model.GUID = await CreateALARM(model);
            return model.GUID;
        }

        /// <summary>Updates a specific alarm by its primary key</summary>
        /// <param name="id">The primary key of the alarm</param>
        /// <param name="updatedEntity">The alarm data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, ALARM updatedEntity)
        {
            await UpdateALARM(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific alarm by its primary key</summary>
        /// <param name="id">The primary key of the alarm</param>
        /// <param name="updatedEntity">The alarm data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<ALARM> updatedEntity)
        {
            await PatchALARM(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific alarm by its primary key</summary>
        /// <param name="id">The primary key of the alarm</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteALARM(id);
            return true;
        }
        #region
        private async Task<List<ALARM>> GetALARM(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ALARM.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ALARM>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ALARM), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ALARM, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateALARM(ALARM model)
        {
            _dbContext.ALARM.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateALARM(Guid id, ALARM updatedEntity)
        {
            _dbContext.ALARM.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteALARM(Guid id)
        {
            var entityData = _dbContext.ALARM.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ALARM.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchALARM(Guid id, JsonPatchDocument<ALARM> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ALARM.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ALARM.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}