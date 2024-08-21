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
    /// The external_login_providerService responsible for managing external_login_provider related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting external_login_provider information.
    /// </remarks>
    public interface IEXTERNAL_LOGIN_PROVIDERService
    {
        /// <summary>Retrieves a specific external_login_provider by its primary key</summary>
        /// <param name="id">The primary key of the external_login_provider</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The external_login_provider data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of external_login_providers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of external_login_providers</returns>
        Task<List<EXTERNAL_LOGIN_PROVIDER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new external_login_provider</summary>
        /// <param name="model">The external_login_provider data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(EXTERNAL_LOGIN_PROVIDER model);

        /// <summary>Updates a specific external_login_provider by its primary key</summary>
        /// <param name="id">The primary key of the external_login_provider</param>
        /// <param name="updatedEntity">The external_login_provider data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, EXTERNAL_LOGIN_PROVIDER updatedEntity);

        /// <summary>Updates a specific external_login_provider by its primary key</summary>
        /// <param name="id">The primary key of the external_login_provider</param>
        /// <param name="updatedEntity">The external_login_provider data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<EXTERNAL_LOGIN_PROVIDER> updatedEntity);

        /// <summary>Deletes a specific external_login_provider by its primary key</summary>
        /// <param name="id">The primary key of the external_login_provider</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The external_login_providerService responsible for managing external_login_provider related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting external_login_provider information.
    /// </remarks>
    public class EXTERNAL_LOGIN_PROVIDERService : IEXTERNAL_LOGIN_PROVIDERService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the EXTERNAL_LOGIN_PROVIDER class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public EXTERNAL_LOGIN_PROVIDERService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific external_login_provider by its primary key</summary>
        /// <param name="id">The primary key of the external_login_provider</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The external_login_provider data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.EXTERNAL_LOGIN_PROVIDER.AsQueryable();
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

        /// <summary>Retrieves a list of external_login_providers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of external_login_providers</returns>/// <exception cref="Exception"></exception>
        public async Task<List<EXTERNAL_LOGIN_PROVIDER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetEXTERNAL_LOGIN_PROVIDER(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new external_login_provider</summary>
        /// <param name="model">The external_login_provider data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(EXTERNAL_LOGIN_PROVIDER model)
        {
            model.GUID = await CreateEXTERNAL_LOGIN_PROVIDER(model);
            return model.GUID;
        }

        /// <summary>Updates a specific external_login_provider by its primary key</summary>
        /// <param name="id">The primary key of the external_login_provider</param>
        /// <param name="updatedEntity">The external_login_provider data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, EXTERNAL_LOGIN_PROVIDER updatedEntity)
        {
            await UpdateEXTERNAL_LOGIN_PROVIDER(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific external_login_provider by its primary key</summary>
        /// <param name="id">The primary key of the external_login_provider</param>
        /// <param name="updatedEntity">The external_login_provider data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<EXTERNAL_LOGIN_PROVIDER> updatedEntity)
        {
            await PatchEXTERNAL_LOGIN_PROVIDER(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific external_login_provider by its primary key</summary>
        /// <param name="id">The primary key of the external_login_provider</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteEXTERNAL_LOGIN_PROVIDER(id);
            return true;
        }
        #region
        private async Task<List<EXTERNAL_LOGIN_PROVIDER>> GetEXTERNAL_LOGIN_PROVIDER(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EXTERNAL_LOGIN_PROVIDER.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EXTERNAL_LOGIN_PROVIDER>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EXTERNAL_LOGIN_PROVIDER), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EXTERNAL_LOGIN_PROVIDER, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateEXTERNAL_LOGIN_PROVIDER(EXTERNAL_LOGIN_PROVIDER model)
        {
            _dbContext.EXTERNAL_LOGIN_PROVIDER.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateEXTERNAL_LOGIN_PROVIDER(Guid id, EXTERNAL_LOGIN_PROVIDER updatedEntity)
        {
            _dbContext.EXTERNAL_LOGIN_PROVIDER.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteEXTERNAL_LOGIN_PROVIDER(Guid id)
        {
            var entityData = _dbContext.EXTERNAL_LOGIN_PROVIDER.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EXTERNAL_LOGIN_PROVIDER.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchEXTERNAL_LOGIN_PROVIDER(Guid id, JsonPatchDocument<EXTERNAL_LOGIN_PROVIDER> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EXTERNAL_LOGIN_PROVIDER.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EXTERNAL_LOGIN_PROVIDER.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}