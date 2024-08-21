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
    /// The intervalService responsible for managing interval related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting interval information.
    /// </remarks>
    public interface IINTERVALService
    {
        /// <summary>Retrieves a specific interval by its primary key</summary>
        /// <param name="id">The primary key of the interval</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The interval data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of intervals based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of intervals</returns>
        Task<List<INTERVAL>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new interval</summary>
        /// <param name="model">The interval data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(INTERVAL model);

        /// <summary>Updates a specific interval by its primary key</summary>
        /// <param name="id">The primary key of the interval</param>
        /// <param name="updatedEntity">The interval data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, INTERVAL updatedEntity);

        /// <summary>Updates a specific interval by its primary key</summary>
        /// <param name="id">The primary key of the interval</param>
        /// <param name="updatedEntity">The interval data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<INTERVAL> updatedEntity);

        /// <summary>Deletes a specific interval by its primary key</summary>
        /// <param name="id">The primary key of the interval</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The intervalService responsible for managing interval related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting interval information.
    /// </remarks>
    public class INTERVALService : IINTERVALService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the INTERVAL class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public INTERVALService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific interval by its primary key</summary>
        /// <param name="id">The primary key of the interval</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The interval data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.INTERVAL.AsQueryable();
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

        /// <summary>Retrieves a list of intervals based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of intervals</returns>/// <exception cref="Exception"></exception>
        public async Task<List<INTERVAL>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetINTERVAL(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new interval</summary>
        /// <param name="model">The interval data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(INTERVAL model)
        {
            model.GUID = await CreateINTERVAL(model);
            return model.GUID;
        }

        /// <summary>Updates a specific interval by its primary key</summary>
        /// <param name="id">The primary key of the interval</param>
        /// <param name="updatedEntity">The interval data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, INTERVAL updatedEntity)
        {
            await UpdateINTERVAL(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific interval by its primary key</summary>
        /// <param name="id">The primary key of the interval</param>
        /// <param name="updatedEntity">The interval data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<INTERVAL> updatedEntity)
        {
            await PatchINTERVAL(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific interval by its primary key</summary>
        /// <param name="id">The primary key of the interval</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteINTERVAL(id);
            return true;
        }
        #region
        private async Task<List<INTERVAL>> GetINTERVAL(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.INTERVAL.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<INTERVAL>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(INTERVAL), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<INTERVAL, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateINTERVAL(INTERVAL model)
        {
            _dbContext.INTERVAL.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateINTERVAL(Guid id, INTERVAL updatedEntity)
        {
            _dbContext.INTERVAL.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteINTERVAL(Guid id)
        {
            var entityData = _dbContext.INTERVAL.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.INTERVAL.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchINTERVAL(Guid id, JsonPatchDocument<INTERVAL> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.INTERVAL.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.INTERVAL.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}