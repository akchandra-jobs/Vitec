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
    /// The contact_personService responsible for managing contact_person related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting contact_person information.
    /// </remarks>
    public interface ICONTACT_PERSONService
    {
        /// <summary>Retrieves a specific contact_person by its primary key</summary>
        /// <param name="id">The primary key of the contact_person</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The contact_person data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of contact_persons based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of contact_persons</returns>
        Task<List<CONTACT_PERSON>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new contact_person</summary>
        /// <param name="model">The contact_person data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(CONTACT_PERSON model);

        /// <summary>Updates a specific contact_person by its primary key</summary>
        /// <param name="id">The primary key of the contact_person</param>
        /// <param name="updatedEntity">The contact_person data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, CONTACT_PERSON updatedEntity);

        /// <summary>Updates a specific contact_person by its primary key</summary>
        /// <param name="id">The primary key of the contact_person</param>
        /// <param name="updatedEntity">The contact_person data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<CONTACT_PERSON> updatedEntity);

        /// <summary>Deletes a specific contact_person by its primary key</summary>
        /// <param name="id">The primary key of the contact_person</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The contact_personService responsible for managing contact_person related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting contact_person information.
    /// </remarks>
    public class CONTACT_PERSONService : ICONTACT_PERSONService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the CONTACT_PERSON class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public CONTACT_PERSONService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific contact_person by its primary key</summary>
        /// <param name="id">The primary key of the contact_person</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The contact_person data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.CONTACT_PERSON.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_CUSTOMER_CUSTOMER","GUID_SUPPLIER_SUPPLIER","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of contact_persons based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of contact_persons</returns>/// <exception cref="Exception"></exception>
        public async Task<List<CONTACT_PERSON>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetCONTACT_PERSON(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new contact_person</summary>
        /// <param name="model">The contact_person data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(CONTACT_PERSON model)
        {
            model.GUID = await CreateCONTACT_PERSON(model);
            return model.GUID;
        }

        /// <summary>Updates a specific contact_person by its primary key</summary>
        /// <param name="id">The primary key of the contact_person</param>
        /// <param name="updatedEntity">The contact_person data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, CONTACT_PERSON updatedEntity)
        {
            await UpdateCONTACT_PERSON(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific contact_person by its primary key</summary>
        /// <param name="id">The primary key of the contact_person</param>
        /// <param name="updatedEntity">The contact_person data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<CONTACT_PERSON> updatedEntity)
        {
            await PatchCONTACT_PERSON(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific contact_person by its primary key</summary>
        /// <param name="id">The primary key of the contact_person</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteCONTACT_PERSON(id);
            return true;
        }
        #region
        private async Task<List<CONTACT_PERSON>> GetCONTACT_PERSON(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CONTACT_PERSON.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CONTACT_PERSON>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CONTACT_PERSON), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CONTACT_PERSON, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateCONTACT_PERSON(CONTACT_PERSON model)
        {
            _dbContext.CONTACT_PERSON.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateCONTACT_PERSON(Guid id, CONTACT_PERSON updatedEntity)
        {
            _dbContext.CONTACT_PERSON.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteCONTACT_PERSON(Guid id)
        {
            var entityData = _dbContext.CONTACT_PERSON.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CONTACT_PERSON.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchCONTACT_PERSON(Guid id, JsonPatchDocument<CONTACT_PERSON> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CONTACT_PERSON.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CONTACT_PERSON.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}