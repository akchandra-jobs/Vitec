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
    /// The data_importService responsible for managing data_import related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting data_import information.
    /// </remarks>
    public interface IDATA_IMPORTService
    {
        /// <summary>Retrieves a specific data_import by its primary key</summary>
        /// <param name="id">The primary key of the data_import</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The data_import data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of data_imports based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of data_imports</returns>
        Task<List<DATA_IMPORT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new data_import</summary>
        /// <param name="model">The data_import data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(DATA_IMPORT model);

        /// <summary>Updates a specific data_import by its primary key</summary>
        /// <param name="id">The primary key of the data_import</param>
        /// <param name="updatedEntity">The data_import data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, DATA_IMPORT updatedEntity);

        /// <summary>Updates a specific data_import by its primary key</summary>
        /// <param name="id">The primary key of the data_import</param>
        /// <param name="updatedEntity">The data_import data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<DATA_IMPORT> updatedEntity);

        /// <summary>Deletes a specific data_import by its primary key</summary>
        /// <param name="id">The primary key of the data_import</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The data_importService responsible for managing data_import related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting data_import information.
    /// </remarks>
    public class DATA_IMPORTService : IDATA_IMPORTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the DATA_IMPORT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public DATA_IMPORTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific data_import by its primary key</summary>
        /// <param name="id">The primary key of the data_import</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The data_import data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.DATA_IMPORT.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_BINARY_DATA_BINARY_DATA","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of data_imports based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of data_imports</returns>/// <exception cref="Exception"></exception>
        public async Task<List<DATA_IMPORT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetDATA_IMPORT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new data_import</summary>
        /// <param name="model">The data_import data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(DATA_IMPORT model)
        {
            model.GUID = await CreateDATA_IMPORT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific data_import by its primary key</summary>
        /// <param name="id">The primary key of the data_import</param>
        /// <param name="updatedEntity">The data_import data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, DATA_IMPORT updatedEntity)
        {
            await UpdateDATA_IMPORT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific data_import by its primary key</summary>
        /// <param name="id">The primary key of the data_import</param>
        /// <param name="updatedEntity">The data_import data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<DATA_IMPORT> updatedEntity)
        {
            await PatchDATA_IMPORT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific data_import by its primary key</summary>
        /// <param name="id">The primary key of the data_import</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteDATA_IMPORT(id);
            return true;
        }
        #region
        private async Task<List<DATA_IMPORT>> GetDATA_IMPORT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DATA_IMPORT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DATA_IMPORT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DATA_IMPORT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DATA_IMPORT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateDATA_IMPORT(DATA_IMPORT model)
        {
            _dbContext.DATA_IMPORT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateDATA_IMPORT(Guid id, DATA_IMPORT updatedEntity)
        {
            _dbContext.DATA_IMPORT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteDATA_IMPORT(Guid id)
        {
            var entityData = _dbContext.DATA_IMPORT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DATA_IMPORT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchDATA_IMPORT(Guid id, JsonPatchDocument<DATA_IMPORT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DATA_IMPORT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DATA_IMPORT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}