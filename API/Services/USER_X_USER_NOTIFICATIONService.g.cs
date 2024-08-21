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
    /// The user_x_user_notificationService responsible for managing user_x_user_notification related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting user_x_user_notification information.
    /// </remarks>
    public interface IUSER_X_USER_NOTIFICATIONService
    {
        /// <summary>Retrieves a specific user_x_user_notification by its primary key</summary>
        /// <param name="id">The primary key of the user_x_user_notification</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The user_x_user_notification data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of user_x_user_notifications based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of user_x_user_notifications</returns>
        Task<List<USER_X_USER_NOTIFICATION>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new user_x_user_notification</summary>
        /// <param name="model">The user_x_user_notification data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(USER_X_USER_NOTIFICATION model);

        /// <summary>Updates a specific user_x_user_notification by its primary key</summary>
        /// <param name="id">The primary key of the user_x_user_notification</param>
        /// <param name="updatedEntity">The user_x_user_notification data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, USER_X_USER_NOTIFICATION updatedEntity);

        /// <summary>Updates a specific user_x_user_notification by its primary key</summary>
        /// <param name="id">The primary key of the user_x_user_notification</param>
        /// <param name="updatedEntity">The user_x_user_notification data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<USER_X_USER_NOTIFICATION> updatedEntity);

        /// <summary>Deletes a specific user_x_user_notification by its primary key</summary>
        /// <param name="id">The primary key of the user_x_user_notification</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The user_x_user_notificationService responsible for managing user_x_user_notification related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting user_x_user_notification information.
    /// </remarks>
    public class USER_X_USER_NOTIFICATIONService : IUSER_X_USER_NOTIFICATIONService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the USER_X_USER_NOTIFICATION class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public USER_X_USER_NOTIFICATIONService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific user_x_user_notification by its primary key</summary>
        /// <param name="id">The primary key of the user_x_user_notification</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The user_x_user_notification data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.USER_X_USER_NOTIFICATION.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_USR","GUID_USER_NOTIFICATION_USER_NOTIFICATION","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of user_x_user_notifications based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of user_x_user_notifications</returns>/// <exception cref="Exception"></exception>
        public async Task<List<USER_X_USER_NOTIFICATION>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetUSER_X_USER_NOTIFICATION(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new user_x_user_notification</summary>
        /// <param name="model">The user_x_user_notification data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(USER_X_USER_NOTIFICATION model)
        {
            model.GUID = await CreateUSER_X_USER_NOTIFICATION(model);
            return model.GUID;
        }

        /// <summary>Updates a specific user_x_user_notification by its primary key</summary>
        /// <param name="id">The primary key of the user_x_user_notification</param>
        /// <param name="updatedEntity">The user_x_user_notification data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, USER_X_USER_NOTIFICATION updatedEntity)
        {
            await UpdateUSER_X_USER_NOTIFICATION(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific user_x_user_notification by its primary key</summary>
        /// <param name="id">The primary key of the user_x_user_notification</param>
        /// <param name="updatedEntity">The user_x_user_notification data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<USER_X_USER_NOTIFICATION> updatedEntity)
        {
            await PatchUSER_X_USER_NOTIFICATION(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific user_x_user_notification by its primary key</summary>
        /// <param name="id">The primary key of the user_x_user_notification</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteUSER_X_USER_NOTIFICATION(id);
            return true;
        }
        #region
        private async Task<List<USER_X_USER_NOTIFICATION>> GetUSER_X_USER_NOTIFICATION(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.USER_X_USER_NOTIFICATION.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<USER_X_USER_NOTIFICATION>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(USER_X_USER_NOTIFICATION), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<USER_X_USER_NOTIFICATION, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateUSER_X_USER_NOTIFICATION(USER_X_USER_NOTIFICATION model)
        {
            _dbContext.USER_X_USER_NOTIFICATION.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateUSER_X_USER_NOTIFICATION(Guid id, USER_X_USER_NOTIFICATION updatedEntity)
        {
            _dbContext.USER_X_USER_NOTIFICATION.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteUSER_X_USER_NOTIFICATION(Guid id)
        {
            var entityData = _dbContext.USER_X_USER_NOTIFICATION.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.USER_X_USER_NOTIFICATION.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchUSER_X_USER_NOTIFICATION(Guid id, JsonPatchDocument<USER_X_USER_NOTIFICATION> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.USER_X_USER_NOTIFICATION.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.USER_X_USER_NOTIFICATION.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}