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
    /// The duty_log_groupService responsible for managing duty_log_group related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting duty_log_group information.
    /// </remarks>
    public interface IDUTY_LOG_GROUPService
    {
        /// <summary>Retrieves a specific duty_log_group by its primary key</summary>
        /// <param name="id">The primary key of the duty_log_group</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The duty_log_group data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of duty_log_groups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of duty_log_groups</returns>
        Task<List<DUTY_LOG_GROUP>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new duty_log_group</summary>
        /// <param name="model">The duty_log_group data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(DUTY_LOG_GROUP model);

        /// <summary>Updates a specific duty_log_group by its primary key</summary>
        /// <param name="id">The primary key of the duty_log_group</param>
        /// <param name="updatedEntity">The duty_log_group data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, DUTY_LOG_GROUP updatedEntity);

        /// <summary>Updates a specific duty_log_group by its primary key</summary>
        /// <param name="id">The primary key of the duty_log_group</param>
        /// <param name="updatedEntity">The duty_log_group data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<DUTY_LOG_GROUP> updatedEntity);

        /// <summary>Deletes a specific duty_log_group by its primary key</summary>
        /// <param name="id">The primary key of the duty_log_group</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The duty_log_groupService responsible for managing duty_log_group related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting duty_log_group information.
    /// </remarks>
    public class DUTY_LOG_GROUPService : IDUTY_LOG_GROUPService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the DUTY_LOG_GROUP class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public DUTY_LOG_GROUPService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific duty_log_group by its primary key</summary>
        /// <param name="id">The primary key of the duty_log_group</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The duty_log_group data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.DUTY_LOG_GROUP.AsQueryable();
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

        /// <summary>Retrieves a list of duty_log_groups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of duty_log_groups</returns>/// <exception cref="Exception"></exception>
        public async Task<List<DUTY_LOG_GROUP>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetDUTY_LOG_GROUP(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new duty_log_group</summary>
        /// <param name="model">The duty_log_group data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(DUTY_LOG_GROUP model)
        {
            model.GUID = await CreateDUTY_LOG_GROUP(model);
            return model.GUID;
        }

        /// <summary>Updates a specific duty_log_group by its primary key</summary>
        /// <param name="id">The primary key of the duty_log_group</param>
        /// <param name="updatedEntity">The duty_log_group data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, DUTY_LOG_GROUP updatedEntity)
        {
            await UpdateDUTY_LOG_GROUP(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific duty_log_group by its primary key</summary>
        /// <param name="id">The primary key of the duty_log_group</param>
        /// <param name="updatedEntity">The duty_log_group data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<DUTY_LOG_GROUP> updatedEntity)
        {
            await PatchDUTY_LOG_GROUP(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific duty_log_group by its primary key</summary>
        /// <param name="id">The primary key of the duty_log_group</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteDUTY_LOG_GROUP(id);
            return true;
        }
        #region
        private async Task<List<DUTY_LOG_GROUP>> GetDUTY_LOG_GROUP(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DUTY_LOG_GROUP.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DUTY_LOG_GROUP>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DUTY_LOG_GROUP), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DUTY_LOG_GROUP, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateDUTY_LOG_GROUP(DUTY_LOG_GROUP model)
        {
            _dbContext.DUTY_LOG_GROUP.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateDUTY_LOG_GROUP(Guid id, DUTY_LOG_GROUP updatedEntity)
        {
            _dbContext.DUTY_LOG_GROUP.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteDUTY_LOG_GROUP(Guid id)
        {
            var entityData = _dbContext.DUTY_LOG_GROUP.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DUTY_LOG_GROUP.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchDUTY_LOG_GROUP(Guid id, JsonPatchDocument<DUTY_LOG_GROUP> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DUTY_LOG_GROUP.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DUTY_LOG_GROUP.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}