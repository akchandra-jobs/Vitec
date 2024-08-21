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
    /// The area_x_entityService responsible for managing area_x_entity related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting area_x_entity information.
    /// </remarks>
    public interface IAREA_X_ENTITYService
    {
        /// <summary>Retrieves a specific area_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the area_x_entity</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The area_x_entity data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of area_x_entitys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of area_x_entitys</returns>
        Task<List<AREA_X_ENTITY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new area_x_entity</summary>
        /// <param name="model">The area_x_entity data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(AREA_X_ENTITY model);

        /// <summary>Updates a specific area_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the area_x_entity</param>
        /// <param name="updatedEntity">The area_x_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, AREA_X_ENTITY updatedEntity);

        /// <summary>Updates a specific area_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the area_x_entity</param>
        /// <param name="updatedEntity">The area_x_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<AREA_X_ENTITY> updatedEntity);

        /// <summary>Deletes a specific area_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the area_x_entity</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The area_x_entityService responsible for managing area_x_entity related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting area_x_entity information.
    /// </remarks>
    public class AREA_X_ENTITYService : IAREA_X_ENTITYService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the AREA_X_ENTITY class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public AREA_X_ENTITYService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific area_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the area_x_entity</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The area_x_entity data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.AREA_X_ENTITY.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_AREA_AREA","GUID_ROOM_AREA","GUID_ARTICLE_ARTICLE","GUID_SERVICE_SERVICE","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of area_x_entitys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of area_x_entitys</returns>/// <exception cref="Exception"></exception>
        public async Task<List<AREA_X_ENTITY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetAREA_X_ENTITY(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new area_x_entity</summary>
        /// <param name="model">The area_x_entity data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(AREA_X_ENTITY model)
        {
            model.GUID = await CreateAREA_X_ENTITY(model);
            return model.GUID;
        }

        /// <summary>Updates a specific area_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the area_x_entity</param>
        /// <param name="updatedEntity">The area_x_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, AREA_X_ENTITY updatedEntity)
        {
            await UpdateAREA_X_ENTITY(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific area_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the area_x_entity</param>
        /// <param name="updatedEntity">The area_x_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<AREA_X_ENTITY> updatedEntity)
        {
            await PatchAREA_X_ENTITY(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific area_x_entity by its primary key</summary>
        /// <param name="id">The primary key of the area_x_entity</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteAREA_X_ENTITY(id);
            return true;
        }
        #region
        private async Task<List<AREA_X_ENTITY>> GetAREA_X_ENTITY(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AREA_X_ENTITY.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AREA_X_ENTITY>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AREA_X_ENTITY), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AREA_X_ENTITY, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateAREA_X_ENTITY(AREA_X_ENTITY model)
        {
            _dbContext.AREA_X_ENTITY.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateAREA_X_ENTITY(Guid id, AREA_X_ENTITY updatedEntity)
        {
            _dbContext.AREA_X_ENTITY.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteAREA_X_ENTITY(Guid id)
        {
            var entityData = _dbContext.AREA_X_ENTITY.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AREA_X_ENTITY.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchAREA_X_ENTITY(Guid id, JsonPatchDocument<AREA_X_ENTITY> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AREA_X_ENTITY.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AREA_X_ENTITY.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}