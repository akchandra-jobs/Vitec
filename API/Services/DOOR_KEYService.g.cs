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
    /// The door_keyService responsible for managing door_key related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting door_key information.
    /// </remarks>
    public interface IDOOR_KEYService
    {
        /// <summary>Retrieves a specific door_key by its primary key</summary>
        /// <param name="id">The primary key of the door_key</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The door_key data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of door_keys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of door_keys</returns>
        Task<List<DOOR_KEY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new door_key</summary>
        /// <param name="model">The door_key data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(DOOR_KEY model);

        /// <summary>Updates a specific door_key by its primary key</summary>
        /// <param name="id">The primary key of the door_key</param>
        /// <param name="updatedEntity">The door_key data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, DOOR_KEY updatedEntity);

        /// <summary>Updates a specific door_key by its primary key</summary>
        /// <param name="id">The primary key of the door_key</param>
        /// <param name="updatedEntity">The door_key data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<DOOR_KEY> updatedEntity);

        /// <summary>Deletes a specific door_key by its primary key</summary>
        /// <param name="id">The primary key of the door_key</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The door_keyService responsible for managing door_key related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting door_key information.
    /// </remarks>
    public class DOOR_KEYService : IDOOR_KEYService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the DOOR_KEY class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public DOOR_KEYService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific door_key by its primary key</summary>
        /// <param name="id">The primary key of the door_key</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The door_key data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.DOOR_KEY.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_DOOR_KEY_SYSTEM_DOOR_KEY_SYSTEM"];
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

        /// <summary>Retrieves a list of door_keys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of door_keys</returns>/// <exception cref="Exception"></exception>
        public async Task<List<DOOR_KEY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetDOOR_KEY(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new door_key</summary>
        /// <param name="model">The door_key data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(DOOR_KEY model)
        {
            model.GUID = await CreateDOOR_KEY(model);
            return model.GUID;
        }

        /// <summary>Updates a specific door_key by its primary key</summary>
        /// <param name="id">The primary key of the door_key</param>
        /// <param name="updatedEntity">The door_key data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, DOOR_KEY updatedEntity)
        {
            await UpdateDOOR_KEY(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific door_key by its primary key</summary>
        /// <param name="id">The primary key of the door_key</param>
        /// <param name="updatedEntity">The door_key data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<DOOR_KEY> updatedEntity)
        {
            await PatchDOOR_KEY(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific door_key by its primary key</summary>
        /// <param name="id">The primary key of the door_key</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteDOOR_KEY(id);
            return true;
        }
        #region
        private async Task<List<DOOR_KEY>> GetDOOR_KEY(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DOOR_KEY.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DOOR_KEY>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DOOR_KEY), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DOOR_KEY, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateDOOR_KEY(DOOR_KEY model)
        {
            _dbContext.DOOR_KEY.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateDOOR_KEY(Guid id, DOOR_KEY updatedEntity)
        {
            _dbContext.DOOR_KEY.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteDOOR_KEY(Guid id)
        {
            var entityData = _dbContext.DOOR_KEY.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DOOR_KEY.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchDOOR_KEY(Guid id, JsonPatchDocument<DOOR_KEY> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DOOR_KEY.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DOOR_KEY.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}