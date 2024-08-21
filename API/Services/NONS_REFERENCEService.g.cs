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
    /// The nons_referenceService responsible for managing nons_reference related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting nons_reference information.
    /// </remarks>
    public interface INONS_REFERENCEService
    {
        /// <summary>Retrieves a specific nons_reference by its primary key</summary>
        /// <param name="id">The primary key of the nons_reference</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The nons_reference data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of nons_references based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of nons_references</returns>
        Task<List<NONS_REFERENCE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new nons_reference</summary>
        /// <param name="model">The nons_reference data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(NONS_REFERENCE model);

        /// <summary>Updates a specific nons_reference by its primary key</summary>
        /// <param name="id">The primary key of the nons_reference</param>
        /// <param name="updatedEntity">The nons_reference data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, NONS_REFERENCE updatedEntity);

        /// <summary>Updates a specific nons_reference by its primary key</summary>
        /// <param name="id">The primary key of the nons_reference</param>
        /// <param name="updatedEntity">The nons_reference data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<NONS_REFERENCE> updatedEntity);

        /// <summary>Deletes a specific nons_reference by its primary key</summary>
        /// <param name="id">The primary key of the nons_reference</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The nons_referenceService responsible for managing nons_reference related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting nons_reference information.
    /// </remarks>
    public class NONS_REFERENCEService : INONS_REFERENCEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the NONS_REFERENCE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public NONS_REFERENCEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific nons_reference by its primary key</summary>
        /// <param name="id">The primary key of the nons_reference</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The nons_reference data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.NONS_REFERENCE.AsQueryable();
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

        /// <summary>Retrieves a list of nons_references based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of nons_references</returns>/// <exception cref="Exception"></exception>
        public async Task<List<NONS_REFERENCE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetNONS_REFERENCE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new nons_reference</summary>
        /// <param name="model">The nons_reference data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(NONS_REFERENCE model)
        {
            model.GUID = await CreateNONS_REFERENCE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific nons_reference by its primary key</summary>
        /// <param name="id">The primary key of the nons_reference</param>
        /// <param name="updatedEntity">The nons_reference data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, NONS_REFERENCE updatedEntity)
        {
            await UpdateNONS_REFERENCE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific nons_reference by its primary key</summary>
        /// <param name="id">The primary key of the nons_reference</param>
        /// <param name="updatedEntity">The nons_reference data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<NONS_REFERENCE> updatedEntity)
        {
            await PatchNONS_REFERENCE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific nons_reference by its primary key</summary>
        /// <param name="id">The primary key of the nons_reference</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteNONS_REFERENCE(id);
            return true;
        }
        #region
        private async Task<List<NONS_REFERENCE>> GetNONS_REFERENCE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.NONS_REFERENCE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<NONS_REFERENCE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(NONS_REFERENCE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<NONS_REFERENCE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateNONS_REFERENCE(NONS_REFERENCE model)
        {
            _dbContext.NONS_REFERENCE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateNONS_REFERENCE(Guid id, NONS_REFERENCE updatedEntity)
        {
            _dbContext.NONS_REFERENCE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteNONS_REFERENCE(Guid id)
        {
            var entityData = _dbContext.NONS_REFERENCE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.NONS_REFERENCE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchNONS_REFERENCE(Guid id, JsonPatchDocument<NONS_REFERENCE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.NONS_REFERENCE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.NONS_REFERENCE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}