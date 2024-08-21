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
    /// The resource_group_x_causeService responsible for managing resource_group_x_cause related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting resource_group_x_cause information.
    /// </remarks>
    public interface IRESOURCE_GROUP_X_CAUSEService
    {
        /// <summary>Retrieves a specific resource_group_x_cause by its primary key</summary>
        /// <param name="id">The primary key of the resource_group_x_cause</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The resource_group_x_cause data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of resource_group_x_causes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of resource_group_x_causes</returns>
        Task<List<RESOURCE_GROUP_X_CAUSE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new resource_group_x_cause</summary>
        /// <param name="model">The resource_group_x_cause data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(RESOURCE_GROUP_X_CAUSE model);

        /// <summary>Updates a specific resource_group_x_cause by its primary key</summary>
        /// <param name="id">The primary key of the resource_group_x_cause</param>
        /// <param name="updatedEntity">The resource_group_x_cause data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, RESOURCE_GROUP_X_CAUSE updatedEntity);

        /// <summary>Updates a specific resource_group_x_cause by its primary key</summary>
        /// <param name="id">The primary key of the resource_group_x_cause</param>
        /// <param name="updatedEntity">The resource_group_x_cause data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<RESOURCE_GROUP_X_CAUSE> updatedEntity);

        /// <summary>Deletes a specific resource_group_x_cause by its primary key</summary>
        /// <param name="id">The primary key of the resource_group_x_cause</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The resource_group_x_causeService responsible for managing resource_group_x_cause related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting resource_group_x_cause information.
    /// </remarks>
    public class RESOURCE_GROUP_X_CAUSEService : IRESOURCE_GROUP_X_CAUSEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the RESOURCE_GROUP_X_CAUSE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public RESOURCE_GROUP_X_CAUSEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific resource_group_x_cause by its primary key</summary>
        /// <param name="id">The primary key of the resource_group_x_cause</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The resource_group_x_cause data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.RESOURCE_GROUP_X_CAUSE.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_RESOURCE_GROUP_RESOURCE_GROUP","GUID_CAUSE_CAUSE","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of resource_group_x_causes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of resource_group_x_causes</returns>/// <exception cref="Exception"></exception>
        public async Task<List<RESOURCE_GROUP_X_CAUSE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetRESOURCE_GROUP_X_CAUSE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new resource_group_x_cause</summary>
        /// <param name="model">The resource_group_x_cause data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(RESOURCE_GROUP_X_CAUSE model)
        {
            model.GUID = await CreateRESOURCE_GROUP_X_CAUSE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific resource_group_x_cause by its primary key</summary>
        /// <param name="id">The primary key of the resource_group_x_cause</param>
        /// <param name="updatedEntity">The resource_group_x_cause data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, RESOURCE_GROUP_X_CAUSE updatedEntity)
        {
            await UpdateRESOURCE_GROUP_X_CAUSE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific resource_group_x_cause by its primary key</summary>
        /// <param name="id">The primary key of the resource_group_x_cause</param>
        /// <param name="updatedEntity">The resource_group_x_cause data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<RESOURCE_GROUP_X_CAUSE> updatedEntity)
        {
            await PatchRESOURCE_GROUP_X_CAUSE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific resource_group_x_cause by its primary key</summary>
        /// <param name="id">The primary key of the resource_group_x_cause</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteRESOURCE_GROUP_X_CAUSE(id);
            return true;
        }
        #region
        private async Task<List<RESOURCE_GROUP_X_CAUSE>> GetRESOURCE_GROUP_X_CAUSE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.RESOURCE_GROUP_X_CAUSE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<RESOURCE_GROUP_X_CAUSE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(RESOURCE_GROUP_X_CAUSE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<RESOURCE_GROUP_X_CAUSE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateRESOURCE_GROUP_X_CAUSE(RESOURCE_GROUP_X_CAUSE model)
        {
            _dbContext.RESOURCE_GROUP_X_CAUSE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateRESOURCE_GROUP_X_CAUSE(Guid id, RESOURCE_GROUP_X_CAUSE updatedEntity)
        {
            _dbContext.RESOURCE_GROUP_X_CAUSE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteRESOURCE_GROUP_X_CAUSE(Guid id)
        {
            var entityData = _dbContext.RESOURCE_GROUP_X_CAUSE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.RESOURCE_GROUP_X_CAUSE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchRESOURCE_GROUP_X_CAUSE(Guid id, JsonPatchDocument<RESOURCE_GROUP_X_CAUSE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.RESOURCE_GROUP_X_CAUSE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.RESOURCE_GROUP_X_CAUSE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}