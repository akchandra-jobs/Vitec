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
    /// The language_x_web_textService responsible for managing language_x_web_text related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting language_x_web_text information.
    /// </remarks>
    public interface ILANGUAGE_X_WEB_TEXTService
    {
        /// <summary>Retrieves a specific language_x_web_text by its primary key</summary>
        /// <param name="id">The primary key of the language_x_web_text</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The language_x_web_text data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of language_x_web_texts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of language_x_web_texts</returns>
        Task<List<LANGUAGE_X_WEB_TEXT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new language_x_web_text</summary>
        /// <param name="model">The language_x_web_text data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(LANGUAGE_X_WEB_TEXT model);

        /// <summary>Updates a specific language_x_web_text by its primary key</summary>
        /// <param name="id">The primary key of the language_x_web_text</param>
        /// <param name="updatedEntity">The language_x_web_text data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, LANGUAGE_X_WEB_TEXT updatedEntity);

        /// <summary>Updates a specific language_x_web_text by its primary key</summary>
        /// <param name="id">The primary key of the language_x_web_text</param>
        /// <param name="updatedEntity">The language_x_web_text data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<LANGUAGE_X_WEB_TEXT> updatedEntity);

        /// <summary>Deletes a specific language_x_web_text by its primary key</summary>
        /// <param name="id">The primary key of the language_x_web_text</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The language_x_web_textService responsible for managing language_x_web_text related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting language_x_web_text information.
    /// </remarks>
    public class LANGUAGE_X_WEB_TEXTService : ILANGUAGE_X_WEB_TEXTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the LANGUAGE_X_WEB_TEXT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public LANGUAGE_X_WEB_TEXTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific language_x_web_text by its primary key</summary>
        /// <param name="id">The primary key of the language_x_web_text</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The language_x_web_text data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.LANGUAGE_X_WEB_TEXT.AsQueryable();
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

            string[] navigationProperties = ["GUID_LANGUAGE_LANGUAGE","GUID_WEB_TEXT_WEB_TEXT","GUID_USER_CREATED_BY_USR","GUID_USER_UPDATED_BY_USR"];
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

        /// <summary>Retrieves a list of language_x_web_texts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of language_x_web_texts</returns>/// <exception cref="Exception"></exception>
        public async Task<List<LANGUAGE_X_WEB_TEXT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetLANGUAGE_X_WEB_TEXT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new language_x_web_text</summary>
        /// <param name="model">The language_x_web_text data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(LANGUAGE_X_WEB_TEXT model)
        {
            model.GUID = await CreateLANGUAGE_X_WEB_TEXT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific language_x_web_text by its primary key</summary>
        /// <param name="id">The primary key of the language_x_web_text</param>
        /// <param name="updatedEntity">The language_x_web_text data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, LANGUAGE_X_WEB_TEXT updatedEntity)
        {
            await UpdateLANGUAGE_X_WEB_TEXT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific language_x_web_text by its primary key</summary>
        /// <param name="id">The primary key of the language_x_web_text</param>
        /// <param name="updatedEntity">The language_x_web_text data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<LANGUAGE_X_WEB_TEXT> updatedEntity)
        {
            await PatchLANGUAGE_X_WEB_TEXT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific language_x_web_text by its primary key</summary>
        /// <param name="id">The primary key of the language_x_web_text</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteLANGUAGE_X_WEB_TEXT(id);
            return true;
        }
        #region
        private async Task<List<LANGUAGE_X_WEB_TEXT>> GetLANGUAGE_X_WEB_TEXT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.LANGUAGE_X_WEB_TEXT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<LANGUAGE_X_WEB_TEXT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(LANGUAGE_X_WEB_TEXT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<LANGUAGE_X_WEB_TEXT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateLANGUAGE_X_WEB_TEXT(LANGUAGE_X_WEB_TEXT model)
        {
            _dbContext.LANGUAGE_X_WEB_TEXT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateLANGUAGE_X_WEB_TEXT(Guid id, LANGUAGE_X_WEB_TEXT updatedEntity)
        {
            _dbContext.LANGUAGE_X_WEB_TEXT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteLANGUAGE_X_WEB_TEXT(Guid id)
        {
            var entityData = _dbContext.LANGUAGE_X_WEB_TEXT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.LANGUAGE_X_WEB_TEXT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchLANGUAGE_X_WEB_TEXT(Guid id, JsonPatchDocument<LANGUAGE_X_WEB_TEXT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.LANGUAGE_X_WEB_TEXT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.LANGUAGE_X_WEB_TEXT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}