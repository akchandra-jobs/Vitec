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
    /// The transferService responsible for managing transfer related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting transfer information.
    /// </remarks>
    public interface ITRANSFERService
    {
        /// <summary>Retrieves a specific transfer by its primary key</summary>
        /// <param name="id">The primary key of the transfer</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The transfer data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of transfers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of transfers</returns>
        Task<List<TRANSFER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new transfer</summary>
        /// <param name="model">The transfer data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(TRANSFER model);

        /// <summary>Updates a specific transfer by its primary key</summary>
        /// <param name="id">The primary key of the transfer</param>
        /// <param name="updatedEntity">The transfer data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, TRANSFER updatedEntity);

        /// <summary>Updates a specific transfer by its primary key</summary>
        /// <param name="id">The primary key of the transfer</param>
        /// <param name="updatedEntity">The transfer data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<TRANSFER> updatedEntity);

        /// <summary>Deletes a specific transfer by its primary key</summary>
        /// <param name="id">The primary key of the transfer</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The transferService responsible for managing transfer related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting transfer information.
    /// </remarks>
    public class TRANSFERService : ITRANSFERService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the TRANSFER class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public TRANSFERService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific transfer by its primary key</summary>
        /// <param name="id">The primary key of the transfer</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The transfer data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.TRANSFER.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_USER_GENERATED_BY_USR","GUID_USER_APPROVED_BY_USR"];
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

        /// <summary>Retrieves a list of transfers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of transfers</returns>/// <exception cref="Exception"></exception>
        public async Task<List<TRANSFER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetTRANSFER(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new transfer</summary>
        /// <param name="model">The transfer data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(TRANSFER model)
        {
            model.GUID = await CreateTRANSFER(model);
            return model.GUID;
        }

        /// <summary>Updates a specific transfer by its primary key</summary>
        /// <param name="id">The primary key of the transfer</param>
        /// <param name="updatedEntity">The transfer data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, TRANSFER updatedEntity)
        {
            await UpdateTRANSFER(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific transfer by its primary key</summary>
        /// <param name="id">The primary key of the transfer</param>
        /// <param name="updatedEntity">The transfer data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<TRANSFER> updatedEntity)
        {
            await PatchTRANSFER(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific transfer by its primary key</summary>
        /// <param name="id">The primary key of the transfer</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteTRANSFER(id);
            return true;
        }
        #region
        private async Task<List<TRANSFER>> GetTRANSFER(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.TRANSFER.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<TRANSFER>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(TRANSFER), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<TRANSFER, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateTRANSFER(TRANSFER model)
        {
            _dbContext.TRANSFER.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateTRANSFER(Guid id, TRANSFER updatedEntity)
        {
            _dbContext.TRANSFER.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteTRANSFER(Guid id)
        {
            var entityData = _dbContext.TRANSFER.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.TRANSFER.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchTRANSFER(Guid id, JsonPatchDocument<TRANSFER> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.TRANSFER.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.TRANSFER.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}