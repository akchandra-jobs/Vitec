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
    /// The buildingService responsible for managing building related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting building information.
    /// </remarks>
    public interface IBUILDINGService
    {
        /// <summary>Retrieves a specific building by its primary key</summary>
        /// <param name="id">The primary key of the building</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The building data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of buildings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of buildings</returns>
        Task<List<BUILDING>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new building</summary>
        /// <param name="model">The building data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(BUILDING model);

        /// <summary>Updates a specific building by its primary key</summary>
        /// <param name="id">The primary key of the building</param>
        /// <param name="updatedEntity">The building data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, BUILDING updatedEntity);

        /// <summary>Updates a specific building by its primary key</summary>
        /// <param name="id">The primary key of the building</param>
        /// <param name="updatedEntity">The building data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<BUILDING> updatedEntity);

        /// <summary>Deletes a specific building by its primary key</summary>
        /// <param name="id">The primary key of the building</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The buildingService responsible for managing building related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting building information.
    /// </remarks>
    public class BUILDINGService : IBUILDINGService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the BUILDING class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public BUILDINGService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific building by its primary key</summary>
        /// <param name="id">The primary key of the building</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The building data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.BUILDING.AsQueryable();
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

            string[] navigationProperties = ["GUID_MANAGER_PERSON1_PERSON","GUID_MANAGER_PERSON2_PERSON","GUID_DATA_OWNER_DATA_OWNER","GUID_OPERATIONS_MANAGER_PERSON","GUID_ESTATE_ESTATE","GUID_RENTAL_GROUP_RENTAL_GROUP","GUID_BUILDING_CATEGORY_BUILDING_CATEGORY","GUID_COST_CENTER_COST_CENTER","GUID_REGION_REGION","GUID_POST_POSTAL_CODE","GUID_USER_AREA_COMPUTED_BY_USR","GUID_USER_CAF_COMPUTED_BY_USR","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_CONDITION_CONDITION","GUID_BUILDING_TYPE_REFERENCE_DATA","GUID_GIS_ENTITY_GIS_ENTITY","GUID_BUSINESS_UNIT_REFERENCE_DATA","GUID_OWNER_CUSTOMER","GUID_EXTERNAL_FACILITY_MANAGER_CUSTOMER","GUID_FACILITY_MANAGER_PERSON","GUID_TEMPLATE_BUILDING"];
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

        /// <summary>Retrieves a list of buildings based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of buildings</returns>/// <exception cref="Exception"></exception>
        public async Task<List<BUILDING>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetBUILDING(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new building</summary>
        /// <param name="model">The building data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(BUILDING model)
        {
            model.GUID = await CreateBUILDING(model);
            return model.GUID;
        }

        /// <summary>Updates a specific building by its primary key</summary>
        /// <param name="id">The primary key of the building</param>
        /// <param name="updatedEntity">The building data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, BUILDING updatedEntity)
        {
            await UpdateBUILDING(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific building by its primary key</summary>
        /// <param name="id">The primary key of the building</param>
        /// <param name="updatedEntity">The building data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<BUILDING> updatedEntity)
        {
            await PatchBUILDING(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific building by its primary key</summary>
        /// <param name="id">The primary key of the building</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteBUILDING(id);
            return true;
        }
        #region
        private async Task<List<BUILDING>> GetBUILDING(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.BUILDING.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<BUILDING>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(BUILDING), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<BUILDING, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateBUILDING(BUILDING model)
        {
            _dbContext.BUILDING.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateBUILDING(Guid id, BUILDING updatedEntity)
        {
            _dbContext.BUILDING.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteBUILDING(Guid id)
        {
            var entityData = _dbContext.BUILDING.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.BUILDING.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchBUILDING(Guid id, JsonPatchDocument<BUILDING> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.BUILDING.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.BUILDING.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}