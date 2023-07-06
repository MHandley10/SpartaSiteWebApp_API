using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.CareerItemDTOs;

namespace SpartaSiteWebApp_API.Repositories;

public class CareerItemRepository : ICareerItemRepository
{
	private readonly SpartaSiteDbContext dbContext;
	public CareerItemRepository(SpartaSiteDbContext dbContext)
	{
		this.dbContext = dbContext;
	}
	public async Task<List<CareerItem>> GetAllAsync()
	{
		return await dbContext.CareerItems.Include(x => x.Author).ToListAsync();
	}
	public async Task<CareerItem?> GetByIdAsync(Guid id)
	{
		return await dbContext.CareerItems.Include(x => x.Author).FirstOrDefaultAsync(x => x.CareerItemId == id);
	}
	public async Task<CareerItem> CreateAsync(CareerItem careerItem)
	{
		careerItem.Author = await dbContext.Spartans.FirstOrDefaultAsync(x => x.SpartanId == careerItem.SpartanId);
		await dbContext.CareerItems.AddAsync(careerItem);
		await dbContext.SaveChangesAsync();

		var newCareerItem = await GetByIdAsync(careerItem.CareerItemId);
		return newCareerItem;
	}
	public async Task<CareerItem?> UpdateAsync(Guid id, CareerItem careerItem)
	{
		var existingItem = await dbContext.CareerItems.FirstOrDefaultAsync(x => x.CareerItemId == id);

		if (existingItem is null)
		{
			return null;
		}

		existingItem.Title = careerItem.Title ?? existingItem.Title;
		existingItem.Description = careerItem.Description ?? existingItem.Description;
		existingItem.Salary = careerItem.Salary;
		existingItem.CloseDate = careerItem.CloseDate;
		existingItem.IsFilled = careerItem.IsFilled;

		await dbContext.SaveChangesAsync();

		return existingItem;
	}
	public async Task<CareerItem?> DeleteAsync(Guid id)
	{
		var existingItem = await dbContext.CareerItems.FirstOrDefaultAsync(x => x.CareerItemId == id);

		if (existingItem is null)
		{
			return null;
		}

		dbContext.CareerItems.Remove(existingItem);

		await dbContext.SaveChangesAsync();

		return existingItem;
	}
}
