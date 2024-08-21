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
    /// The customer_line_of_businessService responsible for managing customer_line_of_business related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting customer_line_of_business information.
    /// </remarks>
    public interface ICUSTOMER_LINE_OF_BUSINESSService
    {
        /// <summary>Retrieves a specific customer_line_of_business by its primary key</summary>
        /// <param name="id">The primary key of the customer_line_of_business</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The customer_line_of_business data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of customer_line_of_businesss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of customer_line_of_businesss</returns>
        Task<List<CUSTOMER_LINE_OF_BUSINESS>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new customer_line_of_business</summary>
        /// <param name="model">The customer_line_of_business data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(CUSTOMER_LINE_OF_BUSINESS model);

        /// <summary>Updates a specific customer_line_of_business by its primary key</summary>
        /// <param name="id">The primary key of the customer_line_of_business</param>
        /// <param name="updatedEntity">The customer_line_of_business data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, CUSTOMER_LINE_OF_BUSINESS updatedEntity);

        /// <summary>Updates a specific customer_line_of_business by its primary key</summary>
        /// <param name="id">The primary key of the customer_line_of_business</param>
        /// <param name="updatedEntity">The customer_line_of_business data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<CUSTOMER_LINE_OF_BUSINESS> updatedEntity);

        /// <summary>Deletes a specific customer_line_of_business by its primary key</summary>
        /// <param name="id">The primary key of the customer_line_of_business</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The customer_line_of_businessService responsible for managing customer_line_of_business related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting customer_line_of_business information.
    /// </remarks>
    public class CUSTOMER_LINE_OF_BUSINESSService : ICUSTOMER_LINE_OF_BUSINESSService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the CUSTOMER_LINE_OF_BUSINESS class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public CUSTOMER_LINE_OF_BUSINESSService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific customer_line_of_business by its primary key</summary>
        /// <param name="id">The primary key of the customer_line_of_business</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The customer_line_of_business data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.CUSTOMER_LINE_OF_BUSINESS.AsQueryable();
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

        /// <summary>Retrieves a list of customer_line_of_businesss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of customer_line_of_businesss</returns>/// <exception cref="Exception"></exception>
        public async Task<List<CUSTOMER_LINE_OF_BUSINESS>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetCUSTOMER_LINE_OF_BUSINESS(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new customer_line_of_business</summary>
        /// <param name="model">The customer_line_of_business data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(CUSTOMER_LINE_OF_BUSINESS model)
        {
            model.GUID = await CreateCUSTOMER_LINE_OF_BUSINESS(model);
            return model.GUID;
        }

        /// <summary>Updates a specific customer_line_of_business by its primary key</summary>
        /// <param name="id">The primary key of the customer_line_of_business</param>
        /// <param name="updatedEntity">The customer_line_of_business data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, CUSTOMER_LINE_OF_BUSINESS updatedEntity)
        {
            await UpdateCUSTOMER_LINE_OF_BUSINESS(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific customer_line_of_business by its primary key</summary>
        /// <param name="id">The primary key of the customer_line_of_business</param>
        /// <param name="updatedEntity">The customer_line_of_business data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<CUSTOMER_LINE_OF_BUSINESS> updatedEntity)
        {
            await PatchCUSTOMER_LINE_OF_BUSINESS(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific customer_line_of_business by its primary key</summary>
        /// <param name="id">The primary key of the customer_line_of_business</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteCUSTOMER_LINE_OF_BUSINESS(id);
            return true;
        }
        #region
        private async Task<List<CUSTOMER_LINE_OF_BUSINESS>> GetCUSTOMER_LINE_OF_BUSINESS(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CUSTOMER_LINE_OF_BUSINESS.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CUSTOMER_LINE_OF_BUSINESS>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CUSTOMER_LINE_OF_BUSINESS), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CUSTOMER_LINE_OF_BUSINESS, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateCUSTOMER_LINE_OF_BUSINESS(CUSTOMER_LINE_OF_BUSINESS model)
        {
            _dbContext.CUSTOMER_LINE_OF_BUSINESS.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateCUSTOMER_LINE_OF_BUSINESS(Guid id, CUSTOMER_LINE_OF_BUSINESS updatedEntity)
        {
            _dbContext.CUSTOMER_LINE_OF_BUSINESS.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteCUSTOMER_LINE_OF_BUSINESS(Guid id)
        {
            var entityData = _dbContext.CUSTOMER_LINE_OF_BUSINESS.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CUSTOMER_LINE_OF_BUSINESS.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchCUSTOMER_LINE_OF_BUSINESS(Guid id, JsonPatchDocument<CUSTOMER_LINE_OF_BUSINESS> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CUSTOMER_LINE_OF_BUSINESS.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CUSTOMER_LINE_OF_BUSINESS.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}