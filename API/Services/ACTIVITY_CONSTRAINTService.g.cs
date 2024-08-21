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
    /// The activity_constraintService responsible for managing activity_constraint related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting activity_constraint information.
    /// </remarks>
    public interface IACTIVITY_CONSTRAINTService
    {
        /// <summary>Retrieves a specific activity_constraint by its primary key</summary>
        /// <param name="id">The primary key of the activity_constraint</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The activity_constraint data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of activity_constraints based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of activity_constraints</returns>
        Task<List<ACTIVITY_CONSTRAINT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new activity_constraint</summary>
        /// <param name="model">The activity_constraint data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(ACTIVITY_CONSTRAINT model);

        /// <summary>Updates a specific activity_constraint by its primary key</summary>
        /// <param name="id">The primary key of the activity_constraint</param>
        /// <param name="updatedEntity">The activity_constraint data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, ACTIVITY_CONSTRAINT updatedEntity);

        /// <summary>Updates a specific activity_constraint by its primary key</summary>
        /// <param name="id">The primary key of the activity_constraint</param>
        /// <param name="updatedEntity">The activity_constraint data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<ACTIVITY_CONSTRAINT> updatedEntity);

        /// <summary>Deletes a specific activity_constraint by its primary key</summary>
        /// <param name="id">The primary key of the activity_constraint</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The activity_constraintService responsible for managing activity_constraint related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting activity_constraint information.
    /// </remarks>
    public class ACTIVITY_CONSTRAINTService : IACTIVITY_CONSTRAINTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the ACTIVITY_CONSTRAINT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ACTIVITY_CONSTRAINTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific activity_constraint by its primary key</summary>
        /// <param name="id">The primary key of the activity_constraint</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The activity_constraint data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.ACTIVITY_CONSTRAINT.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_PERIODIC_TASK_PERIODIC_TASK","GUID_PERIODIC_TASK_MASTER_PERIODIC_TASK"];
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

        /// <summary>Retrieves a list of activity_constraints based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of activity_constraints</returns>/// <exception cref="Exception"></exception>
        public async Task<List<ACTIVITY_CONSTRAINT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetACTIVITY_CONSTRAINT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new activity_constraint</summary>
        /// <param name="model">The activity_constraint data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(ACTIVITY_CONSTRAINT model)
        {
            model.GUID = await CreateACTIVITY_CONSTRAINT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific activity_constraint by its primary key</summary>
        /// <param name="id">The primary key of the activity_constraint</param>
        /// <param name="updatedEntity">The activity_constraint data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, ACTIVITY_CONSTRAINT updatedEntity)
        {
            await UpdateACTIVITY_CONSTRAINT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific activity_constraint by its primary key</summary>
        /// <param name="id">The primary key of the activity_constraint</param>
        /// <param name="updatedEntity">The activity_constraint data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<ACTIVITY_CONSTRAINT> updatedEntity)
        {
            await PatchACTIVITY_CONSTRAINT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific activity_constraint by its primary key</summary>
        /// <param name="id">The primary key of the activity_constraint</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteACTIVITY_CONSTRAINT(id);
            return true;
        }
        #region
        private async Task<List<ACTIVITY_CONSTRAINT>> GetACTIVITY_CONSTRAINT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ACTIVITY_CONSTRAINT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ACTIVITY_CONSTRAINT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ACTIVITY_CONSTRAINT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ACTIVITY_CONSTRAINT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateACTIVITY_CONSTRAINT(ACTIVITY_CONSTRAINT model)
        {
            _dbContext.ACTIVITY_CONSTRAINT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateACTIVITY_CONSTRAINT(Guid id, ACTIVITY_CONSTRAINT updatedEntity)
        {
            _dbContext.ACTIVITY_CONSTRAINT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteACTIVITY_CONSTRAINT(Guid id)
        {
            var entityData = _dbContext.ACTIVITY_CONSTRAINT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ACTIVITY_CONSTRAINT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchACTIVITY_CONSTRAINT(Guid id, JsonPatchDocument<ACTIVITY_CONSTRAINT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ACTIVITY_CONSTRAINT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ACTIVITY_CONSTRAINT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}