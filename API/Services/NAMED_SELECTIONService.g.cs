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
    /// The named_selectionService responsible for managing named_selection related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting named_selection information.
    /// </remarks>
    public interface INAMED_SELECTIONService
    {
        /// <summary>Retrieves a specific named_selection by its primary key</summary>
        /// <param name="id">The primary key of the named_selection</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The named_selection data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of named_selections based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of named_selections</returns>
        Task<List<NAMED_SELECTION>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new named_selection</summary>
        /// <param name="model">The named_selection data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(NAMED_SELECTION model);

        /// <summary>Updates a specific named_selection by its primary key</summary>
        /// <param name="id">The primary key of the named_selection</param>
        /// <param name="updatedEntity">The named_selection data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, NAMED_SELECTION updatedEntity);

        /// <summary>Updates a specific named_selection by its primary key</summary>
        /// <param name="id">The primary key of the named_selection</param>
        /// <param name="updatedEntity">The named_selection data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<NAMED_SELECTION> updatedEntity);

        /// <summary>Deletes a specific named_selection by its primary key</summary>
        /// <param name="id">The primary key of the named_selection</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The named_selectionService responsible for managing named_selection related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting named_selection information.
    /// </remarks>
    public class NAMED_SELECTIONService : INAMED_SELECTIONService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the NAMED_SELECTION class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public NAMED_SELECTIONService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific named_selection by its primary key</summary>
        /// <param name="id">The primary key of the named_selection</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The named_selection data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.NAMED_SELECTION.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DEFAULT_NAMED_SELECTION_VALUE_NAMED_SELECTION_VALUE"];
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

        /// <summary>Retrieves a list of named_selections based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of named_selections</returns>/// <exception cref="Exception"></exception>
        public async Task<List<NAMED_SELECTION>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetNAMED_SELECTION(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new named_selection</summary>
        /// <param name="model">The named_selection data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(NAMED_SELECTION model)
        {
            model.GUID = await CreateNAMED_SELECTION(model);
            return model.GUID;
        }

        /// <summary>Updates a specific named_selection by its primary key</summary>
        /// <param name="id">The primary key of the named_selection</param>
        /// <param name="updatedEntity">The named_selection data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, NAMED_SELECTION updatedEntity)
        {
            await UpdateNAMED_SELECTION(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific named_selection by its primary key</summary>
        /// <param name="id">The primary key of the named_selection</param>
        /// <param name="updatedEntity">The named_selection data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<NAMED_SELECTION> updatedEntity)
        {
            await PatchNAMED_SELECTION(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific named_selection by its primary key</summary>
        /// <param name="id">The primary key of the named_selection</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteNAMED_SELECTION(id);
            return true;
        }
        #region
        private async Task<List<NAMED_SELECTION>> GetNAMED_SELECTION(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.NAMED_SELECTION.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<NAMED_SELECTION>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(NAMED_SELECTION), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<NAMED_SELECTION, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateNAMED_SELECTION(NAMED_SELECTION model)
        {
            _dbContext.NAMED_SELECTION.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateNAMED_SELECTION(Guid id, NAMED_SELECTION updatedEntity)
        {
            _dbContext.NAMED_SELECTION.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteNAMED_SELECTION(Guid id)
        {
            var entityData = _dbContext.NAMED_SELECTION.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.NAMED_SELECTION.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchNAMED_SELECTION(Guid id, JsonPatchDocument<NAMED_SELECTION> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.NAMED_SELECTION.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.NAMED_SELECTION.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}