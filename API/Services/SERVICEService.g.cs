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
    /// The serviceService responsible for managing service related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting service information.
    /// </remarks>
    public interface ISERVICEService
    {
        /// <summary>Retrieves a specific service by its primary key</summary>
        /// <param name="id">The primary key of the service</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The service data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of services based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of services</returns>
        Task<List<SERVICE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new service</summary>
        /// <param name="model">The service data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(SERVICE model);

        /// <summary>Updates a specific service by its primary key</summary>
        /// <param name="id">The primary key of the service</param>
        /// <param name="updatedEntity">The service data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, SERVICE updatedEntity);

        /// <summary>Updates a specific service by its primary key</summary>
        /// <param name="id">The primary key of the service</param>
        /// <param name="updatedEntity">The service data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<SERVICE> updatedEntity);

        /// <summary>Deletes a specific service by its primary key</summary>
        /// <param name="id">The primary key of the service</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The serviceService responsible for managing service related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting service information.
    /// </remarks>
    public class SERVICEService : ISERVICEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the SERVICE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public SERVICEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific service by its primary key</summary>
        /// <param name="id">The primary key of the service</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The service data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.SERVICE.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_SUPPLIER_SUPPLIER","GUID_ACCOUNT_ACCOUNT","GUID_DEPARTMENT_DEPARTMENT","GUID_ACCOUNTING0_ACCOUNTING","GUID_ACCOUNTING1_ACCOUNTING","GUID_ACCOUNTING2_ACCOUNTING","GUID_ACCOUNTING3_ACCOUNTING","GUID_ACCOUNTING4_ACCOUNTING"];
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

        /// <summary>Retrieves a list of services based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of services</returns>/// <exception cref="Exception"></exception>
        public async Task<List<SERVICE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetSERVICE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new service</summary>
        /// <param name="model">The service data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(SERVICE model)
        {
            model.GUID = await CreateSERVICE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific service by its primary key</summary>
        /// <param name="id">The primary key of the service</param>
        /// <param name="updatedEntity">The service data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, SERVICE updatedEntity)
        {
            await UpdateSERVICE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific service by its primary key</summary>
        /// <param name="id">The primary key of the service</param>
        /// <param name="updatedEntity">The service data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<SERVICE> updatedEntity)
        {
            await PatchSERVICE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific service by its primary key</summary>
        /// <param name="id">The primary key of the service</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteSERVICE(id);
            return true;
        }
        #region
        private async Task<List<SERVICE>> GetSERVICE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SERVICE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SERVICE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SERVICE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SERVICE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateSERVICE(SERVICE model)
        {
            _dbContext.SERVICE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateSERVICE(Guid id, SERVICE updatedEntity)
        {
            _dbContext.SERVICE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteSERVICE(Guid id)
        {
            var entityData = _dbContext.SERVICE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SERVICE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchSERVICE(Guid id, JsonPatchDocument<SERVICE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SERVICE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SERVICE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}