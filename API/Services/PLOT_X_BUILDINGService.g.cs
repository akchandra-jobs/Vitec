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
    /// The plot_x_buildingService responsible for managing plot_x_building related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting plot_x_building information.
    /// </remarks>
    public interface IPLOT_X_BUILDINGService
    {
        /// <summary>Retrieves a specific plot_x_building by its primary key</summary>
        /// <param name="id">The primary key of the plot_x_building</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The plot_x_building data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of plot_x_buildings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of plot_x_buildings</returns>
        Task<List<PLOT_X_BUILDING>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new plot_x_building</summary>
        /// <param name="model">The plot_x_building data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PLOT_X_BUILDING model);

        /// <summary>Updates a specific plot_x_building by its primary key</summary>
        /// <param name="id">The primary key of the plot_x_building</param>
        /// <param name="updatedEntity">The plot_x_building data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PLOT_X_BUILDING updatedEntity);

        /// <summary>Updates a specific plot_x_building by its primary key</summary>
        /// <param name="id">The primary key of the plot_x_building</param>
        /// <param name="updatedEntity">The plot_x_building data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PLOT_X_BUILDING> updatedEntity);

        /// <summary>Deletes a specific plot_x_building by its primary key</summary>
        /// <param name="id">The primary key of the plot_x_building</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The plot_x_buildingService responsible for managing plot_x_building related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting plot_x_building information.
    /// </remarks>
    public class PLOT_X_BUILDINGService : IPLOT_X_BUILDINGService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PLOT_X_BUILDING class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PLOT_X_BUILDINGService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific plot_x_building by its primary key</summary>
        /// <param name="id">The primary key of the plot_x_building</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The plot_x_building data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PLOT_X_BUILDING.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_BUILDING_BUILDING","GUID_PLOT_BUILDING","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of plot_x_buildings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of plot_x_buildings</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PLOT_X_BUILDING>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPLOT_X_BUILDING(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new plot_x_building</summary>
        /// <param name="model">The plot_x_building data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PLOT_X_BUILDING model)
        {
            model.GUID = await CreatePLOT_X_BUILDING(model);
            return model.GUID;
        }

        /// <summary>Updates a specific plot_x_building by its primary key</summary>
        /// <param name="id">The primary key of the plot_x_building</param>
        /// <param name="updatedEntity">The plot_x_building data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PLOT_X_BUILDING updatedEntity)
        {
            await UpdatePLOT_X_BUILDING(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific plot_x_building by its primary key</summary>
        /// <param name="id">The primary key of the plot_x_building</param>
        /// <param name="updatedEntity">The plot_x_building data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PLOT_X_BUILDING> updatedEntity)
        {
            await PatchPLOT_X_BUILDING(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific plot_x_building by its primary key</summary>
        /// <param name="id">The primary key of the plot_x_building</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePLOT_X_BUILDING(id);
            return true;
        }
        #region
        private async Task<List<PLOT_X_BUILDING>> GetPLOT_X_BUILDING(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PLOT_X_BUILDING.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PLOT_X_BUILDING>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PLOT_X_BUILDING), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PLOT_X_BUILDING, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePLOT_X_BUILDING(PLOT_X_BUILDING model)
        {
            _dbContext.PLOT_X_BUILDING.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePLOT_X_BUILDING(Guid id, PLOT_X_BUILDING updatedEntity)
        {
            _dbContext.PLOT_X_BUILDING.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePLOT_X_BUILDING(Guid id)
        {
            var entityData = _dbContext.PLOT_X_BUILDING.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PLOT_X_BUILDING.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPLOT_X_BUILDING(Guid id, JsonPatchDocument<PLOT_X_BUILDING> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PLOT_X_BUILDING.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PLOT_X_BUILDING.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}