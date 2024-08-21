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
    /// The project_statusService responsible for managing project_status related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting project_status information.
    /// </remarks>
    public interface IPROJECT_STATUSService
    {
        /// <summary>Retrieves a specific project_status by its primary key</summary>
        /// <param name="id">The primary key of the project_status</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The project_status data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of project_statuss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of project_statuss</returns>
        Task<List<PROJECT_STATUS>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new project_status</summary>
        /// <param name="model">The project_status data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PROJECT_STATUS model);

        /// <summary>Updates a specific project_status by its primary key</summary>
        /// <param name="id">The primary key of the project_status</param>
        /// <param name="updatedEntity">The project_status data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PROJECT_STATUS updatedEntity);

        /// <summary>Updates a specific project_status by its primary key</summary>
        /// <param name="id">The primary key of the project_status</param>
        /// <param name="updatedEntity">The project_status data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PROJECT_STATUS> updatedEntity);

        /// <summary>Deletes a specific project_status by its primary key</summary>
        /// <param name="id">The primary key of the project_status</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The project_statusService responsible for managing project_status related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting project_status information.
    /// </remarks>
    public class PROJECT_STATUSService : IPROJECT_STATUSService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PROJECT_STATUS class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PROJECT_STATUSService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific project_status by its primary key</summary>
        /// <param name="id">The primary key of the project_status</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The project_status data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PROJECT_STATUS.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_PROJECT_PHASE_PROJECT_PHASE"];
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

        /// <summary>Retrieves a list of project_statuss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of project_statuss</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PROJECT_STATUS>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPROJECT_STATUS(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new project_status</summary>
        /// <param name="model">The project_status data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PROJECT_STATUS model)
        {
            model.GUID = await CreatePROJECT_STATUS(model);
            return model.GUID;
        }

        /// <summary>Updates a specific project_status by its primary key</summary>
        /// <param name="id">The primary key of the project_status</param>
        /// <param name="updatedEntity">The project_status data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PROJECT_STATUS updatedEntity)
        {
            await UpdatePROJECT_STATUS(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific project_status by its primary key</summary>
        /// <param name="id">The primary key of the project_status</param>
        /// <param name="updatedEntity">The project_status data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PROJECT_STATUS> updatedEntity)
        {
            await PatchPROJECT_STATUS(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific project_status by its primary key</summary>
        /// <param name="id">The primary key of the project_status</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePROJECT_STATUS(id);
            return true;
        }
        #region
        private async Task<List<PROJECT_STATUS>> GetPROJECT_STATUS(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PROJECT_STATUS.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PROJECT_STATUS>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PROJECT_STATUS), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PROJECT_STATUS, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePROJECT_STATUS(PROJECT_STATUS model)
        {
            _dbContext.PROJECT_STATUS.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePROJECT_STATUS(Guid id, PROJECT_STATUS updatedEntity)
        {
            _dbContext.PROJECT_STATUS.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePROJECT_STATUS(Guid id)
        {
            var entityData = _dbContext.PROJECT_STATUS.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PROJECT_STATUS.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPROJECT_STATUS(Guid id, JsonPatchDocument<PROJECT_STATUS> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PROJECT_STATUS.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PROJECT_STATUS.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}