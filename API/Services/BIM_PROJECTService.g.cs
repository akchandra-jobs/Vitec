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
    /// The bim_projectService responsible for managing bim_project related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting bim_project information.
    /// </remarks>
    public interface IBIM_PROJECTService
    {
        /// <summary>Retrieves a specific bim_project by its primary key</summary>
        /// <param name="id">The primary key of the bim_project</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The bim_project data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of bim_projects based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of bim_projects</returns>
        Task<List<BIM_PROJECT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new bim_project</summary>
        /// <param name="model">The bim_project data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(BIM_PROJECT model);

        /// <summary>Updates a specific bim_project by its primary key</summary>
        /// <param name="id">The primary key of the bim_project</param>
        /// <param name="updatedEntity">The bim_project data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, BIM_PROJECT updatedEntity);

        /// <summary>Updates a specific bim_project by its primary key</summary>
        /// <param name="id">The primary key of the bim_project</param>
        /// <param name="updatedEntity">The bim_project data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<BIM_PROJECT> updatedEntity);

        /// <summary>Deletes a specific bim_project by its primary key</summary>
        /// <param name="id">The primary key of the bim_project</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The bim_projectService responsible for managing bim_project related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting bim_project information.
    /// </remarks>
    public class BIM_PROJECTService : IBIM_PROJECTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the BIM_PROJECT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public BIM_PROJECTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific bim_project by its primary key</summary>
        /// <param name="id">The primary key of the bim_project</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The bim_project data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.BIM_PROJECT.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_ESTATE_ESTATE","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of bim_projects based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of bim_projects</returns>/// <exception cref="Exception"></exception>
        public async Task<List<BIM_PROJECT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetBIM_PROJECT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new bim_project</summary>
        /// <param name="model">The bim_project data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(BIM_PROJECT model)
        {
            model.GUID = await CreateBIM_PROJECT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific bim_project by its primary key</summary>
        /// <param name="id">The primary key of the bim_project</param>
        /// <param name="updatedEntity">The bim_project data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, BIM_PROJECT updatedEntity)
        {
            await UpdateBIM_PROJECT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific bim_project by its primary key</summary>
        /// <param name="id">The primary key of the bim_project</param>
        /// <param name="updatedEntity">The bim_project data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<BIM_PROJECT> updatedEntity)
        {
            await PatchBIM_PROJECT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific bim_project by its primary key</summary>
        /// <param name="id">The primary key of the bim_project</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteBIM_PROJECT(id);
            return true;
        }
        #region
        private async Task<List<BIM_PROJECT>> GetBIM_PROJECT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.BIM_PROJECT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<BIM_PROJECT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(BIM_PROJECT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<BIM_PROJECT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateBIM_PROJECT(BIM_PROJECT model)
        {
            _dbContext.BIM_PROJECT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateBIM_PROJECT(Guid id, BIM_PROJECT updatedEntity)
        {
            _dbContext.BIM_PROJECT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteBIM_PROJECT(Guid id)
        {
            var entityData = _dbContext.BIM_PROJECT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.BIM_PROJECT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchBIM_PROJECT(Guid id, JsonPatchDocument<BIM_PROJECT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.BIM_PROJECT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.BIM_PROJECT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}