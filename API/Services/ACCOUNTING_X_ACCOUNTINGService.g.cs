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
    /// The accounting_x_accountingService responsible for managing accounting_x_accounting related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting accounting_x_accounting information.
    /// </remarks>
    public interface IACCOUNTING_X_ACCOUNTINGService
    {
        /// <summary>Retrieves a specific accounting_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting_x_accounting</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The accounting_x_accounting data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of accounting_x_accountings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of accounting_x_accountings</returns>
        Task<List<ACCOUNTING_X_ACCOUNTING>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new accounting_x_accounting</summary>
        /// <param name="model">The accounting_x_accounting data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(ACCOUNTING_X_ACCOUNTING model);

        /// <summary>Updates a specific accounting_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting_x_accounting</param>
        /// <param name="updatedEntity">The accounting_x_accounting data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, ACCOUNTING_X_ACCOUNTING updatedEntity);

        /// <summary>Updates a specific accounting_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting_x_accounting</param>
        /// <param name="updatedEntity">The accounting_x_accounting data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<ACCOUNTING_X_ACCOUNTING> updatedEntity);

        /// <summary>Deletes a specific accounting_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting_x_accounting</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The accounting_x_accountingService responsible for managing accounting_x_accounting related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting accounting_x_accounting information.
    /// </remarks>
    public class ACCOUNTING_X_ACCOUNTINGService : IACCOUNTING_X_ACCOUNTINGService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the ACCOUNTING_X_ACCOUNTING class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ACCOUNTING_X_ACCOUNTINGService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific accounting_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting_x_accounting</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The accounting_x_accounting data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.ACCOUNTING_X_ACCOUNTING.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_PARENT_ACCOUNTING_ACCOUNTING","GUID_CHILD_ACCOUNTING_ACCOUNTING","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of accounting_x_accountings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of accounting_x_accountings</returns>/// <exception cref="Exception"></exception>
        public async Task<List<ACCOUNTING_X_ACCOUNTING>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetACCOUNTING_X_ACCOUNTING(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new accounting_x_accounting</summary>
        /// <param name="model">The accounting_x_accounting data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(ACCOUNTING_X_ACCOUNTING model)
        {
            model.GUID = await CreateACCOUNTING_X_ACCOUNTING(model);
            return model.GUID;
        }

        /// <summary>Updates a specific accounting_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting_x_accounting</param>
        /// <param name="updatedEntity">The accounting_x_accounting data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, ACCOUNTING_X_ACCOUNTING updatedEntity)
        {
            await UpdateACCOUNTING_X_ACCOUNTING(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific accounting_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting_x_accounting</param>
        /// <param name="updatedEntity">The accounting_x_accounting data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<ACCOUNTING_X_ACCOUNTING> updatedEntity)
        {
            await PatchACCOUNTING_X_ACCOUNTING(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific accounting_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the accounting_x_accounting</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteACCOUNTING_X_ACCOUNTING(id);
            return true;
        }
        #region
        private async Task<List<ACCOUNTING_X_ACCOUNTING>> GetACCOUNTING_X_ACCOUNTING(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ACCOUNTING_X_ACCOUNTING.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ACCOUNTING_X_ACCOUNTING>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ACCOUNTING_X_ACCOUNTING), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ACCOUNTING_X_ACCOUNTING, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateACCOUNTING_X_ACCOUNTING(ACCOUNTING_X_ACCOUNTING model)
        {
            _dbContext.ACCOUNTING_X_ACCOUNTING.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateACCOUNTING_X_ACCOUNTING(Guid id, ACCOUNTING_X_ACCOUNTING updatedEntity)
        {
            _dbContext.ACCOUNTING_X_ACCOUNTING.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteACCOUNTING_X_ACCOUNTING(Guid id)
        {
            var entityData = _dbContext.ACCOUNTING_X_ACCOUNTING.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ACCOUNTING_X_ACCOUNTING.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchACCOUNTING_X_ACCOUNTING(Guid id, JsonPatchDocument<ACCOUNTING_X_ACCOUNTING> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ACCOUNTING_X_ACCOUNTING.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ACCOUNTING_X_ACCOUNTING.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}