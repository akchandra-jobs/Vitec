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
    /// The supplierService responsible for managing supplier related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting supplier information.
    /// </remarks>
    public interface ISUPPLIERService
    {
        /// <summary>Retrieves a specific supplier by its primary key</summary>
        /// <param name="id">The primary key of the supplier</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The supplier data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of suppliers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of suppliers</returns>
        Task<List<SUPPLIER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new supplier</summary>
        /// <param name="model">The supplier data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(SUPPLIER model);

        /// <summary>Updates a specific supplier by its primary key</summary>
        /// <param name="id">The primary key of the supplier</param>
        /// <param name="updatedEntity">The supplier data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, SUPPLIER updatedEntity);

        /// <summary>Updates a specific supplier by its primary key</summary>
        /// <param name="id">The primary key of the supplier</param>
        /// <param name="updatedEntity">The supplier data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<SUPPLIER> updatedEntity);

        /// <summary>Deletes a specific supplier by its primary key</summary>
        /// <param name="id">The primary key of the supplier</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The supplierService responsible for managing supplier related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting supplier information.
    /// </remarks>
    public class SUPPLIERService : ISUPPLIERService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the SUPPLIER class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public SUPPLIERService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific supplier by its primary key</summary>
        /// <param name="id">The primary key of the supplier</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The supplier data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.SUPPLIER.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_SUPPLIER_LINE_OF_BUSINESS_SUPPLIER_LINE_OF_BUSINESS","GUID_MAIN_SUPPLIER_SUPPLIER"];
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

        /// <summary>Retrieves a list of suppliers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of suppliers</returns>/// <exception cref="Exception"></exception>
        public async Task<List<SUPPLIER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetSUPPLIER(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new supplier</summary>
        /// <param name="model">The supplier data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(SUPPLIER model)
        {
            model.GUID = await CreateSUPPLIER(model);
            return model.GUID;
        }

        /// <summary>Updates a specific supplier by its primary key</summary>
        /// <param name="id">The primary key of the supplier</param>
        /// <param name="updatedEntity">The supplier data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, SUPPLIER updatedEntity)
        {
            await UpdateSUPPLIER(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific supplier by its primary key</summary>
        /// <param name="id">The primary key of the supplier</param>
        /// <param name="updatedEntity">The supplier data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<SUPPLIER> updatedEntity)
        {
            await PatchSUPPLIER(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific supplier by its primary key</summary>
        /// <param name="id">The primary key of the supplier</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteSUPPLIER(id);
            return true;
        }
        #region
        private async Task<List<SUPPLIER>> GetSUPPLIER(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.SUPPLIER.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<SUPPLIER>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(SUPPLIER), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<SUPPLIER, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateSUPPLIER(SUPPLIER model)
        {
            _dbContext.SUPPLIER.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateSUPPLIER(Guid id, SUPPLIER updatedEntity)
        {
            _dbContext.SUPPLIER.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteSUPPLIER(Guid id)
        {
            var entityData = _dbContext.SUPPLIER.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.SUPPLIER.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchSUPPLIER(Guid id, JsonPatchDocument<SUPPLIER> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.SUPPLIER.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.SUPPLIER.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}