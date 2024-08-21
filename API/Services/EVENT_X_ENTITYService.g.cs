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
    /// The event_x_entityService responsible for managing event_x_entity related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting event_x_entity information.
    /// </remarks>
    public interface IEVENT_X_ENTITYService
    {
        /// <summary>Retrieves a specific event_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the event_x_entity</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The event_x_entity data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of event_x_entitys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of event_x_entitys</returns>
        Task<List<EVENT_X_ENTITY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new event_x_entity</summary>
        /// <param name="model">The event_x_entity data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(EVENT_X_ENTITY model);

        /// <summary>Updates a specific event_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the event_x_entity</param>
        /// <param name="updatedEntity">The event_x_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, EVENT_X_ENTITY updatedEntity);

        /// <summary>Updates a specific event_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the event_x_entity</param>
        /// <param name="updatedEntity">The event_x_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<EVENT_X_ENTITY> updatedEntity);

        /// <summary>Deletes a specific event_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the event_x_entity</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The event_x_entityService responsible for managing event_x_entity related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting event_x_entity information.
    /// </remarks>
    public class EVENT_X_ENTITYService : IEVENT_X_ENTITYService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the EVENT_X_ENTITY class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public EVENT_X_ENTITYService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific event_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the event_x_entity</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The event_x_entity data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.EVENT_X_ENTITY.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_EVENT_EVENT","GUID_PERSON_PERSON","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of event_x_entitys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of event_x_entitys</returns>/// <exception cref="Exception"></exception>
        public async Task<List<EVENT_X_ENTITY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetEVENT_X_ENTITY(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new event_x_entity</summary>
        /// <param name="model">The event_x_entity data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(EVENT_X_ENTITY model)
        {
            model.GUID = await CreateEVENT_X_ENTITY(model);
            return model.GUID;
        }

        /// <summary>Updates a specific event_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the event_x_entity</param>
        /// <param name="updatedEntity">The event_x_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, EVENT_X_ENTITY updatedEntity)
        {
            await UpdateEVENT_X_ENTITY(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific event_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the event_x_entity</param>
        /// <param name="updatedEntity">The event_x_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<EVENT_X_ENTITY> updatedEntity)
        {
            await PatchEVENT_X_ENTITY(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific event_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the event_x_entity</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteEVENT_X_ENTITY(id);
            return true;
        }
        #region
        private async Task<List<EVENT_X_ENTITY>> GetEVENT_X_ENTITY(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EVENT_X_ENTITY.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EVENT_X_ENTITY>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EVENT_X_ENTITY), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EVENT_X_ENTITY, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateEVENT_X_ENTITY(EVENT_X_ENTITY model)
        {
            _dbContext.EVENT_X_ENTITY.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateEVENT_X_ENTITY(Guid id, EVENT_X_ENTITY updatedEntity)
        {
            _dbContext.EVENT_X_ENTITY.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteEVENT_X_ENTITY(Guid id)
        {
            var entityData = _dbContext.EVENT_X_ENTITY.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EVENT_X_ENTITY.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchEVENT_X_ENTITY(Guid id, JsonPatchDocument<EVENT_X_ENTITY> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EVENT_X_ENTITY.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EVENT_X_ENTITY.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}