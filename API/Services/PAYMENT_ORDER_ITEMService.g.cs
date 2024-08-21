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
    /// The payment_order_itemService responsible for managing payment_order_item related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting payment_order_item information.
    /// </remarks>
    public interface IPAYMENT_ORDER_ITEMService
    {
        /// <summary>Retrieves a specific payment_order_item by its primary key</summary>
        /// <param name="id">The primary key of the payment_order_item</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The payment_order_item data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of payment_order_items based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of payment_order_items</returns>
        Task<List<PAYMENT_ORDER_ITEM>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new payment_order_item</summary>
        /// <param name="model">The payment_order_item data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PAYMENT_ORDER_ITEM model);

        /// <summary>Updates a specific payment_order_item by its primary key</summary>
        /// <param name="id">The primary key of the payment_order_item</param>
        /// <param name="updatedEntity">The payment_order_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PAYMENT_ORDER_ITEM updatedEntity);

        /// <summary>Updates a specific payment_order_item by its primary key</summary>
        /// <param name="id">The primary key of the payment_order_item</param>
        /// <param name="updatedEntity">The payment_order_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PAYMENT_ORDER_ITEM> updatedEntity);

        /// <summary>Deletes a specific payment_order_item by its primary key</summary>
        /// <param name="id">The primary key of the payment_order_item</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The payment_order_itemService responsible for managing payment_order_item related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting payment_order_item information.
    /// </remarks>
    public class PAYMENT_ORDER_ITEMService : IPAYMENT_ORDER_ITEMService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PAYMENT_ORDER_ITEM class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PAYMENT_ORDER_ITEMService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific payment_order_item by its primary key</summary>
        /// <param name="id">The primary key of the payment_order_item</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The payment_order_item data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PAYMENT_ORDER_ITEM.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_EQUIPMENT_EQUIPMENT","GUID_AREA_AREA","GUID_ARTICLE_ARTICLE","GUID_DEPARTMENT_DEPARTMENT","GUID_BUILDING_BUILDING","GUID_ACCOUNTING0_ACCOUNTING","GUID_ACCOUNTING1_ACCOUNTING","GUID_ACCOUNTING2_ACCOUNTING","GUID_ACCOUNTING3_ACCOUNTING","GUID_ACCOUNTING4_ACCOUNTING","GUID_COMPONENT_COMPONENT","GUID_ACCOUNT_ACCOUNT","GUID_PAYMENT_ORDER_PAYMENT_ORDER","GUID_SERVICE_SERVICE","GUID_CONTRACT_ITEM_CONTRACT_ITEM"];
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

        /// <summary>Retrieves a list of payment_order_items based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of payment_order_items</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PAYMENT_ORDER_ITEM>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPAYMENT_ORDER_ITEM(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new payment_order_item</summary>
        /// <param name="model">The payment_order_item data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PAYMENT_ORDER_ITEM model)
        {
            model.GUID = await CreatePAYMENT_ORDER_ITEM(model);
            return model.GUID;
        }

        /// <summary>Updates a specific payment_order_item by its primary key</summary>
        /// <param name="id">The primary key of the payment_order_item</param>
        /// <param name="updatedEntity">The payment_order_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PAYMENT_ORDER_ITEM updatedEntity)
        {
            await UpdatePAYMENT_ORDER_ITEM(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific payment_order_item by its primary key</summary>
        /// <param name="id">The primary key of the payment_order_item</param>
        /// <param name="updatedEntity">The payment_order_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PAYMENT_ORDER_ITEM> updatedEntity)
        {
            await PatchPAYMENT_ORDER_ITEM(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific payment_order_item by its primary key</summary>
        /// <param name="id">The primary key of the payment_order_item</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePAYMENT_ORDER_ITEM(id);
            return true;
        }
        #region
        private async Task<List<PAYMENT_ORDER_ITEM>> GetPAYMENT_ORDER_ITEM(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PAYMENT_ORDER_ITEM.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PAYMENT_ORDER_ITEM>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PAYMENT_ORDER_ITEM), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PAYMENT_ORDER_ITEM, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePAYMENT_ORDER_ITEM(PAYMENT_ORDER_ITEM model)
        {
            _dbContext.PAYMENT_ORDER_ITEM.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePAYMENT_ORDER_ITEM(Guid id, PAYMENT_ORDER_ITEM updatedEntity)
        {
            _dbContext.PAYMENT_ORDER_ITEM.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePAYMENT_ORDER_ITEM(Guid id)
        {
            var entityData = _dbContext.PAYMENT_ORDER_ITEM.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PAYMENT_ORDER_ITEM.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPAYMENT_ORDER_ITEM(Guid id, JsonPatchDocument<PAYMENT_ORDER_ITEM> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PAYMENT_ORDER_ITEM.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PAYMENT_ORDER_ITEM.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}