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
    /// The drawing_x_layer_groupService responsible for managing drawing_x_layer_group related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting drawing_x_layer_group information.
    /// </remarks>
    public interface IDRAWING_X_LAYER_GROUPService
    {
        /// <summary>Retrieves a specific drawing_x_layer_group by its primary key</summary>
        /// <param name="id">The primary key of the drawing_x_layer_group</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The drawing_x_layer_group data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of drawing_x_layer_groups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of drawing_x_layer_groups</returns>
        Task<List<DRAWING_X_LAYER_GROUP>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new drawing_x_layer_group</summary>
        /// <param name="model">The drawing_x_layer_group data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(DRAWING_X_LAYER_GROUP model);

        /// <summary>Updates a specific drawing_x_layer_group by its primary key</summary>
        /// <param name="id">The primary key of the drawing_x_layer_group</param>
        /// <param name="updatedEntity">The drawing_x_layer_group data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, DRAWING_X_LAYER_GROUP updatedEntity);

        /// <summary>Updates a specific drawing_x_layer_group by its primary key</summary>
        /// <param name="id">The primary key of the drawing_x_layer_group</param>
        /// <param name="updatedEntity">The drawing_x_layer_group data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<DRAWING_X_LAYER_GROUP> updatedEntity);

        /// <summary>Deletes a specific drawing_x_layer_group by its primary key</summary>
        /// <param name="id">The primary key of the drawing_x_layer_group</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The drawing_x_layer_groupService responsible for managing drawing_x_layer_group related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting drawing_x_layer_group information.
    /// </remarks>
    public class DRAWING_X_LAYER_GROUPService : IDRAWING_X_LAYER_GROUPService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the DRAWING_X_LAYER_GROUP class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public DRAWING_X_LAYER_GROUPService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific drawing_x_layer_group by its primary key</summary>
        /// <param name="id">The primary key of the drawing_x_layer_group</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The drawing_x_layer_group data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.DRAWING_X_LAYER_GROUP.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_LAYER_GROUP_LAYER_GROUP","GUID_DRAWING_DRAWING","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of drawing_x_layer_groups based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of drawing_x_layer_groups</returns>/// <exception cref="Exception"></exception>
        public async Task<List<DRAWING_X_LAYER_GROUP>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetDRAWING_X_LAYER_GROUP(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new drawing_x_layer_group</summary>
        /// <param name="model">The drawing_x_layer_group data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(DRAWING_X_LAYER_GROUP model)
        {
            model.GUID = await CreateDRAWING_X_LAYER_GROUP(model);
            return model.GUID;
        }

        /// <summary>Updates a specific drawing_x_layer_group by its primary key</summary>
        /// <param name="id">The primary key of the drawing_x_layer_group</param>
        /// <param name="updatedEntity">The drawing_x_layer_group data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, DRAWING_X_LAYER_GROUP updatedEntity)
        {
            await UpdateDRAWING_X_LAYER_GROUP(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific drawing_x_layer_group by its primary key</summary>
        /// <param name="id">The primary key of the drawing_x_layer_group</param>
        /// <param name="updatedEntity">The drawing_x_layer_group data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<DRAWING_X_LAYER_GROUP> updatedEntity)
        {
            await PatchDRAWING_X_LAYER_GROUP(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific drawing_x_layer_group by its primary key</summary>
        /// <param name="id">The primary key of the drawing_x_layer_group</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteDRAWING_X_LAYER_GROUP(id);
            return true;
        }
        #region
        private async Task<List<DRAWING_X_LAYER_GROUP>> GetDRAWING_X_LAYER_GROUP(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DRAWING_X_LAYER_GROUP.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DRAWING_X_LAYER_GROUP>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DRAWING_X_LAYER_GROUP), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DRAWING_X_LAYER_GROUP, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateDRAWING_X_LAYER_GROUP(DRAWING_X_LAYER_GROUP model)
        {
            _dbContext.DRAWING_X_LAYER_GROUP.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateDRAWING_X_LAYER_GROUP(Guid id, DRAWING_X_LAYER_GROUP updatedEntity)
        {
            _dbContext.DRAWING_X_LAYER_GROUP.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteDRAWING_X_LAYER_GROUP(Guid id)
        {
            var entityData = _dbContext.DRAWING_X_LAYER_GROUP.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DRAWING_X_LAYER_GROUP.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchDRAWING_X_LAYER_GROUP(Guid id, JsonPatchDocument<DRAWING_X_LAYER_GROUP> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DRAWING_X_LAYER_GROUP.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DRAWING_X_LAYER_GROUP.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}