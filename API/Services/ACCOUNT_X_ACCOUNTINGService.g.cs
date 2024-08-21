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
    /// The account_x_accountingService responsible for managing account_x_accounting related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting account_x_accounting information.
    /// </remarks>
    public interface IACCOUNT_X_ACCOUNTINGService
    {
        /// <summary>Retrieves a specific account_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the account_x_accounting</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The account_x_accounting data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of account_x_accountings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of account_x_accountings</returns>
        Task<List<ACCOUNT_X_ACCOUNTING>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new account_x_accounting</summary>
        /// <param name="model">The account_x_accounting data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(ACCOUNT_X_ACCOUNTING model);

        /// <summary>Updates a specific account_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the account_x_accounting</param>
        /// <param name="updatedEntity">The account_x_accounting data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, ACCOUNT_X_ACCOUNTING updatedEntity);

        /// <summary>Updates a specific account_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the account_x_accounting</param>
        /// <param name="updatedEntity">The account_x_accounting data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<ACCOUNT_X_ACCOUNTING> updatedEntity);

        /// <summary>Deletes a specific account_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the account_x_accounting</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The account_x_accountingService responsible for managing account_x_accounting related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting account_x_accounting information.
    /// </remarks>
    public class ACCOUNT_X_ACCOUNTINGService : IACCOUNT_X_ACCOUNTINGService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the ACCOUNT_X_ACCOUNTING class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ACCOUNT_X_ACCOUNTINGService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific account_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the account_x_accounting</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The account_x_accounting data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.ACCOUNT_X_ACCOUNTING.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_ACCOUNT_ACCOUNT","GUID_ACCOUNTING_ACCOUNTING","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of account_x_accountings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of account_x_accountings</returns>/// <exception cref="Exception"></exception>
        public async Task<List<ACCOUNT_X_ACCOUNTING>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetACCOUNT_X_ACCOUNTING(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new account_x_accounting</summary>
        /// <param name="model">The account_x_accounting data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(ACCOUNT_X_ACCOUNTING model)
        {
            model.GUID = await CreateACCOUNT_X_ACCOUNTING(model);
            return model.GUID;
        }

        /// <summary>Updates a specific account_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the account_x_accounting</param>
        /// <param name="updatedEntity">The account_x_accounting data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, ACCOUNT_X_ACCOUNTING updatedEntity)
        {
            await UpdateACCOUNT_X_ACCOUNTING(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific account_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the account_x_accounting</param>
        /// <param name="updatedEntity">The account_x_accounting data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<ACCOUNT_X_ACCOUNTING> updatedEntity)
        {
            await PatchACCOUNT_X_ACCOUNTING(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific account_x_accounting by its primary key</summary>
        /// <param name="id">The primary key of the account_x_accounting</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteACCOUNT_X_ACCOUNTING(id);
            return true;
        }
        #region
        private async Task<List<ACCOUNT_X_ACCOUNTING>> GetACCOUNT_X_ACCOUNTING(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ACCOUNT_X_ACCOUNTING.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ACCOUNT_X_ACCOUNTING>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ACCOUNT_X_ACCOUNTING), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ACCOUNT_X_ACCOUNTING, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateACCOUNT_X_ACCOUNTING(ACCOUNT_X_ACCOUNTING model)
        {
            _dbContext.ACCOUNT_X_ACCOUNTING.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateACCOUNT_X_ACCOUNTING(Guid id, ACCOUNT_X_ACCOUNTING updatedEntity)
        {
            _dbContext.ACCOUNT_X_ACCOUNTING.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteACCOUNT_X_ACCOUNTING(Guid id)
        {
            var entityData = _dbContext.ACCOUNT_X_ACCOUNTING.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ACCOUNT_X_ACCOUNTING.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchACCOUNT_X_ACCOUNTING(Guid id, JsonPatchDocument<ACCOUNT_X_ACCOUNTING> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ACCOUNT_X_ACCOUNTING.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ACCOUNT_X_ACCOUNTING.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}