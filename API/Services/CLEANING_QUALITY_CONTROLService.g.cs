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
    /// The cleaning_quality_controlService responsible for managing cleaning_quality_control related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cleaning_quality_control information.
    /// </remarks>
    public interface ICLEANING_QUALITY_CONTROLService
    {
        /// <summary>Retrieves a specific cleaning_quality_control by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_quality_control</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The cleaning_quality_control data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of cleaning_quality_controls based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cleaning_quality_controls</returns>
        Task<List<CLEANING_QUALITY_CONTROL>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new cleaning_quality_control</summary>
        /// <param name="model">The cleaning_quality_control data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(CLEANING_QUALITY_CONTROL model);

        /// <summary>Updates a specific cleaning_quality_control by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_quality_control</param>
        /// <param name="updatedEntity">The cleaning_quality_control data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, CLEANING_QUALITY_CONTROL updatedEntity);

        /// <summary>Updates a specific cleaning_quality_control by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_quality_control</param>
        /// <param name="updatedEntity">The cleaning_quality_control data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<CLEANING_QUALITY_CONTROL> updatedEntity);

        /// <summary>Deletes a specific cleaning_quality_control by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_quality_control</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The cleaning_quality_controlService responsible for managing cleaning_quality_control related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cleaning_quality_control information.
    /// </remarks>
    public class CLEANING_QUALITY_CONTROLService : ICLEANING_QUALITY_CONTROLService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the CLEANING_QUALITY_CONTROL class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public CLEANING_QUALITY_CONTROLService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific cleaning_quality_control by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_quality_control</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The cleaning_quality_control data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.CLEANING_QUALITY_CONTROL.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_DRAWING_DRAWING","GUID_RESOURCE_GROUP_RESOURCE_GROUP"];
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

        /// <summary>Retrieves a list of cleaning_quality_controls based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cleaning_quality_controls</returns>/// <exception cref="Exception"></exception>
        public async Task<List<CLEANING_QUALITY_CONTROL>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetCLEANING_QUALITY_CONTROL(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new cleaning_quality_control</summary>
        /// <param name="model">The cleaning_quality_control data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(CLEANING_QUALITY_CONTROL model)
        {
            model.GUID = await CreateCLEANING_QUALITY_CONTROL(model);
            return model.GUID;
        }

        /// <summary>Updates a specific cleaning_quality_control by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_quality_control</param>
        /// <param name="updatedEntity">The cleaning_quality_control data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, CLEANING_QUALITY_CONTROL updatedEntity)
        {
            await UpdateCLEANING_QUALITY_CONTROL(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific cleaning_quality_control by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_quality_control</param>
        /// <param name="updatedEntity">The cleaning_quality_control data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<CLEANING_QUALITY_CONTROL> updatedEntity)
        {
            await PatchCLEANING_QUALITY_CONTROL(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific cleaning_quality_control by its primary key</summary>
        /// <param name="id">The primary key of the cleaning_quality_control</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteCLEANING_QUALITY_CONTROL(id);
            return true;
        }
        #region
        private async Task<List<CLEANING_QUALITY_CONTROL>> GetCLEANING_QUALITY_CONTROL(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CLEANING_QUALITY_CONTROL.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CLEANING_QUALITY_CONTROL>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CLEANING_QUALITY_CONTROL), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CLEANING_QUALITY_CONTROL, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateCLEANING_QUALITY_CONTROL(CLEANING_QUALITY_CONTROL model)
        {
            _dbContext.CLEANING_QUALITY_CONTROL.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateCLEANING_QUALITY_CONTROL(Guid id, CLEANING_QUALITY_CONTROL updatedEntity)
        {
            _dbContext.CLEANING_QUALITY_CONTROL.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteCLEANING_QUALITY_CONTROL(Guid id)
        {
            var entityData = _dbContext.CLEANING_QUALITY_CONTROL.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CLEANING_QUALITY_CONTROL.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchCLEANING_QUALITY_CONTROL(Guid id, JsonPatchDocument<CLEANING_QUALITY_CONTROL> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CLEANING_QUALITY_CONTROL.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CLEANING_QUALITY_CONTROL.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}