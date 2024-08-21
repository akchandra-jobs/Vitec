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
    /// The document_web_accessService responsible for managing document_web_access related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting document_web_access information.
    /// </remarks>
    public interface IDOCUMENT_WEB_ACCESSService
    {
        /// <summary>Retrieves a specific document_web_access by its primary key</summary>
        /// <param name="id">The primary key of the document_web_access</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The document_web_access data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of document_web_accesss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of document_web_accesss</returns>
        Task<List<DOCUMENT_WEB_ACCESS>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new document_web_access</summary>
        /// <param name="model">The document_web_access data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(DOCUMENT_WEB_ACCESS model);

        /// <summary>Updates a specific document_web_access by its primary key</summary>
        /// <param name="id">The primary key of the document_web_access</param>
        /// <param name="updatedEntity">The document_web_access data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, DOCUMENT_WEB_ACCESS updatedEntity);

        /// <summary>Updates a specific document_web_access by its primary key</summary>
        /// <param name="id">The primary key of the document_web_access</param>
        /// <param name="updatedEntity">The document_web_access data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<DOCUMENT_WEB_ACCESS> updatedEntity);

        /// <summary>Deletes a specific document_web_access by its primary key</summary>
        /// <param name="id">The primary key of the document_web_access</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The document_web_accessService responsible for managing document_web_access related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting document_web_access information.
    /// </remarks>
    public class DOCUMENT_WEB_ACCESSService : IDOCUMENT_WEB_ACCESSService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the DOCUMENT_WEB_ACCESS class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public DOCUMENT_WEB_ACCESSService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific document_web_access by its primary key</summary>
        /// <param name="id">The primary key of the document_web_access</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The document_web_access data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.DOCUMENT_WEB_ACCESS.AsQueryable();
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

            string[] navigationProperties = ["GUID_DOCUMENT_DOCUMENT","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER"];
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

        /// <summary>Retrieves a list of document_web_accesss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of document_web_accesss</returns>/// <exception cref="Exception"></exception>
        public async Task<List<DOCUMENT_WEB_ACCESS>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetDOCUMENT_WEB_ACCESS(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new document_web_access</summary>
        /// <param name="model">The document_web_access data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(DOCUMENT_WEB_ACCESS model)
        {
            model.GUID = await CreateDOCUMENT_WEB_ACCESS(model);
            return model.GUID;
        }

        /// <summary>Updates a specific document_web_access by its primary key</summary>
        /// <param name="id">The primary key of the document_web_access</param>
        /// <param name="updatedEntity">The document_web_access data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, DOCUMENT_WEB_ACCESS updatedEntity)
        {
            await UpdateDOCUMENT_WEB_ACCESS(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific document_web_access by its primary key</summary>
        /// <param name="id">The primary key of the document_web_access</param>
        /// <param name="updatedEntity">The document_web_access data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<DOCUMENT_WEB_ACCESS> updatedEntity)
        {
            await PatchDOCUMENT_WEB_ACCESS(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific document_web_access by its primary key</summary>
        /// <param name="id">The primary key of the document_web_access</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteDOCUMENT_WEB_ACCESS(id);
            return true;
        }
        #region
        private async Task<List<DOCUMENT_WEB_ACCESS>> GetDOCUMENT_WEB_ACCESS(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DOCUMENT_WEB_ACCESS.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DOCUMENT_WEB_ACCESS>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DOCUMENT_WEB_ACCESS), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DOCUMENT_WEB_ACCESS, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateDOCUMENT_WEB_ACCESS(DOCUMENT_WEB_ACCESS model)
        {
            _dbContext.DOCUMENT_WEB_ACCESS.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateDOCUMENT_WEB_ACCESS(Guid id, DOCUMENT_WEB_ACCESS updatedEntity)
        {
            _dbContext.DOCUMENT_WEB_ACCESS.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteDOCUMENT_WEB_ACCESS(Guid id)
        {
            var entityData = _dbContext.DOCUMENT_WEB_ACCESS.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DOCUMENT_WEB_ACCESS.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchDOCUMENT_WEB_ACCESS(Guid id, JsonPatchDocument<DOCUMENT_WEB_ACCESS> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DOCUMENT_WEB_ACCESS.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DOCUMENT_WEB_ACCESS.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}