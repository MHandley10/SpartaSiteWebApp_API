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
	public async Task<List<CareerItem>> GetAllAsync()
	{
		return await _dbContext.CareerItems.Include(x => x.Author).ThenInclude(x => x.Course).ToListAsync();
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

		return careerItem; //await _dbContext.CareerItems.Include(x => x.Author).FirstOrDefaultAsync(x => x.CareerItemId == careerItem.CareerItemId);
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
