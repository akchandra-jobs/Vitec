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
    /// The accountingService responsible for managing accounting related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting accounting information.
    /// </remarks>
    public interface IACCOUNTINGService
    {
        /// <summary>Retrieves a specific accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The accounting data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of accountings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of accountings</returns>
        Task<List<ACCOUNTING>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new accounting</summary>
        /// <param name="model">The accounting data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(ACCOUNTING model);

        /// <summary>Updates a specific accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting</param>
        /// <param name="updatedEntity">The accounting data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, ACCOUNTING updatedEntity);

        /// <summary>Updates a specific accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting</param>
        /// <param name="updatedEntity">The accounting data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<ACCOUNTING> updatedEntity);

        /// <summary>Deletes a specific accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The accountingService responsible for managing accounting related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting accounting information.
    /// </remarks>
    public class ACCOUNTINGService : IACCOUNTINGService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the ACCOUNTING class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ACCOUNTINGService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The accounting data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.ACCOUNTING.AsQueryable();
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

        /// <summary>Retrieves a list of accountings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of accountings</returns>/// <exception cref="Exception"></exception>
        public async Task<List<ACCOUNTING>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetACCOUNTING(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new accounting</summary>
        /// <param name="model">The accounting data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(ACCOUNTING model)
        {
            model.GUID = await CreateACCOUNTING(model);
            return model.GUID;
        }

        /// <summary>Updates a specific accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting</param>
        /// <param name="updatedEntity">The accounting data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, ACCOUNTING updatedEntity)
        {
            await UpdateACCOUNTING(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting</param>
        /// <param name="updatedEntity">The accounting data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<ACCOUNTING> updatedEntity)
        {
            await PatchACCOUNTING(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteACCOUNTING(id);
            return true;
        }
        #region
        private async Task<List<ACCOUNTING>> GetACCOUNTING(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ACCOUNTING.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ACCOUNTING>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ACCOUNTING), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ACCOUNTING, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateACCOUNTING(ACCOUNTING model)
        {
            _dbContext.ACCOUNTING.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateACCOUNTING(Guid id, ACCOUNTING updatedEntity)
        {
            _dbContext.ACCOUNTING.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteACCOUNTING(Guid id)
        {
            var entityData = _dbContext.ACCOUNTING.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ACCOUNTING.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchACCOUNTING(Guid id, JsonPatchDocument<ACCOUNTING> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ACCOUNTING.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ACCOUNTING.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}