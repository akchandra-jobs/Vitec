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
    /// The registered_fieldService responsible for managing registered_field related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting registered_field information.
    /// </remarks>
    public interface IREGISTERED_FIELDService
    {
        /// <summary>Retrieves a specific registered_field by its primary key</summary>
        /// <param name="id">The primary key of the registered_field</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The registered_field data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of registered_fields based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of registered_fields</returns>
        Task<List<REGISTERED_FIELD>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new registered_field</summary>
        /// <param name="model">The registered_field data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(REGISTERED_FIELD model);

        /// <summary>Updates a specific registered_field by its primary key</summary>
        /// <param name="id">The primary key of the registered_field</param>
        /// <param name="updatedEntity">The registered_field data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, REGISTERED_FIELD updatedEntity);

        /// <summary>Updates a specific registered_field by its primary key</summary>
        /// <param name="id">The primary key of the registered_field</param>
        /// <param name="updatedEntity">The registered_field data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<REGISTERED_FIELD> updatedEntity);

        /// <summary>Deletes a specific registered_field by its primary key</summary>
        /// <param name="id">The primary key of the registered_field</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The registered_fieldService responsible for managing registered_field related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting registered_field information.
    /// </remarks>
    public class REGISTERED_FIELDService : IREGISTERED_FIELDService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the REGISTERED_FIELD class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public REGISTERED_FIELDService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific registered_field by its primary key</summary>
        /// <param name="id">The primary key of the registered_field</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The registered_field data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.REGISTERED_FIELD.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of registered_fields based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of registered_fields</returns>/// <exception cref="Exception"></exception>
        public async Task<List<REGISTERED_FIELD>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetREGISTERED_FIELD(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new registered_field</summary>
        /// <param name="model">The registered_field data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(REGISTERED_FIELD model)
        {
            model.GUID = await CreateREGISTERED_FIELD(model);
            return model.GUID;
        }

        /// <summary>Updates a specific registered_field by its primary key</summary>
        /// <param name="id">The primary key of the registered_field</param>
        /// <param name="updatedEntity">The registered_field data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, REGISTERED_FIELD updatedEntity)
        {
            await UpdateREGISTERED_FIELD(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific registered_field by its primary key</summary>
        /// <param name="id">The primary key of the registered_field</param>
        /// <param name="updatedEntity">The registered_field data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<REGISTERED_FIELD> updatedEntity)
        {
            await PatchREGISTERED_FIELD(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific registered_field by its primary key</summary>
        /// <param name="id">The primary key of the registered_field</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteREGISTERED_FIELD(id);
            return true;
        }
        #region
        private async Task<List<REGISTERED_FIELD>> GetREGISTERED_FIELD(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.REGISTERED_FIELD.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<REGISTERED_FIELD>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(REGISTERED_FIELD), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<REGISTERED_FIELD, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateREGISTERED_FIELD(REGISTERED_FIELD model)
        {
            _dbContext.REGISTERED_FIELD.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateREGISTERED_FIELD(Guid id, REGISTERED_FIELD updatedEntity)
        {
            _dbContext.REGISTERED_FIELD.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteREGISTERED_FIELD(Guid id)
        {
            var entityData = _dbContext.REGISTERED_FIELD.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.REGISTERED_FIELD.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchREGISTERED_FIELD(Guid id, JsonPatchDocument<REGISTERED_FIELD> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.REGISTERED_FIELD.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.REGISTERED_FIELD.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}