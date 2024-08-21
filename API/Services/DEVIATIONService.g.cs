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
    /// The deviationService responsible for managing deviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting deviation information.
    /// </remarks>
    public interface IDEVIATIONService
    {
        /// <summary>Retrieves a specific deviation by its primary key</summary>
        /// <param name="id">The primary key of the deviation</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The deviation data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of deviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of deviations</returns>
        Task<List<DEVIATION>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new deviation</summary>
        /// <param name="model">The deviation data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(DEVIATION model);

        /// <summary>Updates a specific deviation by its primary key</summary>
        /// <param name="id">The primary key of the deviation</param>
        /// <param name="updatedEntity">The deviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, DEVIATION updatedEntity);

        /// <summary>Updates a specific deviation by its primary key</summary>
        /// <param name="id">The primary key of the deviation</param>
        /// <param name="updatedEntity">The deviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<DEVIATION> updatedEntity);

        /// <summary>Deletes a specific deviation by its primary key</summary>
        /// <param name="id">The primary key of the deviation</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The deviationService responsible for managing deviation related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting deviation information.
    /// </remarks>
    public class DEVIATIONService : IDEVIATIONService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the DEVIATION class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public DEVIATIONService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific deviation by its primary key</summary>
        /// <param name="id">The primary key of the deviation</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The deviation data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.DEVIATION.AsQueryable();
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

            string[] navigationProperties = ["GUID_PRIORITY_PRIORITY","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_USER_CLOSED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_AREA_AREA","GUID_BUILDING_BUILDING","GUID_CONTROL_LIST_ITEM_ANSWER_CONTROL_LIST_ITEM_ANSWER","GUID_CORRECTIVE_WORK_ORDER_WORK_ORDER","GUID_DEVIATION_TYPE_DEVIATION_TYPE","GUID_EQUIPMENT_EQUIPMENT","GUID_ESTATE_ESTATE","GUID_INSPECTION_WORK_ORDER_WORK_ORDER","GUID_WORK_ORDER_WORK_ORDER"];
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

        /// <summary>Retrieves a list of deviations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of deviations</returns>/// <exception cref="Exception"></exception>
        public async Task<List<DEVIATION>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetDEVIATION(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new deviation</summary>
        /// <param name="model">The deviation data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(DEVIATION model)
        {
            model.GUID = await CreateDEVIATION(model);
            return model.GUID;
        }

        /// <summary>Updates a specific deviation by its primary key</summary>
        /// <param name="id">The primary key of the deviation</param>
        /// <param name="updatedEntity">The deviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, DEVIATION updatedEntity)
        {
            await UpdateDEVIATION(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific deviation by its primary key</summary>
        /// <param name="id">The primary key of the deviation</param>
        /// <param name="updatedEntity">The deviation data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<DEVIATION> updatedEntity)
        {
            await PatchDEVIATION(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific deviation by its primary key</summary>
        /// <param name="id">The primary key of the deviation</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteDEVIATION(id);
            return true;
        }
        #region
        private async Task<List<DEVIATION>> GetDEVIATION(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.DEVIATION.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<DEVIATION>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(DEVIATION), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<DEVIATION, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateDEVIATION(DEVIATION model)
        {
            _dbContext.DEVIATION.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateDEVIATION(Guid id, DEVIATION updatedEntity)
        {
            _dbContext.DEVIATION.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteDEVIATION(Guid id)
        {
            var entityData = _dbContext.DEVIATION.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.DEVIATION.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchDEVIATION(Guid id, JsonPatchDocument<DEVIATION> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.DEVIATION.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.DEVIATION.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}