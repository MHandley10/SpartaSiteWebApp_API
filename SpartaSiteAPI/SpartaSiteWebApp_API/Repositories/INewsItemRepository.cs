using SpartaSiteWebApp_API.Models.Domain;

namespace SpartaSiteWebApp_API.Repositories;

public interface INewsItemRepository
{
	Task<List<NewsItem>> GetAllAsync();
	Task<NewsItem?> GetByIdAsync(Guid id);
	Task<NewsItem> CreateAsync(NewsItem newsItem);
	Task<NewsItem?> UpdateAsync(Guid id, NewsItem newsItem);
	Task<NewsItem?> DeleteAsync(Guid id);
}
