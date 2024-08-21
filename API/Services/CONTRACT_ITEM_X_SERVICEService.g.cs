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
    /// The contract_item_x_serviceService responsible for managing contract_item_x_service related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting contract_item_x_service information.
    /// </remarks>
    public interface ICONTRACT_ITEM_X_SERVICEService
    {
        /// <summary>Retrieves a specific contract_item_x_service by its primary key</summary>
        /// <param name="id">The primary key of the contract_item_x_service</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The contract_item_x_service data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of contract_item_x_services based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of contract_item_x_services</returns>
        Task<List<CONTRACT_ITEM_X_SERVICE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new contract_item_x_service</summary>
        /// <param name="model">The contract_item_x_service data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(CONTRACT_ITEM_X_SERVICE model);

        /// <summary>Updates a specific contract_item_x_service by its primary key</summary>
        /// <param name="id">The primary key of the contract_item_x_service</param>
        /// <param name="updatedEntity">The contract_item_x_service data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, CONTRACT_ITEM_X_SERVICE updatedEntity);

        /// <summary>Updates a specific contract_item_x_service by its primary key</summary>
        /// <param name="id">The primary key of the contract_item_x_service</param>
        /// <param name="updatedEntity">The contract_item_x_service data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<CONTRACT_ITEM_X_SERVICE> updatedEntity);

        /// <summary>Deletes a specific contract_item_x_service by its primary key</summary>
        /// <param name="id">The primary key of the contract_item_x_service</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The contract_item_x_serviceService responsible for managing contract_item_x_service related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting contract_item_x_service information.
    /// </remarks>
    public class CONTRACT_ITEM_X_SERVICEService : ICONTRACT_ITEM_X_SERVICEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the CONTRACT_ITEM_X_SERVICE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public CONTRACT_ITEM_X_SERVICEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific contract_item_x_service by its primary key</summary>
        /// <param name="id">The primary key of the contract_item_x_service</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The contract_item_x_service data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.CONTRACT_ITEM_X_SERVICE.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_CONTRACT_ITEM_CONTRACT_ITEM","GUID_SERVICE_SERVICE"];
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

        /// <summary>Retrieves a list of contract_item_x_services based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of contract_item_x_services</returns>/// <exception cref="Exception"></exception>
        public async Task<List<CONTRACT_ITEM_X_SERVICE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetCONTRACT_ITEM_X_SERVICE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new contract_item_x_service</summary>
        /// <param name="model">The contract_item_x_service data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(CONTRACT_ITEM_X_SERVICE model)
        {
            model.GUID = await CreateCONTRACT_ITEM_X_SERVICE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific contract_item_x_service by its primary key</summary>
        /// <param name="id">The primary key of the contract_item_x_service</param>
        /// <param name="updatedEntity">The contract_item_x_service data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, CONTRACT_ITEM_X_SERVICE updatedEntity)
        {
            await UpdateCONTRACT_ITEM_X_SERVICE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific contract_item_x_service by its primary key</summary>
        /// <param name="id">The primary key of the contract_item_x_service</param>
        /// <param name="updatedEntity">The contract_item_x_service data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<CONTRACT_ITEM_X_SERVICE> updatedEntity)
        {
            await PatchCONTRACT_ITEM_X_SERVICE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific contract_item_x_service by its primary key</summary>
        /// <param name="id">The primary key of the contract_item_x_service</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteCONTRACT_ITEM_X_SERVICE(id);
            return true;
        }
        #region
        private async Task<List<CONTRACT_ITEM_X_SERVICE>> GetCONTRACT_ITEM_X_SERVICE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CONTRACT_ITEM_X_SERVICE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CONTRACT_ITEM_X_SERVICE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CONTRACT_ITEM_X_SERVICE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CONTRACT_ITEM_X_SERVICE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateCONTRACT_ITEM_X_SERVICE(CONTRACT_ITEM_X_SERVICE model)
        {
            _dbContext.CONTRACT_ITEM_X_SERVICE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateCONTRACT_ITEM_X_SERVICE(Guid id, CONTRACT_ITEM_X_SERVICE updatedEntity)
        {
            _dbContext.CONTRACT_ITEM_X_SERVICE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteCONTRACT_ITEM_X_SERVICE(Guid id)
        {
            var entityData = _dbContext.CONTRACT_ITEM_X_SERVICE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CONTRACT_ITEM_X_SERVICE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchCONTRACT_ITEM_X_SERVICE(Guid id, JsonPatchDocument<CONTRACT_ITEM_X_SERVICE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CONTRACT_ITEM_X_SERVICE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CONTRACT_ITEM_X_SERVICE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}