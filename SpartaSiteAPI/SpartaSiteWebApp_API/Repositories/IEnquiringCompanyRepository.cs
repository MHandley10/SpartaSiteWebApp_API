using SpartaSiteWebApp_API.Models.Domain;

namespace SpartaSiteWebApp_API.Repositories;

public interface IEnquiringCompanyRepository
{
	Task<List<EnquiringCompany>> GetAllAsync();
	Task<EnquiringCompany?> GetByIdAsync(Guid id);
	Task<EnquiringCompany> CreateAsync(User user);
	Task<EnquiringCompany?> UpdateAsync(Guid id, User user);
	Task<EnquiringCompany?> DeleteAsync(Guid id);
}
