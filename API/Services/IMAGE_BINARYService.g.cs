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
    /// The image_binaryService responsible for managing image_binary related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting image_binary information.
    /// </remarks>
    public interface IIMAGE_BINARYService
    {
        /// <summary>Retrieves a specific image_binary by its primary key</summary>
        /// <param name="id">The primary key of the image_binary</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The image_binary data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of image_binarys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of image_binarys</returns>
        Task<List<IMAGE_BINARY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new image_binary</summary>
        /// <param name="model">The image_binary data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(IMAGE_BINARY model);

        /// <summary>Updates a specific image_binary by its primary key</summary>
        /// <param name="id">The primary key of the image_binary</param>
        /// <param name="updatedEntity">The image_binary data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, IMAGE_BINARY updatedEntity);

        /// <summary>Updates a specific image_binary by its primary key</summary>
        /// <param name="id">The primary key of the image_binary</param>
        /// <param name="updatedEntity">The image_binary data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<IMAGE_BINARY> updatedEntity);

        /// <summary>Deletes a specific image_binary by its primary key</summary>
        /// <param name="id">The primary key of the image_binary</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The image_binaryService responsible for managing image_binary related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting image_binary information.
    /// </remarks>
    public class IMAGE_BINARYService : IIMAGE_BINARYService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the IMAGE_BINARY class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public IMAGE_BINARYService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific image_binary by its primary key</summary>
        /// <param name="id">The primary key of the image_binary</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The image_binary data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.IMAGE_BINARY.AsQueryable();
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

        /// <summary>Retrieves a list of image_binarys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of image_binarys</returns>/// <exception cref="Exception"></exception>
        public async Task<List<IMAGE_BINARY>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetIMAGE_BINARY(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new image_binary</summary>
        /// <param name="model">The image_binary data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(IMAGE_BINARY model)
        {
            model.GUID = await CreateIMAGE_BINARY(model);
            return model.GUID;
        }

        /// <summary>Updates a specific image_binary by its primary key</summary>
        /// <param name="id">The primary key of the image_binary</param>
        /// <param name="updatedEntity">The image_binary data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, IMAGE_BINARY updatedEntity)
        {
            await UpdateIMAGE_BINARY(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific image_binary by its primary key</summary>
        /// <param name="id">The primary key of the image_binary</param>
        /// <param name="updatedEntity">The image_binary data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<IMAGE_BINARY> updatedEntity)
        {
            await PatchIMAGE_BINARY(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific image_binary by its primary key</summary>
        /// <param name="id">The primary key of the image_binary</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteIMAGE_BINARY(id);
            return true;
        }
        #region
        private async Task<List<IMAGE_BINARY>> GetIMAGE_BINARY(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.IMAGE_BINARY.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<IMAGE_BINARY>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(IMAGE_BINARY), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<IMAGE_BINARY, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateIMAGE_BINARY(IMAGE_BINARY model)
        {
            _dbContext.IMAGE_BINARY.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateIMAGE_BINARY(Guid id, IMAGE_BINARY updatedEntity)
        {
            _dbContext.IMAGE_BINARY.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteIMAGE_BINARY(Guid id)
        {
            var entityData = _dbContext.IMAGE_BINARY.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.IMAGE_BINARY.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchIMAGE_BINARY(Guid id, JsonPatchDocument<IMAGE_BINARY> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.IMAGE_BINARY.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.IMAGE_BINARY.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}