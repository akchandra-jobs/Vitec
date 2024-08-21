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
    /// The entity_type_infoService responsible for managing entity_type_info related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting entity_type_info information.
    /// </remarks>
    public interface IENTITY_TYPE_INFOService
    {
        /// <summary>Retrieves a specific entity_type_info by its primary key</summary>
        /// <param name="id">The primary key of the entity_type_info</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The entity_type_info data</returns>
        Task<dynamic> GetById(Int64 id, string fields);

        /// <summary>Retrieves a list of entity_type_infos based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of entity_type_infos</returns>
        Task<List<ENTITY_TYPE_INFO>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new entity_type_info</summary>
        /// <param name="model">The entity_type_info data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Int64> Create(ENTITY_TYPE_INFO model);

        /// <summary>Updates a specific entity_type_info by its primary key</summary>
        /// <param name="id">The primary key of the entity_type_info</param>
        /// <param name="updatedEntity">The entity_type_info data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Int64 id, ENTITY_TYPE_INFO updatedEntity);

        /// <summary>Updates a specific entity_type_info by its primary key</summary>
        /// <param name="id">The primary key of the entity_type_info</param>
        /// <param name="updatedEntity">The entity_type_info data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Int64 id, JsonPatchDocument<ENTITY_TYPE_INFO> updatedEntity);

        /// <summary>Deletes a specific entity_type_info by its primary key</summary>
        /// <param name="id">The primary key of the entity_type_info</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Int64 id);
    }

    /// <summary>
    /// The entity_type_infoService responsible for managing entity_type_info related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting entity_type_info information.
    /// </remarks>
    public class ENTITY_TYPE_INFOService : IENTITY_TYPE_INFOService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the ENTITY_TYPE_INFO class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ENTITY_TYPE_INFOService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific entity_type_info by its primary key</summary>
        /// <param name="id">The primary key of the entity_type_info</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The entity_type_info data</returns>
        public async Task<dynamic> GetById(Int64 id, string fields)
        {
            var query = _dbContext.ENTITY_TYPE_INFO.AsQueryable();
            List<string> allfields = new List<string>();
            if (!string.IsNullOrEmpty(fields))
            {
                allfields.AddRange(fields.Split(","));
                fields = $"MODULE,{fields}";
            }
            else
            {
                fields = "MODULE";
            }

            string[] navigationProperties = [];
            foreach (var navigationProperty in navigationProperties)
            {
                if (allfields.Any(field => field.StartsWith(navigationProperty + ".", StringComparison.OrdinalIgnoreCase)))
                {
                    query = query.Include(navigationProperty);
                }
            }

            query = query.Where(entity => entity.MODULE == id);
            return _mapper.MapToFields(await query.FirstOrDefaultAsync(),fields);
        }

        /// <summary>Retrieves a list of entity_type_infos based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of entity_type_infos</returns>/// <exception cref="Exception"></exception>
        public async Task<List<ENTITY_TYPE_INFO>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetENTITY_TYPE_INFO(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new entity_type_info</summary>
        /// <param name="model">The entity_type_info data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Int64> Create(ENTITY_TYPE_INFO model)
        {
            model.MODULE = await CreateENTITY_TYPE_INFO(model);
            return model.MODULE;
        }

        /// <summary>Updates a specific entity_type_info by its primary key</summary>
        /// <param name="id">The primary key of the entity_type_info</param>
        /// <param name="updatedEntity">The entity_type_info data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Int64 id, ENTITY_TYPE_INFO updatedEntity)
        {
            await UpdateENTITY_TYPE_INFO(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific entity_type_info by its primary key</summary>
        /// <param name="id">The primary key of the entity_type_info</param>
        /// <param name="updatedEntity">The entity_type_info data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Int64 id, JsonPatchDocument<ENTITY_TYPE_INFO> updatedEntity)
        {
            await PatchENTITY_TYPE_INFO(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific entity_type_info by its primary key</summary>
        /// <param name="id">The primary key of the entity_type_info</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Int64 id)
        {
            await DeleteENTITY_TYPE_INFO(id);
            return true;
        }
        #region
        private async Task<List<ENTITY_TYPE_INFO>> GetENTITY_TYPE_INFO(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ENTITY_TYPE_INFO.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ENTITY_TYPE_INFO>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ENTITY_TYPE_INFO), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ENTITY_TYPE_INFO, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Int64> CreateENTITY_TYPE_INFO(ENTITY_TYPE_INFO model)
        {
            _dbContext.ENTITY_TYPE_INFO.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.MODULE;
        }

        private async Task UpdateENTITY_TYPE_INFO(Int64 id, ENTITY_TYPE_INFO updatedEntity)
        {
            _dbContext.ENTITY_TYPE_INFO.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteENTITY_TYPE_INFO(Int64 id)
        {
            var entityData = _dbContext.ENTITY_TYPE_INFO.FirstOrDefault(entity => entity.MODULE == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ENTITY_TYPE_INFO.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchENTITY_TYPE_INFO(Int64 id, JsonPatchDocument<ENTITY_TYPE_INFO> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ENTITY_TYPE_INFO.FirstOrDefault(t => t.MODULE == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ENTITY_TYPE_INFO.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}