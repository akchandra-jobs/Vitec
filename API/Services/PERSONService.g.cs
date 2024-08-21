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
    /// The personService responsible for managing person related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting person information.
    /// </remarks>
    public interface IPERSONService
    {
        /// <summary>Retrieves a specific person by its primary key</summary>
        /// <param name="id">The primary key of the person</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The person data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of persons based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of persons</returns>
        Task<List<PERSON>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new person</summary>
        /// <param name="model">The person data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(PERSON model);

        /// <summary>Updates a specific person by its primary key</summary>
        /// <param name="id">The primary key of the person</param>
        /// <param name="updatedEntity">The person data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, PERSON updatedEntity);

        /// <summary>Updates a specific person by its primary key</summary>
        /// <param name="id">The primary key of the person</param>
        /// <param name="updatedEntity">The person data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<PERSON> updatedEntity);

        /// <summary>Deletes a specific person by its primary key</summary>
        /// <param name="id">The primary key of the person</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The personService responsible for managing person related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting person information.
    /// </remarks>
    public class PERSONService : IPERSONService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the PERSON class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public PERSONService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific person by its primary key</summary>
        /// <param name="id">The primary key of the person</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The person data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.PERSON.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_ORGANIZATION_SECTION_ORGANIZATION_SECTION","GUID_ORGANIZATION_UNIT_ORGANIZATION_UNIT","GUID_DATA_OWNER_DATA_OWNER","GUID_DEPARTMENT_DEPARTMENT","GUID_AREA_AREA","GUID_RESOURCE_GROUP_RESOURCE_GROUP","GUID_ORGANIZATION_ORGANIZATION","GUID_PERSON_ROLE_PERSON_ROLE"];
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

        /// <summary>Retrieves a list of persons based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of persons</returns>/// <exception cref="Exception"></exception>
        public async Task<List<PERSON>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetPERSON(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new person</summary>
        /// <param name="model">The person data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(PERSON model)
        {
            model.GUID = await CreatePERSON(model);
            return model.GUID;
        }

        /// <summary>Updates a specific person by its primary key</summary>
        /// <param name="id">The primary key of the person</param>
        /// <param name="updatedEntity">The person data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, PERSON updatedEntity)
        {
            await UpdatePERSON(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific person by its primary key</summary>
        /// <param name="id">The primary key of the person</param>
        /// <param name="updatedEntity">The person data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<PERSON> updatedEntity)
        {
            await PatchPERSON(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific person by its primary key</summary>
        /// <param name="id">The primary key of the person</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeletePERSON(id);
            return true;
        }
        #region
        private async Task<List<PERSON>> GetPERSON(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.PERSON.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PERSON>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(PERSON), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<PERSON, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreatePERSON(PERSON model)
        {
            _dbContext.PERSON.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdatePERSON(Guid id, PERSON updatedEntity)
        {
            _dbContext.PERSON.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeletePERSON(Guid id)
        {
            var entityData = _dbContext.PERSON.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.PERSON.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchPERSON(Guid id, JsonPatchDocument<PERSON> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.PERSON.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.PERSON.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}