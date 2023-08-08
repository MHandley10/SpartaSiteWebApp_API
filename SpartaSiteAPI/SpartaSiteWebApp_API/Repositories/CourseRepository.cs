using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.CourseDTOs;

namespace SpartaSiteWebApp_API.Repositories;

public class CourseRepository : ICourseRepository
{
	private readonly SpartaSiteDbContext _dbContext;

	public CourseRepository(SpartaSiteDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	public async Task<Course> CreateAsync(Course course)
	{
		_dbContext.Courses.Add(course);
		await _dbContext.SaveChangesAsync();

		return course;
	}

	public async Task<Course?> DeleteAsync(Guid id)
	{
		var deleteItem = await _dbContext.Courses.FirstOrDefaultAsync(x => x.CourseId == id);

		if (deleteItem is null)
		{
			return null;
		}

		_dbContext.Courses.Remove(deleteItem);
		await _dbContext.SaveChangesAsync();

		return deleteItem;
	}

	public async Task<List<Course>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true)
	{
		var courses = _dbContext.Courses.AsQueryable();

		if (string.IsNullOrWhiteSpace(filterOn) is false && string.IsNullOrWhiteSpace(filterQuery) is false)
		{
			if (filterOn.Equals("StreamName", StringComparison.OrdinalIgnoreCase))
			{
				courses = courses.Where(x => x.StreamName.Contains(filterQuery));
			}
			else if (filterOn.Equals("CourseName", StringComparison.OrdinalIgnoreCase))
			{
				courses = courses.Where(x => x.CourseName.Contains(filterQuery));
			}
			else if (filterOn.Equals("CourseType", StringComparison.OrdinalIgnoreCase))
			{
				courses = courses.Where(x => x.CourseType.Contains(filterQuery));
			}
			else if (filterOn.Equals("StartDate", StringComparison.OrdinalIgnoreCase))
			{
				courses = courses.Where(x => x.StartDate.Equals(DateTime.Parse(filterQuery)));
			}
			else if (filterOn.Equals("EndDate", StringComparison.OrdinalIgnoreCase))
			{
				courses = courses.Where(x => x.EndDate.Equals(DateTime.Parse(filterQuery)));
			}
		}

		if (string.IsNullOrWhiteSpace(sortBy) is false)
		{
			if (sortBy.Equals("StreamName", StringComparison.OrdinalIgnoreCase))
			{
				courses = isAscending ? courses.OrderBy(x => x.StreamName) : courses.OrderByDescending(x => x.StreamName);
			}
			else if (sortBy.Equals("CourseName", StringComparison.OrdinalIgnoreCase))
			{
				courses = isAscending ? courses.OrderBy(x => x.CourseName) : courses.OrderByDescending(x => x.CourseName);
			}
			else if (sortBy.Equals("CourseType", StringComparison.OrdinalIgnoreCase))
			{
				courses = isAscending ? courses.OrderBy(x => x.CourseType) : courses.OrderByDescending(x => x.CourseType);
			}
			else if (sortBy.Equals("StartDate", StringComparison.OrdinalIgnoreCase))
			{
				courses = isAscending ? courses.OrderBy(x => x.StartDate) : courses.OrderByDescending(x => x.StartDate);
			}
			else if (sortBy.Equals("EndDate", StringComparison.OrdinalIgnoreCase))
			{
				courses = isAscending ? courses.OrderBy(x => x.EndDate) : courses.OrderByDescending(x => x.EndDate);
			}
		}

		return await courses.ToListAsync();
	}

	public async Task<Course?> GetByIdAsync(Guid id)
	{
		return await _dbContext.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
	}

	public async Task<Course?> UpdateAsync(Guid id, Course course)
	{
		var updateItem = await _dbContext.Courses.FirstOrDefaultAsync(x => x.CourseId == id);

		if (updateItem is null)
		{
			return null;
		}

		updateItem.StreamName = course.StreamName ?? updateItem.StreamName;
		updateItem.CourseName = course.CourseName ?? updateItem.CourseName;
		updateItem.CourseType = course.CourseType ?? updateItem.CourseType;
		updateItem.StartDate = course.StartDate;
		updateItem.EndDate = course.EndDate;

		await _dbContext.SaveChangesAsync();

		return updateItem;
	}
}
