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
    /// The adjustmentService responsible for managing adjustment related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting adjustment information.
    /// </remarks>
    public interface IADJUSTMENTService
    {
        /// <summary>Retrieves a specific adjustment by its primary key</summary>
        /// <param name="id">The primary key of the adjustment</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The adjustment data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of adjustments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of adjustments</returns>
        Task<List<ADJUSTMENT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new adjustment</summary>
        /// <param name="model">The adjustment data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(ADJUSTMENT model);

        /// <summary>Updates a specific adjustment by its primary key</summary>
        /// <param name="id">The primary key of the adjustment</param>
        /// <param name="updatedEntity">The adjustment data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, ADJUSTMENT updatedEntity);

        /// <summary>Updates a specific adjustment by its primary key</summary>
        /// <param name="id">The primary key of the adjustment</param>
        /// <param name="updatedEntity">The adjustment data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<ADJUSTMENT> updatedEntity);

        /// <summary>Deletes a specific adjustment by its primary key</summary>
        /// <param name="id">The primary key of the adjustment</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The adjustmentService responsible for managing adjustment related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting adjustment information.
    /// </remarks>
    public class ADJUSTMENTService : IADJUSTMENTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the ADJUSTMENT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ADJUSTMENTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific adjustment by its primary key</summary>
        /// <param name="id">The primary key of the adjustment</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The adjustment data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.ADJUSTMENT.AsQueryable();
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

        /// <summary>Retrieves a list of adjustments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of adjustments</returns>/// <exception cref="Exception"></exception>
        public async Task<List<ADJUSTMENT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetADJUSTMENT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new adjustment</summary>
        /// <param name="model">The adjustment data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(ADJUSTMENT model)
        {
            model.GUID = await CreateADJUSTMENT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific adjustment by its primary key</summary>
        /// <param name="id">The primary key of the adjustment</param>
        /// <param name="updatedEntity">The adjustment data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, ADJUSTMENT updatedEntity)
        {
            await UpdateADJUSTMENT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific adjustment by its primary key</summary>
        /// <param name="id">The primary key of the adjustment</param>
        /// <param name="updatedEntity">The adjustment data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<ADJUSTMENT> updatedEntity)
        {
            await PatchADJUSTMENT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific adjustment by its primary key</summary>
        /// <param name="id">The primary key of the adjustment</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteADJUSTMENT(id);
            return true;
        }
        #region
        private async Task<List<ADJUSTMENT>> GetADJUSTMENT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ADJUSTMENT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ADJUSTMENT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ADJUSTMENT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ADJUSTMENT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateADJUSTMENT(ADJUSTMENT model)
        {
            _dbContext.ADJUSTMENT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateADJUSTMENT(Guid id, ADJUSTMENT updatedEntity)
        {
            _dbContext.ADJUSTMENT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteADJUSTMENT(Guid id)
        {
            var entityData = _dbContext.ADJUSTMENT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ADJUSTMENT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchADJUSTMENT(Guid id, JsonPatchDocument<ADJUSTMENT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ADJUSTMENT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ADJUSTMENT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}