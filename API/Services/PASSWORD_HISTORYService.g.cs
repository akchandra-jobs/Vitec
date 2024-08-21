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
    /// The password_historyService responsible for managing password_history related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting password_history information.
    /// </remarks>
    public interface IPASSWORD_HISTORYService
    {
        /// <summary>Retrieves a specific password_history by its primary key</summary>
        /// <param name="id">The primary key of the password_history</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The password_history data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of password_historys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of password_historys</returns>
        Task<List<PASSWORD_HISTORY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new password_history</summary>
        /// <param name="model">The password_history data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PASSWORD_HISTORY model);

        /// <summary>Updates a specific password_history by its primary key</summary>
        /// <param name="id">The primary key of the password_history</param>
        /// <param name="updatedEntity">The password_history data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PASSWORD_HISTORY updatedEntity);

        /// <summary>Updates a specific password_history by its primary key</summary>
        /// <param name="id">The primary key of the password_history</param>
        /// <param name="updatedEntity">The password_history data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PASSWORD_HISTORY> updatedEntity);

        /// <summary>Deletes a specific password_history by its primary key</summary>
        /// <param name="id">The primary key of the password_history</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The password_historyService responsible for managing password_history related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting password_history information.
    /// </remarks>
    public class PASSWORD_HISTORYService : IPASSWORD_HISTORYService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PASSWORD_HISTORY class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PASSWORD_HISTORYService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific password_history by its primary key</summary>
        /// <param name="id">The primary key of the password_history</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The password_history data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PASSWORD_HISTORY.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_USR","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of password_historys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of password_historys</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PASSWORD_HISTORY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPASSWORD_HISTORY(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new password_history</summary>
        /// <param name="model">The password_history data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PASSWORD_HISTORY model)
        {
            model.GUID = await CreatePASSWORD_HISTORY(model);
            return model.GUID;
        }

        /// <summary>Updates a specific password_history by its primary key</summary>
        /// <param name="id">The primary key of the password_history</param>
        /// <param name="updatedEntity">The password_history data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PASSWORD_HISTORY updatedEntity)
        {
            await UpdatePASSWORD_HISTORY(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific password_history by its primary key</summary>
        /// <param name="id">The primary key of the password_history</param>
        /// <param name="updatedEntity">The password_history data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PASSWORD_HISTORY> updatedEntity)
        {
            await PatchPASSWORD_HISTORY(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific password_history by its primary key</summary>
        /// <param name="id">The primary key of the password_history</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePASSWORD_HISTORY(id);
            return true;
        }
        #region
        private async Task<List<PASSWORD_HISTORY>> GetPASSWORD_HISTORY(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PASSWORD_HISTORY.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PASSWORD_HISTORY>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PASSWORD_HISTORY), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PASSWORD_HISTORY, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePASSWORD_HISTORY(PASSWORD_HISTORY model)
        {
            _dbContext.PASSWORD_HISTORY.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePASSWORD_HISTORY(Guid id, PASSWORD_HISTORY updatedEntity)
        {
            _dbContext.PASSWORD_HISTORY.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePASSWORD_HISTORY(Guid id)
        {
            var entityData = _dbContext.PASSWORD_HISTORY.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PASSWORD_HISTORY.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPASSWORD_HISTORY(Guid id, JsonPatchDocument<PASSWORD_HISTORY> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PASSWORD_HISTORY.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PASSWORD_HISTORY.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}