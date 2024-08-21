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
    /// The work_orderService responsible for managing work_order related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting work_order information.
    /// </remarks>
    public interface IWORK_ORDERService
    {
        /// <summary>Retrieves a specific work_order by its primary key</summary>
        /// <param name="id">The primary key of the work_order</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The work_order data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of work_orders based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of work_orders</returns>
        Task<List<WORK_ORDER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new work_order</summary>
        /// <param name="model">The work_order data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(WORK_ORDER model);

        /// <summary>Updates a specific work_order by its primary key</summary>
        /// <param name="id">The primary key of the work_order</param>
        /// <param name="updatedEntity">The work_order data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, WORK_ORDER updatedEntity);

        /// <summary>Updates a specific work_order by its primary key</summary>
        /// <param name="id">The primary key of the work_order</param>
        /// <param name="updatedEntity">The work_order data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<WORK_ORDER> updatedEntity);

        /// <summary>Deletes a specific work_order by its primary key</summary>
        /// <param name="id">The primary key of the work_order</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The work_orderService responsible for managing work_order related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting work_order information.
    /// </remarks>
    public class WORK_ORDERService : IWORK_ORDERService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the WORK_ORDER class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public WORK_ORDERService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific work_order by its primary key</summary>
        /// <param name="id">The primary key of the work_order</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The work_order data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.WORK_ORDER.AsQueryable();
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

            string[] navigationProperties = ["GUID_ALARM_LOG_ALARM_LOG","GUID_INVOICE_CUSTOMER_CUSTOMER","GUID_ACTIVITY_GROUP_ACTIVITY_GROUP","GUID_RESOURCE_RESPONSIBLE_PERSON","GUID_ESTATE_ESTATE","GUID_PROJECT_MILESTONE_PROJECT_MILESTONE","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_USER_CLOSED_BY_USR","GUID_GIS_ENTITY_GIS_ENTITY","GUID_DATA_OWNER_DATA_OWNER","GUID_CAUSE_CAUSE","GUID_EQUIPMENT_EQUIPMENT","GUID_AREA_AREA","GUID_DEPARTMENT_DEPARTMENT","GUID_BUILDING_BUILDING","GUID_CONTRACT_ITEM_CONTRACT_ITEM","GUID_RESOURCE_GROUP_RESOURCE_GROUP","GUID_PERIODIC_TASK_PERIODIC_TASK","GUID_ACTIVITY_CATEGORY_ACTIVITY_CATEGORY","GUID_CUSTOMER_CUSTOMER","GUID_SUPPLIER_SUPPLIER","GUID_PRIORITY_PRIORITY","GUID_PROJECT_PROJECT","GUID_RESPONSIBLE_PERSON_PERSON","GUID_USER_PRINTED_BY_USR","GUID_REQUEST_REQUEST"];
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

        /// <summary>Retrieves a list of work_orders based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of work_orders</returns>/// <exception cref="Exception"></exception>
        public async Task<List<WORK_ORDER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetWORK_ORDER(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new work_order</summary>
        /// <param name="model">The work_order data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(WORK_ORDER model)
        {
            model.GUID = await CreateWORK_ORDER(model);
            return model.GUID;
        }

        /// <summary>Updates a specific work_order by its primary key</summary>
        /// <param name="id">The primary key of the work_order</param>
        /// <param name="updatedEntity">The work_order data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, WORK_ORDER updatedEntity)
        {
            await UpdateWORK_ORDER(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific work_order by its primary key</summary>
        /// <param name="id">The primary key of the work_order</param>
        /// <param name="updatedEntity">The work_order data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<WORK_ORDER> updatedEntity)
        {
            await PatchWORK_ORDER(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific work_order by its primary key</summary>
        /// <param name="id">The primary key of the work_order</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteWORK_ORDER(id);
            return true;
        }
        #region
        private async Task<List<WORK_ORDER>> GetWORK_ORDER(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.WORK_ORDER.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<WORK_ORDER>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(WORK_ORDER), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<WORK_ORDER, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateWORK_ORDER(WORK_ORDER model)
        {
            _dbContext.WORK_ORDER.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateWORK_ORDER(Guid id, WORK_ORDER updatedEntity)
        {
            _dbContext.WORK_ORDER.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteWORK_ORDER(Guid id)
        {
            var entityData = _dbContext.WORK_ORDER.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.WORK_ORDER.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchWORK_ORDER(Guid id, JsonPatchDocument<WORK_ORDER> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.WORK_ORDER.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.WORK_ORDER.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}