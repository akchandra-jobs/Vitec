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
    /// The work_order_invoice_itemService responsible for managing work_order_invoice_item related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting work_order_invoice_item information.
    /// </remarks>
    public interface IWORK_ORDER_INVOICE_ITEMService
    {
        /// <summary>Retrieves a specific work_order_invoice_item by its primary key</summary>
        /// <param name="id">The primary key of the work_order_invoice_item</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The work_order_invoice_item data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of work_order_invoice_items based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of work_order_invoice_items</returns>
        Task<List<WORK_ORDER_INVOICE_ITEM>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new work_order_invoice_item</summary>
        /// <param name="model">The work_order_invoice_item data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(WORK_ORDER_INVOICE_ITEM model);

        /// <summary>Updates a specific work_order_invoice_item by its primary key</summary>
        /// <param name="id">The primary key of the work_order_invoice_item</param>
        /// <param name="updatedEntity">The work_order_invoice_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, WORK_ORDER_INVOICE_ITEM updatedEntity);

        /// <summary>Updates a specific work_order_invoice_item by its primary key</summary>
        /// <param name="id">The primary key of the work_order_invoice_item</param>
        /// <param name="updatedEntity">The work_order_invoice_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<WORK_ORDER_INVOICE_ITEM> updatedEntity);

        /// <summary>Deletes a specific work_order_invoice_item by its primary key</summary>
        /// <param name="id">The primary key of the work_order_invoice_item</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The work_order_invoice_itemService responsible for managing work_order_invoice_item related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting work_order_invoice_item information.
    /// </remarks>
    public class WORK_ORDER_INVOICE_ITEMService : IWORK_ORDER_INVOICE_ITEMService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the WORK_ORDER_INVOICE_ITEM class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public WORK_ORDER_INVOICE_ITEMService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific work_order_invoice_item by its primary key</summary>
        /// <param name="id">The primary key of the work_order_invoice_item</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The work_order_invoice_item data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.WORK_ORDER_INVOICE_ITEM.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_PAYMENT_ORDER_ITEM_PAYMENT_ORDER_ITEM","GUID_PAYMENT_ORDER_ITEM_ADJUSTMENT_PAYMENT_ORDER_ITEM","GUID_CONTRACT_ITEM_CONTRACT_ITEM","GUID_PURCHASE_ORDER_ITEM_PURCHASE_ORDER_ITEM","GUID_WORK_ORDER_X_EQUIPMENT_WORK_ORDER_X_EQUIPMENT","GUID_WORK_ORDER_X_RESOURCE_GROUP_WORK_ORDER_X_RESOURCE_GROUP","GUID_WORK_ORDER_X_SPARE_PART_WORK_ORDER_X_SPARE_PART","GUID_COST_COST","GUID_ARTICLE_ARTICLE","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of work_order_invoice_items based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of work_order_invoice_items</returns>/// <exception cref="Exception"></exception>
        public async Task<List<WORK_ORDER_INVOICE_ITEM>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetWORK_ORDER_INVOICE_ITEM(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new work_order_invoice_item</summary>
        /// <param name="model">The work_order_invoice_item data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(WORK_ORDER_INVOICE_ITEM model)
        {
            model.GUID = await CreateWORK_ORDER_INVOICE_ITEM(model);
            return model.GUID;
        }

        /// <summary>Updates a specific work_order_invoice_item by its primary key</summary>
        /// <param name="id">The primary key of the work_order_invoice_item</param>
        /// <param name="updatedEntity">The work_order_invoice_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, WORK_ORDER_INVOICE_ITEM updatedEntity)
        {
            await UpdateWORK_ORDER_INVOICE_ITEM(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific work_order_invoice_item by its primary key</summary>
        /// <param name="id">The primary key of the work_order_invoice_item</param>
        /// <param name="updatedEntity">The work_order_invoice_item data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<WORK_ORDER_INVOICE_ITEM> updatedEntity)
        {
            await PatchWORK_ORDER_INVOICE_ITEM(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific work_order_invoice_item by its primary key</summary>
        /// <param name="id">The primary key of the work_order_invoice_item</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteWORK_ORDER_INVOICE_ITEM(id);
            return true;
        }
        #region
        private async Task<List<WORK_ORDER_INVOICE_ITEM>> GetWORK_ORDER_INVOICE_ITEM(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.WORK_ORDER_INVOICE_ITEM.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<WORK_ORDER_INVOICE_ITEM>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(WORK_ORDER_INVOICE_ITEM), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<WORK_ORDER_INVOICE_ITEM, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateWORK_ORDER_INVOICE_ITEM(WORK_ORDER_INVOICE_ITEM model)
        {
            _dbContext.WORK_ORDER_INVOICE_ITEM.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateWORK_ORDER_INVOICE_ITEM(Guid id, WORK_ORDER_INVOICE_ITEM updatedEntity)
        {
            _dbContext.WORK_ORDER_INVOICE_ITEM.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteWORK_ORDER_INVOICE_ITEM(Guid id)
        {
            var entityData = _dbContext.WORK_ORDER_INVOICE_ITEM.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.WORK_ORDER_INVOICE_ITEM.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchWORK_ORDER_INVOICE_ITEM(Guid id, JsonPatchDocument<WORK_ORDER_INVOICE_ITEM> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.WORK_ORDER_INVOICE_ITEM.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.WORK_ORDER_INVOICE_ITEM.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}