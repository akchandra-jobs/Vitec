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
    /// The budgetService responsible for managing budget related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting budget information.
    /// </remarks>
    public interface IBUDGETService
    {
        /// <summary>Retrieves a specific budget by its primary key</summary>
        /// <param name="id">The primary key of the budget</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The budget data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of budgets based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of budgets</returns>
        Task<List<BUDGET>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new budget</summary>
        /// <param name="model">The budget data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(BUDGET model);

        /// <summary>Updates a specific budget by its primary key</summary>
        /// <param name="id">The primary key of the budget</param>
        /// <param name="updatedEntity">The budget data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, BUDGET updatedEntity);

        /// <summary>Updates a specific budget by its primary key</summary>
        /// <param name="id">The primary key of the budget</param>
        /// <param name="updatedEntity">The budget data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<BUDGET> updatedEntity);

        /// <summary>Deletes a specific budget by its primary key</summary>
        /// <param name="id">The primary key of the budget</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The budgetService responsible for managing budget related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting budget information.
    /// </remarks>
    public class BUDGETService : IBUDGETService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the BUDGET class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public BUDGETService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific budget by its primary key</summary>
        /// <param name="id">The primary key of the budget</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The budget data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.BUDGET.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_DEPARTMENT_DEPARTMENT","GUID_ACCOUNT_ACCOUNT","GUID_COST_CENTER_COST_CENTER","GUID_ACCOUNTING0_ACCOUNTING","GUID_ACCOUNTING1_ACCOUNTING","GUID_ACCOUNTING2_ACCOUNTING","GUID_ACCOUNTING3_ACCOUNTING","GUID_ACCOUNTING4_ACCOUNTING","GUID_SERVICE_SERVICE","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of budgets based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of budgets</returns>/// <exception cref="Exception"></exception>
        public async Task<List<BUDGET>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetBUDGET(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new budget</summary>
        /// <param name="model">The budget data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(BUDGET model)
        {
            model.GUID = await CreateBUDGET(model);
            return model.GUID;
        }

        /// <summary>Updates a specific budget by its primary key</summary>
        /// <param name="id">The primary key of the budget</param>
        /// <param name="updatedEntity">The budget data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, BUDGET updatedEntity)
        {
            await UpdateBUDGET(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific budget by its primary key</summary>
        /// <param name="id">The primary key of the budget</param>
        /// <param name="updatedEntity">The budget data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<BUDGET> updatedEntity)
        {
            await PatchBUDGET(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific budget by its primary key</summary>
        /// <param name="id">The primary key of the budget</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteBUDGET(id);
            return true;
        }
        #region
        private async Task<List<BUDGET>> GetBUDGET(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.BUDGET.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<BUDGET>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(BUDGET), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<BUDGET, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateBUDGET(BUDGET model)
        {
            _dbContext.BUDGET.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateBUDGET(Guid id, BUDGET updatedEntity)
        {
            _dbContext.BUDGET.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteBUDGET(Guid id)
        {
            var entityData = _dbContext.BUDGET.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.BUDGET.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchBUDGET(Guid id, JsonPatchDocument<BUDGET> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.BUDGET.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.BUDGET.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}