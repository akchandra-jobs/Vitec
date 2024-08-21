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
    /// The general_optionsService responsible for managing general_options related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting general_options information.
    /// </remarks>
    public interface IGENERAL_OPTIONSService
    {
        /// <summary>Retrieves a specific general_options by its primary key</summary>
        /// <param name="id">The primary key of the general_options</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The general_options data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of general_optionss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of general_optionss</returns>
        Task<List<GENERAL_OPTIONS>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new general_options</summary>
        /// <param name="model">The general_options data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(GENERAL_OPTIONS model);

        /// <summary>Updates a specific general_options by its primary key</summary>
        /// <param name="id">The primary key of the general_options</param>
        /// <param name="updatedEntity">The general_options data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, GENERAL_OPTIONS updatedEntity);

        /// <summary>Updates a specific general_options by its primary key</summary>
        /// <param name="id">The primary key of the general_options</param>
        /// <param name="updatedEntity">The general_options data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<GENERAL_OPTIONS> updatedEntity);

        /// <summary>Deletes a specific general_options by its primary key</summary>
        /// <param name="id">The primary key of the general_options</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The general_optionsService responsible for managing general_options related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting general_options information.
    /// </remarks>
    public class GENERAL_OPTIONSService : IGENERAL_OPTIONSService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the GENERAL_OPTIONS class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public GENERAL_OPTIONSService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific general_options by its primary key</summary>
        /// <param name="id">The primary key of the general_options</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The general_options data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.GENERAL_OPTIONS.AsQueryable();
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

            string[] navigationProperties = ["GUID_IMAGE_BACKGROUND_IMAGE","GUID_IMAGE_LOGO_IMAGE","GUID_DOCUMENT_TERMS_OF_USE_DOCUMENT","GUID_SYSTEM_OWNER_USR","GUID_DEFAULT_INVOICING_INVOICING","GUID_DEFAULT_PAYMENT_TERM_PAYMENT_TERM","GUID_DEFAULT_PAYMENT_ORDER_FORM_PAYMENT_ORDER_FORM","GUID_USER_GROUP_FOR_NEW_USERS_USR","GUID_COMMON_DATA_OWNER_DATA_OWNER","GUID_CAUSE_NOT_EXECUTED_CAUSE","GUID_DEFAULT_ORDER_FORM_PURCHASE_ORDER_FORM","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of general_optionss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of general_optionss</returns>/// <exception cref="Exception"></exception>
        public async Task<List<GENERAL_OPTIONS>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetGENERAL_OPTIONS(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new general_options</summary>
        /// <param name="model">The general_options data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(GENERAL_OPTIONS model)
        {
            model.GUID = await CreateGENERAL_OPTIONS(model);
            return model.GUID;
        }

        /// <summary>Updates a specific general_options by its primary key</summary>
        /// <param name="id">The primary key of the general_options</param>
        /// <param name="updatedEntity">The general_options data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, GENERAL_OPTIONS updatedEntity)
        {
            await UpdateGENERAL_OPTIONS(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific general_options by its primary key</summary>
        /// <param name="id">The primary key of the general_options</param>
        /// <param name="updatedEntity">The general_options data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<GENERAL_OPTIONS> updatedEntity)
        {
            await PatchGENERAL_OPTIONS(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific general_options by its primary key</summary>
        /// <param name="id">The primary key of the general_options</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteGENERAL_OPTIONS(id);
            return true;
        }
        #region
        private async Task<List<GENERAL_OPTIONS>> GetGENERAL_OPTIONS(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.GENERAL_OPTIONS.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<GENERAL_OPTIONS>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(GENERAL_OPTIONS), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<GENERAL_OPTIONS, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateGENERAL_OPTIONS(GENERAL_OPTIONS model)
        {
            _dbContext.GENERAL_OPTIONS.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateGENERAL_OPTIONS(Guid id, GENERAL_OPTIONS updatedEntity)
        {
            _dbContext.GENERAL_OPTIONS.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteGENERAL_OPTIONS(Guid id)
        {
            var entityData = _dbContext.GENERAL_OPTIONS.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.GENERAL_OPTIONS.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchGENERAL_OPTIONS(Guid id, JsonPatchDocument<GENERAL_OPTIONS> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.GENERAL_OPTIONS.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.GENERAL_OPTIONS.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}