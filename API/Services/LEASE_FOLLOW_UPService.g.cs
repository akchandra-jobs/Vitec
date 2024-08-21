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
    /// The lease_follow_upService responsible for managing lease_follow_up related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting lease_follow_up information.
    /// </remarks>
    public interface ILEASE_FOLLOW_UPService
    {
        /// <summary>Retrieves a specific lease_follow_up by its primary key</summary>
        /// <param name="id">The primary key of the lease_follow_up</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The lease_follow_up data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of lease_follow_ups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of lease_follow_ups</returns>
        Task<List<LEASE_FOLLOW_UP>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new lease_follow_up</summary>
        /// <param name="model">The lease_follow_up data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(LEASE_FOLLOW_UP model);

        /// <summary>Updates a specific lease_follow_up by its primary key</summary>
        /// <param name="id">The primary key of the lease_follow_up</param>
        /// <param name="updatedEntity">The lease_follow_up data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, LEASE_FOLLOW_UP updatedEntity);

        /// <summary>Updates a specific lease_follow_up by its primary key</summary>
        /// <param name="id">The primary key of the lease_follow_up</param>
        /// <param name="updatedEntity">The lease_follow_up data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<LEASE_FOLLOW_UP> updatedEntity);

        /// <summary>Deletes a specific lease_follow_up by its primary key</summary>
        /// <param name="id">The primary key of the lease_follow_up</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The lease_follow_upService responsible for managing lease_follow_up related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting lease_follow_up information.
    /// </remarks>
    public class LEASE_FOLLOW_UPService : ILEASE_FOLLOW_UPService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the LEASE_FOLLOW_UP class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public LEASE_FOLLOW_UPService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific lease_follow_up by its primary key</summary>
        /// <param name="id">The primary key of the lease_follow_up</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The lease_follow_up data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.LEASE_FOLLOW_UP.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_RESPONSIBLE_PERSON_PERSON","GUID_CONTACT_PERSON_CONTACT_PERSON","GUID_CONTRACT_LEASE_CONTRACT_LEASE","GUID_SUPPLIER_SUPPLIER","GUID_PREVIOUS_LEASE_FOLLOW_UP"];
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

        /// <summary>Retrieves a list of lease_follow_ups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of lease_follow_ups</returns>/// <exception cref="Exception"></exception>
        public async Task<List<LEASE_FOLLOW_UP>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetLEASE_FOLLOW_UP(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new lease_follow_up</summary>
        /// <param name="model">The lease_follow_up data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(LEASE_FOLLOW_UP model)
        {
            model.GUID = await CreateLEASE_FOLLOW_UP(model);
            return model.GUID;
        }

        /// <summary>Updates a specific lease_follow_up by its primary key</summary>
        /// <param name="id">The primary key of the lease_follow_up</param>
        /// <param name="updatedEntity">The lease_follow_up data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, LEASE_FOLLOW_UP updatedEntity)
        {
            await UpdateLEASE_FOLLOW_UP(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific lease_follow_up by its primary key</summary>
        /// <param name="id">The primary key of the lease_follow_up</param>
        /// <param name="updatedEntity">The lease_follow_up data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<LEASE_FOLLOW_UP> updatedEntity)
        {
            await PatchLEASE_FOLLOW_UP(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific lease_follow_up by its primary key</summary>
        /// <param name="id">The primary key of the lease_follow_up</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteLEASE_FOLLOW_UP(id);
            return true;
        }
        #region
        private async Task<List<LEASE_FOLLOW_UP>> GetLEASE_FOLLOW_UP(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.LEASE_FOLLOW_UP.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<LEASE_FOLLOW_UP>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(LEASE_FOLLOW_UP), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<LEASE_FOLLOW_UP, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateLEASE_FOLLOW_UP(LEASE_FOLLOW_UP model)
        {
            _dbContext.LEASE_FOLLOW_UP.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateLEASE_FOLLOW_UP(Guid id, LEASE_FOLLOW_UP updatedEntity)
        {
            _dbContext.LEASE_FOLLOW_UP.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteLEASE_FOLLOW_UP(Guid id)
        {
            var entityData = _dbContext.LEASE_FOLLOW_UP.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.LEASE_FOLLOW_UP.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchLEASE_FOLLOW_UP(Guid id, JsonPatchDocument<LEASE_FOLLOW_UP> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.LEASE_FOLLOW_UP.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.LEASE_FOLLOW_UP.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}