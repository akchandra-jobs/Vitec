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
    /// The productrelationsService responsible for managing productrelations related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productrelations information.
    /// </remarks>
    public interface IProductRelationsService
    {
        /// <summary>Retrieves a specific productrelations by its primary key</summary>
        /// <param name="id">The primary key of the productrelations</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The productrelations data</returns>
        Task<dynamic> GetById(Int64 id, string fields);

        /// <summary>Retrieves a list of productrelationss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productrelationss</returns>
        Task<List<ProductRelations>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new productrelations</summary>
        /// <param name="model">The productrelations data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Int64> Create(ProductRelations model);

        /// <summary>Updates a specific productrelations by its primary key</summary>
        /// <param name="id">The primary key of the productrelations</param>
        /// <param name="updatedEntity">The productrelations data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Int64 id, ProductRelations updatedEntity);

        /// <summary>Updates a specific productrelations by its primary key</summary>
        /// <param name="id">The primary key of the productrelations</param>
        /// <param name="updatedEntity">The productrelations data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Int64 id, JsonPatchDocument<ProductRelations> updatedEntity);

        /// <summary>Deletes a specific productrelations by its primary key</summary>
        /// <param name="id">The primary key of the productrelations</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Int64 id);
    }

    /// <summary>
    /// The productrelationsService responsible for managing productrelations related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting productrelations information.
    /// </remarks>
    public class ProductRelationsService : IProductRelationsService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the ProductRelations class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ProductRelationsService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific productrelations by its primary key</summary>
        /// <param name="id">The primary key of the productrelations</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The productrelations data</returns>
        public async Task<dynamic> GetById(Int64 id, string fields)
        {
            var query = _dbContext.ProductRelations.AsQueryable();
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

            string[] navigationProperties = [];
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

        /// <summary>Retrieves a list of productrelationss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productrelationss</returns>/// <exception cref="Exception"></exception>
        public async Task<List<ProductRelations>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetProductRelations(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new productrelations</summary>
        /// <param name="model">The productrelations data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Int64> Create(ProductRelations model)
        {
            model.Id = await CreateProductRelations(model);
            return model.Id;
        }

        /// <summary>Updates a specific productrelations by its primary key</summary>
        /// <param name="id">The primary key of the productrelations</param>
        /// <param name="updatedEntity">The productrelations data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Int64 id, ProductRelations updatedEntity)
        {
            await UpdateProductRelations(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific productrelations by its primary key</summary>
        /// <param name="id">The primary key of the productrelations</param>
        /// <param name="updatedEntity">The productrelations data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Int64 id, JsonPatchDocument<ProductRelations> updatedEntity)
        {
            await PatchProductRelations(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific productrelations by its primary key</summary>
        /// <param name="id">The primary key of the productrelations</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Int64 id)
        {
            await DeleteProductRelations(id);
            return true;
        }
        #region
        private async Task<List<ProductRelations>> GetProductRelations(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.ProductRelations.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<ProductRelations>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(ProductRelations), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<ProductRelations, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Int64> CreateProductRelations(ProductRelations model)
        {
            _dbContext.ProductRelations.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        private async Task UpdateProductRelations(Int64 id, ProductRelations updatedEntity)
        {
            _dbContext.ProductRelations.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteProductRelations(Int64 id)
        {
            var entityData = _dbContext.ProductRelations.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.ProductRelations.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchProductRelations(Int64 id, JsonPatchDocument<ProductRelations> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.ProductRelations.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.ProductRelations.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}