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
    /// The cost_centerService responsible for managing cost_center related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cost_center information.
    /// </remarks>
    public interface ICOST_CENTERService
    {
        /// <summary>Retrieves a specific cost_center by its primary key</summary>
        /// <param name="id">The primary key of the cost_center</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The cost_center data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of cost_centers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cost_centers</returns>
        Task<List<COST_CENTER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new cost_center</summary>
        /// <param name="model">The cost_center data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(COST_CENTER model);

        /// <summary>Updates a specific cost_center by its primary key</summary>
        /// <param name="id">The primary key of the cost_center</param>
        /// <param name="updatedEntity">The cost_center data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, COST_CENTER updatedEntity);

        /// <summary>Updates a specific cost_center by its primary key</summary>
        /// <param name="id">The primary key of the cost_center</param>
        /// <param name="updatedEntity">The cost_center data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<COST_CENTER> updatedEntity);

        /// <summary>Deletes a specific cost_center by its primary key</summary>
        /// <param name="id">The primary key of the cost_center</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The cost_centerService responsible for managing cost_center related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cost_center information.
    /// </remarks>
    public class COST_CENTERService : ICOST_CENTERService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the COST_CENTER class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public COST_CENTERService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific cost_center by its primary key</summary>
        /// <param name="id">The primary key of the cost_center</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The cost_center data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.COST_CENTER.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_ESTATE_ESTATE","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of cost_centers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of cost_centers</returns>/// <exception cref="Exception"></exception>
        public async Task<List<COST_CENTER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetCOST_CENTER(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new cost_center</summary>
        /// <param name="model">The cost_center data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(COST_CENTER model)
        {
            model.GUID = await CreateCOST_CENTER(model);
            return model.GUID;
        }

        /// <summary>Updates a specific cost_center by its primary key</summary>
        /// <param name="id">The primary key of the cost_center</param>
        /// <param name="updatedEntity">The cost_center data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, COST_CENTER updatedEntity)
        {
            await UpdateCOST_CENTER(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific cost_center by its primary key</summary>
        /// <param name="id">The primary key of the cost_center</param>
        /// <param name="updatedEntity">The cost_center data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<COST_CENTER> updatedEntity)
        {
            await PatchCOST_CENTER(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific cost_center by its primary key</summary>
        /// <param name="id">The primary key of the cost_center</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteCOST_CENTER(id);
            return true;
        }
        #region
        private async Task<List<COST_CENTER>> GetCOST_CENTER(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.COST_CENTER.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<COST_CENTER>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(COST_CENTER), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<COST_CENTER, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateCOST_CENTER(COST_CENTER model)
        {
            _dbContext.COST_CENTER.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateCOST_CENTER(Guid id, COST_CENTER updatedEntity)
        {
            _dbContext.COST_CENTER.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteCOST_CENTER(Guid id)
        {
            var entityData = _dbContext.COST_CENTER.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.COST_CENTER.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchCOST_CENTER(Guid id, JsonPatchDocument<COST_CENTER> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.COST_CENTER.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.COST_CENTER.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}