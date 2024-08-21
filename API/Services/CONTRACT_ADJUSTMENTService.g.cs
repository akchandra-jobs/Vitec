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
    /// The contract_adjustmentService responsible for managing contract_adjustment related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting contract_adjustment information.
    /// </remarks>
    public interface ICONTRACT_ADJUSTMENTService
    {
        /// <summary>Retrieves a specific contract_adjustment by its primary key</summary>
        /// <param name="id">The primary key of the contract_adjustment</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The contract_adjustment data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of contract_adjustments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of contract_adjustments</returns>
        Task<List<CONTRACT_ADJUSTMENT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new contract_adjustment</summary>
        /// <param name="model">The contract_adjustment data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(CONTRACT_ADJUSTMENT model);

        /// <summary>Updates a specific contract_adjustment by its primary key</summary>
        /// <param name="id">The primary key of the contract_adjustment</param>
        /// <param name="updatedEntity">The contract_adjustment data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, CONTRACT_ADJUSTMENT updatedEntity);

        /// <summary>Updates a specific contract_adjustment by its primary key</summary>
        /// <param name="id">The primary key of the contract_adjustment</param>
        /// <param name="updatedEntity">The contract_adjustment data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<CONTRACT_ADJUSTMENT> updatedEntity);

        /// <summary>Deletes a specific contract_adjustment by its primary key</summary>
        /// <param name="id">The primary key of the contract_adjustment</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The contract_adjustmentService responsible for managing contract_adjustment related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting contract_adjustment information.
    /// </remarks>
    public class CONTRACT_ADJUSTMENTService : ICONTRACT_ADJUSTMENTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the CONTRACT_ADJUSTMENT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public CONTRACT_ADJUSTMENTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific contract_adjustment by its primary key</summary>
        /// <param name="id">The primary key of the contract_adjustment</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The contract_adjustment data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.CONTRACT_ADJUSTMENT.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_PREVIOUS_CONTRACT_ADJUSTMENT_CONTRACT_ADJUSTMENT","GUID_DATA_OWNER_DATA_OWNER","GUID_CONTRACT_CONTRACT","GUID_ADJUSTMENT_ADJUSTMENT","GUID_SERVICE_SERVICE"];
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

        /// <summary>Retrieves a list of contract_adjustments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of contract_adjustments</returns>/// <exception cref="Exception"></exception>
        public async Task<List<CONTRACT_ADJUSTMENT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetCONTRACT_ADJUSTMENT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new contract_adjustment</summary>
        /// <param name="model">The contract_adjustment data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(CONTRACT_ADJUSTMENT model)
        {
            model.GUID = await CreateCONTRACT_ADJUSTMENT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific contract_adjustment by its primary key</summary>
        /// <param name="id">The primary key of the contract_adjustment</param>
        /// <param name="updatedEntity">The contract_adjustment data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, CONTRACT_ADJUSTMENT updatedEntity)
        {
            await UpdateCONTRACT_ADJUSTMENT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific contract_adjustment by its primary key</summary>
        /// <param name="id">The primary key of the contract_adjustment</param>
        /// <param name="updatedEntity">The contract_adjustment data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<CONTRACT_ADJUSTMENT> updatedEntity)
        {
            await PatchCONTRACT_ADJUSTMENT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific contract_adjustment by its primary key</summary>
        /// <param name="id">The primary key of the contract_adjustment</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteCONTRACT_ADJUSTMENT(id);
            return true;
        }
        #region
        private async Task<List<CONTRACT_ADJUSTMENT>> GetCONTRACT_ADJUSTMENT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CONTRACT_ADJUSTMENT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CONTRACT_ADJUSTMENT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CONTRACT_ADJUSTMENT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CONTRACT_ADJUSTMENT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateCONTRACT_ADJUSTMENT(CONTRACT_ADJUSTMENT model)
        {
            _dbContext.CONTRACT_ADJUSTMENT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateCONTRACT_ADJUSTMENT(Guid id, CONTRACT_ADJUSTMENT updatedEntity)
        {
            _dbContext.CONTRACT_ADJUSTMENT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteCONTRACT_ADJUSTMENT(Guid id)
        {
            var entityData = _dbContext.CONTRACT_ADJUSTMENT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CONTRACT_ADJUSTMENT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchCONTRACT_ADJUSTMENT(Guid id, JsonPatchDocument<CONTRACT_ADJUSTMENT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CONTRACT_ADJUSTMENT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CONTRACT_ADJUSTMENT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}