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
    /// The usrService responsible for managing usr related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting usr information.
    /// </remarks>
    public interface IUSRService
    {
        /// <summary>Retrieves a specific usr by its primary key</summary>
        /// <param name="id">The primary key of the usr</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The usr data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of usrs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of usrs</returns>
        Task<List<USR>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new usr</summary>
        /// <param name="model">The usr data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(USR model);

        /// <summary>Updates a specific usr by its primary key</summary>
        /// <param name="id">The primary key of the usr</param>
        /// <param name="updatedEntity">The usr data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, USR updatedEntity);

        /// <summary>Updates a specific usr by its primary key</summary>
        /// <param name="id">The primary key of the usr</param>
        /// <param name="updatedEntity">The usr data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<USR> updatedEntity);

        /// <summary>Deletes a specific usr by its primary key</summary>
        /// <param name="id">The primary key of the usr</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The usrService responsible for managing usr related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting usr information.
    /// </remarks>
    public class USRService : IUSRService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the USR class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public USRService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific usr by its primary key</summary>
        /// <param name="id">The primary key of the usr</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The usr data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.USR.AsQueryable();
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

            string[] navigationProperties = ["GUID_IMAGE_IMAGE","GUID_MOBILE_MENU_PROFILE_MOBILE_MENU_PROFILE","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_CUSTOMER_CUSTOMER","GUID_RESOURCE_GROUP_RESOURCE_GROUP","GUID_ACCOUNT_ACCOUNT","GUID_DEPARTMENT_DEPARTMENT","GUID_BUILDING_SELECTION_BUILDING_SELECTION","GUID_USER_GROUP_USR","GUID_WEB_MENU_WEB_MENU","GUID_SUPPLIER_SUPPLIER","GUID_PERSON_PERSON","GUID_START_PAGE_START_PAGE","GUID_ENTITY_PERMISSION_PROFILE_ENTITY_PERMISSION_PROFILE","GUID_LANGUAGE_LANGUAGE"];
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

        /// <summary>Retrieves a list of usrs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of usrs</returns>/// <exception cref="Exception"></exception>
        public async Task<List<USR>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetUSR(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new usr</summary>
        /// <param name="model">The usr data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(USR model)
        {
            model.GUID = await CreateUSR(model);
            return model.GUID;
        }

        /// <summary>Updates a specific usr by its primary key</summary>
        /// <param name="id">The primary key of the usr</param>
        /// <param name="updatedEntity">The usr data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, USR updatedEntity)
        {
            await UpdateUSR(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific usr by its primary key</summary>
        /// <param name="id">The primary key of the usr</param>
        /// <param name="updatedEntity">The usr data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<USR> updatedEntity)
        {
            await PatchUSR(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific usr by its primary key</summary>
        /// <param name="id">The primary key of the usr</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteUSR(id);
            return true;
        }
        #region
        private async Task<List<USR>> GetUSR(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.USR.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<USR>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(USR), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<USR, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateUSR(USR model)
        {
            _dbContext.USR.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateUSR(Guid id, USR updatedEntity)
        {
            _dbContext.USR.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteUSR(Guid id)
        {
            var entityData = _dbContext.USR.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.USR.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchUSR(Guid id, JsonPatchDocument<USR> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.USR.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.USR.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}