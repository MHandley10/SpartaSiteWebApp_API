using SpartaSiteWebApp_API.Models.Domain;

namespace SpartaSiteWebApp_API.Repositories;

public interface IEnquiringCompanyRepository
{
	Task<List<EnquiringCompany>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true);
	Task<EnquiringCompany?> GetByIdAsync(Guid id);
	Task<EnquiringCompany> CreateAsync(EnquiringCompany company);
	Task<EnquiringCompany?> UpdateAsync(Guid id, EnquiringCompany company);
	Task<EnquiringCompany?> DeleteAsync(Guid id);
}
