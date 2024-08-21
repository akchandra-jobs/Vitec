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
    /// The departmentService responsible for managing department related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting department information.
    /// </remarks>
    public interface IDEPARTMENTService
    {
        /// <summary>Retrieves a specific department by its primary key</summary>
        /// <param name="id">The primary key of the department</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The department data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of departments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of departments</returns>
        Task<List<DEPARTMENT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new department</summary>
        /// <param name="model">The department data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(DEPARTMENT model);

        /// <summary>Updates a specific department by its primary key</summary>
        /// <param name="id">The primary key of the department</param>
        /// <param name="updatedEntity">The department data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, DEPARTMENT updatedEntity);

        /// <summary>Updates a specific department by its primary key</summary>
        /// <param name="id">The primary key of the department</param>
        /// <param name="updatedEntity">The department data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<DEPARTMENT> updatedEntity);

        /// <summary>Deletes a specific department by its primary key</summary>
        /// <param name="id">The primary key of the department</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The departmentService responsible for managing department related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting department information.
    /// </remarks>
    public class DEPARTMENTService : IDEPARTMENTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the DEPARTMENT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public DEPARTMENTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific department by its primary key</summary>
        /// <param name="id">The primary key of the department</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The department data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.DEPARTMENT.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_PURCHASE_ORDER_FORM_PURCHASE_ORDER_FORM","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of departments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of departments</returns>/// <exception cref="Exception"></exception>
        public async Task<List<DEPARTMENT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetDEPARTMENT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new department</summary>
        /// <param name="model">The department data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(DEPARTMENT model)
        {
            model.GUID = await CreateDEPARTMENT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific department by its primary key</summary>
        /// <param name="id">The primary key of the department</param>
        /// <param name="updatedEntity">The department data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, DEPARTMENT updatedEntity)
        {
            await UpdateDEPARTMENT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific department by its primary key</summary>
        /// <param name="id">The primary key of the department</param>
        /// <param name="updatedEntity">The department data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<DEPARTMENT> updatedEntity)
        {
            await PatchDEPARTMENT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific department by its primary key</summary>
        /// <param name="id">The primary key of the department</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteDEPARTMENT(id);
            return true;
        }
        #region
        private async Task<List<DEPARTMENT>> GetDEPARTMENT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DEPARTMENT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DEPARTMENT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DEPARTMENT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DEPARTMENT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateDEPARTMENT(DEPARTMENT model)
        {
            _dbContext.DEPARTMENT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateDEPARTMENT(Guid id, DEPARTMENT updatedEntity)
        {
            _dbContext.DEPARTMENT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteDEPARTMENT(Guid id)
        {
            var entityData = _dbContext.DEPARTMENT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DEPARTMENT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchDEPARTMENT(Guid id, JsonPatchDocument<DEPARTMENT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DEPARTMENT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DEPARTMENT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}