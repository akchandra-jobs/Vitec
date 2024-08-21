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
    /// The door_key_x_userService responsible for managing door_key_x_user related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting door_key_x_user information.
    /// </remarks>
    public interface IDOOR_KEY_X_USERService
    {
        /// <summary>Retrieves a specific door_key_x_user by its primary key</summary>
        /// <param name="id">The primary key of the door_key_x_user</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The door_key_x_user data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of door_key_x_users based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of door_key_x_users</returns>
        Task<List<DOOR_KEY_X_USER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new door_key_x_user</summary>
        /// <param name="model">The door_key_x_user data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(DOOR_KEY_X_USER model);

        /// <summary>Updates a specific door_key_x_user by its primary key</summary>
        /// <param name="id">The primary key of the door_key_x_user</param>
        /// <param name="updatedEntity">The door_key_x_user data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, DOOR_KEY_X_USER updatedEntity);

        /// <summary>Updates a specific door_key_x_user by its primary key</summary>
        /// <param name="id">The primary key of the door_key_x_user</param>
        /// <param name="updatedEntity">The door_key_x_user data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<DOOR_KEY_X_USER> updatedEntity);

        /// <summary>Deletes a specific door_key_x_user by its primary key</summary>
        /// <param name="id">The primary key of the door_key_x_user</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The door_key_x_userService responsible for managing door_key_x_user related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting door_key_x_user information.
    /// </remarks>
    public class DOOR_KEY_X_USERService : IDOOR_KEY_X_USERService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the DOOR_KEY_X_USER class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public DOOR_KEY_X_USERService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific door_key_x_user by its primary key</summary>
        /// <param name="id">The primary key of the door_key_x_user</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The door_key_x_user data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.DOOR_KEY_X_USER.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_DOOR_KEY_DOOR_KEY","GUID_PERSON_PERSON","GUID_CUSTOMER_CUSTOMER"];
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

        /// <summary>Retrieves a list of door_key_x_users based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of door_key_x_users</returns>/// <exception cref="Exception"></exception>
        public async Task<List<DOOR_KEY_X_USER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetDOOR_KEY_X_USER(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new door_key_x_user</summary>
        /// <param name="model">The door_key_x_user data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(DOOR_KEY_X_USER model)
        {
            model.GUID = await CreateDOOR_KEY_X_USER(model);
            return model.GUID;
        }

        /// <summary>Updates a specific door_key_x_user by its primary key</summary>
        /// <param name="id">The primary key of the door_key_x_user</param>
        /// <param name="updatedEntity">The door_key_x_user data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, DOOR_KEY_X_USER updatedEntity)
        {
            await UpdateDOOR_KEY_X_USER(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific door_key_x_user by its primary key</summary>
        /// <param name="id">The primary key of the door_key_x_user</param>
        /// <param name="updatedEntity">The door_key_x_user data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<DOOR_KEY_X_USER> updatedEntity)
        {
            await PatchDOOR_KEY_X_USER(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific door_key_x_user by its primary key</summary>
        /// <param name="id">The primary key of the door_key_x_user</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteDOOR_KEY_X_USER(id);
            return true;
        }
        #region
        private async Task<List<DOOR_KEY_X_USER>> GetDOOR_KEY_X_USER(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DOOR_KEY_X_USER.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DOOR_KEY_X_USER>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DOOR_KEY_X_USER), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DOOR_KEY_X_USER, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateDOOR_KEY_X_USER(DOOR_KEY_X_USER model)
        {
            _dbContext.DOOR_KEY_X_USER.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateDOOR_KEY_X_USER(Guid id, DOOR_KEY_X_USER updatedEntity)
        {
            _dbContext.DOOR_KEY_X_USER.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteDOOR_KEY_X_USER(Guid id)
        {
            var entityData = _dbContext.DOOR_KEY_X_USER.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DOOR_KEY_X_USER.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchDOOR_KEY_X_USER(Guid id, JsonPatchDocument<DOOR_KEY_X_USER> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DOOR_KEY_X_USER.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DOOR_KEY_X_USER.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}