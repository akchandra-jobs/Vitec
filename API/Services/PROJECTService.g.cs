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
    /// The projectService responsible for managing project related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting project information.
    /// </remarks>
    public interface IPROJECTService
    {
        /// <summary>Retrieves a specific project by its primary key</summary>
        /// <param name="id">The primary key of the project</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The project data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of projects based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of projects</returns>
        Task<List<PROJECT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new project</summary>
        /// <param name="model">The project data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PROJECT model);

        /// <summary>Updates a specific project by its primary key</summary>
        /// <param name="id">The primary key of the project</param>
        /// <param name="updatedEntity">The project data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PROJECT updatedEntity);

        /// <summary>Updates a specific project by its primary key</summary>
        /// <param name="id">The primary key of the project</param>
        /// <param name="updatedEntity">The project data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PROJECT> updatedEntity);

        /// <summary>Deletes a specific project by its primary key</summary>
        /// <param name="id">The primary key of the project</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The projectService responsible for managing project related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting project information.
    /// </remarks>
    public class PROJECTService : IPROJECTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PROJECT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PROJECTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific project by its primary key</summary>
        /// <param name="id">The primary key of the project</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The project data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PROJECT.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_ESTATE_ESTATE","GUID_AREA_AREA","GUID_COST_CENTER_COST_CENTER","GUID_DEPARTMENT_DEPARTMENT","GUID_PROJECT_CATEGORY_PROJECT_CATEGORY","GUID_MANAGER_PERSON_PERSON","GUID_OWNER_PERSON_PERSON","GUID_PROJECT_STATUS_PROJECT_STATUS","GUID_RESPONSIBLE_PERSON2_PERSON","GUID_SUPPLIER_SUPPLIER","GUID_DATA_OWNER_DATA_OWNER","GUID_RESPONSIBLE_PERSON_PERSON","GUID_BUILDING_BUILDING","GUID_PROJECT_TYPE_PROJECT_TYPE","GUID_CUSTOMER_CUSTOMER"];
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

        /// <summary>Retrieves a list of projects based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of projects</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PROJECT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPROJECT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new project</summary>
        /// <param name="model">The project data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PROJECT model)
        {
            model.GUID = await CreatePROJECT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific project by its primary key</summary>
        /// <param name="id">The primary key of the project</param>
        /// <param name="updatedEntity">The project data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PROJECT updatedEntity)
        {
            await UpdatePROJECT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific project by its primary key</summary>
        /// <param name="id">The primary key of the project</param>
        /// <param name="updatedEntity">The project data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PROJECT> updatedEntity)
        {
            await PatchPROJECT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific project by its primary key</summary>
        /// <param name="id">The primary key of the project</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePROJECT(id);
            return true;
        }
        #region
        private async Task<List<PROJECT>> GetPROJECT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PROJECT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PROJECT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PROJECT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PROJECT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePROJECT(PROJECT model)
        {
            _dbContext.PROJECT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePROJECT(Guid id, PROJECT updatedEntity)
        {
            _dbContext.PROJECT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePROJECT(Guid id)
        {
            var entityData = _dbContext.PROJECT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PROJECT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPROJECT(Guid id, JsonPatchDocument<PROJECT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PROJECT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PROJECT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}