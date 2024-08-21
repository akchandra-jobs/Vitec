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
    /// The areaService responsible for managing area related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting area information.
    /// </remarks>
    public interface IAREAService
    {
        /// <summary>Retrieves a specific area by its primary key</summary>
        /// <param name="id">The primary key of the area</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The area data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of areas based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of areas</returns>
        Task<List<AREA>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new area</summary>
        /// <param name="model">The area data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(AREA model);

        /// <summary>Updates a specific area by its primary key</summary>
        /// <param name="id">The primary key of the area</param>
        /// <param name="updatedEntity">The area data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, AREA updatedEntity);

        /// <summary>Updates a specific area by its primary key</summary>
        /// <param name="id">The primary key of the area</param>
        /// <param name="updatedEntity">The area data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<AREA> updatedEntity);

        /// <summary>Deletes a specific area by its primary key</summary>
        /// <param name="id">The primary key of the area</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The areaService responsible for managing area related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting area information.
    /// </remarks>
    public class AREAService : IAREAService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the AREA class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public AREAService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific area by its primary key</summary>
        /// <param name="id">The primary key of the area</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The area data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.AREA.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_CONDITION_CONDITION","GUID_DATA_OWNER_DATA_OWNER","GUID_WORK_ORDER_WORK_ORDER","GUID_WORK_ORDER_X_AREA_WORK_ORDER_X_AREA","GUID_AREA_GROUP_AREA","GUID_BUILDING_BUILDING","GUID_CONTRACT_ITEM_CONTRACT_ITEM","GUID_COST_CENTER_COST_CENTER","GUID_OWNER_CUSTOMER","GUID_AREA_CATEGORY_AREA_CATEGORY","GUID_ACCOUNT_ACCOUNT","GUID_ORGANIZATION_ORGANIZATION","GUID_ORGANIZATION_SECTION_ORGANIZATION_SECTION","GUID_ORGANIZATION_UNIT_ORGANIZATION_UNIT","GUID_CLEANING_CLEANING","GUID_CLEANER_PERSON","GUID_CLEANING_QUALITY_CLEANING_QUALITY","GUID_DRAWING_DRAWING","GUID_CONDITION_TYPE_CONDITION_TYPE","GUID_AREA_TYPE_AREA_TYPE","GUID_CLEANING_TEAM_RESOURCE_GROUP","GUID_MEDICAL_OWNERSHIP_MEDICAL_OWNERSHIP","GUID_MEDICAL_REGION_MEDICAL_REGION"];
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

        /// <summary>Retrieves a list of areas based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of areas</returns>/// <exception cref="Exception"></exception>
        public async Task<List<AREA>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetAREA(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new area</summary>
        /// <param name="model">The area data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(AREA model)
        {
            model.GUID = await CreateAREA(model);
            return model.GUID;
        }

        /// <summary>Updates a specific area by its primary key</summary>
        /// <param name="id">The primary key of the area</param>
        /// <param name="updatedEntity">The area data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, AREA updatedEntity)
        {
            await UpdateAREA(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific area by its primary key</summary>
        /// <param name="id">The primary key of the area</param>
        /// <param name="updatedEntity">The area data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<AREA> updatedEntity)
        {
            await PatchAREA(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific area by its primary key</summary>
        /// <param name="id">The primary key of the area</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteAREA(id);
            return true;
        }
        #region
        private async Task<List<AREA>> GetAREA(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.AREA.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<AREA>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(AREA), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<AREA, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateAREA(AREA model)
        {
            _dbContext.AREA.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateAREA(Guid id, AREA updatedEntity)
        {
            _dbContext.AREA.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteAREA(Guid id)
        {
            var entityData = _dbContext.AREA.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.AREA.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchAREA(Guid id, JsonPatchDocument<AREA> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.AREA.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.AREA.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}