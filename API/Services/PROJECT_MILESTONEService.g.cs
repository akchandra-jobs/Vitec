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
    /// The project_milestoneService responsible for managing project_milestone related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting project_milestone information.
    /// </remarks>
    public interface IPROJECT_MILESTONEService
    {
        /// <summary>Retrieves a specific project_milestone by its primary key</summary>
        /// <param name="id">The primary key of the project_milestone</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The project_milestone data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of project_milestones based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of project_milestones</returns>
        Task<List<PROJECT_MILESTONE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new project_milestone</summary>
        /// <param name="model">The project_milestone data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PROJECT_MILESTONE model);

        /// <summary>Updates a specific project_milestone by its primary key</summary>
        /// <param name="id">The primary key of the project_milestone</param>
        /// <param name="updatedEntity">The project_milestone data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PROJECT_MILESTONE updatedEntity);

        /// <summary>Updates a specific project_milestone by its primary key</summary>
        /// <param name="id">The primary key of the project_milestone</param>
        /// <param name="updatedEntity">The project_milestone data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PROJECT_MILESTONE> updatedEntity);

        /// <summary>Deletes a specific project_milestone by its primary key</summary>
        /// <param name="id">The primary key of the project_milestone</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The project_milestoneService responsible for managing project_milestone related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting project_milestone information.
    /// </remarks>
    public class PROJECT_MILESTONEService : IPROJECT_MILESTONEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PROJECT_MILESTONE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PROJECT_MILESTONEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific project_milestone by its primary key</summary>
        /// <param name="id">The primary key of the project_milestone</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The project_milestone data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PROJECT_MILESTONE.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_PROJECT_PROJECT","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of project_milestones based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of project_milestones</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PROJECT_MILESTONE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPROJECT_MILESTONE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new project_milestone</summary>
        /// <param name="model">The project_milestone data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PROJECT_MILESTONE model)
        {
            model.GUID = await CreatePROJECT_MILESTONE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific project_milestone by its primary key</summary>
        /// <param name="id">The primary key of the project_milestone</param>
        /// <param name="updatedEntity">The project_milestone data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PROJECT_MILESTONE updatedEntity)
        {
            await UpdatePROJECT_MILESTONE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific project_milestone by its primary key</summary>
        /// <param name="id">The primary key of the project_milestone</param>
        /// <param name="updatedEntity">The project_milestone data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PROJECT_MILESTONE> updatedEntity)
        {
            await PatchPROJECT_MILESTONE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific project_milestone by its primary key</summary>
        /// <param name="id">The primary key of the project_milestone</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePROJECT_MILESTONE(id);
            return true;
        }
        #region
        private async Task<List<PROJECT_MILESTONE>> GetPROJECT_MILESTONE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PROJECT_MILESTONE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PROJECT_MILESTONE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PROJECT_MILESTONE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PROJECT_MILESTONE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePROJECT_MILESTONE(PROJECT_MILESTONE model)
        {
            _dbContext.PROJECT_MILESTONE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePROJECT_MILESTONE(Guid id, PROJECT_MILESTONE updatedEntity)
        {
            _dbContext.PROJECT_MILESTONE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePROJECT_MILESTONE(Guid id)
        {
            var entityData = _dbContext.PROJECT_MILESTONE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PROJECT_MILESTONE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPROJECT_MILESTONE(Guid id, JsonPatchDocument<PROJECT_MILESTONE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PROJECT_MILESTONE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PROJECT_MILESTONE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}