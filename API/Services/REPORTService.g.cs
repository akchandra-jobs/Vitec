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
    /// The reportService responsible for managing report related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting report information.
    /// </remarks>
    public interface IREPORTService
    {
        /// <summary>Retrieves a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The report data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of reports based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of reports</returns>
        Task<List<REPORT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new report</summary>
        /// <param name="model">The report data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(REPORT model);

        /// <summary>Updates a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <param name="updatedEntity">The report data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, REPORT updatedEntity);

        /// <summary>Updates a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <param name="updatedEntity">The report data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<REPORT> updatedEntity);

        /// <summary>Deletes a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The reportService responsible for managing report related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting report information.
    /// </remarks>
    public class REPORTService : IREPORTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the REPORT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public REPORTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The report data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.REPORT.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER"];
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

        /// <summary>Retrieves a list of reports based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of reports</returns>/// <exception cref="Exception"></exception>
        public async Task<List<REPORT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetREPORT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new report</summary>
        /// <param name="model">The report data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(REPORT model)
        {
            model.GUID = await CreateREPORT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <param name="updatedEntity">The report data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, REPORT updatedEntity)
        {
            await UpdateREPORT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <param name="updatedEntity">The report data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<REPORT> updatedEntity)
        {
            await PatchREPORT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific report by its primary key</summary>
        /// <param name="id">The primary key of the report</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteREPORT(id);
            return true;
        }
        #region
        private async Task<List<REPORT>> GetREPORT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.REPORT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<REPORT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(REPORT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<REPORT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateREPORT(REPORT model)
        {
            _dbContext.REPORT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateREPORT(Guid id, REPORT updatedEntity)
        {
            _dbContext.REPORT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteREPORT(Guid id)
        {
            var entityData = _dbContext.REPORT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.REPORT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchREPORT(Guid id, JsonPatchDocument<REPORT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.REPORT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.REPORT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}