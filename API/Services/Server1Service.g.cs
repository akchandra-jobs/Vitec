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
    /// The server1Service responsible for managing server1 related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting server1 information.
    /// </remarks>
    public interface IServer1Service
    {
        /// <summary>Retrieves a specific server1 by its primary key</summary>
        /// <param name="id">The primary key of the server1</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The server1 data</returns>
        Task<dynamic> GetById(string id, string fields);

        /// <summary>Retrieves a list of server1s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of server1s</returns>
        Task<List<Server1>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new server1</summary>
        /// <param name="model">The server1 data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<string> Create(Server1 model);

        /// <summary>Updates a specific server1 by its primary key</summary>
        /// <param name="id">The primary key of the server1</param>
        /// <param name="updatedEntity">The server1 data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(string id, Server1 updatedEntity);

        /// <summary>Updates a specific server1 by its primary key</summary>
        /// <param name="id">The primary key of the server1</param>
        /// <param name="updatedEntity">The server1 data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(string id, JsonPatchDocument<Server1> updatedEntity);

        /// <summary>Deletes a specific server1 by its primary key</summary>
        /// <param name="id">The primary key of the server1</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(string id);
    }

    /// <summary>
    /// The server1Service responsible for managing server1 related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting server1 information.
    /// </remarks>
    public class Server1Service : IServer1Service
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the Server1 class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public Server1Service(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific server1 by its primary key</summary>
        /// <param name="id">The primary key of the server1</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The server1 data</returns>
        public async Task<dynamic> GetById(string id, string fields)
        {
            var query = _dbContext.Server1.AsQueryable();
            List<string> allfields = new List<string>();
            if (!string.IsNullOrEmpty(fields))
            {
                allfields.AddRange(fields.Split(","));
                fields = $"Id,{fields}";
            }
            else
            {
                fields = "Id";
            }

            string[] navigationProperties = [];
            foreach (var navigationProperty in navigationProperties)
            {
                if (allfields.Any(field => field.StartsWith(navigationProperty + ".", StringComparison.OrdinalIgnoreCase)))
                {
                    query = query.Include(navigationProperty);
                }
            }

            query = query.Where(entity => entity.Id == id);
            return _mapper.MapToFields(await query.FirstOrDefaultAsync(),fields);
        }

        /// <summary>Retrieves a list of server1s based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of server1s</returns>/// <exception cref="Exception"></exception>
        public async Task<List<Server1>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetServer1(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new server1</summary>
        /// <param name="model">The server1 data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<string> Create(Server1 model)
        {
            model.Id = await CreateServer1(model);
            return model.Id;
        }

        /// <summary>Updates a specific server1 by its primary key</summary>
        /// <param name="id">The primary key of the server1</param>
        /// <param name="updatedEntity">The server1 data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(string id, Server1 updatedEntity)
        {
            await UpdateServer1(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific server1 by its primary key</summary>
        /// <param name="id">The primary key of the server1</param>
        /// <param name="updatedEntity">The server1 data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(string id, JsonPatchDocument<Server1> updatedEntity)
        {
            await PatchServer1(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific server1 by its primary key</summary>
        /// <param name="id">The primary key of the server1</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(string id)
        {
            await DeleteServer1(id);
            return true;
        }
        #region
        private async Task<List<Server1>> GetServer1(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Server1.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Server1>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Server1), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Server1, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<string> CreateServer1(Server1 model)
        {
            _dbContext.Server1.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        private async Task UpdateServer1(string id, Server1 updatedEntity)
        {
            _dbContext.Server1.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteServer1(string id)
        {
            var entityData = _dbContext.Server1.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Server1.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchServer1(string id, JsonPatchDocument<Server1> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Server1.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Server1.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}