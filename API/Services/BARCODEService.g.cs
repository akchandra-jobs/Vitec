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
    /// The barcodeService responsible for managing barcode related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting barcode information.
    /// </remarks>
    public interface IBARCODEService
    {
        /// <summary>Retrieves a specific barcode by its primary key</summary>
        /// <param name="id">The primary key of the barcode</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The barcode data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of barcodes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of barcodes</returns>
        Task<List<BARCODE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new barcode</summary>
        /// <param name="model">The barcode data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(BARCODE model);

        /// <summary>Updates a specific barcode by its primary key</summary>
        /// <param name="id">The primary key of the barcode</param>
        /// <param name="updatedEntity">The barcode data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, BARCODE updatedEntity);

        /// <summary>Updates a specific barcode by its primary key</summary>
        /// <param name="id">The primary key of the barcode</param>
        /// <param name="updatedEntity">The barcode data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<BARCODE> updatedEntity);

        /// <summary>Deletes a specific barcode by its primary key</summary>
        /// <param name="id">The primary key of the barcode</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The barcodeService responsible for managing barcode related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting barcode information.
    /// </remarks>
    public class BARCODEService : IBARCODEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the BARCODE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public BARCODEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific barcode by its primary key</summary>
        /// <param name="id">The primary key of the barcode</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The barcode data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.BARCODE.AsQueryable();
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

            string[] navigationProperties = ["GUID_BUILDING_BUILDING","GUID_AREA_AREA","GUID_EQUIPMENT_EQUIPMENT","GUID_COMPONENT_COMPONENT","GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER"];
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

        /// <summary>Retrieves a list of barcodes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of barcodes</returns>/// <exception cref="Exception"></exception>
        public async Task<List<BARCODE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetBARCODE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new barcode</summary>
        /// <param name="model">The barcode data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(BARCODE model)
        {
            model.GUID = await CreateBARCODE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific barcode by its primary key</summary>
        /// <param name="id">The primary key of the barcode</param>
        /// <param name="updatedEntity">The barcode data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, BARCODE updatedEntity)
        {
            await UpdateBARCODE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific barcode by its primary key</summary>
        /// <param name="id">The primary key of the barcode</param>
        /// <param name="updatedEntity">The barcode data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<BARCODE> updatedEntity)
        {
            await PatchBARCODE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific barcode by its primary key</summary>
        /// <param name="id">The primary key of the barcode</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteBARCODE(id);
            return true;
        }
        #region
        private async Task<List<BARCODE>> GetBARCODE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.BARCODE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<BARCODE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(BARCODE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<BARCODE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateBARCODE(BARCODE model)
        {
            _dbContext.BARCODE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateBARCODE(Guid id, BARCODE updatedEntity)
        {
            _dbContext.BARCODE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteBARCODE(Guid id)
        {
            var entityData = _dbContext.BARCODE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.BARCODE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchBARCODE(Guid id, JsonPatchDocument<BARCODE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.BARCODE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.BARCODE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}