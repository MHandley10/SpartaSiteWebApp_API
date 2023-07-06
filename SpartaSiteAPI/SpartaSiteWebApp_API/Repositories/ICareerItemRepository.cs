using SpartaSiteWebApp_API.Models.Domain;

namespace SpartaSiteWebApp_API.Repositories;

public interface ICareerItemRepository
{

	Task<List<CareerItem>> GetAllAsync();
	Task<CareerItem?> GetByIdAsync(Guid id);
	Task<CareerItem> CreateAsync(CareerItem careerItem);
	Task<CareerItem?> UpdateAsync(Guid id, CareerItem careerItem);
	Task<CareerItem?> DeleteAsync(Guid id);
}
