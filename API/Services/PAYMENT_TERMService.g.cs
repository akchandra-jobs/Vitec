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
    /// The payment_termService responsible for managing payment_term related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting payment_term information.
    /// </remarks>
    public interface IPAYMENT_TERMService
    {
        /// <summary>Retrieves a specific payment_term by its primary key</summary>
        /// <param name="id">The primary key of the payment_term</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The payment_term data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of payment_terms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of payment_terms</returns>
        Task<List<PAYMENT_TERM>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new payment_term</summary>
        /// <param name="model">The payment_term data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PAYMENT_TERM model);

        /// <summary>Updates a specific payment_term by its primary key</summary>
        /// <param name="id">The primary key of the payment_term</param>
        /// <param name="updatedEntity">The payment_term data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PAYMENT_TERM updatedEntity);

        /// <summary>Updates a specific payment_term by its primary key</summary>
        /// <param name="id">The primary key of the payment_term</param>
        /// <param name="updatedEntity">The payment_term data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PAYMENT_TERM> updatedEntity);

        /// <summary>Deletes a specific payment_term by its primary key</summary>
        /// <param name="id">The primary key of the payment_term</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The payment_termService responsible for managing payment_term related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting payment_term information.
    /// </remarks>
    public class PAYMENT_TERMService : IPAYMENT_TERMService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PAYMENT_TERM class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PAYMENT_TERMService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific payment_term by its primary key</summary>
        /// <param name="id">The primary key of the payment_term</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The payment_term data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PAYMENT_TERM.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of payment_terms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of payment_terms</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PAYMENT_TERM>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPAYMENT_TERM(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new payment_term</summary>
        /// <param name="model">The payment_term data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PAYMENT_TERM model)
        {
            model.GUID = await CreatePAYMENT_TERM(model);
            return model.GUID;
        }

        /// <summary>Updates a specific payment_term by its primary key</summary>
        /// <param name="id">The primary key of the payment_term</param>
        /// <param name="updatedEntity">The payment_term data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PAYMENT_TERM updatedEntity)
        {
            await UpdatePAYMENT_TERM(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific payment_term by its primary key</summary>
        /// <param name="id">The primary key of the payment_term</param>
        /// <param name="updatedEntity">The payment_term data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PAYMENT_TERM> updatedEntity)
        {
            await PatchPAYMENT_TERM(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific payment_term by its primary key</summary>
        /// <param name="id">The primary key of the payment_term</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePAYMENT_TERM(id);
            return true;
        }
        #region
        private async Task<List<PAYMENT_TERM>> GetPAYMENT_TERM(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PAYMENT_TERM.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PAYMENT_TERM>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PAYMENT_TERM), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PAYMENT_TERM, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePAYMENT_TERM(PAYMENT_TERM model)
        {
            _dbContext.PAYMENT_TERM.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePAYMENT_TERM(Guid id, PAYMENT_TERM updatedEntity)
        {
            _dbContext.PAYMENT_TERM.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePAYMENT_TERM(Guid id)
        {
            var entityData = _dbContext.PAYMENT_TERM.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PAYMENT_TERM.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPAYMENT_TERM(Guid id, JsonPatchDocument<PAYMENT_TERM> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PAYMENT_TERM.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PAYMENT_TERM.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}