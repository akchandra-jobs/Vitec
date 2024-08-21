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
    /// The estateService responsible for managing estate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting estate information.
    /// </remarks>
    public interface IESTATEService
    {
        /// <summary>Retrieves a specific estate by its primary key</summary>
        /// <param name="id">The primary key of the estate</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The estate data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of estates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of estates</returns>
        Task<List<ESTATE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new estate</summary>
        /// <param name="model">The estate data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(ESTATE model);

        /// <summary>Updates a specific estate by its primary key</summary>
        /// <param name="id">The primary key of the estate</param>
        /// <param name="updatedEntity">The estate data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, ESTATE updatedEntity);

        /// <summary>Updates a specific estate by its primary key</summary>
        /// <param name="id">The primary key of the estate</param>
        /// <param name="updatedEntity">The estate data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<ESTATE> updatedEntity);

        /// <summary>Deletes a specific estate by its primary key</summary>
        /// <param name="id">The primary key of the estate</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The estateService responsible for managing estate related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting estate information.
    /// </remarks>
    public class ESTATEService : IESTATEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the ESTATE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ESTATEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific estate by its primary key</summary>
        /// <param name="id">The primary key of the estate</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The estate data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.ESTATE.AsQueryable();
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

            string[] navigationProperties = ["GUID_MANAGER_PERSON1_PERSON","GUID_MANAGER_PERSON2_PERSON","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_CONDITION_CONDITION","GUID_GIS_ENTITY_GIS_ENTITY","GUID_BUSINESS_UNIT_REFERENCE_DATA","GUID_OWNER_CUSTOMER","GUID_EXTERNAL_FACILITY_MANAGER_CUSTOMER","GUID_FACILITY_MANAGER_PERSON","GUID_BIM_PROJECT_BIM_PROJECT","GUID_DATA_OWNER_DATA_OWNER","GUID_OPERATIONS_MANAGER_PERSON","GUID_RENTAL_GROUP_RENTAL_GROUP","GUID_ESTATE_CATEGORY_ESTATE_CATEGORY","GUID_COST_CENTER_COST_CENTER","GUID_REGION_REGION","GUID_POST_POSTAL_CODE","GUID_USER_CAF_COMPUTED_BY_USR"];
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

        /// <summary>Retrieves a list of estates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of estates</returns>/// <exception cref="Exception"></exception>
        public async Task<List<ESTATE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetESTATE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new estate</summary>
        /// <param name="model">The estate data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(ESTATE model)
        {
            model.GUID = await CreateESTATE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific estate by its primary key</summary>
        /// <param name="id">The primary key of the estate</param>
        /// <param name="updatedEntity">The estate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, ESTATE updatedEntity)
        {
            await UpdateESTATE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific estate by its primary key</summary>
        /// <param name="id">The primary key of the estate</param>
        /// <param name="updatedEntity">The estate data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<ESTATE> updatedEntity)
        {
            await PatchESTATE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific estate by its primary key</summary>
        /// <param name="id">The primary key of the estate</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteESTATE(id);
            return true;
        }
        #region
        private async Task<List<ESTATE>> GetESTATE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ESTATE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ESTATE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ESTATE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ESTATE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateESTATE(ESTATE model)
        {
            _dbContext.ESTATE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateESTATE(Guid id, ESTATE updatedEntity)
        {
            _dbContext.ESTATE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteESTATE(Guid id)
        {
            var entityData = _dbContext.ESTATE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ESTATE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchESTATE(Guid id, JsonPatchDocument<ESTATE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ESTATE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ESTATE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}