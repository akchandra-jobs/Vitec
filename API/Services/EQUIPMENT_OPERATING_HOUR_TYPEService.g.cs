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
    /// The equipment_operating_hour_typeService responsible for managing equipment_operating_hour_type related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting equipment_operating_hour_type information.
    /// </remarks>
    public interface IEQUIPMENT_OPERATING_HOUR_TYPEService
    {
        /// <summary>Retrieves a specific equipment_operating_hour_type by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hour_type</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The equipment_operating_hour_type data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of equipment_operating_hour_types based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of equipment_operating_hour_types</returns>
        Task<List<EQUIPMENT_OPERATING_HOUR_TYPE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new equipment_operating_hour_type</summary>
        /// <param name="model">The equipment_operating_hour_type data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(EQUIPMENT_OPERATING_HOUR_TYPE model);

        /// <summary>Updates a specific equipment_operating_hour_type by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hour_type</param>
        /// <param name="updatedEntity">The equipment_operating_hour_type data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, EQUIPMENT_OPERATING_HOUR_TYPE updatedEntity);

        /// <summary>Updates a specific equipment_operating_hour_type by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hour_type</param>
        /// <param name="updatedEntity">The equipment_operating_hour_type data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<EQUIPMENT_OPERATING_HOUR_TYPE> updatedEntity);

        /// <summary>Deletes a specific equipment_operating_hour_type by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hour_type</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The equipment_operating_hour_typeService responsible for managing equipment_operating_hour_type related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting equipment_operating_hour_type information.
    /// </remarks>
    public class EQUIPMENT_OPERATING_HOUR_TYPEService : IEQUIPMENT_OPERATING_HOUR_TYPEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the EQUIPMENT_OPERATING_HOUR_TYPE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public EQUIPMENT_OPERATING_HOUR_TYPEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific equipment_operating_hour_type by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hour_type</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The equipment_operating_hour_type data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.EQUIPMENT_OPERATING_HOUR_TYPE.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of equipment_operating_hour_types based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of equipment_operating_hour_types</returns>/// <exception cref="Exception"></exception>
        public async Task<List<EQUIPMENT_OPERATING_HOUR_TYPE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetEQUIPMENT_OPERATING_HOUR_TYPE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new equipment_operating_hour_type</summary>
        /// <param name="model">The equipment_operating_hour_type data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(EQUIPMENT_OPERATING_HOUR_TYPE model)
        {
            model.GUID = await CreateEQUIPMENT_OPERATING_HOUR_TYPE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific equipment_operating_hour_type by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hour_type</param>
        /// <param name="updatedEntity">The equipment_operating_hour_type data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, EQUIPMENT_OPERATING_HOUR_TYPE updatedEntity)
        {
            await UpdateEQUIPMENT_OPERATING_HOUR_TYPE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific equipment_operating_hour_type by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hour_type</param>
        /// <param name="updatedEntity">The equipment_operating_hour_type data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<EQUIPMENT_OPERATING_HOUR_TYPE> updatedEntity)
        {
            await PatchEQUIPMENT_OPERATING_HOUR_TYPE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific equipment_operating_hour_type by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hour_type</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteEQUIPMENT_OPERATING_HOUR_TYPE(id);
            return true;
        }
        #region
        private async Task<List<EQUIPMENT_OPERATING_HOUR_TYPE>> GetEQUIPMENT_OPERATING_HOUR_TYPE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EQUIPMENT_OPERATING_HOUR_TYPE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EQUIPMENT_OPERATING_HOUR_TYPE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EQUIPMENT_OPERATING_HOUR_TYPE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EQUIPMENT_OPERATING_HOUR_TYPE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateEQUIPMENT_OPERATING_HOUR_TYPE(EQUIPMENT_OPERATING_HOUR_TYPE model)
        {
            _dbContext.EQUIPMENT_OPERATING_HOUR_TYPE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateEQUIPMENT_OPERATING_HOUR_TYPE(Guid id, EQUIPMENT_OPERATING_HOUR_TYPE updatedEntity)
        {
            _dbContext.EQUIPMENT_OPERATING_HOUR_TYPE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteEQUIPMENT_OPERATING_HOUR_TYPE(Guid id)
        {
            var entityData = _dbContext.EQUIPMENT_OPERATING_HOUR_TYPE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EQUIPMENT_OPERATING_HOUR_TYPE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchEQUIPMENT_OPERATING_HOUR_TYPE(Guid id, JsonPatchDocument<EQUIPMENT_OPERATING_HOUR_TYPE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EQUIPMENT_OPERATING_HOUR_TYPE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EQUIPMENT_OPERATING_HOUR_TYPE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}