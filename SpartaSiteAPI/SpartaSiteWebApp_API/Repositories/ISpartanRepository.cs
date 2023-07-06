using SpartaSiteWebApp_API.Models.Domain;

namespace SpartaSiteWebApp_API.Repositories;

public interface ISpartanRepository
{
	Task<List<Spartan>> GetAllAsync();
	Task<Spartan?> GetByIdAsync(Guid id);
	Task<Spartan> CreateAsync(Spartan spartan);
	Task<Spartan?> UpdateAsync(Guid id, Spartan spartan);
	Task<Spartan?> DeleteAsync(Guid id);
}
