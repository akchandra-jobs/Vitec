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
    /// The hatchingService responsible for managing hatching related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting hatching information.
    /// </remarks>
    public interface IHATCHINGService
    {
        /// <summary>Retrieves a specific hatching by its primary key</summary>
        /// <param name="id">The primary key of the hatching</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The hatching data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of hatchings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of hatchings</returns>
        Task<List<HATCHING>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new hatching</summary>
        /// <param name="model">The hatching data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(HATCHING model);

        /// <summary>Updates a specific hatching by its primary key</summary>
        /// <param name="id">The primary key of the hatching</param>
        /// <param name="updatedEntity">The hatching data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, HATCHING updatedEntity);

        /// <summary>Updates a specific hatching by its primary key</summary>
        /// <param name="id">The primary key of the hatching</param>
        /// <param name="updatedEntity">The hatching data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<HATCHING> updatedEntity);

        /// <summary>Deletes a specific hatching by its primary key</summary>
        /// <param name="id">The primary key of the hatching</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The hatchingService responsible for managing hatching related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting hatching information.
    /// </remarks>
    public class HATCHINGService : IHATCHINGService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the HATCHING class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public HATCHINGService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific hatching by its primary key</summary>
        /// <param name="id">The primary key of the hatching</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The hatching data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.HATCHING.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_DRAWING_DRAWING"];
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

        /// <summary>Retrieves a list of hatchings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of hatchings</returns>/// <exception cref="Exception"></exception>
        public async Task<List<HATCHING>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetHATCHING(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new hatching</summary>
        /// <param name="model">The hatching data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(HATCHING model)
        {
            model.GUID = await CreateHATCHING(model);
            return model.GUID;
        }

        /// <summary>Updates a specific hatching by its primary key</summary>
        /// <param name="id">The primary key of the hatching</param>
        /// <param name="updatedEntity">The hatching data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, HATCHING updatedEntity)
        {
            await UpdateHATCHING(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific hatching by its primary key</summary>
        /// <param name="id">The primary key of the hatching</param>
        /// <param name="updatedEntity">The hatching data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<HATCHING> updatedEntity)
        {
            await PatchHATCHING(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific hatching by its primary key</summary>
        /// <param name="id">The primary key of the hatching</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteHATCHING(id);
            return true;
        }
        #region
        private async Task<List<HATCHING>> GetHATCHING(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.HATCHING.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<HATCHING>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(HATCHING), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<HATCHING, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateHATCHING(HATCHING model)
        {
            _dbContext.HATCHING.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateHATCHING(Guid id, HATCHING updatedEntity)
        {
            _dbContext.HATCHING.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteHATCHING(Guid id)
        {
            var entityData = _dbContext.HATCHING.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.HATCHING.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchHATCHING(Guid id, JsonPatchDocument<HATCHING> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.HATCHING.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.HATCHING.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}