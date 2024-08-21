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
    /// The supplier_agreementService responsible for managing supplier_agreement related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting supplier_agreement information.
    /// </remarks>
    public interface ISUPPLIER_AGREEMENTService
    {
        /// <summary>Retrieves a specific supplier_agreement by its primary key</summary>
        /// <param name="id">The primary key of the supplier_agreement</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The supplier_agreement data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of supplier_agreements based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of supplier_agreements</returns>
        Task<List<SUPPLIER_AGREEMENT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new supplier_agreement</summary>
        /// <param name="model">The supplier_agreement data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(SUPPLIER_AGREEMENT model);

        /// <summary>Updates a specific supplier_agreement by its primary key</summary>
        /// <param name="id">The primary key of the supplier_agreement</param>
        /// <param name="updatedEntity">The supplier_agreement data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, SUPPLIER_AGREEMENT updatedEntity);

        /// <summary>Updates a specific supplier_agreement by its primary key</summary>
        /// <param name="id">The primary key of the supplier_agreement</param>
        /// <param name="updatedEntity">The supplier_agreement data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<SUPPLIER_AGREEMENT> updatedEntity);

        /// <summary>Deletes a specific supplier_agreement by its primary key</summary>
        /// <param name="id">The primary key of the supplier_agreement</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The supplier_agreementService responsible for managing supplier_agreement related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting supplier_agreement information.
    /// </remarks>
    public class SUPPLIER_AGREEMENTService : ISUPPLIER_AGREEMENTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the SUPPLIER_AGREEMENT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public SUPPLIER_AGREEMENTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific supplier_agreement by its primary key</summary>
        /// <param name="id">The primary key of the supplier_agreement</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The supplier_agreement data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.SUPPLIER_AGREEMENT.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_SUPPLIER_SUPPLIER","GUID_PAYMENT_TERM_PAYMENT_TERM"];
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

        /// <summary>Retrieves a list of supplier_agreements based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of supplier_agreements</returns>/// <exception cref="Exception"></exception>
        public async Task<List<SUPPLIER_AGREEMENT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetSUPPLIER_AGREEMENT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new supplier_agreement</summary>
        /// <param name="model">The supplier_agreement data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(SUPPLIER_AGREEMENT model)
        {
            model.GUID = await CreateSUPPLIER_AGREEMENT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific supplier_agreement by its primary key</summary>
        /// <param name="id">The primary key of the supplier_agreement</param>
        /// <param name="updatedEntity">The supplier_agreement data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, SUPPLIER_AGREEMENT updatedEntity)
        {
            await UpdateSUPPLIER_AGREEMENT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific supplier_agreement by its primary key</summary>
        /// <param name="id">The primary key of the supplier_agreement</param>
        /// <param name="updatedEntity">The supplier_agreement data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<SUPPLIER_AGREEMENT> updatedEntity)
        {
            await PatchSUPPLIER_AGREEMENT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific supplier_agreement by its primary key</summary>
        /// <param name="id">The primary key of the supplier_agreement</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteSUPPLIER_AGREEMENT(id);
            return true;
        }
        #region
        private async Task<List<SUPPLIER_AGREEMENT>> GetSUPPLIER_AGREEMENT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SUPPLIER_AGREEMENT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SUPPLIER_AGREEMENT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SUPPLIER_AGREEMENT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SUPPLIER_AGREEMENT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateSUPPLIER_AGREEMENT(SUPPLIER_AGREEMENT model)
        {
            _dbContext.SUPPLIER_AGREEMENT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateSUPPLIER_AGREEMENT(Guid id, SUPPLIER_AGREEMENT updatedEntity)
        {
            _dbContext.SUPPLIER_AGREEMENT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteSUPPLIER_AGREEMENT(Guid id)
        {
            var entityData = _dbContext.SUPPLIER_AGREEMENT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SUPPLIER_AGREEMENT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchSUPPLIER_AGREEMENT(Guid id, JsonPatchDocument<SUPPLIER_AGREEMENT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SUPPLIER_AGREEMENT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SUPPLIER_AGREEMENT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}