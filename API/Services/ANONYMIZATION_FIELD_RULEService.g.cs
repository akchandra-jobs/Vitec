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
    /// The anonymization_field_ruleService responsible for managing anonymization_field_rule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting anonymization_field_rule information.
    /// </remarks>
    public interface IANONYMIZATION_FIELD_RULEService
    {
        /// <summary>Retrieves a specific anonymization_field_rule by its primary key</summary>
        /// <param name="id">The primary key of the anonymization_field_rule</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The anonymization_field_rule data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of anonymization_field_rules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of anonymization_field_rules</returns>
        Task<List<ANONYMIZATION_FIELD_RULE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new anonymization_field_rule</summary>
        /// <param name="model">The anonymization_field_rule data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(ANONYMIZATION_FIELD_RULE model);

        /// <summary>Updates a specific anonymization_field_rule by its primary key</summary>
        /// <param name="id">The primary key of the anonymization_field_rule</param>
        /// <param name="updatedEntity">The anonymization_field_rule data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, ANONYMIZATION_FIELD_RULE updatedEntity);

        /// <summary>Updates a specific anonymization_field_rule by its primary key</summary>
        /// <param name="id">The primary key of the anonymization_field_rule</param>
        /// <param name="updatedEntity">The anonymization_field_rule data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<ANONYMIZATION_FIELD_RULE> updatedEntity);

        /// <summary>Deletes a specific anonymization_field_rule by its primary key</summary>
        /// <param name="id">The primary key of the anonymization_field_rule</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The anonymization_field_ruleService responsible for managing anonymization_field_rule related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting anonymization_field_rule information.
    /// </remarks>
    public class ANONYMIZATION_FIELD_RULEService : IANONYMIZATION_FIELD_RULEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the ANONYMIZATION_FIELD_RULE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ANONYMIZATION_FIELD_RULEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific anonymization_field_rule by its primary key</summary>
        /// <param name="id">The primary key of the anonymization_field_rule</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The anonymization_field_rule data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.ANONYMIZATION_FIELD_RULE.AsQueryable();
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

            string[] navigationProperties = ["GUID_REGISTERED_FIELD_REGISTERED_FIELD","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of anonymization_field_rules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of anonymization_field_rules</returns>/// <exception cref="Exception"></exception>
        public async Task<List<ANONYMIZATION_FIELD_RULE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetANONYMIZATION_FIELD_RULE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new anonymization_field_rule</summary>
        /// <param name="model">The anonymization_field_rule data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(ANONYMIZATION_FIELD_RULE model)
        {
            model.GUID = await CreateANONYMIZATION_FIELD_RULE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific anonymization_field_rule by its primary key</summary>
        /// <param name="id">The primary key of the anonymization_field_rule</param>
        /// <param name="updatedEntity">The anonymization_field_rule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, ANONYMIZATION_FIELD_RULE updatedEntity)
        {
            await UpdateANONYMIZATION_FIELD_RULE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific anonymization_field_rule by its primary key</summary>
        /// <param name="id">The primary key of the anonymization_field_rule</param>
        /// <param name="updatedEntity">The anonymization_field_rule data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<ANONYMIZATION_FIELD_RULE> updatedEntity)
        {
            await PatchANONYMIZATION_FIELD_RULE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific anonymization_field_rule by its primary key</summary>
        /// <param name="id">The primary key of the anonymization_field_rule</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteANONYMIZATION_FIELD_RULE(id);
            return true;
        }
        #region
        private async Task<List<ANONYMIZATION_FIELD_RULE>> GetANONYMIZATION_FIELD_RULE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ANONYMIZATION_FIELD_RULE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ANONYMIZATION_FIELD_RULE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ANONYMIZATION_FIELD_RULE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ANONYMIZATION_FIELD_RULE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateANONYMIZATION_FIELD_RULE(ANONYMIZATION_FIELD_RULE model)
        {
            _dbContext.ANONYMIZATION_FIELD_RULE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateANONYMIZATION_FIELD_RULE(Guid id, ANONYMIZATION_FIELD_RULE updatedEntity)
        {
            _dbContext.ANONYMIZATION_FIELD_RULE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteANONYMIZATION_FIELD_RULE(Guid id)
        {
            var entityData = _dbContext.ANONYMIZATION_FIELD_RULE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ANONYMIZATION_FIELD_RULE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchANONYMIZATION_FIELD_RULE(Guid id, JsonPatchDocument<ANONYMIZATION_FIELD_RULE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ANONYMIZATION_FIELD_RULE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ANONYMIZATION_FIELD_RULE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}