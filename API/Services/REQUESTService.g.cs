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
    /// The requestService responsible for managing request related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting request information.
    /// </remarks>
    public interface IREQUESTService
    {
        /// <summary>Retrieves a specific request by its primary key</summary>
        /// <param name="id">The primary key of the request</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The request data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of requests based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of requests</returns>
        Task<List<REQUEST>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new request</summary>
        /// <param name="model">The request data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(REQUEST model);

        /// <summary>Updates a specific request by its primary key</summary>
        /// <param name="id">The primary key of the request</param>
        /// <param name="updatedEntity">The request data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, REQUEST updatedEntity);

        /// <summary>Updates a specific request by its primary key</summary>
        /// <param name="id">The primary key of the request</param>
        /// <param name="updatedEntity">The request data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<REQUEST> updatedEntity);

        /// <summary>Deletes a specific request by its primary key</summary>
        /// <param name="id">The primary key of the request</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The requestService responsible for managing request related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting request information.
    /// </remarks>
    public class REQUESTService : IREQUESTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the REQUEST class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public REQUESTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific request by its primary key</summary>
        /// <param name="id">The primary key of the request</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The request data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.REQUEST.AsQueryable();
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

            string[] navigationProperties = ["GUID_CONTROL_LIST_ITEM_ANSWER_CONTROL_LIST_ITEM_ANSWER","GUID_GIS_ENTITY_GIS_ENTITY","GUID_BCF_PROJECT_BCF_PROJECT","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_CAUSE_CAUSE","GUID_EQUIPMENT_EQUIPMENT","GUID_WORK_ORDER_WORK_ORDER","GUID_AREA_AREA","GUID_DEPARTMENT_DEPARTMENT","GUID_BUILDING_BUILDING","GUID_COMPONENT_COMPONENT","GUID_RESOURCE_GROUP_RESOURCE_GROUP","GUID_ACTIVITY_CATEGORY_ACTIVITY_CATEGORY","GUID_ACCOUNT_ACCOUNT","GUID_PERSON_PERSON","GUID_PRIORITY_PRIORITY","GUID_PROJECT_PROJECT","GUID_RESPONSIBLE_PERSON_PERSON","GUID_USER_USR","GUID_DRAWING_DRAWING","GUID_CUSTOMER_CUSTOMER"];
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

        /// <summary>Retrieves a list of requests based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of requests</returns>/// <exception cref="Exception"></exception>
        public async Task<List<REQUEST>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetREQUEST(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new request</summary>
        /// <param name="model">The request data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(REQUEST model)
        {
            model.GUID = await CreateREQUEST(model);
            return model.GUID;
        }

        /// <summary>Updates a specific request by its primary key</summary>
        /// <param name="id">The primary key of the request</param>
        /// <param name="updatedEntity">The request data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, REQUEST updatedEntity)
        {
            await UpdateREQUEST(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific request by its primary key</summary>
        /// <param name="id">The primary key of the request</param>
        /// <param name="updatedEntity">The request data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<REQUEST> updatedEntity)
        {
            await PatchREQUEST(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific request by its primary key</summary>
        /// <param name="id">The primary key of the request</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteREQUEST(id);
            return true;
        }
        #region
        private async Task<List<REQUEST>> GetREQUEST(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.REQUEST.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<REQUEST>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(REQUEST), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<REQUEST, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateREQUEST(REQUEST model)
        {
            _dbContext.REQUEST.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateREQUEST(Guid id, REQUEST updatedEntity)
        {
            _dbContext.REQUEST.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteREQUEST(Guid id)
        {
            var entityData = _dbContext.REQUEST.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.REQUEST.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchREQUEST(Guid id, JsonPatchDocument<REQUEST> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.REQUEST.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.REQUEST.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}