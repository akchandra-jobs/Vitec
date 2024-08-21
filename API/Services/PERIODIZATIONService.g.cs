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
    /// The periodizationService responsible for managing periodization related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting periodization information.
    /// </remarks>
    public interface IPERIODIZATIONService
    {
        /// <summary>Retrieves a specific periodization by its primary key</summary>
        /// <param name="id">The primary key of the periodization</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The periodization data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of periodizations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of periodizations</returns>
        Task<List<PERIODIZATION>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new periodization</summary>
        /// <param name="model">The periodization data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PERIODIZATION model);

        /// <summary>Updates a specific periodization by its primary key</summary>
        /// <param name="id">The primary key of the periodization</param>
        /// <param name="updatedEntity">The periodization data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PERIODIZATION updatedEntity);

        /// <summary>Updates a specific periodization by its primary key</summary>
        /// <param name="id">The primary key of the periodization</param>
        /// <param name="updatedEntity">The periodization data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PERIODIZATION> updatedEntity);

        /// <summary>Deletes a specific periodization by its primary key</summary>
        /// <param name="id">The primary key of the periodization</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The periodizationService responsible for managing periodization related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting periodization information.
    /// </remarks>
    public class PERIODIZATIONService : IPERIODIZATIONService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PERIODIZATION class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PERIODIZATIONService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific periodization by its primary key</summary>
        /// <param name="id">The primary key of the periodization</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The periodization data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PERIODIZATION.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_PAYMENT_ORDER_ITEM_PAYMENT_ORDER_ITEM","GUID_SERVICE_SERVICE","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of periodizations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of periodizations</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PERIODIZATION>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPERIODIZATION(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new periodization</summary>
        /// <param name="model">The periodization data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PERIODIZATION model)
        {
            model.GUID = await CreatePERIODIZATION(model);
            return model.GUID;
        }

        /// <summary>Updates a specific periodization by its primary key</summary>
        /// <param name="id">The primary key of the periodization</param>
        /// <param name="updatedEntity">The periodization data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PERIODIZATION updatedEntity)
        {
            await UpdatePERIODIZATION(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific periodization by its primary key</summary>
        /// <param name="id">The primary key of the periodization</param>
        /// <param name="updatedEntity">The periodization data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PERIODIZATION> updatedEntity)
        {
            await PatchPERIODIZATION(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific periodization by its primary key</summary>
        /// <param name="id">The primary key of the periodization</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePERIODIZATION(id);
            return true;
        }
        #region
        private async Task<List<PERIODIZATION>> GetPERIODIZATION(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PERIODIZATION.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PERIODIZATION>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PERIODIZATION), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PERIODIZATION, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePERIODIZATION(PERIODIZATION model)
        {
            _dbContext.PERIODIZATION.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePERIODIZATION(Guid id, PERIODIZATION updatedEntity)
        {
            _dbContext.PERIODIZATION.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePERIODIZATION(Guid id)
        {
            var entityData = _dbContext.PERIODIZATION.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PERIODIZATION.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPERIODIZATION(Guid id, JsonPatchDocument<PERIODIZATION> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PERIODIZATION.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PERIODIZATION.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}