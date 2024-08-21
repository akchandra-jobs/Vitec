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
    /// The reference_dataService responsible for managing reference_data related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting reference_data information.
    /// </remarks>
    public interface IREFERENCE_DATAService
    {
        /// <summary>Retrieves a specific reference_data by its primary key</summary>
        /// <param name="id">The primary key of the reference_data</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The reference_data data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of reference_datas based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of reference_datas</returns>
        Task<List<REFERENCE_DATA>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new reference_data</summary>
        /// <param name="model">The reference_data data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(REFERENCE_DATA model);

        /// <summary>Updates a specific reference_data by its primary key</summary>
        /// <param name="id">The primary key of the reference_data</param>
        /// <param name="updatedEntity">The reference_data data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, REFERENCE_DATA updatedEntity);

        /// <summary>Updates a specific reference_data by its primary key</summary>
        /// <param name="id">The primary key of the reference_data</param>
        /// <param name="updatedEntity">The reference_data data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<REFERENCE_DATA> updatedEntity);

        /// <summary>Deletes a specific reference_data by its primary key</summary>
        /// <param name="id">The primary key of the reference_data</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The reference_dataService responsible for managing reference_data related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting reference_data information.
    /// </remarks>
    public class REFERENCE_DATAService : IREFERENCE_DATAService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the REFERENCE_DATA class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public REFERENCE_DATAService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific reference_data by its primary key</summary>
        /// <param name="id">The primary key of the reference_data</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The reference_data data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.REFERENCE_DATA.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_REFERENCE_TYPE_REFERENCE_TYPE","GUID_PARENT_REFERENCE_DATA"];
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

        /// <summary>Retrieves a list of reference_datas based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of reference_datas</returns>/// <exception cref="Exception"></exception>
        public async Task<List<REFERENCE_DATA>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetREFERENCE_DATA(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new reference_data</summary>
        /// <param name="model">The reference_data data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(REFERENCE_DATA model)
        {
            model.GUID = await CreateREFERENCE_DATA(model);
            return model.GUID;
        }

        /// <summary>Updates a specific reference_data by its primary key</summary>
        /// <param name="id">The primary key of the reference_data</param>
        /// <param name="updatedEntity">The reference_data data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, REFERENCE_DATA updatedEntity)
        {
            await UpdateREFERENCE_DATA(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific reference_data by its primary key</summary>
        /// <param name="id">The primary key of the reference_data</param>
        /// <param name="updatedEntity">The reference_data data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<REFERENCE_DATA> updatedEntity)
        {
            await PatchREFERENCE_DATA(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific reference_data by its primary key</summary>
        /// <param name="id">The primary key of the reference_data</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteREFERENCE_DATA(id);
            return true;
        }
        #region
        private async Task<List<REFERENCE_DATA>> GetREFERENCE_DATA(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.REFERENCE_DATA.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<REFERENCE_DATA>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(REFERENCE_DATA), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<REFERENCE_DATA, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateREFERENCE_DATA(REFERENCE_DATA model)
        {
            _dbContext.REFERENCE_DATA.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateREFERENCE_DATA(Guid id, REFERENCE_DATA updatedEntity)
        {
            _dbContext.REFERENCE_DATA.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteREFERENCE_DATA(Guid id)
        {
            var entityData = _dbContext.REFERENCE_DATA.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.REFERENCE_DATA.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchREFERENCE_DATA(Guid id, JsonPatchDocument<REFERENCE_DATA> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.REFERENCE_DATA.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.REFERENCE_DATA.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}