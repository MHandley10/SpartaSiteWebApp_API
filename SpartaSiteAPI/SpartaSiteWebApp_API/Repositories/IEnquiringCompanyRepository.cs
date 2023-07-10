using SpartaSiteWebApp_API.Models.Domain;

namespace SpartaSiteWebApp_API.Repositories;

public interface IEnquiringCompanyRepository
{
	Task<List<EnquiringCompany>> GetAllAsync();
	Task<EnquiringCompany?> GetByIdAsync(Guid id);
	Task<EnquiringCompany> CreateAsync(EnquiringCompany company);
	Task<EnquiringCompany?> UpdateAsync(Guid id, EnquiringCompany company);
	Task<EnquiringCompany?> DeleteAsync(Guid id);
}
