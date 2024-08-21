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
    /// The equipmentService responsible for managing equipment related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting equipment information.
    /// </remarks>
    public interface IEQUIPMENTService
    {
        /// <summary>Retrieves a specific equipment by its primary key</summary>
        /// <param name="id">The primary key of the equipment</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The equipment data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of equipments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of equipments</returns>
        Task<List<EQUIPMENT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new equipment</summary>
        /// <param name="model">The equipment data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(EQUIPMENT model);

        /// <summary>Updates a specific equipment by its primary key</summary>
        /// <param name="id">The primary key of the equipment</param>
        /// <param name="updatedEntity">The equipment data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, EQUIPMENT updatedEntity);

        /// <summary>Updates a specific equipment by its primary key</summary>
        /// <param name="id">The primary key of the equipment</param>
        /// <param name="updatedEntity">The equipment data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<EQUIPMENT> updatedEntity);

        /// <summary>Deletes a specific equipment by its primary key</summary>
        /// <param name="id">The primary key of the equipment</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The equipmentService responsible for managing equipment related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting equipment information.
    /// </remarks>
    public class EQUIPMENTService : IEQUIPMENTService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the EQUIPMENT class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public EQUIPMENTService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific equipment by its primary key</summary>
        /// <param name="id">The primary key of the equipment</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The equipment data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.EQUIPMENT.AsQueryable();
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

            string[] navigationProperties = ["GUID_TEMPLATE_EQUIPMENT","GUID_CONTRACTOR_SUPPLIER","GUID_INSTALLER_SUPPLIER","GUID_SERVICE_PROVIDER_SUPPLIER","GUID_NONS_REFERENCE_NONS_REFERENCE","GUID_GIS_ENTITY_GIS_ENTITY","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_WORK_ORDER_WORK_ORDER","GUID_AREA_AREA","GUID_BUILDING_BUILDING","GUID_CONTRACT_ITEM_CONTRACT_ITEM","GUID_COST_CENTER_COST_CENTER","GUID_OPERATIONS_MANAGER_PERSON","GUID_EQUIPMENT_TEMPLATE_EQUIPMENT_TEMPLATE","GUID_EQUIPMENT_GROUP_EQUIPMENT","GUID_EQUIPMENT_CATEGORY_EQUIPMENT_CATEGORY","GUID_COMPONENT_COMPONENT","GUID_ACCOUNT_ACCOUNT","GUID_SUPPLIER_SUPPLIER","GUID_ORGANIZATION_ORGANIZATION","GUID_ORGANIZATION_SECTION_ORGANIZATION_SECTION","GUID_ORGANIZATION_UNIT_ORGANIZATION_UNIT","GUID_DRAWING_DRAWING"];
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

        /// <summary>Retrieves a list of equipments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of equipments</returns>/// <exception cref="Exception"></exception>
        public async Task<List<EQUIPMENT>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetEQUIPMENT(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new equipment</summary>
        /// <param name="model">The equipment data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(EQUIPMENT model)
        {
            model.GUID = await CreateEQUIPMENT(model);
            return model.GUID;
        }

        /// <summary>Updates a specific equipment by its primary key</summary>
        /// <param name="id">The primary key of the equipment</param>
        /// <param name="updatedEntity">The equipment data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, EQUIPMENT updatedEntity)
        {
            await UpdateEQUIPMENT(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific equipment by its primary key</summary>
        /// <param name="id">The primary key of the equipment</param>
        /// <param name="updatedEntity">The equipment data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<EQUIPMENT> updatedEntity)
        {
            await PatchEQUIPMENT(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific equipment by its primary key</summary>
        /// <param name="id">The primary key of the equipment</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteEQUIPMENT(id);
            return true;
        }
        #region
        private async Task<List<EQUIPMENT>> GetEQUIPMENT(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.EQUIPMENT.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<EQUIPMENT>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(EQUIPMENT), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<EQUIPMENT, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateEQUIPMENT(EQUIPMENT model)
        {
            _dbContext.EQUIPMENT.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateEQUIPMENT(Guid id, EQUIPMENT updatedEntity)
        {
            _dbContext.EQUIPMENT.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteEQUIPMENT(Guid id)
        {
            var entityData = _dbContext.EQUIPMENT.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.EQUIPMENT.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchEQUIPMENT(Guid id, JsonPatchDocument<EQUIPMENT> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.EQUIPMENT.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.EQUIPMENT.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}