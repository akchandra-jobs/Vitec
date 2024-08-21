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
    /// The email_templateService responsible for managing email_template related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting email_template information.
    /// </remarks>
    public interface IEMAIL_TEMPLATEService
    {
        /// <summary>Retrieves a specific email_template by its primary key</summary>
        /// <param name="id">The primary key of the email_template</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The email_template data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of email_templates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of email_templates</returns>
        Task<List<EMAIL_TEMPLATE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new email_template</summary>
        /// <param name="model">The email_template data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(EMAIL_TEMPLATE model);

        /// <summary>Updates a specific email_template by its primary key</summary>
        /// <param name="id">The primary key of the email_template</param>
        /// <param name="updatedEntity">The email_template data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, EMAIL_TEMPLATE updatedEntity);

        /// <summary>Updates a specific email_template by its primary key</summary>
        /// <param name="id">The primary key of the email_template</param>
        /// <param name="updatedEntity">The email_template data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<EMAIL_TEMPLATE> updatedEntity);

        /// <summary>Deletes a specific email_template by its primary key</summary>
        /// <param name="id">The primary key of the email_template</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The email_templateService responsible for managing email_template related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting email_template information.
    /// </remarks>
    public class EMAIL_TEMPLATEService : IEMAIL_TEMPLATEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the EMAIL_TEMPLATE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public EMAIL_TEMPLATEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific email_template by its primary key</summary>
        /// <param name="id">The primary key of the email_template</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The email_template data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.EMAIL_TEMPLATE.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER"];
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

        /// <summary>Retrieves a list of email_templates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of email_templates</returns>/// <exception cref="Exception"></exception>
        public async Task<List<EMAIL_TEMPLATE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetEMAIL_TEMPLATE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new email_template</summary>
        /// <param name="model">The email_template data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(EMAIL_TEMPLATE model)
        {
            model.GUID = await CreateEMAIL_TEMPLATE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific email_template by its primary key</summary>
        /// <param name="id">The primary key of the email_template</param>
        /// <param name="updatedEntity">The email_template data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, EMAIL_TEMPLATE updatedEntity)
        {
            await UpdateEMAIL_TEMPLATE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific email_template by its primary key</summary>
        /// <param name="id">The primary key of the email_template</param>
        /// <param name="updatedEntity">The email_template data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<EMAIL_TEMPLATE> updatedEntity)
        {
            await PatchEMAIL_TEMPLATE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific email_template by its primary key</summary>
        /// <param name="id">The primary key of the email_template</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteEMAIL_TEMPLATE(id);
            return true;
        }
        #region
        private async Task<List<EMAIL_TEMPLATE>> GetEMAIL_TEMPLATE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EMAIL_TEMPLATE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EMAIL_TEMPLATE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EMAIL_TEMPLATE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EMAIL_TEMPLATE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateEMAIL_TEMPLATE(EMAIL_TEMPLATE model)
        {
            _dbContext.EMAIL_TEMPLATE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateEMAIL_TEMPLATE(Guid id, EMAIL_TEMPLATE updatedEntity)
        {
            _dbContext.EMAIL_TEMPLATE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteEMAIL_TEMPLATE(Guid id)
        {
            var entityData = _dbContext.EMAIL_TEMPLATE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EMAIL_TEMPLATE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchEMAIL_TEMPLATE(Guid id, JsonPatchDocument<EMAIL_TEMPLATE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EMAIL_TEMPLATE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EMAIL_TEMPLATE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}