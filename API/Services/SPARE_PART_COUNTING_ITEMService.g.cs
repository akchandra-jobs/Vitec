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
    /// The spare_part_counting_itemService responsible for managing spare_part_counting_item related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting spare_part_counting_item information.
    /// </remarks>
    public interface ISPARE_PART_COUNTING_ITEMService
    {
        /// <summary>Retrieves a specific spare_part_counting_item by its primary key</summary>
        /// <param name="id">The primary key of the spare_part_counting_item</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The spare_part_counting_item data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of spare_part_counting_items based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of spare_part_counting_items</returns>
        Task<List<SPARE_PART_COUNTING_ITEM>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new spare_part_counting_item</summary>
        /// <param name="model">The spare_part_counting_item data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(SPARE_PART_COUNTING_ITEM model);

        /// <summary>Updates a specific spare_part_counting_item by its primary key</summary>
        /// <param name="id">The primary key of the spare_part_counting_item</param>
        /// <param name="updatedEntity">The spare_part_counting_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, SPARE_PART_COUNTING_ITEM updatedEntity);

        /// <summary>Updates a specific spare_part_counting_item by its primary key</summary>
        /// <param name="id">The primary key of the spare_part_counting_item</param>
        /// <param name="updatedEntity">The spare_part_counting_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<SPARE_PART_COUNTING_ITEM> updatedEntity);

        /// <summary>Deletes a specific spare_part_counting_item by its primary key</summary>
        /// <param name="id">The primary key of the spare_part_counting_item</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The spare_part_counting_itemService responsible for managing spare_part_counting_item related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting spare_part_counting_item information.
    /// </remarks>
    public class SPARE_PART_COUNTING_ITEMService : ISPARE_PART_COUNTING_ITEMService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the SPARE_PART_COUNTING_ITEM class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public SPARE_PART_COUNTING_ITEMService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific spare_part_counting_item by its primary key</summary>
        /// <param name="id">The primary key of the spare_part_counting_item</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The spare_part_counting_item data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.SPARE_PART_COUNTING_ITEM.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_SPARE_PART_SPARE_PART","GUID_SPARE_PART_COUNTING_LIST_SPARE_PART_COUNTING_LIST","GUID_USER_COUNTED_BY_USR","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of spare_part_counting_items based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of spare_part_counting_items</returns>/// <exception cref="Exception"></exception>
        public async Task<List<SPARE_PART_COUNTING_ITEM>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetSPARE_PART_COUNTING_ITEM(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new spare_part_counting_item</summary>
        /// <param name="model">The spare_part_counting_item data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(SPARE_PART_COUNTING_ITEM model)
        {
            model.GUID = await CreateSPARE_PART_COUNTING_ITEM(model);
            return model.GUID;
        }

        /// <summary>Updates a specific spare_part_counting_item by its primary key</summary>
        /// <param name="id">The primary key of the spare_part_counting_item</param>
        /// <param name="updatedEntity">The spare_part_counting_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, SPARE_PART_COUNTING_ITEM updatedEntity)
        {
            await UpdateSPARE_PART_COUNTING_ITEM(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific spare_part_counting_item by its primary key</summary>
        /// <param name="id">The primary key of the spare_part_counting_item</param>
        /// <param name="updatedEntity">The spare_part_counting_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<SPARE_PART_COUNTING_ITEM> updatedEntity)
        {
            await PatchSPARE_PART_COUNTING_ITEM(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific spare_part_counting_item by its primary key</summary>
        /// <param name="id">The primary key of the spare_part_counting_item</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteSPARE_PART_COUNTING_ITEM(id);
            return true;
        }
        #region
        private async Task<List<SPARE_PART_COUNTING_ITEM>> GetSPARE_PART_COUNTING_ITEM(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SPARE_PART_COUNTING_ITEM.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SPARE_PART_COUNTING_ITEM>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SPARE_PART_COUNTING_ITEM), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SPARE_PART_COUNTING_ITEM, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateSPARE_PART_COUNTING_ITEM(SPARE_PART_COUNTING_ITEM model)
        {
            _dbContext.SPARE_PART_COUNTING_ITEM.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateSPARE_PART_COUNTING_ITEM(Guid id, SPARE_PART_COUNTING_ITEM updatedEntity)
        {
            _dbContext.SPARE_PART_COUNTING_ITEM.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteSPARE_PART_COUNTING_ITEM(Guid id)
        {
            var entityData = _dbContext.SPARE_PART_COUNTING_ITEM.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SPARE_PART_COUNTING_ITEM.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchSPARE_PART_COUNTING_ITEM(Guid id, JsonPatchDocument<SPARE_PART_COUNTING_ITEM> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SPARE_PART_COUNTING_ITEM.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SPARE_PART_COUNTING_ITEM.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}