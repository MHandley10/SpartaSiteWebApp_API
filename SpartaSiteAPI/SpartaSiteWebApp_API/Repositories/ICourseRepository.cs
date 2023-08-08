using SpartaSiteWebApp_API.Models.Domain;

namespace SpartaSiteWebApp_API.Repositories;

public interface ICourseRepository
{
	Task<List<Course>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true);
	Task<Course?> GetByIdAsync(Guid id);
	Task<Course> CreateAsync(Course course);
	Task<Course?> UpdateAsync(Guid id, Course course);
	Task<Course?> DeleteAsync(Guid id);
}
