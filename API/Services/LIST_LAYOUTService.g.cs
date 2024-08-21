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
    /// The list_layoutService responsible for managing list_layout related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting list_layout information.
    /// </remarks>
    public interface ILIST_LAYOUTService
    {
        /// <summary>Retrieves a specific list_layout by its primary key</summary>
        /// <param name="id">The primary key of the list_layout</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The list_layout data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of list_layouts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of list_layouts</returns>
        Task<List<LIST_LAYOUT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new list_layout</summary>
        /// <param name="model">The list_layout data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(LIST_LAYOUT model);

        /// <summary>Updates a specific list_layout by its primary key</summary>
        /// <param name="id">The primary key of the list_layout</param>
        /// <param name="updatedEntity">The list_layout data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, LIST_LAYOUT updatedEntity);

        /// <summary>Updates a specific list_layout by its primary key</summary>
        /// <param name="id">The primary key of the list_layout</param>
        /// <param name="updatedEntity">The list_layout data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<LIST_LAYOUT> updatedEntity);

        /// <summary>Deletes a specific list_layout by its primary key</summary>
        /// <param name="id">The primary key of the list_layout</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The list_layoutService responsible for managing list_layout related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting list_layout information.
    /// </remarks>
    public class LIST_LAYOUTService : ILIST_LAYOUTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the LIST_LAYOUT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public LIST_LAYOUTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific list_layout by its primary key</summary>
        /// <param name="id">The primary key of the list_layout</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The list_layout data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.LIST_LAYOUT.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_USER_USR","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of list_layouts based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of list_layouts</returns>/// <exception cref="Exception"></exception>
        public async Task<List<LIST_LAYOUT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetLIST_LAYOUT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new list_layout</summary>
        /// <param name="model">The list_layout data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(LIST_LAYOUT model)
        {
            model.GUID = await CreateLIST_LAYOUT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific list_layout by its primary key</summary>
        /// <param name="id">The primary key of the list_layout</param>
        /// <param name="updatedEntity">The list_layout data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, LIST_LAYOUT updatedEntity)
        {
            await UpdateLIST_LAYOUT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific list_layout by its primary key</summary>
        /// <param name="id">The primary key of the list_layout</param>
        /// <param name="updatedEntity">The list_layout data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<LIST_LAYOUT> updatedEntity)
        {
            await PatchLIST_LAYOUT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific list_layout by its primary key</summary>
        /// <param name="id">The primary key of the list_layout</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteLIST_LAYOUT(id);
            return true;
        }
        #region
        private async Task<List<LIST_LAYOUT>> GetLIST_LAYOUT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.LIST_LAYOUT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<LIST_LAYOUT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(LIST_LAYOUT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<LIST_LAYOUT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateLIST_LAYOUT(LIST_LAYOUT model)
        {
            _dbContext.LIST_LAYOUT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateLIST_LAYOUT(Guid id, LIST_LAYOUT updatedEntity)
        {
            _dbContext.LIST_LAYOUT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteLIST_LAYOUT(Guid id)
        {
            var entityData = _dbContext.LIST_LAYOUT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.LIST_LAYOUT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchLIST_LAYOUT(Guid id, JsonPatchDocument<LIST_LAYOUT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.LIST_LAYOUT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.LIST_LAYOUT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}