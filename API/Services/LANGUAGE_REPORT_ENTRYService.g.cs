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
    /// The language_report_entryService responsible for managing language_report_entry related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting language_report_entry information.
    /// </remarks>
    public interface ILANGUAGE_REPORT_ENTRYService
    {
        /// <summary>Retrieves a specific language_report_entry by its primary key</summary>
        /// <param name="id">The primary key of the language_report_entry</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The language_report_entry data</returns>
        Task<dynamic> GetById(string id, string fields);

        /// <summary>Retrieves a list of language_report_entrys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of language_report_entrys</returns>
        Task<List<LANGUAGE_REPORT_ENTRY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new language_report_entry</summary>
        /// <param name="model">The language_report_entry data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<string> Create(LANGUAGE_REPORT_ENTRY model);

        /// <summary>Updates a specific language_report_entry by its primary key</summary>
        /// <param name="id">The primary key of the language_report_entry</param>
        /// <param name="updatedEntity">The language_report_entry data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(string id, LANGUAGE_REPORT_ENTRY updatedEntity);

        /// <summary>Updates a specific language_report_entry by its primary key</summary>
        /// <param name="id">The primary key of the language_report_entry</param>
        /// <param name="updatedEntity">The language_report_entry data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(string id, JsonPatchDocument<LANGUAGE_REPORT_ENTRY> updatedEntity);

        /// <summary>Deletes a specific language_report_entry by its primary key</summary>
        /// <param name="id">The primary key of the language_report_entry</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(string id);
    }

    /// <summary>
    /// The language_report_entryService responsible for managing language_report_entry related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting language_report_entry information.
    /// </remarks>
    public class LANGUAGE_REPORT_ENTRYService : ILANGUAGE_REPORT_ENTRYService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the LANGUAGE_REPORT_ENTRY class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public LANGUAGE_REPORT_ENTRYService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific language_report_entry by its primary key</summary>
        /// <param name="id">The primary key of the language_report_entry</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The language_report_entry data</returns>
        public async Task<dynamic> GetById(string id, string fields)
        {
            var query = _dbContext.LANGUAGE_REPORT_ENTRY.AsQueryable();
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

            string[] navigationProperties = [];
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

        /// <summary>Retrieves a list of language_report_entrys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of language_report_entrys</returns>/// <exception cref="Exception"></exception>
        public async Task<List<LANGUAGE_REPORT_ENTRY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetLANGUAGE_REPORT_ENTRY(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new language_report_entry</summary>
        /// <param name="model">The language_report_entry data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<string> Create(LANGUAGE_REPORT_ENTRY model)
        {
            model.GUID = await CreateLANGUAGE_REPORT_ENTRY(model);
            return model.GUID;
        }

        /// <summary>Updates a specific language_report_entry by its primary key</summary>
        /// <param name="id">The primary key of the language_report_entry</param>
        /// <param name="updatedEntity">The language_report_entry data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(string id, LANGUAGE_REPORT_ENTRY updatedEntity)
        {
            await UpdateLANGUAGE_REPORT_ENTRY(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific language_report_entry by its primary key</summary>
        /// <param name="id">The primary key of the language_report_entry</param>
        /// <param name="updatedEntity">The language_report_entry data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(string id, JsonPatchDocument<LANGUAGE_REPORT_ENTRY> updatedEntity)
        {
            await PatchLANGUAGE_REPORT_ENTRY(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific language_report_entry by its primary key</summary>
        /// <param name="id">The primary key of the language_report_entry</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(string id)
        {
            await DeleteLANGUAGE_REPORT_ENTRY(id);
            return true;
        }
        #region
        private async Task<List<LANGUAGE_REPORT_ENTRY>> GetLANGUAGE_REPORT_ENTRY(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.LANGUAGE_REPORT_ENTRY.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<LANGUAGE_REPORT_ENTRY>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(LANGUAGE_REPORT_ENTRY), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<LANGUAGE_REPORT_ENTRY, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<string> CreateLANGUAGE_REPORT_ENTRY(LANGUAGE_REPORT_ENTRY model)
        {
            _dbContext.LANGUAGE_REPORT_ENTRY.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateLANGUAGE_REPORT_ENTRY(string id, LANGUAGE_REPORT_ENTRY updatedEntity)
        {
            _dbContext.LANGUAGE_REPORT_ENTRY.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteLANGUAGE_REPORT_ENTRY(string id)
        {
            var entityData = _dbContext.LANGUAGE_REPORT_ENTRY.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.LANGUAGE_REPORT_ENTRY.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchLANGUAGE_REPORT_ENTRY(string id, JsonPatchDocument<LANGUAGE_REPORT_ENTRY> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.LANGUAGE_REPORT_ENTRY.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.LANGUAGE_REPORT_ENTRY.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}