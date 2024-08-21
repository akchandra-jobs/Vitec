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
    /// The follow_upService responsible for managing follow_up related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting follow_up information.
    /// </remarks>
    public interface IFOLLOW_UPService
    {
        /// <summary>Retrieves a specific follow_up by its primary key</summary>
        /// <param name="id">The primary key of the follow_up</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The follow_up data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of follow_ups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of follow_ups</returns>
        Task<List<FOLLOW_UP>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new follow_up</summary>
        /// <param name="model">The follow_up data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(FOLLOW_UP model);

        /// <summary>Updates a specific follow_up by its primary key</summary>
        /// <param name="id">The primary key of the follow_up</param>
        /// <param name="updatedEntity">The follow_up data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, FOLLOW_UP updatedEntity);

        /// <summary>Updates a specific follow_up by its primary key</summary>
        /// <param name="id">The primary key of the follow_up</param>
        /// <param name="updatedEntity">The follow_up data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<FOLLOW_UP> updatedEntity);

        /// <summary>Deletes a specific follow_up by its primary key</summary>
        /// <param name="id">The primary key of the follow_up</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The follow_upService responsible for managing follow_up related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting follow_up information.
    /// </remarks>
    public class FOLLOW_UPService : IFOLLOW_UPService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the FOLLOW_UP class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public FOLLOW_UPService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific follow_up by its primary key</summary>
        /// <param name="id">The primary key of the follow_up</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The follow_up data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.FOLLOW_UP.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_RESPONSIBLE_PERSON_PERSON","GUID_CONTACT_PERSON_CONTACT_PERSON","GUID_CONTRACT_CONTRACT","GUID_CUSTOMER_CUSTOMER","GUID_PREVIOUS_FOLLOW_UP"];
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

        /// <summary>Retrieves a list of follow_ups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of follow_ups</returns>/// <exception cref="Exception"></exception>
        public async Task<List<FOLLOW_UP>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetFOLLOW_UP(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new follow_up</summary>
        /// <param name="model">The follow_up data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(FOLLOW_UP model)
        {
            model.GUID = await CreateFOLLOW_UP(model);
            return model.GUID;
        }

        /// <summary>Updates a specific follow_up by its primary key</summary>
        /// <param name="id">The primary key of the follow_up</param>
        /// <param name="updatedEntity">The follow_up data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, FOLLOW_UP updatedEntity)
        {
            await UpdateFOLLOW_UP(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific follow_up by its primary key</summary>
        /// <param name="id">The primary key of the follow_up</param>
        /// <param name="updatedEntity">The follow_up data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<FOLLOW_UP> updatedEntity)
        {
            await PatchFOLLOW_UP(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific follow_up by its primary key</summary>
        /// <param name="id">The primary key of the follow_up</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteFOLLOW_UP(id);
            return true;
        }
        #region
        private async Task<List<FOLLOW_UP>> GetFOLLOW_UP(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.FOLLOW_UP.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<FOLLOW_UP>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(FOLLOW_UP), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<FOLLOW_UP, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateFOLLOW_UP(FOLLOW_UP model)
        {
            _dbContext.FOLLOW_UP.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateFOLLOW_UP(Guid id, FOLLOW_UP updatedEntity)
        {
            _dbContext.FOLLOW_UP.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteFOLLOW_UP(Guid id)
        {
            var entityData = _dbContext.FOLLOW_UP.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.FOLLOW_UP.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchFOLLOW_UP(Guid id, JsonPatchDocument<FOLLOW_UP> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.FOLLOW_UP.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.FOLLOW_UP.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}