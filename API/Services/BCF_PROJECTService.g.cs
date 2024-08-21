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
    /// The bcf_projectService responsible for managing bcf_project related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting bcf_project information.
    /// </remarks>
    public interface IBCF_PROJECTService
    {
        /// <summary>Retrieves a specific bcf_project by its primary key</summary>
        /// <param name="id">The primary key of the bcf_project</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The bcf_project data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of bcf_projects based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of bcf_projects</returns>
        Task<List<BCF_PROJECT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new bcf_project</summary>
        /// <param name="model">The bcf_project data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(BCF_PROJECT model);

        /// <summary>Updates a specific bcf_project by its primary key</summary>
        /// <param name="id">The primary key of the bcf_project</param>
        /// <param name="updatedEntity">The bcf_project data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, BCF_PROJECT updatedEntity);

        /// <summary>Updates a specific bcf_project by its primary key</summary>
        /// <param name="id">The primary key of the bcf_project</param>
        /// <param name="updatedEntity">The bcf_project data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<BCF_PROJECT> updatedEntity);

        /// <summary>Deletes a specific bcf_project by its primary key</summary>
        /// <param name="id">The primary key of the bcf_project</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The bcf_projectService responsible for managing bcf_project related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting bcf_project information.
    /// </remarks>
    public class BCF_PROJECTService : IBCF_PROJECTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the BCF_PROJECT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public BCF_PROJECTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific bcf_project by its primary key</summary>
        /// <param name="id">The primary key of the bcf_project</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The bcf_project data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.BCF_PROJECT.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_ESTATE_ESTATE","GUID_BUILDING_BUILDING","GUID_EXPORTED_BY_USER_USR","GUID_CLOSED_BY_USER_USR"];
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

        /// <summary>Retrieves a list of bcf_projects based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of bcf_projects</returns>/// <exception cref="Exception"></exception>
        public async Task<List<BCF_PROJECT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetBCF_PROJECT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new bcf_project</summary>
        /// <param name="model">The bcf_project data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(BCF_PROJECT model)
        {
            model.GUID = await CreateBCF_PROJECT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific bcf_project by its primary key</summary>
        /// <param name="id">The primary key of the bcf_project</param>
        /// <param name="updatedEntity">The bcf_project data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, BCF_PROJECT updatedEntity)
        {
            await UpdateBCF_PROJECT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific bcf_project by its primary key</summary>
        /// <param name="id">The primary key of the bcf_project</param>
        /// <param name="updatedEntity">The bcf_project data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<BCF_PROJECT> updatedEntity)
        {
            await PatchBCF_PROJECT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific bcf_project by its primary key</summary>
        /// <param name="id">The primary key of the bcf_project</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteBCF_PROJECT(id);
            return true;
        }
        #region
        private async Task<List<BCF_PROJECT>> GetBCF_PROJECT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.BCF_PROJECT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<BCF_PROJECT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(BCF_PROJECT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<BCF_PROJECT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateBCF_PROJECT(BCF_PROJECT model)
        {
            _dbContext.BCF_PROJECT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateBCF_PROJECT(Guid id, BCF_PROJECT updatedEntity)
        {
            _dbContext.BCF_PROJECT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteBCF_PROJECT(Guid id)
        {
            var entityData = _dbContext.BCF_PROJECT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.BCF_PROJECT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchBCF_PROJECT(Guid id, JsonPatchDocument<BCF_PROJECT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.BCF_PROJECT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.BCF_PROJECT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}