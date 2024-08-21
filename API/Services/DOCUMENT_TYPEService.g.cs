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
    /// The document_typeService responsible for managing document_type related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting document_type information.
    /// </remarks>
    public interface IDOCUMENT_TYPEService
    {
        /// <summary>Retrieves a specific document_type by its primary key</summary>
        /// <param name="id">The primary key of the document_type</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The document_type data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of document_types based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of document_types</returns>
        Task<List<DOCUMENT_TYPE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new document_type</summary>
        /// <param name="model">The document_type data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(DOCUMENT_TYPE model);

        /// <summary>Updates a specific document_type by its primary key</summary>
        /// <param name="id">The primary key of the document_type</param>
        /// <param name="updatedEntity">The document_type data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, DOCUMENT_TYPE updatedEntity);

        /// <summary>Updates a specific document_type by its primary key</summary>
        /// <param name="id">The primary key of the document_type</param>
        /// <param name="updatedEntity">The document_type data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<DOCUMENT_TYPE> updatedEntity);

        /// <summary>Deletes a specific document_type by its primary key</summary>
        /// <param name="id">The primary key of the document_type</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The document_typeService responsible for managing document_type related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting document_type information.
    /// </remarks>
    public class DOCUMENT_TYPEService : IDOCUMENT_TYPEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the DOCUMENT_TYPE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public DOCUMENT_TYPEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific document_type by its primary key</summary>
        /// <param name="id">The primary key of the document_type</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The document_type data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.DOCUMENT_TYPE.AsQueryable();
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

        /// <summary>Retrieves a list of document_types based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of document_types</returns>/// <exception cref="Exception"></exception>
        public async Task<List<DOCUMENT_TYPE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetDOCUMENT_TYPE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new document_type</summary>
        /// <param name="model">The document_type data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(DOCUMENT_TYPE model)
        {
            model.GUID = await CreateDOCUMENT_TYPE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific document_type by its primary key</summary>
        /// <param name="id">The primary key of the document_type</param>
        /// <param name="updatedEntity">The document_type data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, DOCUMENT_TYPE updatedEntity)
        {
            await UpdateDOCUMENT_TYPE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific document_type by its primary key</summary>
        /// <param name="id">The primary key of the document_type</param>
        /// <param name="updatedEntity">The document_type data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<DOCUMENT_TYPE> updatedEntity)
        {
            await PatchDOCUMENT_TYPE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific document_type by its primary key</summary>
        /// <param name="id">The primary key of the document_type</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteDOCUMENT_TYPE(id);
            return true;
        }
        #region
        private async Task<List<DOCUMENT_TYPE>> GetDOCUMENT_TYPE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DOCUMENT_TYPE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DOCUMENT_TYPE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DOCUMENT_TYPE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DOCUMENT_TYPE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateDOCUMENT_TYPE(DOCUMENT_TYPE model)
        {
            _dbContext.DOCUMENT_TYPE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateDOCUMENT_TYPE(Guid id, DOCUMENT_TYPE updatedEntity)
        {
            _dbContext.DOCUMENT_TYPE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteDOCUMENT_TYPE(Guid id)
        {
            var entityData = _dbContext.DOCUMENT_TYPE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DOCUMENT_TYPE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchDOCUMENT_TYPE(Guid id, JsonPatchDocument<DOCUMENT_TYPE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DOCUMENT_TYPE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DOCUMENT_TYPE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}