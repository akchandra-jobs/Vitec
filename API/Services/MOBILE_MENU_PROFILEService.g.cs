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
    /// The mobile_menu_profileService responsible for managing mobile_menu_profile related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting mobile_menu_profile information.
    /// </remarks>
    public interface IMOBILE_MENU_PROFILEService
    {
        /// <summary>Retrieves a specific mobile_menu_profile by its primary key</summary>
        /// <param name="id">The primary key of the mobile_menu_profile</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The mobile_menu_profile data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of mobile_menu_profiles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of mobile_menu_profiles</returns>
        Task<List<MOBILE_MENU_PROFILE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new mobile_menu_profile</summary>
        /// <param name="model">The mobile_menu_profile data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(MOBILE_MENU_PROFILE model);

        /// <summary>Updates a specific mobile_menu_profile by its primary key</summary>
        /// <param name="id">The primary key of the mobile_menu_profile</param>
        /// <param name="updatedEntity">The mobile_menu_profile data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, MOBILE_MENU_PROFILE updatedEntity);

        /// <summary>Updates a specific mobile_menu_profile by its primary key</summary>
        /// <param name="id">The primary key of the mobile_menu_profile</param>
        /// <param name="updatedEntity">The mobile_menu_profile data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<MOBILE_MENU_PROFILE> updatedEntity);

        /// <summary>Deletes a specific mobile_menu_profile by its primary key</summary>
        /// <param name="id">The primary key of the mobile_menu_profile</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The mobile_menu_profileService responsible for managing mobile_menu_profile related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting mobile_menu_profile information.
    /// </remarks>
    public class MOBILE_MENU_PROFILEService : IMOBILE_MENU_PROFILEService
    {
        private readonly VitecContext _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the MOBILE_MENU_PROFILE class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public MOBILE_MENU_PROFILEService(VitecContext dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific mobile_menu_profile by its primary key</summary>
        /// <param name="id">The primary key of the mobile_menu_profile</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The mobile_menu_profile data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.MOBILE_MENU_PROFILE.AsQueryable();
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

            string[] navigationProperties = ["GUID_USER_UPDATED_BY_USR","GUID_USER_CREATED_BY_USR"];
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

        /// <summary>Retrieves a list of mobile_menu_profiles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of mobile_menu_profiles</returns>/// <exception cref="Exception"></exception>
        public async Task<List<MOBILE_MENU_PROFILE>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetMOBILE_MENU_PROFILE(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new mobile_menu_profile</summary>
        /// <param name="model">The mobile_menu_profile data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(MOBILE_MENU_PROFILE model)
        {
            model.GUID = await CreateMOBILE_MENU_PROFILE(model);
            return model.GUID;
        }

        /// <summary>Updates a specific mobile_menu_profile by its primary key</summary>
        /// <param name="id">The primary key of the mobile_menu_profile</param>
        /// <param name="updatedEntity">The mobile_menu_profile data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, MOBILE_MENU_PROFILE updatedEntity)
        {
            await UpdateMOBILE_MENU_PROFILE(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific mobile_menu_profile by its primary key</summary>
        /// <param name="id">The primary key of the mobile_menu_profile</param>
        /// <param name="updatedEntity">The mobile_menu_profile data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<MOBILE_MENU_PROFILE> updatedEntity)
        {
            await PatchMOBILE_MENU_PROFILE(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific mobile_menu_profile by its primary key</summary>
        /// <param name="id">The primary key of the mobile_menu_profile</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteMOBILE_MENU_PROFILE(id);
            return true;
        }
        #region
        private async Task<List<MOBILE_MENU_PROFILE>> GetMOBILE_MENU_PROFILE(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MOBILE_MENU_PROFILE.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MOBILE_MENU_PROFILE>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MOBILE_MENU_PROFILE), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MOBILE_MENU_PROFILE, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateMOBILE_MENU_PROFILE(MOBILE_MENU_PROFILE model)
        {
            _dbContext.MOBILE_MENU_PROFILE.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.GUID;
        }

        private async Task UpdateMOBILE_MENU_PROFILE(Guid id, MOBILE_MENU_PROFILE updatedEntity)
        {
            _dbContext.MOBILE_MENU_PROFILE.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteMOBILE_MENU_PROFILE(Guid id)
        {
            var entityData = _dbContext.MOBILE_MENU_PROFILE.FirstOrDefault(entity => entity.GUID == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MOBILE_MENU_PROFILE.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchMOBILE_MENU_PROFILE(Guid id, JsonPatchDocument<MOBILE_MENU_PROFILE> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MOBILE_MENU_PROFILE.FirstOrDefault(t => t.GUID == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MOBILE_MENU_PROFILE.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}