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
    /// The nonsreferencesService responsible for managing nonsreferences related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting nonsreferences information.
    /// </remarks>
    public interface INonsReferencesService
    {
        /// <summary>Retrieves a specific nonsreferences by its primary key</summary>
        /// <param name="id">The primary key of the nonsreferences</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The nonsreferences data</returns>
        Task<dynamic> GetById(Int64 id, string fields);

        /// <summary>Retrieves a list of nonsreferencess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of nonsreferencess</returns>
        Task<List<NonsReferences>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new nonsreferences</summary>
        /// <param name="model">The nonsreferences data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Int64> Create(NonsReferences model);

        /// <summary>Updates a specific nonsreferences by its primary key</summary>
        /// <param name="id">The primary key of the nonsreferences</param>
        /// <param name="updatedEntity">The nonsreferences data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Int64 id, NonsReferences updatedEntity);

        /// <summary>Updates a specific nonsreferences by its primary key</summary>
        /// <param name="id">The primary key of the nonsreferences</param>
        /// <param name="updatedEntity">The nonsreferences data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Int64 id, JsonPatchDocument<NonsReferences> updatedEntity);

        /// <summary>Deletes a specific nonsreferences by its primary key</summary>
        /// <param name="id">The primary key of the nonsreferences</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Int64 id);
    }

    /// <summary>
    /// The nonsreferencesService responsible for managing nonsreferences related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting nonsreferences information.
    /// </remarks>
    public class NonsReferencesService : INonsReferencesService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the NonsReferences class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public NonsReferencesService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific nonsreferences by its primary key</summary>
        /// <param name="id">The primary key of the nonsreferences</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The nonsreferences data</returns>
        public async Task<dynamic> GetById(Int64 id, string fields)
        {
            var query = _dbContext.NonsReferences.AsQueryable();
            List<string> allfields = new List<string>();
            if (!string.IsNullOrEmpty(fields))
            {
                allfields.AddRange(fields.Split(","));
                fields = $"Id,{fields}";
            }
            else
            {
                fields = "Id";
            }

            string[] navigationProperties = ["Id_Products"];
            foreach (var navigationProperty in navigationProperties)
            {
                if (allfields.Any(field => field.StartsWith(navigationProperty + ".", StringComparison.OrdinalIgnoreCase)))
                {
                    query = query.Include(navigationProperty);
                }
            }

            query = query.Where(entity => entity.Id == id);
            return _mapper.MapToFields(await query.FirstOrDefaultAsync(),fields);
        }

        /// <summary>Retrieves a list of nonsreferencess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of nonsreferencess</returns>/// <exception cref="Exception"></exception>
        public async Task<List<NonsReferences>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetNonsReferences(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new nonsreferences</summary>
        /// <param name="model">The nonsreferences data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Int64> Create(NonsReferences model)
        {
            model.Id = await CreateNonsReferences(model);
            return model.Id;
        }

        /// <summary>Updates a specific nonsreferences by its primary key</summary>
        /// <param name="id">The primary key of the nonsreferences</param>
        /// <param name="updatedEntity">The nonsreferences data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Int64 id, NonsReferences updatedEntity)
        {
            await UpdateNonsReferences(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific nonsreferences by its primary key</summary>
        /// <param name="id">The primary key of the nonsreferences</param>
        /// <param name="updatedEntity">The nonsreferences data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Int64 id, JsonPatchDocument<NonsReferences> updatedEntity)
        {
            await PatchNonsReferences(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific nonsreferences by its primary key</summary>
        /// <param name="id">The primary key of the nonsreferences</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Int64 id)
        {
            await DeleteNonsReferences(id);
            return true;
        }
        #region
        private async Task<List<NonsReferences>> GetNonsReferences(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.NonsReferences.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<NonsReferences>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(NonsReferences), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<NonsReferences, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Int64> CreateNonsReferences(NonsReferences model)
        {
            _dbContext.NonsReferences.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        private async Task UpdateNonsReferences(Int64 id, NonsReferences updatedEntity)
        {
            _dbContext.NonsReferences.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteNonsReferences(Int64 id)
        {
            var entityData = _dbContext.NonsReferences.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.NonsReferences.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchNonsReferences(Int64 id, JsonPatchDocument<NonsReferences> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.NonsReferences.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.NonsReferences.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}