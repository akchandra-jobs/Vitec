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
    /// The postal_codeService responsible for managing postal_code related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting postal_code information.
    /// </remarks>
    public interface IPOSTAL_CODEService
    {
        /// <summary>Retrieves a specific postal_code by its primary key</summary>
        /// <param name="id">The primary key of the postal_code</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The postal_code data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of postal_codes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of postal_codes</returns>
        Task<List<POSTAL_CODE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new postal_code</summary>
        /// <param name="model">The postal_code data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(POSTAL_CODE model);

        /// <summary>Updates a specific postal_code by its primary key</summary>
        /// <param name="id">The primary key of the postal_code</param>
        /// <param name="updatedEntity">The postal_code data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, POSTAL_CODE updatedEntity);

        /// <summary>Updates a specific postal_code by its primary key</summary>
        /// <param name="id">The primary key of the postal_code</param>
        /// <param name="updatedEntity">The postal_code data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<POSTAL_CODE> updatedEntity);

        /// <summary>Deletes a specific postal_code by its primary key</summary>
        /// <param name="id">The primary key of the postal_code</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The postal_codeService responsible for managing postal_code related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting postal_code information.
    /// </remarks>
    public class POSTAL_CODEService : IPOSTAL_CODEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the POSTAL_CODE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public POSTAL_CODEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific postal_code by its primary key</summary>
        /// <param name="id">The primary key of the postal_code</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The postal_code data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.POSTAL_CODE.AsQueryable();
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

        /// <summary>Retrieves a list of postal_codes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of postal_codes</returns>/// <exception cref="Exception"></exception>
        public async Task<List<POSTAL_CODE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPOSTAL_CODE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new postal_code</summary>
        /// <param name="model">The postal_code data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(POSTAL_CODE model)
        {
            model.GUID = await CreatePOSTAL_CODE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific postal_code by its primary key</summary>
        /// <param name="id">The primary key of the postal_code</param>
        /// <param name="updatedEntity">The postal_code data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, POSTAL_CODE updatedEntity)
        {
            await UpdatePOSTAL_CODE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific postal_code by its primary key</summary>
        /// <param name="id">The primary key of the postal_code</param>
        /// <param name="updatedEntity">The postal_code data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<POSTAL_CODE> updatedEntity)
        {
            await PatchPOSTAL_CODE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific postal_code by its primary key</summary>
        /// <param name="id">The primary key of the postal_code</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePOSTAL_CODE(id);
            return true;
        }
        #region
        private async Task<List<POSTAL_CODE>> GetPOSTAL_CODE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.POSTAL_CODE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<POSTAL_CODE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(POSTAL_CODE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<POSTAL_CODE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePOSTAL_CODE(POSTAL_CODE model)
        {
            _dbContext.POSTAL_CODE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePOSTAL_CODE(Guid id, POSTAL_CODE updatedEntity)
        {
            _dbContext.POSTAL_CODE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePOSTAL_CODE(Guid id)
        {
            var entityData = _dbContext.POSTAL_CODE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.POSTAL_CODE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPOSTAL_CODE(Guid id, JsonPatchDocument<POSTAL_CODE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.POSTAL_CODE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.POSTAL_CODE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}