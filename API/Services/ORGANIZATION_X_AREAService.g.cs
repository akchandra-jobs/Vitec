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
    /// The organization_x_areaService responsible for managing organization_x_area related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting organization_x_area information.
    /// </remarks>
    public interface IORGANIZATION_X_AREAService
    {
        /// <summary>Retrieves a specific organization_x_area by its primary key</summary>
        /// <param name="id">The primary key of the organization_x_area</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The organization_x_area data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of organization_x_areas based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of organization_x_areas</returns>
        Task<List<ORGANIZATION_X_AREA>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new organization_x_area</summary>
        /// <param name="model">The organization_x_area data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(ORGANIZATION_X_AREA model);

        /// <summary>Updates a specific organization_x_area by its primary key</summary>
        /// <param name="id">The primary key of the organization_x_area</param>
        /// <param name="updatedEntity">The organization_x_area data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, ORGANIZATION_X_AREA updatedEntity);

        /// <summary>Updates a specific organization_x_area by its primary key</summary>
        /// <param name="id">The primary key of the organization_x_area</param>
        /// <param name="updatedEntity">The organization_x_area data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<ORGANIZATION_X_AREA> updatedEntity);

        /// <summary>Deletes a specific organization_x_area by its primary key</summary>
        /// <param name="id">The primary key of the organization_x_area</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The organization_x_areaService responsible for managing organization_x_area related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting organization_x_area information.
    /// </remarks>
    public class ORGANIZATION_X_AREAService : IORGANIZATION_X_AREAService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the ORGANIZATION_X_AREA class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ORGANIZATION_X_AREAService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific organization_x_area by its primary key</summary>
        /// <param name="id">The primary key of the organization_x_area</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The organization_x_area data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.ORGANIZATION_X_AREA.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_AREA_AREA","GUID_ORGANIZATION_ORGANIZATION"];
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

        /// <summary>Retrieves a list of organization_x_areas based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of organization_x_areas</returns>/// <exception cref="Exception"></exception>
        public async Task<List<ORGANIZATION_X_AREA>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetORGANIZATION_X_AREA(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new organization_x_area</summary>
        /// <param name="model">The organization_x_area data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(ORGANIZATION_X_AREA model)
        {
            model.GUID = await CreateORGANIZATION_X_AREA(model);
            return model.GUID;
        }

        /// <summary>Updates a specific organization_x_area by its primary key</summary>
        /// <param name="id">The primary key of the organization_x_area</param>
        /// <param name="updatedEntity">The organization_x_area data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, ORGANIZATION_X_AREA updatedEntity)
        {
            await UpdateORGANIZATION_X_AREA(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific organization_x_area by its primary key</summary>
        /// <param name="id">The primary key of the organization_x_area</param>
        /// <param name="updatedEntity">The organization_x_area data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<ORGANIZATION_X_AREA> updatedEntity)
        {
            await PatchORGANIZATION_X_AREA(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific organization_x_area by its primary key</summary>
        /// <param name="id">The primary key of the organization_x_area</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteORGANIZATION_X_AREA(id);
            return true;
        }
        #region
        private async Task<List<ORGANIZATION_X_AREA>> GetORGANIZATION_X_AREA(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ORGANIZATION_X_AREA.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ORGANIZATION_X_AREA>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ORGANIZATION_X_AREA), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ORGANIZATION_X_AREA, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateORGANIZATION_X_AREA(ORGANIZATION_X_AREA model)
        {
            _dbContext.ORGANIZATION_X_AREA.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateORGANIZATION_X_AREA(Guid id, ORGANIZATION_X_AREA updatedEntity)
        {
            _dbContext.ORGANIZATION_X_AREA.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteORGANIZATION_X_AREA(Guid id)
        {
            var entityData = _dbContext.ORGANIZATION_X_AREA.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ORGANIZATION_X_AREA.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchORGANIZATION_X_AREA(Guid id, JsonPatchDocument<ORGANIZATION_X_AREA> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ORGANIZATION_X_AREA.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ORGANIZATION_X_AREA.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}