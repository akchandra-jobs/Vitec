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
    /// The integration_dataService responsible for managing integration_data related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting integration_data information.
    /// </remarks>
    public interface IINTEGRATION_DATAService
    {
        /// <summary>Retrieves a specific integration_data by its primary key</summary>
        /// <param name="id">The primary key of the integration_data</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The integration_data data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of integration_datas based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of integration_datas</returns>
        Task<List<INTEGRATION_DATA>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new integration_data</summary>
        /// <param name="model">The integration_data data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(INTEGRATION_DATA model);

        /// <summary>Updates a specific integration_data by its primary key</summary>
        /// <param name="id">The primary key of the integration_data</param>
        /// <param name="updatedEntity">The integration_data data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, INTEGRATION_DATA updatedEntity);

        /// <summary>Updates a specific integration_data by its primary key</summary>
        /// <param name="id">The primary key of the integration_data</param>
        /// <param name="updatedEntity">The integration_data data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<INTEGRATION_DATA> updatedEntity);

        /// <summary>Deletes a specific integration_data by its primary key</summary>
        /// <param name="id">The primary key of the integration_data</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The integration_dataService responsible for managing integration_data related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting integration_data information.
    /// </remarks>
    public class INTEGRATION_DATAService : IINTEGRATION_DATAService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the INTEGRATION_DATA class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public INTEGRATION_DATAService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific integration_data by its primary key</summary>
        /// <param name="id">The primary key of the integration_data</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The integration_data data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.INTEGRATION_DATA.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_CUSTOM_FUNCTION_CUSTOM_FUNCTION","GUID_SCHEDULED_JOB_SCHEDULED_JOB"];
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

        /// <summary>Retrieves a list of integration_datas based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of integration_datas</returns>/// <exception cref="Exception"></exception>
        public async Task<List<INTEGRATION_DATA>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetINTEGRATION_DATA(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new integration_data</summary>
        /// <param name="model">The integration_data data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(INTEGRATION_DATA model)
        {
            model.GUID = await CreateINTEGRATION_DATA(model);
            return model.GUID;
        }

        /// <summary>Updates a specific integration_data by its primary key</summary>
        /// <param name="id">The primary key of the integration_data</param>
        /// <param name="updatedEntity">The integration_data data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, INTEGRATION_DATA updatedEntity)
        {
            await UpdateINTEGRATION_DATA(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific integration_data by its primary key</summary>
        /// <param name="id">The primary key of the integration_data</param>
        /// <param name="updatedEntity">The integration_data data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<INTEGRATION_DATA> updatedEntity)
        {
            await PatchINTEGRATION_DATA(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific integration_data by its primary key</summary>
        /// <param name="id">The primary key of the integration_data</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteINTEGRATION_DATA(id);
            return true;
        }
        #region
        private async Task<List<INTEGRATION_DATA>> GetINTEGRATION_DATA(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.INTEGRATION_DATA.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<INTEGRATION_DATA>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(INTEGRATION_DATA), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<INTEGRATION_DATA, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateINTEGRATION_DATA(INTEGRATION_DATA model)
        {
            _dbContext.INTEGRATION_DATA.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateINTEGRATION_DATA(Guid id, INTEGRATION_DATA updatedEntity)
        {
            _dbContext.INTEGRATION_DATA.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteINTEGRATION_DATA(Guid id)
        {
            var entityData = _dbContext.INTEGRATION_DATA.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.INTEGRATION_DATA.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchINTEGRATION_DATA(Guid id, JsonPatchDocument<INTEGRATION_DATA> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.INTEGRATION_DATA.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.INTEGRATION_DATA.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}