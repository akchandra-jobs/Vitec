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
    /// The costService responsible for managing cost related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cost information.
    /// </remarks>
    public interface ICOSTService
    {
        /// <summary>Retrieves a specific cost by its primary key</summary>
        /// <param name="id">The primary key of the cost</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The cost data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of costs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of costs</returns>
        Task<List<COST>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new cost</summary>
        /// <param name="model">The cost data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(COST model);

        /// <summary>Updates a specific cost by its primary key</summary>
        /// <param name="id">The primary key of the cost</param>
        /// <param name="updatedEntity">The cost data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, COST updatedEntity);

        /// <summary>Updates a specific cost by its primary key</summary>
        /// <param name="id">The primary key of the cost</param>
        /// <param name="updatedEntity">The cost data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<COST> updatedEntity);

        /// <summary>Deletes a specific cost by its primary key</summary>
        /// <param name="id">The primary key of the cost</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The costService responsible for managing cost related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting cost information.
    /// </remarks>
    public class COSTService : ICOSTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the COST class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public COSTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific cost by its primary key</summary>
        /// <param name="id">The primary key of the cost</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The cost data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.COST.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_EQUIPMENT_EQUIPMENT","GUID_WORK_ORDER_WORK_ORDER","GUID_AREA_AREA","GUID_DEPARTMENT_DEPARTMENT","GUID_PURCHASE_ORDER_PURCHASE_ORDER","GUID_BUILDING_BUILDING","GUID_ACCOUNTING0_ACCOUNTING","GUID_ACCOUNTING1_ACCOUNTING","GUID_ACCOUNTING2_ACCOUNTING","GUID_ACCOUNTING3_ACCOUNTING","GUID_ACCOUNTING4_ACCOUNTING","GUID_CONSUMABLE_CONSUMABLE","GUID_ACCOUNT_ACCOUNT","GUID_COST_CENTER_COST_CENTER","GUID_SUPPLIER_SUPPLIER","GUID_PROJECT_PROJECT","GUID_PURCHASE_ORDER_ITEM_PURCHASE_ORDER_ITEM"];
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

        /// <summary>Retrieves a list of costs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of costs</returns>/// <exception cref="Exception"></exception>
        public async Task<List<COST>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetCOST(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new cost</summary>
        /// <param name="model">The cost data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(COST model)
        {
            model.GUID = await CreateCOST(model);
            return model.GUID;
        }

        /// <summary>Updates a specific cost by its primary key</summary>
        /// <param name="id">The primary key of the cost</param>
        /// <param name="updatedEntity">The cost data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, COST updatedEntity)
        {
            await UpdateCOST(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific cost by its primary key</summary>
        /// <param name="id">The primary key of the cost</param>
        /// <param name="updatedEntity">The cost data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<COST> updatedEntity)
        {
            await PatchCOST(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific cost by its primary key</summary>
        /// <param name="id">The primary key of the cost</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteCOST(id);
            return true;
        }
        #region
        private async Task<List<COST>> GetCOST(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.COST.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<COST>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(COST), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<COST, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateCOST(COST model)
        {
            _dbContext.COST.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateCOST(Guid id, COST updatedEntity)
        {
            _dbContext.COST.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteCOST(Guid id)
        {
            var entityData = _dbContext.COST.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.COST.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchCOST(Guid id, JsonPatchDocument<COST> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.COST.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.COST.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}