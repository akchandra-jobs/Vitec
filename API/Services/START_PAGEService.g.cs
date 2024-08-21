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
    /// The start_pageService responsible for managing start_page related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting start_page information.
    /// </remarks>
    public interface ISTART_PAGEService
    {
        /// <summary>Retrieves a specific start_page by its primary key</summary>
        /// <param name="id">The primary key of the start_page</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The start_page data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of start_pages based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of start_pages</returns>
        Task<List<START_PAGE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new start_page</summary>
        /// <param name="model">The start_page data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(START_PAGE model);

        /// <summary>Updates a specific start_page by its primary key</summary>
        /// <param name="id">The primary key of the start_page</param>
        /// <param name="updatedEntity">The start_page data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, START_PAGE updatedEntity);

        /// <summary>Updates a specific start_page by its primary key</summary>
        /// <param name="id">The primary key of the start_page</param>
        /// <param name="updatedEntity">The start_page data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<START_PAGE> updatedEntity);

        /// <summary>Deletes a specific start_page by its primary key</summary>
        /// <param name="id">The primary key of the start_page</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The start_pageService responsible for managing start_page related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting start_page information.
    /// </remarks>
    public class START_PAGEService : ISTART_PAGEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the START_PAGE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public START_PAGEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific start_page by its primary key</summary>
        /// <param name="id">The primary key of the start_page</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The start_page data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.START_PAGE.AsQueryable();
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

        /// <summary>Retrieves a list of start_pages based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of start_pages</returns>/// <exception cref="Exception"></exception>
        public async Task<List<START_PAGE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetSTART_PAGE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new start_page</summary>
        /// <param name="model">The start_page data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(START_PAGE model)
        {
            model.GUID = await CreateSTART_PAGE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific start_page by its primary key</summary>
        /// <param name="id">The primary key of the start_page</param>
        /// <param name="updatedEntity">The start_page data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, START_PAGE updatedEntity)
        {
            await UpdateSTART_PAGE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific start_page by its primary key</summary>
        /// <param name="id">The primary key of the start_page</param>
        /// <param name="updatedEntity">The start_page data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<START_PAGE> updatedEntity)
        {
            await PatchSTART_PAGE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific start_page by its primary key</summary>
        /// <param name="id">The primary key of the start_page</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteSTART_PAGE(id);
            return true;
        }
        #region
        private async Task<List<START_PAGE>> GetSTART_PAGE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.START_PAGE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<START_PAGE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(START_PAGE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<START_PAGE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateSTART_PAGE(START_PAGE model)
        {
            _dbContext.START_PAGE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateSTART_PAGE(Guid id, START_PAGE updatedEntity)
        {
            _dbContext.START_PAGE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteSTART_PAGE(Guid id)
        {
            var entityData = _dbContext.START_PAGE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.START_PAGE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchSTART_PAGE(Guid id, JsonPatchDocument<START_PAGE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.START_PAGE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.START_PAGE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}