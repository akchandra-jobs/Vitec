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
    /// The purchase_order_formService responsible for managing purchase_order_form related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting purchase_order_form information.
    /// </remarks>
    public interface IPURCHASE_ORDER_FORMService
    {
        /// <summary>Retrieves a specific purchase_order_form by its primary key</summary>
        /// <param name="id">The primary key of the purchase_order_form</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The purchase_order_form data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of purchase_order_forms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of purchase_order_forms</returns>
        Task<List<PURCHASE_ORDER_FORM>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new purchase_order_form</summary>
        /// <param name="model">The purchase_order_form data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PURCHASE_ORDER_FORM model);

        /// <summary>Updates a specific purchase_order_form by its primary key</summary>
        /// <param name="id">The primary key of the purchase_order_form</param>
        /// <param name="updatedEntity">The purchase_order_form data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PURCHASE_ORDER_FORM updatedEntity);

        /// <summary>Updates a specific purchase_order_form by its primary key</summary>
        /// <param name="id">The primary key of the purchase_order_form</param>
        /// <param name="updatedEntity">The purchase_order_form data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PURCHASE_ORDER_FORM> updatedEntity);

        /// <summary>Deletes a specific purchase_order_form by its primary key</summary>
        /// <param name="id">The primary key of the purchase_order_form</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The purchase_order_formService responsible for managing purchase_order_form related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting purchase_order_form information.
    /// </remarks>
    public class PURCHASE_ORDER_FORMService : IPURCHASE_ORDER_FORMService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PURCHASE_ORDER_FORM class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PURCHASE_ORDER_FORMService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific purchase_order_form by its primary key</summary>
        /// <param name="id">The primary key of the purchase_order_form</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The purchase_order_form data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PURCHASE_ORDER_FORM.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_REPORT_REPORT"];
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

        /// <summary>Retrieves a list of purchase_order_forms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of purchase_order_forms</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PURCHASE_ORDER_FORM>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPURCHASE_ORDER_FORM(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new purchase_order_form</summary>
        /// <param name="model">The purchase_order_form data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PURCHASE_ORDER_FORM model)
        {
            model.GUID = await CreatePURCHASE_ORDER_FORM(model);
            return model.GUID;
        }

        /// <summary>Updates a specific purchase_order_form by its primary key</summary>
        /// <param name="id">The primary key of the purchase_order_form</param>
        /// <param name="updatedEntity">The purchase_order_form data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PURCHASE_ORDER_FORM updatedEntity)
        {
            await UpdatePURCHASE_ORDER_FORM(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific purchase_order_form by its primary key</summary>
        /// <param name="id">The primary key of the purchase_order_form</param>
        /// <param name="updatedEntity">The purchase_order_form data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PURCHASE_ORDER_FORM> updatedEntity)
        {
            await PatchPURCHASE_ORDER_FORM(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific purchase_order_form by its primary key</summary>
        /// <param name="id">The primary key of the purchase_order_form</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePURCHASE_ORDER_FORM(id);
            return true;
        }
        #region
        private async Task<List<PURCHASE_ORDER_FORM>> GetPURCHASE_ORDER_FORM(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PURCHASE_ORDER_FORM.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PURCHASE_ORDER_FORM>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PURCHASE_ORDER_FORM), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PURCHASE_ORDER_FORM, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePURCHASE_ORDER_FORM(PURCHASE_ORDER_FORM model)
        {
            _dbContext.PURCHASE_ORDER_FORM.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePURCHASE_ORDER_FORM(Guid id, PURCHASE_ORDER_FORM updatedEntity)
        {
            _dbContext.PURCHASE_ORDER_FORM.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePURCHASE_ORDER_FORM(Guid id)
        {
            var entityData = _dbContext.PURCHASE_ORDER_FORM.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PURCHASE_ORDER_FORM.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPURCHASE_ORDER_FORM(Guid id, JsonPatchDocument<PURCHASE_ORDER_FORM> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PURCHASE_ORDER_FORM.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PURCHASE_ORDER_FORM.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}