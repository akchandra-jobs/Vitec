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
    /// The web_list_view_columnService responsible for managing web_list_view_column related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting web_list_view_column information.
    /// </remarks>
    public interface IWEB_LIST_VIEW_COLUMNService
    {
        /// <summary>Retrieves a specific web_list_view_column by its primary key</summary>
        /// <param name="id">The primary key of the web_list_view_column</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The web_list_view_column data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of web_list_view_columns based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of web_list_view_columns</returns>
        Task<List<WEB_LIST_VIEW_COLUMN>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new web_list_view_column</summary>
        /// <param name="model">The web_list_view_column data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(WEB_LIST_VIEW_COLUMN model);

        /// <summary>Updates a specific web_list_view_column by its primary key</summary>
        /// <param name="id">The primary key of the web_list_view_column</param>
        /// <param name="updatedEntity">The web_list_view_column data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, WEB_LIST_VIEW_COLUMN updatedEntity);

        /// <summary>Updates a specific web_list_view_column by its primary key</summary>
        /// <param name="id">The primary key of the web_list_view_column</param>
        /// <param name="updatedEntity">The web_list_view_column data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<WEB_LIST_VIEW_COLUMN> updatedEntity);

        /// <summary>Deletes a specific web_list_view_column by its primary key</summary>
        /// <param name="id">The primary key of the web_list_view_column</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The web_list_view_columnService responsible for managing web_list_view_column related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting web_list_view_column information.
    /// </remarks>
    public class WEB_LIST_VIEW_COLUMNService : IWEB_LIST_VIEW_COLUMNService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the WEB_LIST_VIEW_COLUMN class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public WEB_LIST_VIEW_COLUMNService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific web_list_view_column by its primary key</summary>
        /// <param name="id">The primary key of the web_list_view_column</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The web_list_view_column data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.WEB_LIST_VIEW_COLUMN.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_WEB_LIST_VIEW_WEB_LIST_VIEW","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of web_list_view_columns based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of web_list_view_columns</returns>/// <exception cref="Exception"></exception>
        public async Task<List<WEB_LIST_VIEW_COLUMN>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetWEB_LIST_VIEW_COLUMN(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new web_list_view_column</summary>
        /// <param name="model">The web_list_view_column data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(WEB_LIST_VIEW_COLUMN model)
        {
            model.GUID = await CreateWEB_LIST_VIEW_COLUMN(model);
            return model.GUID;
        }

        /// <summary>Updates a specific web_list_view_column by its primary key</summary>
        /// <param name="id">The primary key of the web_list_view_column</param>
        /// <param name="updatedEntity">The web_list_view_column data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, WEB_LIST_VIEW_COLUMN updatedEntity)
        {
            await UpdateWEB_LIST_VIEW_COLUMN(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific web_list_view_column by its primary key</summary>
        /// <param name="id">The primary key of the web_list_view_column</param>
        /// <param name="updatedEntity">The web_list_view_column data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<WEB_LIST_VIEW_COLUMN> updatedEntity)
        {
            await PatchWEB_LIST_VIEW_COLUMN(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific web_list_view_column by its primary key</summary>
        /// <param name="id">The primary key of the web_list_view_column</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteWEB_LIST_VIEW_COLUMN(id);
            return true;
        }
        #region
        private async Task<List<WEB_LIST_VIEW_COLUMN>> GetWEB_LIST_VIEW_COLUMN(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.WEB_LIST_VIEW_COLUMN.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<WEB_LIST_VIEW_COLUMN>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(WEB_LIST_VIEW_COLUMN), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<WEB_LIST_VIEW_COLUMN, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateWEB_LIST_VIEW_COLUMN(WEB_LIST_VIEW_COLUMN model)
        {
            _dbContext.WEB_LIST_VIEW_COLUMN.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateWEB_LIST_VIEW_COLUMN(Guid id, WEB_LIST_VIEW_COLUMN updatedEntity)
        {
            _dbContext.WEB_LIST_VIEW_COLUMN.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteWEB_LIST_VIEW_COLUMN(Guid id)
        {
            var entityData = _dbContext.WEB_LIST_VIEW_COLUMN.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.WEB_LIST_VIEW_COLUMN.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchWEB_LIST_VIEW_COLUMN(Guid id, JsonPatchDocument<WEB_LIST_VIEW_COLUMN> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.WEB_LIST_VIEW_COLUMN.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.WEB_LIST_VIEW_COLUMN.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}