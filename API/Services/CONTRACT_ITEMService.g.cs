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
    /// The contract_itemService responsible for managing contract_item related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting contract_item information.
    /// </remarks>
    public interface ICONTRACT_ITEMService
    {
        /// <summary>Retrieves a specific contract_item by its primary key</summary>
        /// <param name="id">The primary key of the contract_item</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The contract_item data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of contract_items based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of contract_items</returns>
        Task<List<CONTRACT_ITEM>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new contract_item</summary>
        /// <param name="model">The contract_item data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(CONTRACT_ITEM model);

        /// <summary>Updates a specific contract_item by its primary key</summary>
        /// <param name="id">The primary key of the contract_item</param>
        /// <param name="updatedEntity">The contract_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, CONTRACT_ITEM updatedEntity);

        /// <summary>Updates a specific contract_item by its primary key</summary>
        /// <param name="id">The primary key of the contract_item</param>
        /// <param name="updatedEntity">The contract_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<CONTRACT_ITEM> updatedEntity);

        /// <summary>Deletes a specific contract_item by its primary key</summary>
        /// <param name="id">The primary key of the contract_item</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The contract_itemService responsible for managing contract_item related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting contract_item information.
    /// </remarks>
    public class CONTRACT_ITEMService : ICONTRACT_ITEMService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the CONTRACT_ITEM class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public CONTRACT_ITEMService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific contract_item by its primary key</summary>
        /// <param name="id">The primary key of the contract_item</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The contract_item data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.CONTRACT_ITEM.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_PREVIOUS_VERSION_CONTRACT_ITEM","GUID_MASTER_RECORD_CONTRACT_ITEM","GUID_DATA_OWNER_DATA_OWNER","GUID_EQUIPMENT_EQUIPMENT","GUID_AREA_CATEGORY_AREA_CATEGORY","GUID_AREA_AREA","GUID_ARTICLE_ARTICLE","GUID_DEPARTMENT_DEPARTMENT","GUID_BUILDING_BUILDING","GUID_ACCOUNTING0_ACCOUNTING","GUID_ACCOUNTING1_ACCOUNTING","GUID_ACCOUNTING2_ACCOUNTING","GUID_ACCOUNTING3_ACCOUNTING","GUID_ACCOUNTING4_ACCOUNTING","GUID_COMPONENT_COMPONENT","GUID_ACCOUNT_ACCOUNT","GUID_CONTRACT_CONTRACT","GUID_ORGANIZATION_ORGANIZATION","GUID_PRICE_SHEET_REVISION_PRICE_SHEET_REVISION","GUID_SERVICE_SERVICE"];
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

        /// <summary>Retrieves a list of contract_items based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of contract_items</returns>/// <exception cref="Exception"></exception>
        public async Task<List<CONTRACT_ITEM>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetCONTRACT_ITEM(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new contract_item</summary>
        /// <param name="model">The contract_item data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(CONTRACT_ITEM model)
        {
            model.GUID = await CreateCONTRACT_ITEM(model);
            return model.GUID;
        }

        /// <summary>Updates a specific contract_item by its primary key</summary>
        /// <param name="id">The primary key of the contract_item</param>
        /// <param name="updatedEntity">The contract_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, CONTRACT_ITEM updatedEntity)
        {
            await UpdateCONTRACT_ITEM(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific contract_item by its primary key</summary>
        /// <param name="id">The primary key of the contract_item</param>
        /// <param name="updatedEntity">The contract_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<CONTRACT_ITEM> updatedEntity)
        {
            await PatchCONTRACT_ITEM(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific contract_item by its primary key</summary>
        /// <param name="id">The primary key of the contract_item</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteCONTRACT_ITEM(id);
            return true;
        }
        #region
        private async Task<List<CONTRACT_ITEM>> GetCONTRACT_ITEM(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CONTRACT_ITEM.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CONTRACT_ITEM>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CONTRACT_ITEM), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CONTRACT_ITEM, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateCONTRACT_ITEM(CONTRACT_ITEM model)
        {
            _dbContext.CONTRACT_ITEM.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateCONTRACT_ITEM(Guid id, CONTRACT_ITEM updatedEntity)
        {
            _dbContext.CONTRACT_ITEM.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteCONTRACT_ITEM(Guid id)
        {
            var entityData = _dbContext.CONTRACT_ITEM.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CONTRACT_ITEM.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchCONTRACT_ITEM(Guid id, JsonPatchDocument<CONTRACT_ITEM> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CONTRACT_ITEM.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CONTRACT_ITEM.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}