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
    /// The control_list_item_answerService responsible for managing control_list_item_answer related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting control_list_item_answer information.
    /// </remarks>
    public interface ICONTROL_LIST_ITEM_ANSWERService
    {
        /// <summary>Retrieves a specific control_list_item_answer by its primary key</summary>
        /// <param name="id">The primary key of the control_list_item_answer</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The control_list_item_answer data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of control_list_item_answers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of control_list_item_answers</returns>
        Task<List<CONTROL_LIST_ITEM_ANSWER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new control_list_item_answer</summary>
        /// <param name="model">The control_list_item_answer data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(CONTROL_LIST_ITEM_ANSWER model);

        /// <summary>Updates a specific control_list_item_answer by its primary key</summary>
        /// <param name="id">The primary key of the control_list_item_answer</param>
        /// <param name="updatedEntity">The control_list_item_answer data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, CONTROL_LIST_ITEM_ANSWER updatedEntity);

        /// <summary>Updates a specific control_list_item_answer by its primary key</summary>
        /// <param name="id">The primary key of the control_list_item_answer</param>
        /// <param name="updatedEntity">The control_list_item_answer data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<CONTROL_LIST_ITEM_ANSWER> updatedEntity);

        /// <summary>Deletes a specific control_list_item_answer by its primary key</summary>
        /// <param name="id">The primary key of the control_list_item_answer</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The control_list_item_answerService responsible for managing control_list_item_answer related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting control_list_item_answer information.
    /// </remarks>
    public class CONTROL_LIST_ITEM_ANSWERService : ICONTROL_LIST_ITEM_ANSWERService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the CONTROL_LIST_ITEM_ANSWER class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public CONTROL_LIST_ITEM_ANSWERService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific control_list_item_answer by its primary key</summary>
        /// <param name="id">The primary key of the control_list_item_answer</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The control_list_item_answer data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.CONTROL_LIST_ITEM_ANSWER.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR","GUID_DATA_OWNER_DATA_OWNER","GUID_CONTROL_LIST_ITEM_CONTROL_LIST_ITEM","GUID_CONTROL_LIST_X_ENTITY_CONTROL_LIST_X_ENTITY"];
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

        /// <summary>Retrieves a list of control_list_item_answers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of control_list_item_answers</returns>/// <exception cref="Exception"></exception>
        public async Task<List<CONTROL_LIST_ITEM_ANSWER>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetCONTROL_LIST_ITEM_ANSWER(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new control_list_item_answer</summary>
        /// <param name="model">The control_list_item_answer data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(CONTROL_LIST_ITEM_ANSWER model)
        {
            model.GUID = await CreateCONTROL_LIST_ITEM_ANSWER(model);
            return model.GUID;
        }

        /// <summary>Updates a specific control_list_item_answer by its primary key</summary>
        /// <param name="id">The primary key of the control_list_item_answer</param>
        /// <param name="updatedEntity">The control_list_item_answer data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, CONTROL_LIST_ITEM_ANSWER updatedEntity)
        {
            await UpdateCONTROL_LIST_ITEM_ANSWER(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific control_list_item_answer by its primary key</summary>
        /// <param name="id">The primary key of the control_list_item_answer</param>
        /// <param name="updatedEntity">The control_list_item_answer data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<CONTROL_LIST_ITEM_ANSWER> updatedEntity)
        {
            await PatchCONTROL_LIST_ITEM_ANSWER(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific control_list_item_answer by its primary key</summary>
        /// <param name="id">The primary key of the control_list_item_answer</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteCONTROL_LIST_ITEM_ANSWER(id);
            return true;
        }
        #region
        private async Task<List<CONTROL_LIST_ITEM_ANSWER>> GetCONTROL_LIST_ITEM_ANSWER(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.CONTROL_LIST_ITEM_ANSWER.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<CONTROL_LIST_ITEM_ANSWER>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(CONTROL_LIST_ITEM_ANSWER), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<CONTROL_LIST_ITEM_ANSWER, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateCONTROL_LIST_ITEM_ANSWER(CONTROL_LIST_ITEM_ANSWER model)
        {
            _dbContext.CONTROL_LIST_ITEM_ANSWER.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateCONTROL_LIST_ITEM_ANSWER(Guid id, CONTROL_LIST_ITEM_ANSWER updatedEntity)
        {
            _dbContext.CONTROL_LIST_ITEM_ANSWER.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteCONTROL_LIST_ITEM_ANSWER(Guid id)
        {
            var entityData = _dbContext.CONTROL_LIST_ITEM_ANSWER.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.CONTROL_LIST_ITEM_ANSWER.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchCONTROL_LIST_ITEM_ANSWER(Guid id, JsonPatchDocument<CONTROL_LIST_ITEM_ANSWER> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.CONTROL_LIST_ITEM_ANSWER.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.CONTROL_LIST_ITEM_ANSWER.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}