using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.CareerItemDTOs;

namespace SpartaSiteWebApp_API.Repositories;

public class CareerItemRepository : ICareerItemRepository
{
	private readonly SpartaSiteDbContext _dbContext;
	public CareerItemRepository(SpartaSiteDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	public async Task<List<CareerItem>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true)
	{
		var careerItems = _dbContext.CareerItems.Include(x => x.Author).ThenInclude(x => x.Course).AsQueryable();

		if (string.IsNullOrWhiteSpace(filterOn) is false && string.IsNullOrWhiteSpace(filterQuery) is false)
		{
			if (filterOn.Equals("Salary", StringComparison.OrdinalIgnoreCase))
			{
				careerItems = careerItems.Where(x => x.Salary.Equals(decimal.Parse(filterQuery)));
			}
			else if (filterOn.Equals("Title", StringComparison.OrdinalIgnoreCase))
			{
				careerItems = careerItems.Where(x => x.Title.Contains(filterQuery));
			}
		}

		if (string.IsNullOrWhiteSpace(sortBy) is false)
		{
			if (sortBy.Equals("CloseDate", StringComparison.OrdinalIgnoreCase))
			{
				careerItems = isAscending ? careerItems.OrderBy(x => x.CloseDate) : careerItems.OrderByDescending(x => x.CloseDate);
			}
			else if (sortBy.Equals("PostDate", StringComparison.OrdinalIgnoreCase))
			{
				careerItems = isAscending ? careerItems.OrderBy(x => x.PostDate) : careerItems.OrderByDescending(x => x.PostDate);
			}
			else if (sortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
			{
				careerItems = isAscending ? careerItems.OrderBy(x => x.Title) : careerItems.OrderByDescending(x => x.Title);
			}
			else if (sortBy.Equals("Salary", StringComparison.OrdinalIgnoreCase))
			{
				careerItems = isAscending ? careerItems.OrderBy(x => x.Salary) : careerItems.OrderByDescending(x => x.Salary);
			}
			else if (sortBy.Equals("Author", StringComparison.OrdinalIgnoreCase))
			{
				careerItems = isAscending ? careerItems.OrderBy(x => x.Author) : careerItems.OrderByDescending(x => x.Author);
			}
			else if (sortBy.Equals("IsFilled", StringComparison.OrdinalIgnoreCase))
			{
				careerItems = isAscending ? careerItems.OrderBy(x => x.IsFilled) : careerItems.OrderByDescending(x => x.IsFilled);
			}
		}

		return await careerItems.ToListAsync();
	}
	public async Task<CareerItem?> GetByIdAsync(Guid id)
	{
		return await _dbContext.CareerItems.Include(x => x.Author).ThenInclude(x => x.Course).FirstOrDefaultAsync(x => x.CareerItemId == id);
	}
	public async Task<CareerItem> CreateAsync(CareerItem careerItem)
	{
		careerItem.PostDate = DateTime.Now;
		careerItem.Author = await _dbContext.Spartans.FirstOrDefaultAsync(x => x.SpartanId == careerItem.SpartanId);
		await _dbContext.CareerItems.AddAsync(careerItem);
		await _dbContext.SaveChangesAsync();

		return careerItem;
	}
	public async Task<CareerItem?> UpdateAsync(Guid id, CareerItem careerItem)
	{
		var updateItem = await _dbContext.CareerItems.FirstOrDefaultAsync(x => x.CareerItemId == id);

		if (updateItem is null)
		{
			return null;
		}

		updateItem.Title = careerItem.Title ?? updateItem.Title;
		updateItem.Description = careerItem.Description ?? updateItem.Description;
		updateItem.Salary = careerItem.Salary;
		updateItem.CloseDate = careerItem.CloseDate;
		updateItem.IsFilled = careerItem.IsFilled;

		await _dbContext.SaveChangesAsync();

		return updateItem;
	}
	public async Task<CareerItem?> DeleteAsync(Guid id)
	{
		var existingItem = await _dbContext.CareerItems.FirstOrDefaultAsync(x => x.CareerItemId == id);

		if (existingItem is null)
		{
			return null;
		}

		_dbContext.CareerItems.Remove(existingItem);

		await _dbContext.SaveChangesAsync();

		return existingItem;
	}
}
