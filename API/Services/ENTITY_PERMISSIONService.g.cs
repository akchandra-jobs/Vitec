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
    /// The entity_permissionService responsible for managing entity_permission related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting entity_permission information.
    /// </remarks>
    public interface IENTITY_PERMISSIONService
    {
        /// <summary>Retrieves a specific entity_permission by its primary key</summary>
        /// <param name="id">The primary key of the entity_permission</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The entity_permission data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of entity_permissions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of entity_permissions</returns>
        Task<List<ENTITY_PERMISSION>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new entity_permission</summary>
        /// <param name="model">The entity_permission data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(ENTITY_PERMISSION model);

        /// <summary>Updates a specific entity_permission by its primary key</summary>
        /// <param name="id">The primary key of the entity_permission</param>
        /// <param name="updatedEntity">The entity_permission data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, ENTITY_PERMISSION updatedEntity);

        /// <summary>Updates a specific entity_permission by its primary key</summary>
        /// <param name="id">The primary key of the entity_permission</param>
        /// <param name="updatedEntity">The entity_permission data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<ENTITY_PERMISSION> updatedEntity);

        /// <summary>Deletes a specific entity_permission by its primary key</summary>
        /// <param name="id">The primary key of the entity_permission</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The entity_permissionService responsible for managing entity_permission related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting entity_permission information.
    /// </remarks>
    public class ENTITY_PERMISSIONService : IENTITY_PERMISSIONService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the ENTITY_PERMISSION class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ENTITY_PERMISSIONService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific entity_permission by its primary key</summary>
        /// <param name="id">The primary key of the entity_permission</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The entity_permission data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.ENTITY_PERMISSION.AsQueryable();
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

            string[] navigationProperties = ["GUID_ENTITY_PERMISSION_PROFILE_ENTITY_PERMISSION_PROFILE","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of entity_permissions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of entity_permissions</returns>/// <exception cref="Exception"></exception>
        public async Task<List<ENTITY_PERMISSION>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetENTITY_PERMISSION(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new entity_permission</summary>
        /// <param name="model">The entity_permission data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(ENTITY_PERMISSION model)
        {
            model.GUID = await CreateENTITY_PERMISSION(model);
            return model.GUID;
        }

        /// <summary>Updates a specific entity_permission by its primary key</summary>
        /// <param name="id">The primary key of the entity_permission</param>
        /// <param name="updatedEntity">The entity_permission data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, ENTITY_PERMISSION updatedEntity)
        {
            await UpdateENTITY_PERMISSION(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific entity_permission by its primary key</summary>
        /// <param name="id">The primary key of the entity_permission</param>
        /// <param name="updatedEntity">The entity_permission data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<ENTITY_PERMISSION> updatedEntity)
        {
            await PatchENTITY_PERMISSION(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific entity_permission by its primary key</summary>
        /// <param name="id">The primary key of the entity_permission</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteENTITY_PERMISSION(id);
            return true;
        }
        #region
        private async Task<List<ENTITY_PERMISSION>> GetENTITY_PERMISSION(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ENTITY_PERMISSION.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ENTITY_PERMISSION>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ENTITY_PERMISSION), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ENTITY_PERMISSION, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateENTITY_PERMISSION(ENTITY_PERMISSION model)
        {
            _dbContext.ENTITY_PERMISSION.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateENTITY_PERMISSION(Guid id, ENTITY_PERMISSION updatedEntity)
        {
            _dbContext.ENTITY_PERMISSION.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteENTITY_PERMISSION(Guid id)
        {
            var entityData = _dbContext.ENTITY_PERMISSION.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ENTITY_PERMISSION.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchENTITY_PERMISSION(Guid id, JsonPatchDocument<ENTITY_PERMISSION> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ENTITY_PERMISSION.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ENTITY_PERMISSION.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}