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
    /// The list_highlightService responsible for managing list_highlight related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting list_highlight information.
    /// </remarks>
    public interface ILIST_HIGHLIGHTService
    {
        /// <summary>Retrieves a specific list_highlight by its primary key</summary>
        /// <param name="id">The primary key of the list_highlight</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The list_highlight data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of list_highlights based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of list_highlights</returns>
        Task<List<LIST_HIGHLIGHT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new list_highlight</summary>
        /// <param name="model">The list_highlight data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(LIST_HIGHLIGHT model);

        /// <summary>Updates a specific list_highlight by its primary key</summary>
        /// <param name="id">The primary key of the list_highlight</param>
        /// <param name="updatedEntity">The list_highlight data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, LIST_HIGHLIGHT updatedEntity);

        /// <summary>Updates a specific list_highlight by its primary key</summary>
        /// <param name="id">The primary key of the list_highlight</param>
        /// <param name="updatedEntity">The list_highlight data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<LIST_HIGHLIGHT> updatedEntity);

        /// <summary>Deletes a specific list_highlight by its primary key</summary>
        /// <param name="id">The primary key of the list_highlight</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The list_highlightService responsible for managing list_highlight related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting list_highlight information.
    /// </remarks>
    public class LIST_HIGHLIGHTService : ILIST_HIGHLIGHTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the LIST_HIGHLIGHT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public LIST_HIGHLIGHTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific list_highlight by its primary key</summary>
        /// <param name="id">The primary key of the list_highlight</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The list_highlight data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.LIST_HIGHLIGHT.AsQueryable();
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

        /// <summary>Retrieves a list of list_highlights based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of list_highlights</returns>/// <exception cref="Exception"></exception>
        public async Task<List<LIST_HIGHLIGHT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetLIST_HIGHLIGHT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new list_highlight</summary>
        /// <param name="model">The list_highlight data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(LIST_HIGHLIGHT model)
        {
            model.GUID = await CreateLIST_HIGHLIGHT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific list_highlight by its primary key</summary>
        /// <param name="id">The primary key of the list_highlight</param>
        /// <param name="updatedEntity">The list_highlight data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, LIST_HIGHLIGHT updatedEntity)
        {
            await UpdateLIST_HIGHLIGHT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific list_highlight by its primary key</summary>
        /// <param name="id">The primary key of the list_highlight</param>
        /// <param name="updatedEntity">The list_highlight data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<LIST_HIGHLIGHT> updatedEntity)
        {
            await PatchLIST_HIGHLIGHT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific list_highlight by its primary key</summary>
        /// <param name="id">The primary key of the list_highlight</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteLIST_HIGHLIGHT(id);
            return true;
        }
        #region
        private async Task<List<LIST_HIGHLIGHT>> GetLIST_HIGHLIGHT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.LIST_HIGHLIGHT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<LIST_HIGHLIGHT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(LIST_HIGHLIGHT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<LIST_HIGHLIGHT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateLIST_HIGHLIGHT(LIST_HIGHLIGHT model)
        {
            _dbContext.LIST_HIGHLIGHT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateLIST_HIGHLIGHT(Guid id, LIST_HIGHLIGHT updatedEntity)
        {
            _dbContext.LIST_HIGHLIGHT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteLIST_HIGHLIGHT(Guid id)
        {
            var entityData = _dbContext.LIST_HIGHLIGHT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.LIST_HIGHLIGHT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchLIST_HIGHLIGHT(Guid id, JsonPatchDocument<LIST_HIGHLIGHT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.LIST_HIGHLIGHT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.LIST_HIGHLIGHT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}