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
    /// The payment_orderService responsible for managing payment_order related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting payment_order information.
    /// </remarks>
    public interface IPAYMENT_ORDERService
    {
        /// <summary>Retrieves a specific payment_order by its primary key</summary>
        /// <param name="id">The primary key of the payment_order</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The payment_order data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of payment_orders based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of payment_orders</returns>
        Task<List<PAYMENT_ORDER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new payment_order</summary>
        /// <param name="model">The payment_order data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PAYMENT_ORDER model);

        /// <summary>Updates a specific payment_order by its primary key</summary>
        /// <param name="id">The primary key of the payment_order</param>
        /// <param name="updatedEntity">The payment_order data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PAYMENT_ORDER updatedEntity);

        /// <summary>Updates a specific payment_order by its primary key</summary>
        /// <param name="id">The primary key of the payment_order</param>
        /// <param name="updatedEntity">The payment_order data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PAYMENT_ORDER> updatedEntity);

        /// <summary>Deletes a specific payment_order by its primary key</summary>
        /// <param name="id">The primary key of the payment_order</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The payment_orderService responsible for managing payment_order related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting payment_order information.
    /// </remarks>
    public class PAYMENT_ORDERService : IPAYMENT_ORDERService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PAYMENT_ORDER class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PAYMENT_ORDERService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific payment_order by its primary key</summary>
        /// <param name="id">The primary key of the payment_order</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The payment_order data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PAYMENT_ORDER.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_WORK_ORDER_WORK_ORDER","GUID_USER_BOOKED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_PAYMENT_TERM_PAYMENT_TERM","GUID_BOOKING_CATEGORY_BOOKING_CATEGORY","GUID_TRANSFER_TRANSFER","GUID_CUSTOMER_CUSTOMER","GUID_CUSTOMER_DELIVERY_ADDRESS_CUSTOMER_DELIVERY_ADDRESS","GUID_CONTACT_PERSON_CONTACT_PERSON","GUID_PAYMENT_ORDER_FORM_PAYMENT_ORDER_FORM","GUID_ORGANIZATION_ORGANIZATION","GUID_CONTRACT_CONTRACT"];
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

        /// <summary>Retrieves a list of payment_orders based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of payment_orders</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PAYMENT_ORDER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPAYMENT_ORDER(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new payment_order</summary>
        /// <param name="model">The payment_order data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PAYMENT_ORDER model)
        {
            model.GUID = await CreatePAYMENT_ORDER(model);
            return model.GUID;
        }

        /// <summary>Updates a specific payment_order by its primary key</summary>
        /// <param name="id">The primary key of the payment_order</param>
        /// <param name="updatedEntity">The payment_order data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PAYMENT_ORDER updatedEntity)
        {
            await UpdatePAYMENT_ORDER(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific payment_order by its primary key</summary>
        /// <param name="id">The primary key of the payment_order</param>
        /// <param name="updatedEntity">The payment_order data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PAYMENT_ORDER> updatedEntity)
        {
            await PatchPAYMENT_ORDER(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific payment_order by its primary key</summary>
        /// <param name="id">The primary key of the payment_order</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePAYMENT_ORDER(id);
            return true;
        }
        #region
        private async Task<List<PAYMENT_ORDER>> GetPAYMENT_ORDER(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PAYMENT_ORDER.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PAYMENT_ORDER>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PAYMENT_ORDER), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PAYMENT_ORDER, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePAYMENT_ORDER(PAYMENT_ORDER model)
        {
            _dbContext.PAYMENT_ORDER.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePAYMENT_ORDER(Guid id, PAYMENT_ORDER updatedEntity)
        {
            _dbContext.PAYMENT_ORDER.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePAYMENT_ORDER(Guid id)
        {
            var entityData = _dbContext.PAYMENT_ORDER.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PAYMENT_ORDER.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPAYMENT_ORDER(Guid id, JsonPatchDocument<PAYMENT_ORDER> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PAYMENT_ORDER.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PAYMENT_ORDER.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}