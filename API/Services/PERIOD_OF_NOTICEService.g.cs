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
    /// The period_of_noticeService responsible for managing period_of_notice related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting period_of_notice information.
    /// </remarks>
    public interface IPERIOD_OF_NOTICEService
    {
        /// <summary>Retrieves a specific period_of_notice by its primary key</summary>
        /// <param name="id">The primary key of the period_of_notice</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The period_of_notice data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of period_of_notices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of period_of_notices</returns>
        Task<List<PERIOD_OF_NOTICE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new period_of_notice</summary>
        /// <param name="model">The period_of_notice data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PERIOD_OF_NOTICE model);

        /// <summary>Updates a specific period_of_notice by its primary key</summary>
        /// <param name="id">The primary key of the period_of_notice</param>
        /// <param name="updatedEntity">The period_of_notice data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PERIOD_OF_NOTICE updatedEntity);

        /// <summary>Updates a specific period_of_notice by its primary key</summary>
        /// <param name="id">The primary key of the period_of_notice</param>
        /// <param name="updatedEntity">The period_of_notice data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PERIOD_OF_NOTICE> updatedEntity);

        /// <summary>Deletes a specific period_of_notice by its primary key</summary>
        /// <param name="id">The primary key of the period_of_notice</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The period_of_noticeService responsible for managing period_of_notice related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting period_of_notice information.
    /// </remarks>
    public class PERIOD_OF_NOTICEService : IPERIOD_OF_NOTICEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PERIOD_OF_NOTICE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PERIOD_OF_NOTICEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific period_of_notice by its primary key</summary>
        /// <param name="id">The primary key of the period_of_notice</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The period_of_notice data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PERIOD_OF_NOTICE.AsQueryable();
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

        /// <summary>Retrieves a list of period_of_notices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of period_of_notices</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PERIOD_OF_NOTICE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPERIOD_OF_NOTICE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new period_of_notice</summary>
        /// <param name="model">The period_of_notice data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PERIOD_OF_NOTICE model)
        {
            model.GUID = await CreatePERIOD_OF_NOTICE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific period_of_notice by its primary key</summary>
        /// <param name="id">The primary key of the period_of_notice</param>
        /// <param name="updatedEntity">The period_of_notice data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PERIOD_OF_NOTICE updatedEntity)
        {
            await UpdatePERIOD_OF_NOTICE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific period_of_notice by its primary key</summary>
        /// <param name="id">The primary key of the period_of_notice</param>
        /// <param name="updatedEntity">The period_of_notice data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PERIOD_OF_NOTICE> updatedEntity)
        {
            await PatchPERIOD_OF_NOTICE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific period_of_notice by its primary key</summary>
        /// <param name="id">The primary key of the period_of_notice</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePERIOD_OF_NOTICE(id);
            return true;
        }
        #region
        private async Task<List<PERIOD_OF_NOTICE>> GetPERIOD_OF_NOTICE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PERIOD_OF_NOTICE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PERIOD_OF_NOTICE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PERIOD_OF_NOTICE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PERIOD_OF_NOTICE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePERIOD_OF_NOTICE(PERIOD_OF_NOTICE model)
        {
            _dbContext.PERIOD_OF_NOTICE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePERIOD_OF_NOTICE(Guid id, PERIOD_OF_NOTICE updatedEntity)
        {
            _dbContext.PERIOD_OF_NOTICE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePERIOD_OF_NOTICE(Guid id)
        {
            var entityData = _dbContext.PERIOD_OF_NOTICE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PERIOD_OF_NOTICE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPERIOD_OF_NOTICE(Guid id, JsonPatchDocument<PERIOD_OF_NOTICE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PERIOD_OF_NOTICE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PERIOD_OF_NOTICE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}