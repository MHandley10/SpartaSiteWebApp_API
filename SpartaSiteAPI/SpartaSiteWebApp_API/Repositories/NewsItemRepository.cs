namespace SpartaSiteWebApp_API.Repositories;

public class NewsItemRepository : INewsItemRepository
{
	public Task<NewsItemRepository> CreateAsync(NewsItemRepository newsItem)
	{
		throw new NotImplementedException();
	}

	public Task<NewsItemRepository?> DeleteAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<List<NewsItemRepository>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<NewsItemRepository?> GetByIdAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<NewsItemRepository?> UpdateAsync(Guid id, NewsItemRepository newsItem)
	{
		throw new NotImplementedException();
	}
}
