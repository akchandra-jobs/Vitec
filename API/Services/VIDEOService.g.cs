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
    /// The videoService responsible for managing video related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting video information.
    /// </remarks>
    public interface IVIDEOService
    {
        /// <summary>Retrieves a specific video by its primary key</summary>
        /// <param name="id">The primary key of the video</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The video data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of videos based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of videos</returns>
        Task<List<VIDEO>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new video</summary>
        /// <param name="model">The video data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(VIDEO model);

        /// <summary>Updates a specific video by its primary key</summary>
        /// <param name="id">The primary key of the video</param>
        /// <param name="updatedEntity">The video data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, VIDEO updatedEntity);

        /// <summary>Updates a specific video by its primary key</summary>
        /// <param name="id">The primary key of the video</param>
        /// <param name="updatedEntity">The video data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<VIDEO> updatedEntity);

        /// <summary>Deletes a specific video by its primary key</summary>
        /// <param name="id">The primary key of the video</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The videoService responsible for managing video related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting video information.
    /// </remarks>
    public class VIDEOService : IVIDEOService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the VIDEO class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public VIDEOService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific video by its primary key</summary>
        /// <param name="id">The primary key of the video</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The video data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.VIDEO.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_VIDEO_BINARY_VIDEO_BINARY","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of videos based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of videos</returns>/// <exception cref="Exception"></exception>
        public async Task<List<VIDEO>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetVIDEO(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new video</summary>
        /// <param name="model">The video data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(VIDEO model)
        {
            model.GUID = await CreateVIDEO(model);
            return model.GUID;
        }

        /// <summary>Updates a specific video by its primary key</summary>
        /// <param name="id">The primary key of the video</param>
        /// <param name="updatedEntity">The video data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, VIDEO updatedEntity)
        {
            await UpdateVIDEO(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific video by its primary key</summary>
        /// <param name="id">The primary key of the video</param>
        /// <param name="updatedEntity">The video data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<VIDEO> updatedEntity)
        {
            await PatchVIDEO(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific video by its primary key</summary>
        /// <param name="id">The primary key of the video</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteVIDEO(id);
            return true;
        }
        #region
        private async Task<List<VIDEO>> GetVIDEO(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.VIDEO.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<VIDEO>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(VIDEO), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<VIDEO, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateVIDEO(VIDEO model)
        {
            _dbContext.VIDEO.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateVIDEO(Guid id, VIDEO updatedEntity)
        {
            _dbContext.VIDEO.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteVIDEO(Guid id)
        {
            var entityData = _dbContext.VIDEO.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.VIDEO.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchVIDEO(Guid id, JsonPatchDocument<VIDEO> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.VIDEO.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.VIDEO.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}