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
    /// The equipment_templateService responsible for managing equipment_template related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting equipment_template information.
    /// </remarks>
    public interface IEQUIPMENT_TEMPLATEService
    {
        /// <summary>Retrieves a specific equipment_template by its primary key</summary>
        /// <param name="id">The primary key of the equipment_template</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The equipment_template data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of equipment_templates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of equipment_templates</returns>
        Task<List<EQUIPMENT_TEMPLATE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new equipment_template</summary>
        /// <param name="model">The equipment_template data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(EQUIPMENT_TEMPLATE model);

        /// <summary>Updates a specific equipment_template by its primary key</summary>
        /// <param name="id">The primary key of the equipment_template</param>
        /// <param name="updatedEntity">The equipment_template data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, EQUIPMENT_TEMPLATE updatedEntity);

        /// <summary>Updates a specific equipment_template by its primary key</summary>
        /// <param name="id">The primary key of the equipment_template</param>
        /// <param name="updatedEntity">The equipment_template data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<EQUIPMENT_TEMPLATE> updatedEntity);

        /// <summary>Deletes a specific equipment_template by its primary key</summary>
        /// <param name="id">The primary key of the equipment_template</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The equipment_templateService responsible for managing equipment_template related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting equipment_template information.
    /// </remarks>
    public class EQUIPMENT_TEMPLATEService : IEQUIPMENT_TEMPLATEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the EQUIPMENT_TEMPLATE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public EQUIPMENT_TEMPLATEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific equipment_template by its primary key</summary>
        /// <param name="id">The primary key of the equipment_template</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The equipment_template data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.EQUIPMENT_TEMPLATE.AsQueryable();
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

            string[] navigationProperties = ["GUID_DATA_OWNER_DATA_OWNER","GUID_PARENT_EQUIPMENT_TEMPLATE_EQUIPMENT_TEMPLATE","GUID_EQUIPMENT_CATEGORY_EQUIPMENT_CATEGORY","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of equipment_templates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of equipment_templates</returns>/// <exception cref="Exception"></exception>
        public async Task<List<EQUIPMENT_TEMPLATE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetEQUIPMENT_TEMPLATE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new equipment_template</summary>
        /// <param name="model">The equipment_template data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(EQUIPMENT_TEMPLATE model)
        {
            model.GUID = await CreateEQUIPMENT_TEMPLATE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific equipment_template by its primary key</summary>
        /// <param name="id">The primary key of the equipment_template</param>
        /// <param name="updatedEntity">The equipment_template data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, EQUIPMENT_TEMPLATE updatedEntity)
        {
            await UpdateEQUIPMENT_TEMPLATE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific equipment_template by its primary key</summary>
        /// <param name="id">The primary key of the equipment_template</param>
        /// <param name="updatedEntity">The equipment_template data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<EQUIPMENT_TEMPLATE> updatedEntity)
        {
            await PatchEQUIPMENT_TEMPLATE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific equipment_template by its primary key</summary>
        /// <param name="id">The primary key of the equipment_template</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteEQUIPMENT_TEMPLATE(id);
            return true;
        }
        #region
        private async Task<List<EQUIPMENT_TEMPLATE>> GetEQUIPMENT_TEMPLATE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EQUIPMENT_TEMPLATE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EQUIPMENT_TEMPLATE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EQUIPMENT_TEMPLATE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EQUIPMENT_TEMPLATE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateEQUIPMENT_TEMPLATE(EQUIPMENT_TEMPLATE model)
        {
            _dbContext.EQUIPMENT_TEMPLATE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateEQUIPMENT_TEMPLATE(Guid id, EQUIPMENT_TEMPLATE updatedEntity)
        {
            _dbContext.EQUIPMENT_TEMPLATE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteEQUIPMENT_TEMPLATE(Guid id)
        {
            var entityData = _dbContext.EQUIPMENT_TEMPLATE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EQUIPMENT_TEMPLATE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchEQUIPMENT_TEMPLATE(Guid id, JsonPatchDocument<EQUIPMENT_TEMPLATE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EQUIPMENT_TEMPLATE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EQUIPMENT_TEMPLATE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}