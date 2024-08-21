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
    /// The productsService responsible for managing products related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting products information.
    /// </remarks>
    public interface IProductsService
    {
        /// <summary>Retrieves a specific products by its primary key</summary>
        /// <param name="id">The primary key of the products</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The products data</returns>
        Task<dynamic> GetById(Int64 id, string fields);

        /// <summary>Retrieves a list of productss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productss</returns>
        Task<List<Products>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new products</summary>
        /// <param name="model">The products data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Int64> Create(Products model);

        /// <summary>Updates a specific products by its primary key</summary>
        /// <param name="id">The primary key of the products</param>
        /// <param name="updatedEntity">The products data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Int64 id, Products updatedEntity);

        /// <summary>Updates a specific products by its primary key</summary>
        /// <param name="id">The primary key of the products</param>
        /// <param name="updatedEntity">The products data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Int64 id, JsonPatchDocument<Products> updatedEntity);

        /// <summary>Deletes a specific products by its primary key</summary>
        /// <param name="id">The primary key of the products</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Int64 id);
    }

    /// <summary>
    /// The productsService responsible for managing products related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting products information.
    /// </remarks>
    public class ProductsService : IProductsService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the Products class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ProductsService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific products by its primary key</summary>
        /// <param name="id">The primary key of the products</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The products data</returns>
        public async Task<dynamic> GetById(Int64 id, string fields)
        {
            var query = _dbContext.Products.AsQueryable();
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

        /// <summary>Retrieves a list of productss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of productss</returns>/// <exception cref="Exception"></exception>
        public async Task<List<Products>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetProducts(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new products</summary>
        /// <param name="model">The products data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Int64> Create(Products model)
        {
            model.Id = await CreateProducts(model);
            return model.Id;
        }

        /// <summary>Updates a specific products by its primary key</summary>
        /// <param name="id">The primary key of the products</param>
        /// <param name="updatedEntity">The products data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Int64 id, Products updatedEntity)
        {
            await UpdateProducts(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific products by its primary key</summary>
        /// <param name="id">The primary key of the products</param>
        /// <param name="updatedEntity">The products data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Int64 id, JsonPatchDocument<Products> updatedEntity)
        {
            await PatchProducts(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific products by its primary key</summary>
        /// <param name="id">The primary key of the products</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Int64 id)
        {
            await DeleteProducts(id);
            return true;
        }
        #region
        private async Task<List<Products>> GetProducts(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Products.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Products>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Products), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Products, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Int64> CreateProducts(Products model)
        {
            _dbContext.Products.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        private async Task UpdateProducts(Int64 id, Products updatedEntity)
        {
            _dbContext.Products.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteProducts(Int64 id)
        {
            var entityData = _dbContext.Products.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Products.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchProducts(Int64 id, JsonPatchDocument<Products> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Products.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Products.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}