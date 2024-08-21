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
    /// The building_categoryService responsible for managing building_category related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting building_category information.
    /// </remarks>
    public interface IBUILDING_CATEGORYService
    {
        /// <summary>Retrieves a specific building_category by its primary key</summary>
        /// <param name="id">The primary key of the building_category</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The building_category data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of building_categorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of building_categorys</returns>
        Task<List<BUILDING_CATEGORY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new building_category</summary>
        /// <param name="model">The building_category data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(BUILDING_CATEGORY model);

        /// <summary>Updates a specific building_category by its primary key</summary>
        /// <param name="id">The primary key of the building_category</param>
        /// <param name="updatedEntity">The building_category data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, BUILDING_CATEGORY updatedEntity);

        /// <summary>Updates a specific building_category by its primary key</summary>
        /// <param name="id">The primary key of the building_category</param>
        /// <param name="updatedEntity">The building_category data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<BUILDING_CATEGORY> updatedEntity);

        /// <summary>Deletes a specific building_category by its primary key</summary>
        /// <param name="id">The primary key of the building_category</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The building_categoryService responsible for managing building_category related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting building_category information.
    /// </remarks>
    public class BUILDING_CATEGORYService : IBUILDING_CATEGORYService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the BUILDING_CATEGORY class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public BUILDING_CATEGORYService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific building_category by its primary key</summary>
        /// <param name="id">The primary key of the building_category</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The building_category data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.BUILDING_CATEGORY.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER"];
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

        /// <summary>Retrieves a list of building_categorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of building_categorys</returns>/// <exception cref="Exception"></exception>
        public async Task<List<BUILDING_CATEGORY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetBUILDING_CATEGORY(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new building_category</summary>
        /// <param name="model">The building_category data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(BUILDING_CATEGORY model)
        {
            model.GUID = await CreateBUILDING_CATEGORY(model);
            return model.GUID;
        }

        /// <summary>Updates a specific building_category by its primary key</summary>
        /// <param name="id">The primary key of the building_category</param>
        /// <param name="updatedEntity">The building_category data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, BUILDING_CATEGORY updatedEntity)
        {
            await UpdateBUILDING_CATEGORY(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific building_category by its primary key</summary>
        /// <param name="id">The primary key of the building_category</param>
        /// <param name="updatedEntity">The building_category data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<BUILDING_CATEGORY> updatedEntity)
        {
            await PatchBUILDING_CATEGORY(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific building_category by its primary key</summary>
        /// <param name="id">The primary key of the building_category</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteBUILDING_CATEGORY(id);
            return true;
        }
        #region
        private async Task<List<BUILDING_CATEGORY>> GetBUILDING_CATEGORY(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.BUILDING_CATEGORY.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<BUILDING_CATEGORY>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(BUILDING_CATEGORY), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<BUILDING_CATEGORY, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateBUILDING_CATEGORY(BUILDING_CATEGORY model)
        {
            _dbContext.BUILDING_CATEGORY.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateBUILDING_CATEGORY(Guid id, BUILDING_CATEGORY updatedEntity)
        {
            _dbContext.BUILDING_CATEGORY.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteBUILDING_CATEGORY(Guid id)
        {
            var entityData = _dbContext.BUILDING_CATEGORY.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.BUILDING_CATEGORY.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchBUILDING_CATEGORY(Guid id, JsonPatchDocument<BUILDING_CATEGORY> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.BUILDING_CATEGORY.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.BUILDING_CATEGORY.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}