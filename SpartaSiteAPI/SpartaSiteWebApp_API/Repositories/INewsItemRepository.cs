using SpartaSiteWebApp_API.Models.Domain;

namespace SpartaSiteWebApp_API.Repositories;

public interface INewsItemRepository
{
	Task<List<NewsItemRepository>> GetAllAsync();
	Task<NewsItemRepository?> GetByIdAsync(Guid id);
	Task<NewsItemRepository> CreateAsync(NewsItemRepository newsItem);
	Task<NewsItemRepository?> UpdateAsync(Guid id, NewsItemRepository newsItem);
	Task<NewsItemRepository?> DeleteAsync(Guid id);
}
