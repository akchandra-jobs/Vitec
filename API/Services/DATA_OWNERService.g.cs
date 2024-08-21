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
    /// The data_ownerService responsible for managing data_owner related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting data_owner information.
    /// </remarks>
    public interface IDATA_OWNERService
    {
        /// <summary>Retrieves a specific data_owner by its primary key</summary>
        /// <param name="id">The primary key of the data_owner</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The data_owner data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of data_owners based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of data_owners</returns>
        Task<List<DATA_OWNER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new data_owner</summary>
        /// <param name="model">The data_owner data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(DATA_OWNER model);

        /// <summary>Updates a specific data_owner by its primary key</summary>
        /// <param name="id">The primary key of the data_owner</param>
        /// <param name="updatedEntity">The data_owner data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, DATA_OWNER updatedEntity);

        /// <summary>Updates a specific data_owner by its primary key</summary>
        /// <param name="id">The primary key of the data_owner</param>
        /// <param name="updatedEntity">The data_owner data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<DATA_OWNER> updatedEntity);

        /// <summary>Deletes a specific data_owner by its primary key</summary>
        /// <param name="id">The primary key of the data_owner</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The data_ownerService responsible for managing data_owner related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting data_owner information.
    /// </remarks>
    public class DATA_OWNERService : IDATA_OWNERService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the DATA_OWNER class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public DATA_OWNERService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific data_owner by its primary key</summary>
        /// <param name="id">The primary key of the data_owner</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The data_owner data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.DATA_OWNER.AsQueryable();
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

            string[] navigationProperties = ["GUID_WORK_ORDER_EMAIL_DOCUMENT_CATEGORY_DOCUMENT_CATEGORY","GUID_DEFAULT_EMAIL_DOCUMENT_TYPE_DOCUMENT_TYPE","GUID_PURCHASE_ORDER_EMAIL_DOCUMENT_CATEGORY_DOCUMENT_CATEGORY","GUID_WO_X_EQ_DOCUMENT_CATEGORY_DOCUMENT_CATEGORY","GUID_IMAGE_LOGO_IMAGE","GUID_DEFAULT_DOCUMENT_TYPE_DOCUMENT_TYPE","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of data_owners based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of data_owners</returns>/// <exception cref="Exception"></exception>
        public async Task<List<DATA_OWNER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetDATA_OWNER(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new data_owner</summary>
        /// <param name="model">The data_owner data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(DATA_OWNER model)
        {
            model.GUID = await CreateDATA_OWNER(model);
            return model.GUID;
        }

        /// <summary>Updates a specific data_owner by its primary key</summary>
        /// <param name="id">The primary key of the data_owner</param>
        /// <param name="updatedEntity">The data_owner data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, DATA_OWNER updatedEntity)
        {
            await UpdateDATA_OWNER(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific data_owner by its primary key</summary>
        /// <param name="id">The primary key of the data_owner</param>
        /// <param name="updatedEntity">The data_owner data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<DATA_OWNER> updatedEntity)
        {
            await PatchDATA_OWNER(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific data_owner by its primary key</summary>
        /// <param name="id">The primary key of the data_owner</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteDATA_OWNER(id);
            return true;
        }
        #region
        private async Task<List<DATA_OWNER>> GetDATA_OWNER(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DATA_OWNER.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DATA_OWNER>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DATA_OWNER), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DATA_OWNER, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateDATA_OWNER(DATA_OWNER model)
        {
            _dbContext.DATA_OWNER.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateDATA_OWNER(Guid id, DATA_OWNER updatedEntity)
        {
            _dbContext.DATA_OWNER.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteDATA_OWNER(Guid id)
        {
            var entityData = _dbContext.DATA_OWNER.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DATA_OWNER.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchDATA_OWNER(Guid id, JsonPatchDocument<DATA_OWNER> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DATA_OWNER.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DATA_OWNER.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}