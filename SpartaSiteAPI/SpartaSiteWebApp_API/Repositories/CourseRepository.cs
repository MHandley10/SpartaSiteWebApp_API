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

	public async Task<List<Course>> GetAllAsync()
	{
		return await _dbContext.Courses.ToListAsync();
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
