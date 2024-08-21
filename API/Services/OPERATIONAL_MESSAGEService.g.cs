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
    /// The operational_messageService responsible for managing operational_message related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting operational_message information.
    /// </remarks>
    public interface IOPERATIONAL_MESSAGEService
    {
        /// <summary>Retrieves a specific operational_message by its primary key</summary>
        /// <param name="id">The primary key of the operational_message</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The operational_message data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of operational_messages based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of operational_messages</returns>
        Task<List<OPERATIONAL_MESSAGE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new operational_message</summary>
        /// <param name="model">The operational_message data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(OPERATIONAL_MESSAGE model);

        /// <summary>Updates a specific operational_message by its primary key</summary>
        /// <param name="id">The primary key of the operational_message</param>
        /// <param name="updatedEntity">The operational_message data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, OPERATIONAL_MESSAGE updatedEntity);

        /// <summary>Updates a specific operational_message by its primary key</summary>
        /// <param name="id">The primary key of the operational_message</param>
        /// <param name="updatedEntity">The operational_message data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<OPERATIONAL_MESSAGE> updatedEntity);

        /// <summary>Deletes a specific operational_message by its primary key</summary>
        /// <param name="id">The primary key of the operational_message</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The operational_messageService responsible for managing operational_message related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting operational_message information.
    /// </remarks>
    public class OPERATIONAL_MESSAGEService : IOPERATIONAL_MESSAGEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the OPERATIONAL_MESSAGE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public OPERATIONAL_MESSAGEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific operational_message by its primary key</summary>
        /// <param name="id">The primary key of the operational_message</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The operational_message data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.OPERATIONAL_MESSAGE.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_BUILDING_BUILDING","GUID_EQUIPMENT_EQUIPMENT","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_ESTATE_ESTATE","GUID_CONTACT_PERSON_PERSON","GUID_WORK_ORDER_WORK_ORDER"];
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

        /// <summary>Retrieves a list of operational_messages based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of operational_messages</returns>/// <exception cref="Exception"></exception>
        public async Task<List<OPERATIONAL_MESSAGE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetOPERATIONAL_MESSAGE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new operational_message</summary>
        /// <param name="model">The operational_message data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(OPERATIONAL_MESSAGE model)
        {
            model.GUID = await CreateOPERATIONAL_MESSAGE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific operational_message by its primary key</summary>
        /// <param name="id">The primary key of the operational_message</param>
        /// <param name="updatedEntity">The operational_message data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, OPERATIONAL_MESSAGE updatedEntity)
        {
            await UpdateOPERATIONAL_MESSAGE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific operational_message by its primary key</summary>
        /// <param name="id">The primary key of the operational_message</param>
        /// <param name="updatedEntity">The operational_message data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<OPERATIONAL_MESSAGE> updatedEntity)
        {
            await PatchOPERATIONAL_MESSAGE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific operational_message by its primary key</summary>
        /// <param name="id">The primary key of the operational_message</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteOPERATIONAL_MESSAGE(id);
            return true;
        }
        #region
        private async Task<List<OPERATIONAL_MESSAGE>> GetOPERATIONAL_MESSAGE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.OPERATIONAL_MESSAGE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<OPERATIONAL_MESSAGE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(OPERATIONAL_MESSAGE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<OPERATIONAL_MESSAGE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateOPERATIONAL_MESSAGE(OPERATIONAL_MESSAGE model)
        {
            _dbContext.OPERATIONAL_MESSAGE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateOPERATIONAL_MESSAGE(Guid id, OPERATIONAL_MESSAGE updatedEntity)
        {
            _dbContext.OPERATIONAL_MESSAGE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteOPERATIONAL_MESSAGE(Guid id)
        {
            var entityData = _dbContext.OPERATIONAL_MESSAGE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.OPERATIONAL_MESSAGE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchOPERATIONAL_MESSAGE(Guid id, JsonPatchDocument<OPERATIONAL_MESSAGE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.OPERATIONAL_MESSAGE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.OPERATIONAL_MESSAGE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}