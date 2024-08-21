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
    /// The web_menuService responsible for managing web_menu related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting web_menu information.
    /// </remarks>
    public interface IWEB_MENUService
    {
        /// <summary>Retrieves a specific web_menu by its primary key</summary>
        /// <param name="id">The primary key of the web_menu</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The web_menu data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of web_menus based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of web_menus</returns>
        Task<List<WEB_MENU>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new web_menu</summary>
        /// <param name="model">The web_menu data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(WEB_MENU model);

        /// <summary>Updates a specific web_menu by its primary key</summary>
        /// <param name="id">The primary key of the web_menu</param>
        /// <param name="updatedEntity">The web_menu data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, WEB_MENU updatedEntity);

        /// <summary>Updates a specific web_menu by its primary key</summary>
        /// <param name="id">The primary key of the web_menu</param>
        /// <param name="updatedEntity">The web_menu data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<WEB_MENU> updatedEntity);

        /// <summary>Deletes a specific web_menu by its primary key</summary>
        /// <param name="id">The primary key of the web_menu</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The web_menuService responsible for managing web_menu related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting web_menu information.
    /// </remarks>
    public class WEB_MENUService : IWEB_MENUService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the WEB_MENU class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public WEB_MENUService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific web_menu by its primary key</summary>
        /// <param name="id">The primary key of the web_menu</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The web_menu data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.WEB_MENU.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of web_menus based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of web_menus</returns>/// <exception cref="Exception"></exception>
        public async Task<List<WEB_MENU>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetWEB_MENU(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new web_menu</summary>
        /// <param name="model">The web_menu data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(WEB_MENU model)
        {
            model.GUID = await CreateWEB_MENU(model);
            return model.GUID;
        }

        /// <summary>Updates a specific web_menu by its primary key</summary>
        /// <param name="id">The primary key of the web_menu</param>
        /// <param name="updatedEntity">The web_menu data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, WEB_MENU updatedEntity)
        {
            await UpdateWEB_MENU(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific web_menu by its primary key</summary>
        /// <param name="id">The primary key of the web_menu</param>
        /// <param name="updatedEntity">The web_menu data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<WEB_MENU> updatedEntity)
        {
            await PatchWEB_MENU(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific web_menu by its primary key</summary>
        /// <param name="id">The primary key of the web_menu</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteWEB_MENU(id);
            return true;
        }
        #region
        private async Task<List<WEB_MENU>> GetWEB_MENU(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.WEB_MENU.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<WEB_MENU>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(WEB_MENU), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<WEB_MENU, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateWEB_MENU(WEB_MENU model)
        {
            _dbContext.WEB_MENU.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateWEB_MENU(Guid id, WEB_MENU updatedEntity)
        {
            _dbContext.WEB_MENU.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteWEB_MENU(Guid id)
        {
            var entityData = _dbContext.WEB_MENU.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.WEB_MENU.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchWEB_MENU(Guid id, JsonPatchDocument<WEB_MENU> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.WEB_MENU.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.WEB_MENU.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}