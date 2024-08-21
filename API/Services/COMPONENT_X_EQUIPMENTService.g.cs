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
    /// The component_x_equipmentService responsible for managing component_x_equipment related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting component_x_equipment information.
    /// </remarks>
    public interface ICOMPONENT_X_EQUIPMENTService
    {
        /// <summary>Retrieves a specific component_x_equipment by its primary key</summary>
        /// <param name="id">The primary key of the component_x_equipment</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The component_x_equipment data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of component_x_equipments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of component_x_equipments</returns>
        Task<List<COMPONENT_X_EQUIPMENT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new component_x_equipment</summary>
        /// <param name="model">The component_x_equipment data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(COMPONENT_X_EQUIPMENT model);

        /// <summary>Updates a specific component_x_equipment by its primary key</summary>
        /// <param name="id">The primary key of the component_x_equipment</param>
        /// <param name="updatedEntity">The component_x_equipment data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, COMPONENT_X_EQUIPMENT updatedEntity);

        /// <summary>Updates a specific component_x_equipment by its primary key</summary>
        /// <param name="id">The primary key of the component_x_equipment</param>
        /// <param name="updatedEntity">The component_x_equipment data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<COMPONENT_X_EQUIPMENT> updatedEntity);

        /// <summary>Deletes a specific component_x_equipment by its primary key</summary>
        /// <param name="id">The primary key of the component_x_equipment</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The component_x_equipmentService responsible for managing component_x_equipment related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting component_x_equipment information.
    /// </remarks>
    public class COMPONENT_X_EQUIPMENTService : ICOMPONENT_X_EQUIPMENTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the COMPONENT_X_EQUIPMENT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public COMPONENT_X_EQUIPMENTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific component_x_equipment by its primary key</summary>
        /// <param name="id">The primary key of the component_x_equipment</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The component_x_equipment data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.COMPONENT_X_EQUIPMENT.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_EQUIPMENT_EQUIPMENT","GUID_COMPONENT_COMPONENT"];
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

        /// <summary>Retrieves a list of component_x_equipments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of component_x_equipments</returns>/// <exception cref="Exception"></exception>
        public async Task<List<COMPONENT_X_EQUIPMENT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetCOMPONENT_X_EQUIPMENT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new component_x_equipment</summary>
        /// <param name="model">The component_x_equipment data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(COMPONENT_X_EQUIPMENT model)
        {
            model.GUID = await CreateCOMPONENT_X_EQUIPMENT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific component_x_equipment by its primary key</summary>
        /// <param name="id">The primary key of the component_x_equipment</param>
        /// <param name="updatedEntity">The component_x_equipment data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, COMPONENT_X_EQUIPMENT updatedEntity)
        {
            await UpdateCOMPONENT_X_EQUIPMENT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific component_x_equipment by its primary key</summary>
        /// <param name="id">The primary key of the component_x_equipment</param>
        /// <param name="updatedEntity">The component_x_equipment data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<COMPONENT_X_EQUIPMENT> updatedEntity)
        {
            await PatchCOMPONENT_X_EQUIPMENT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific component_x_equipment by its primary key</summary>
        /// <param name="id">The primary key of the component_x_equipment</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteCOMPONENT_X_EQUIPMENT(id);
            return true;
        }
        #region
        private async Task<List<COMPONENT_X_EQUIPMENT>> GetCOMPONENT_X_EQUIPMENT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.COMPONENT_X_EQUIPMENT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<COMPONENT_X_EQUIPMENT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(COMPONENT_X_EQUIPMENT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<COMPONENT_X_EQUIPMENT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateCOMPONENT_X_EQUIPMENT(COMPONENT_X_EQUIPMENT model)
        {
            _dbContext.COMPONENT_X_EQUIPMENT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateCOMPONENT_X_EQUIPMENT(Guid id, COMPONENT_X_EQUIPMENT updatedEntity)
        {
            _dbContext.COMPONENT_X_EQUIPMENT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteCOMPONENT_X_EQUIPMENT(Guid id)
        {
            var entityData = _dbContext.COMPONENT_X_EQUIPMENT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.COMPONENT_X_EQUIPMENT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchCOMPONENT_X_EQUIPMENT(Guid id, JsonPatchDocument<COMPONENT_X_EQUIPMENT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.COMPONENT_X_EQUIPMENT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.COMPONENT_X_EQUIPMENT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}