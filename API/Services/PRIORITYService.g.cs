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
    /// The priorityService responsible for managing priority related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting priority information.
    /// </remarks>
    public interface IPRIORITYService
    {
        /// <summary>Retrieves a specific priority by its primary key</summary>
        /// <param name="id">The primary key of the priority</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The priority data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of prioritys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of prioritys</returns>
        Task<List<PRIORITY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new priority</summary>
        /// <param name="model">The priority data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PRIORITY model);

        /// <summary>Updates a specific priority by its primary key</summary>
        /// <param name="id">The primary key of the priority</param>
        /// <param name="updatedEntity">The priority data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PRIORITY updatedEntity);

        /// <summary>Updates a specific priority by its primary key</summary>
        /// <param name="id">The primary key of the priority</param>
        /// <param name="updatedEntity">The priority data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PRIORITY> updatedEntity);

        /// <summary>Deletes a specific priority by its primary key</summary>
        /// <param name="id">The primary key of the priority</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The priorityService responsible for managing priority related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting priority information.
    /// </remarks>
    public class PRIORITYService : IPRIORITYService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PRIORITY class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PRIORITYService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific priority by its primary key</summary>
        /// <param name="id">The primary key of the priority</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The priority data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PRIORITY.AsQueryable();
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

        /// <summary>Retrieves a list of prioritys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of prioritys</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PRIORITY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPRIORITY(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new priority</summary>
        /// <param name="model">The priority data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PRIORITY model)
        {
            model.GUID = await CreatePRIORITY(model);
            return model.GUID;
        }

        /// <summary>Updates a specific priority by its primary key</summary>
        /// <param name="id">The primary key of the priority</param>
        /// <param name="updatedEntity">The priority data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PRIORITY updatedEntity)
        {
            await UpdatePRIORITY(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific priority by its primary key</summary>
        /// <param name="id">The primary key of the priority</param>
        /// <param name="updatedEntity">The priority data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PRIORITY> updatedEntity)
        {
            await PatchPRIORITY(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific priority by its primary key</summary>
        /// <param name="id">The primary key of the priority</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePRIORITY(id);
            return true;
        }
        #region
        private async Task<List<PRIORITY>> GetPRIORITY(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PRIORITY.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PRIORITY>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PRIORITY), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PRIORITY, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePRIORITY(PRIORITY model)
        {
            _dbContext.PRIORITY.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePRIORITY(Guid id, PRIORITY updatedEntity)
        {
            _dbContext.PRIORITY.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePRIORITY(Guid id)
        {
            var entityData = _dbContext.PRIORITY.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PRIORITY.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPRIORITY(Guid id, JsonPatchDocument<PRIORITY> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PRIORITY.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PRIORITY.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}