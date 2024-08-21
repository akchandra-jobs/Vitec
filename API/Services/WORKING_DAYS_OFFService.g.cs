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
    /// The working_days_offService responsible for managing working_days_off related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting working_days_off information.
    /// </remarks>
    public interface IWORKING_DAYS_OFFService
    {
        /// <summary>Retrieves a specific working_days_off by its primary key</summary>
        /// <param name="id">The primary key of the working_days_off</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The working_days_off data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of working_days_offs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of working_days_offs</returns>
        Task<List<WORKING_DAYS_OFF>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new working_days_off</summary>
        /// <param name="model">The working_days_off data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(WORKING_DAYS_OFF model);

        /// <summary>Updates a specific working_days_off by its primary key</summary>
        /// <param name="id">The primary key of the working_days_off</param>
        /// <param name="updatedEntity">The working_days_off data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, WORKING_DAYS_OFF updatedEntity);

        /// <summary>Updates a specific working_days_off by its primary key</summary>
        /// <param name="id">The primary key of the working_days_off</param>
        /// <param name="updatedEntity">The working_days_off data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<WORKING_DAYS_OFF> updatedEntity);

        /// <summary>Deletes a specific working_days_off by its primary key</summary>
        /// <param name="id">The primary key of the working_days_off</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The working_days_offService responsible for managing working_days_off related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting working_days_off information.
    /// </remarks>
    public class WORKING_DAYS_OFFService : IWORKING_DAYS_OFFService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the WORKING_DAYS_OFF class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public WORKING_DAYS_OFFService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific working_days_off by its primary key</summary>
        /// <param name="id">The primary key of the working_days_off</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The working_days_off data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.WORKING_DAYS_OFF.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of working_days_offs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of working_days_offs</returns>/// <exception cref="Exception"></exception>
        public async Task<List<WORKING_DAYS_OFF>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetWORKING_DAYS_OFF(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new working_days_off</summary>
        /// <param name="model">The working_days_off data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(WORKING_DAYS_OFF model)
        {
            model.GUID = await CreateWORKING_DAYS_OFF(model);
            return model.GUID;
        }

        /// <summary>Updates a specific working_days_off by its primary key</summary>
        /// <param name="id">The primary key of the working_days_off</param>
        /// <param name="updatedEntity">The working_days_off data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, WORKING_DAYS_OFF updatedEntity)
        {
            await UpdateWORKING_DAYS_OFF(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific working_days_off by its primary key</summary>
        /// <param name="id">The primary key of the working_days_off</param>
        /// <param name="updatedEntity">The working_days_off data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<WORKING_DAYS_OFF> updatedEntity)
        {
            await PatchWORKING_DAYS_OFF(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific working_days_off by its primary key</summary>
        /// <param name="id">The primary key of the working_days_off</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteWORKING_DAYS_OFF(id);
            return true;
        }
        #region
        private async Task<List<WORKING_DAYS_OFF>> GetWORKING_DAYS_OFF(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.WORKING_DAYS_OFF.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<WORKING_DAYS_OFF>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(WORKING_DAYS_OFF), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<WORKING_DAYS_OFF, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateWORKING_DAYS_OFF(WORKING_DAYS_OFF model)
        {
            _dbContext.WORKING_DAYS_OFF.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateWORKING_DAYS_OFF(Guid id, WORKING_DAYS_OFF updatedEntity)
        {
            _dbContext.WORKING_DAYS_OFF.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteWORKING_DAYS_OFF(Guid id)
        {
            var entityData = _dbContext.WORKING_DAYS_OFF.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.WORKING_DAYS_OFF.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchWORKING_DAYS_OFF(Guid id, JsonPatchDocument<WORKING_DAYS_OFF> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.WORKING_DAYS_OFF.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.WORKING_DAYS_OFF.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}