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
    /// The documentService responsible for managing document related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting document information.
    /// </remarks>
    public interface IDOCUMENTService
    {
        /// <summary>Retrieves a specific document by its primary key</summary>
        /// <param name="id">The primary key of the document</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The document data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of documents based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of documents</returns>
        Task<List<DOCUMENT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new document</summary>
        /// <param name="model">The document data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(DOCUMENT model);

        /// <summary>Updates a specific document by its primary key</summary>
        /// <param name="id">The primary key of the document</param>
        /// <param name="updatedEntity">The document data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, DOCUMENT updatedEntity);

        /// <summary>Updates a specific document by its primary key</summary>
        /// <param name="id">The primary key of the document</param>
        /// <param name="updatedEntity">The document data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<DOCUMENT> updatedEntity);

        /// <summary>Deletes a specific document by its primary key</summary>
        /// <param name="id">The primary key of the document</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The documentService responsible for managing document related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting document information.
    /// </remarks>
    public class DOCUMENTService : IDOCUMENTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the DOCUMENT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public DOCUMENTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific document by its primary key</summary>
        /// <param name="id">The primary key of the document</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The document data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.DOCUMENT.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_BUILDING_BUILDING","GUID_DOCUMENT_CATEGORY_DOCUMENT_CATEGORY","GUID_SUPPLIER_SUPPLIER","GUID_DOCUMENT_TYPE_DOCUMENT_TYPE","GUID_DOCUMENT_TEMPLATE_DOCUMENT","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of documents based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of documents</returns>/// <exception cref="Exception"></exception>
        public async Task<List<DOCUMENT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetDOCUMENT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new document</summary>
        /// <param name="model">The document data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(DOCUMENT model)
        {
            model.GUID = await CreateDOCUMENT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific document by its primary key</summary>
        /// <param name="id">The primary key of the document</param>
        /// <param name="updatedEntity">The document data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, DOCUMENT updatedEntity)
        {
            await UpdateDOCUMENT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific document by its primary key</summary>
        /// <param name="id">The primary key of the document</param>
        /// <param name="updatedEntity">The document data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<DOCUMENT> updatedEntity)
        {
            await PatchDOCUMENT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific document by its primary key</summary>
        /// <param name="id">The primary key of the document</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteDOCUMENT(id);
            return true;
        }
        #region
        private async Task<List<DOCUMENT>> GetDOCUMENT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DOCUMENT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DOCUMENT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DOCUMENT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DOCUMENT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateDOCUMENT(DOCUMENT model)
        {
            _dbContext.DOCUMENT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateDOCUMENT(Guid id, DOCUMENT updatedEntity)
        {
            _dbContext.DOCUMENT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteDOCUMENT(Guid id)
        {
            var entityData = _dbContext.DOCUMENT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DOCUMENT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchDOCUMENT(Guid id, JsonPatchDocument<DOCUMENT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DOCUMENT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DOCUMENT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}