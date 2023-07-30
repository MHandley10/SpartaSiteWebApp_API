using SpartaSiteWebApp_API.Data;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Models.Domain;

namespace SpartaSiteWebApp_API.Repositories;

public class NewsItemRepository : INewsItemRepository
{
	private readonly SpartaSiteDbContext _dbContext;

	public NewsItemRepository(SpartaSiteDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	public async Task<NewsItem> CreateAsync(NewsItem newsItem)
	{
		await _dbContext.NewsItems.AddAsync(newsItem);
		await _dbContext.SaveChangesAsync();
		return newsItem;
	}

	public async Task<NewsItem?> DeleteAsync(Guid id)
	{
		var existingItem = await _dbContext.NewsItems.FirstOrDefaultAsync(x => x.NewsItemId == id);
		if (existingItem is null)
		{
			return null;
		}

		_dbContext.NewsItems.Remove(existingItem);

		await _dbContext.SaveChangesAsync();

		return existingItem;
	}

	public Task<List<NewsItem>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<NewsItem?> GetByIdAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<NewsItem?> UpdateAsync(Guid id, NewsItem newsItem)
	{
		throw new NotImplementedException();
	}
}
