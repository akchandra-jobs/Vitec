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
    /// The component_x_supplierService responsible for managing component_x_supplier related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting component_x_supplier information.
    /// </remarks>
    public interface ICOMPONENT_X_SUPPLIERService
    {
        /// <summary>Retrieves a specific component_x_supplier by its primary key</summary>
        /// <param name="id">The primary key of the component_x_supplier</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The component_x_supplier data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of component_x_suppliers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of component_x_suppliers</returns>
        Task<List<COMPONENT_X_SUPPLIER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new component_x_supplier</summary>
        /// <param name="model">The component_x_supplier data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(COMPONENT_X_SUPPLIER model);

        /// <summary>Updates a specific component_x_supplier by its primary key</summary>
        /// <param name="id">The primary key of the component_x_supplier</param>
        /// <param name="updatedEntity">The component_x_supplier data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, COMPONENT_X_SUPPLIER updatedEntity);

        /// <summary>Updates a specific component_x_supplier by its primary key</summary>
        /// <param name="id">The primary key of the component_x_supplier</param>
        /// <param name="updatedEntity">The component_x_supplier data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<COMPONENT_X_SUPPLIER> updatedEntity);

        /// <summary>Deletes a specific component_x_supplier by its primary key</summary>
        /// <param name="id">The primary key of the component_x_supplier</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The component_x_supplierService responsible for managing component_x_supplier related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting component_x_supplier information.
    /// </remarks>
    public class COMPONENT_X_SUPPLIERService : ICOMPONENT_X_SUPPLIERService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the COMPONENT_X_SUPPLIER class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public COMPONENT_X_SUPPLIERService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific component_x_supplier by its primary key</summary>
        /// <param name="id">The primary key of the component_x_supplier</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The component_x_supplier data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.COMPONENT_X_SUPPLIER.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_COMPONENT_COMPONENT","GUID_SUPPLIER_SUPPLIER","GUID_SUPPLIER_AGREEMENT_SUPPLIER_AGREEMENT","GUID_CONTACT_PERSON_CONTACT_PERSON"];
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

        /// <summary>Retrieves a list of component_x_suppliers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of component_x_suppliers</returns>/// <exception cref="Exception"></exception>
        public async Task<List<COMPONENT_X_SUPPLIER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetCOMPONENT_X_SUPPLIER(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new component_x_supplier</summary>
        /// <param name="model">The component_x_supplier data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(COMPONENT_X_SUPPLIER model)
        {
            model.GUID = await CreateCOMPONENT_X_SUPPLIER(model);
            return model.GUID;
        }

        /// <summary>Updates a specific component_x_supplier by its primary key</summary>
        /// <param name="id">The primary key of the component_x_supplier</param>
        /// <param name="updatedEntity">The component_x_supplier data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, COMPONENT_X_SUPPLIER updatedEntity)
        {
            await UpdateCOMPONENT_X_SUPPLIER(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific component_x_supplier by its primary key</summary>
        /// <param name="id">The primary key of the component_x_supplier</param>
        /// <param name="updatedEntity">The component_x_supplier data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<COMPONENT_X_SUPPLIER> updatedEntity)
        {
            await PatchCOMPONENT_X_SUPPLIER(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific component_x_supplier by its primary key</summary>
        /// <param name="id">The primary key of the component_x_supplier</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteCOMPONENT_X_SUPPLIER(id);
            return true;
        }
        #region
        private async Task<List<COMPONENT_X_SUPPLIER>> GetCOMPONENT_X_SUPPLIER(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.COMPONENT_X_SUPPLIER.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<COMPONENT_X_SUPPLIER>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(COMPONENT_X_SUPPLIER), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<COMPONENT_X_SUPPLIER, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateCOMPONENT_X_SUPPLIER(COMPONENT_X_SUPPLIER model)
        {
            _dbContext.COMPONENT_X_SUPPLIER.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateCOMPONENT_X_SUPPLIER(Guid id, COMPONENT_X_SUPPLIER updatedEntity)
        {
            _dbContext.COMPONENT_X_SUPPLIER.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteCOMPONENT_X_SUPPLIER(Guid id)
        {
            var entityData = _dbContext.COMPONENT_X_SUPPLIER.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.COMPONENT_X_SUPPLIER.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchCOMPONENT_X_SUPPLIER(Guid id, JsonPatchDocument<COMPONENT_X_SUPPLIER> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.COMPONENT_X_SUPPLIER.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.COMPONENT_X_SUPPLIER.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}