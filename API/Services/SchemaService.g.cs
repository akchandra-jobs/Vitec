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
    /// The schemaService responsible for managing schema related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting schema information.
    /// </remarks>
    public interface ISchemaService
    {
        /// <summary>Retrieves a specific schema by its primary key</summary>
        /// <param name="id">The primary key of the schema</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The schema data</returns>
        Task<dynamic> GetById(int id, string fields);

        /// <summary>Retrieves a list of schemas based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of schemas</returns>
        Task<List<Schema>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new schema</summary>
        /// <param name="model">The schema data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<int> Create(Schema model);

        /// <summary>Updates a specific schema by its primary key</summary>
        /// <param name="id">The primary key of the schema</param>
        /// <param name="updatedEntity">The schema data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(int id, Schema updatedEntity);

        /// <summary>Updates a specific schema by its primary key</summary>
        /// <param name="id">The primary key of the schema</param>
        /// <param name="updatedEntity">The schema data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(int id, JsonPatchDocument<Schema> updatedEntity);

        /// <summary>Deletes a specific schema by its primary key</summary>
        /// <param name="id">The primary key of the schema</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(int id);
    }

    /// <summary>
    /// The schemaService responsible for managing schema related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting schema information.
    /// </remarks>
    public class SchemaService : ISchemaService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the Schema class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public SchemaService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific schema by its primary key</summary>
        /// <param name="id">The primary key of the schema</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The schema data</returns>
        public async Task<dynamic> GetById(int id, string fields)
        {
            var query = _dbContext.Schema.AsQueryable();
            List<string> allfields = new List<string>();
            if (!string.IsNullOrEmpty(fields))
            {
                allfields.AddRange(fields.Split(","));
                fields = $"Version,{fields}";
            }
            else
            {
                fields = "Version";
            }

            string[] navigationProperties = [];
            foreach (var navigationProperty in navigationProperties)
            {
                if (allfields.Any(field => field.StartsWith(navigationProperty + ".", StringComparison.OrdinalIgnoreCase)))
                {
                    query = query.Include(navigationProperty);
                }
            }

            query = query.Where(entity => entity.Version == id);
            return _mapper.MapToFields(await query.FirstOrDefaultAsync(),fields);
        }

        /// <summary>Retrieves a list of schemas based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of schemas</returns>/// <exception cref="Exception"></exception>
        public async Task<List<Schema>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetSchema(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new schema</summary>
        /// <param name="model">The schema data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<int> Create(Schema model)
        {
            model.Version = await CreateSchema(model);
            return model.Version;
        }

        /// <summary>Updates a specific schema by its primary key</summary>
        /// <param name="id">The primary key of the schema</param>
        /// <param name="updatedEntity">The schema data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(int id, Schema updatedEntity)
        {
            await UpdateSchema(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific schema by its primary key</summary>
        /// <param name="id">The primary key of the schema</param>
        /// <param name="updatedEntity">The schema data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(int id, JsonPatchDocument<Schema> updatedEntity)
        {
            await PatchSchema(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific schema by its primary key</summary>
        /// <param name="id">The primary key of the schema</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(int id)
        {
            await DeleteSchema(id);
            return true;
        }
        #region
        private async Task<List<Schema>> GetSchema(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Schema.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Schema>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Schema), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Schema, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<int> CreateSchema(Schema model)
        {
            _dbContext.Schema.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Version;
        }

        private async Task UpdateSchema(int id, Schema updatedEntity)
        {
            _dbContext.Schema.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteSchema(int id)
        {
            var entityData = _dbContext.Schema.FirstOrDefault(entity => entity.Version == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Schema.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchSchema(int id, JsonPatchDocument<Schema> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Schema.FirstOrDefault(t => t.Version == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Schema.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}