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
    /// The serverService responsible for managing server related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting server information.
    /// </remarks>
    public interface ISERVERService
    {
        /// <summary>Retrieves a specific server by its primary key</summary>
        /// <param name="id">The primary key of the server</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The server data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of servers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of servers</returns>
        Task<List<SERVER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new server</summary>
        /// <param name="model">The server data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(SERVER model);

        /// <summary>Updates a specific server by its primary key</summary>
        /// <param name="id">The primary key of the server</param>
        /// <param name="updatedEntity">The server data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, SERVER updatedEntity);

        /// <summary>Updates a specific server by its primary key</summary>
        /// <param name="id">The primary key of the server</param>
        /// <param name="updatedEntity">The server data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<SERVER> updatedEntity);

        /// <summary>Deletes a specific server by its primary key</summary>
        /// <param name="id">The primary key of the server</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The serverService responsible for managing server related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting server information.
    /// </remarks>
    public class SERVERService : ISERVERService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the SERVER class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public SERVERService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific server by its primary key</summary>
        /// <param name="id">The primary key of the server</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The server data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.SERVER.AsQueryable();
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

            string[] navigationProperties = [];
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

        /// <summary>Retrieves a list of servers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of servers</returns>/// <exception cref="Exception"></exception>
        public async Task<List<SERVER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetSERVER(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new server</summary>
        /// <param name="model">The server data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(SERVER model)
        {
            model.GUID = await CreateSERVER(model);
            return model.GUID;
        }

        /// <summary>Updates a specific server by its primary key</summary>
        /// <param name="id">The primary key of the server</param>
        /// <param name="updatedEntity">The server data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, SERVER updatedEntity)
        {
            await UpdateSERVER(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific server by its primary key</summary>
        /// <param name="id">The primary key of the server</param>
        /// <param name="updatedEntity">The server data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<SERVER> updatedEntity)
        {
            await PatchSERVER(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific server by its primary key</summary>
        /// <param name="id">The primary key of the server</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteSERVER(id);
            return true;
        }
        #region
        private async Task<List<SERVER>> GetSERVER(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SERVER.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SERVER>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SERVER), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SERVER, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateSERVER(SERVER model)
        {
            _dbContext.SERVER.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateSERVER(Guid id, SERVER updatedEntity)
        {
            _dbContext.SERVER.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteSERVER(Guid id)
        {
            var entityData = _dbContext.SERVER.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SERVER.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchSERVER(Guid id, JsonPatchDocument<SERVER> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SERVER.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SERVER.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}