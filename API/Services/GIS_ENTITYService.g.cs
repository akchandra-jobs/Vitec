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
    /// The gis_entityService responsible for managing gis_entity related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting gis_entity information.
    /// </remarks>
    public interface IGIS_ENTITYService
    {
        /// <summary>Retrieves a specific gis_entity by its primary key</summary>
        /// <param name="id">The primary key of the gis_entity</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The gis_entity data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of gis_entitys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of gis_entitys</returns>
        Task<List<GIS_ENTITY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new gis_entity</summary>
        /// <param name="model">The gis_entity data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(GIS_ENTITY model);

        /// <summary>Updates a specific gis_entity by its primary key</summary>
        /// <param name="id">The primary key of the gis_entity</param>
        /// <param name="updatedEntity">The gis_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, GIS_ENTITY updatedEntity);

        /// <summary>Updates a specific gis_entity by its primary key</summary>
        /// <param name="id">The primary key of the gis_entity</param>
        /// <param name="updatedEntity">The gis_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<GIS_ENTITY> updatedEntity);

        /// <summary>Deletes a specific gis_entity by its primary key</summary>
        /// <param name="id">The primary key of the gis_entity</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The gis_entityService responsible for managing gis_entity related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting gis_entity information.
    /// </remarks>
    public class GIS_ENTITYService : IGIS_ENTITYService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the GIS_ENTITY class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public GIS_ENTITYService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific gis_entity by its primary key</summary>
        /// <param name="id">The primary key of the gis_entity</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The gis_entity data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.GIS_ENTITY.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of gis_entitys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of gis_entitys</returns>/// <exception cref="Exception"></exception>
        public async Task<List<GIS_ENTITY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetGIS_ENTITY(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new gis_entity</summary>
        /// <param name="model">The gis_entity data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(GIS_ENTITY model)
        {
            model.GUID = await CreateGIS_ENTITY(model);
            return model.GUID;
        }

        /// <summary>Updates a specific gis_entity by its primary key</summary>
        /// <param name="id">The primary key of the gis_entity</param>
        /// <param name="updatedEntity">The gis_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, GIS_ENTITY updatedEntity)
        {
            await UpdateGIS_ENTITY(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific gis_entity by its primary key</summary>
        /// <param name="id">The primary key of the gis_entity</param>
        /// <param name="updatedEntity">The gis_entity data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<GIS_ENTITY> updatedEntity)
        {
            await PatchGIS_ENTITY(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific gis_entity by its primary key</summary>
        /// <param name="id">The primary key of the gis_entity</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteGIS_ENTITY(id);
            return true;
        }
        #region
        private async Task<List<GIS_ENTITY>> GetGIS_ENTITY(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.GIS_ENTITY.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<GIS_ENTITY>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(GIS_ENTITY), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<GIS_ENTITY, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateGIS_ENTITY(GIS_ENTITY model)
        {
            _dbContext.GIS_ENTITY.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateGIS_ENTITY(Guid id, GIS_ENTITY updatedEntity)
        {
            _dbContext.GIS_ENTITY.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteGIS_ENTITY(Guid id)
        {
            var entityData = _dbContext.GIS_ENTITY.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.GIS_ENTITY.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchGIS_ENTITY(Guid id, JsonPatchDocument<GIS_ENTITY> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.GIS_ENTITY.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.GIS_ENTITY.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}