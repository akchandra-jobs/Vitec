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
    /// The periodic_taskService responsible for managing periodic_task related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting periodic_task information.
    /// </remarks>
    public interface IPERIODIC_TASKService
    {
        /// <summary>Retrieves a specific periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the periodic_task</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The periodic_task data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of periodic_tasks based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of periodic_tasks</returns>
        Task<List<PERIODIC_TASK>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new periodic_task</summary>
        /// <param name="model">The periodic_task data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PERIODIC_TASK model);

        /// <summary>Updates a specific periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the periodic_task</param>
        /// <param name="updatedEntity">The periodic_task data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PERIODIC_TASK updatedEntity);

        /// <summary>Updates a specific periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the periodic_task</param>
        /// <param name="updatedEntity">The periodic_task data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PERIODIC_TASK> updatedEntity);

        /// <summary>Deletes a specific periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the periodic_task</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The periodic_taskService responsible for managing periodic_task related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting periodic_task information.
    /// </remarks>
    public class PERIODIC_TASKService : IPERIODIC_TASKService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PERIODIC_TASK class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PERIODIC_TASKService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the periodic_task</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The periodic_task data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PERIODIC_TASK.AsQueryable();
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

            string[] navigationProperties = ["GUID_INVOICE_CUSTOMER_CUSTOMER","GUID_ACTIVITY_GROUP_ACTIVITY_GROUP","GUID_RESOURCE_RESPONSIBLE_PERSON","GUID_ESTATE_ESTATE","GUID_PROJECT_PROJECT","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_EQUIPMENT_EQUIPMENT","GUID_EQUIPMENT_HOURS_EQUIPMENT","GUID_WORK_ORDER_WORK_ORDER","GUID_RESPONSIBLE_PERSON_PERSON","GUID_AREA_AREA","GUID_DEPARTMENT_DEPARTMENT","GUID_BUILDING_BUILDING","GUID_RESOURCE_GROUP_RESOURCE_GROUP","GUID_ACTIVITY_CATEGORY_ACTIVITY_CATEGORY","GUID_CAUSE_CAUSE","GUID_SUPPLIER_SUPPLIER","GUID_PRIORITY_PRIORITY","GUID_PURCHASE_ORDER_FORM_PURCHASE_ORDER_FORM","GUID_TEMPLATE_PERIODIC_TASK"];
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

        /// <summary>Retrieves a list of periodic_tasks based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of periodic_tasks</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PERIODIC_TASK>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPERIODIC_TASK(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new periodic_task</summary>
        /// <param name="model">The periodic_task data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PERIODIC_TASK model)
        {
            model.GUID = await CreatePERIODIC_TASK(model);
            return model.GUID;
        }

        /// <summary>Updates a specific periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the periodic_task</param>
        /// <param name="updatedEntity">The periodic_task data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PERIODIC_TASK updatedEntity)
        {
            await UpdatePERIODIC_TASK(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the periodic_task</param>
        /// <param name="updatedEntity">The periodic_task data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PERIODIC_TASK> updatedEntity)
        {
            await PatchPERIODIC_TASK(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific periodic_task by its primary key</summary>
        /// <param name="id">The primary key of the periodic_task</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePERIODIC_TASK(id);
            return true;
        }
        #region
        private async Task<List<PERIODIC_TASK>> GetPERIODIC_TASK(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PERIODIC_TASK.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PERIODIC_TASK>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PERIODIC_TASK), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PERIODIC_TASK, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePERIODIC_TASK(PERIODIC_TASK model)
        {
            _dbContext.PERIODIC_TASK.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePERIODIC_TASK(Guid id, PERIODIC_TASK updatedEntity)
        {
            _dbContext.PERIODIC_TASK.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePERIODIC_TASK(Guid id)
        {
            var entityData = _dbContext.PERIODIC_TASK.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PERIODIC_TASK.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPERIODIC_TASK(Guid id, JsonPatchDocument<PERIODIC_TASK> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PERIODIC_TASK.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PERIODIC_TASK.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}