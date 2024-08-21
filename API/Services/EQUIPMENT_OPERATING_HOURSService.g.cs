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
    /// The equipment_operating_hoursService responsible for managing equipment_operating_hours related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting equipment_operating_hours information.
    /// </remarks>
    public interface IEQUIPMENT_OPERATING_HOURSService
    {
        /// <summary>Retrieves a specific equipment_operating_hours by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hours</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The equipment_operating_hours data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of equipment_operating_hourss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of equipment_operating_hourss</returns>
        Task<List<EQUIPMENT_OPERATING_HOURS>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new equipment_operating_hours</summary>
        /// <param name="model">The equipment_operating_hours data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(EQUIPMENT_OPERATING_HOURS model);

        /// <summary>Updates a specific equipment_operating_hours by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hours</param>
        /// <param name="updatedEntity">The equipment_operating_hours data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, EQUIPMENT_OPERATING_HOURS updatedEntity);

        /// <summary>Updates a specific equipment_operating_hours by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hours</param>
        /// <param name="updatedEntity">The equipment_operating_hours data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<EQUIPMENT_OPERATING_HOURS> updatedEntity);

        /// <summary>Deletes a specific equipment_operating_hours by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hours</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The equipment_operating_hoursService responsible for managing equipment_operating_hours related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting equipment_operating_hours information.
    /// </remarks>
    public class EQUIPMENT_OPERATING_HOURSService : IEQUIPMENT_OPERATING_HOURSService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the EQUIPMENT_OPERATING_HOURS class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public EQUIPMENT_OPERATING_HOURSService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific equipment_operating_hours by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hours</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The equipment_operating_hours data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.EQUIPMENT_OPERATING_HOURS.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_EQUIPMENT_EQUIPMENT","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_EQUIPMENT_OPERATING_HOUR_TYPE_EQUIPMENT_OPERATING_HOUR_TYPE"];
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

        /// <summary>Retrieves a list of equipment_operating_hourss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of equipment_operating_hourss</returns>/// <exception cref="Exception"></exception>
        public async Task<List<EQUIPMENT_OPERATING_HOURS>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetEQUIPMENT_OPERATING_HOURS(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new equipment_operating_hours</summary>
        /// <param name="model">The equipment_operating_hours data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(EQUIPMENT_OPERATING_HOURS model)
        {
            model.GUID = await CreateEQUIPMENT_OPERATING_HOURS(model);
            return model.GUID;
        }

        /// <summary>Updates a specific equipment_operating_hours by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hours</param>
        /// <param name="updatedEntity">The equipment_operating_hours data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, EQUIPMENT_OPERATING_HOURS updatedEntity)
        {
            await UpdateEQUIPMENT_OPERATING_HOURS(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific equipment_operating_hours by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hours</param>
        /// <param name="updatedEntity">The equipment_operating_hours data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<EQUIPMENT_OPERATING_HOURS> updatedEntity)
        {
            await PatchEQUIPMENT_OPERATING_HOURS(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific equipment_operating_hours by its primary key</summary>
        /// <param name="id">The primary key of the equipment_operating_hours</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteEQUIPMENT_OPERATING_HOURS(id);
            return true;
        }
        #region
        private async Task<List<EQUIPMENT_OPERATING_HOURS>> GetEQUIPMENT_OPERATING_HOURS(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EQUIPMENT_OPERATING_HOURS.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EQUIPMENT_OPERATING_HOURS>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EQUIPMENT_OPERATING_HOURS), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EQUIPMENT_OPERATING_HOURS, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateEQUIPMENT_OPERATING_HOURS(EQUIPMENT_OPERATING_HOURS model)
        {
            _dbContext.EQUIPMENT_OPERATING_HOURS.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateEQUIPMENT_OPERATING_HOURS(Guid id, EQUIPMENT_OPERATING_HOURS updatedEntity)
        {
            _dbContext.EQUIPMENT_OPERATING_HOURS.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteEQUIPMENT_OPERATING_HOURS(Guid id)
        {
            var entityData = _dbContext.EQUIPMENT_OPERATING_HOURS.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EQUIPMENT_OPERATING_HOURS.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchEQUIPMENT_OPERATING_HOURS(Guid id, JsonPatchDocument<EQUIPMENT_OPERATING_HOURS> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EQUIPMENT_OPERATING_HOURS.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EQUIPMENT_OPERATING_HOURS.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}