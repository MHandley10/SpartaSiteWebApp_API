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
		newsItem.DateUploaded = DateTime.Now;
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

	public async Task<List<NewsItem>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true)
	{

		var newsItems = _dbContext.NewsItems.AsQueryable();

		if (string.IsNullOrWhiteSpace(filterOn) is false && string.IsNullOrWhiteSpace(filterQuery) is false)
		{
			if (filterOn.Equals("Author", StringComparison.OrdinalIgnoreCase))
			{
				newsItems = newsItems.Where(x => x.Author.Contains(filterQuery));
			}
			else if (filterOn.Equals("Title", StringComparison.OrdinalIgnoreCase))
			{
				newsItems = newsItems.Where(x => x.Title.Contains(filterQuery));
			}
		}

		if (string.IsNullOrWhiteSpace(sortBy) is false)
		{
			if (sortBy.Equals("Author", StringComparison.OrdinalIgnoreCase))
			{
				newsItems = isAscending ? newsItems.OrderBy(x => x.Author) : newsItems.OrderByDescending(x => x.Author);
			}
			else if (sortBy.Equals("RepresentativeName", StringComparison.OrdinalIgnoreCase))
			{
				newsItems = isAscending ? newsItems.OrderBy(x => x.Title) : newsItems.OrderByDescending(x => x.Title);
			}
			else if (sortBy.Equals("DateUploaded", StringComparison.OrdinalIgnoreCase))
			{
				newsItems = isAscending ? newsItems.OrderBy(x => x.DateUploaded) : newsItems.OrderByDescending(x => x.DateUploaded);
			}
		}

			return await newsItems.ToListAsync();
	}

	public async Task<NewsItem?> GetByIdAsync(Guid id)
	{
		return await _dbContext.NewsItems.FirstOrDefaultAsync(x => x.NewsItemId == id);
	}

	public async Task<NewsItem?> UpdateAsync(Guid id, NewsItem newsItem)
	{
		var updateItem = await _dbContext.NewsItems.FirstOrDefaultAsync(x => x.NewsItemId == id);

		if (updateItem is null)
		{
			return null;
		}

		updateItem.Content = newsItem.Content ?? updateItem.Content;
		updateItem.Author = newsItem.Author ?? updateItem.Author;
		updateItem.Title = newsItem.Title ?? updateItem.Title;

		await _dbContext.SaveChangesAsync();

		return updateItem;
	}
}
