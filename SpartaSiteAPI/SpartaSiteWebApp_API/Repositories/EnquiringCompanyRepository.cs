using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;

namespace SpartaSiteWebApp_API.Repositories;

public class EnquiringCompanyRepository : IEnquiringCompanyRepository
{
	private readonly SpartaSiteDbContext _dbContext;

	public EnquiringCompanyRepository(SpartaSiteDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<EnquiringCompany> CreateAsync(EnquiringCompany company)
	{
		company.DateEnquired = DateTime.Now;
		await _dbContext.EnquiringCompanies.AddAsync(company);
		await _dbContext.SaveChangesAsync();

		return company;
	}

	public async Task<EnquiringCompany?> DeleteAsync(Guid id)
	{
		var existingItem = await _dbContext.EnquiringCompanies.FirstOrDefaultAsync(x => x.EnquiringCompanyId == id);

		if (existingItem is null)
		{
			return null;
		}

		_dbContext.EnquiringCompanies.Remove(existingItem);

		await _dbContext.SaveChangesAsync();

		return existingItem;
	}

	public async Task<List<EnquiringCompany>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true)
	{
		var enquiringCompanies = _dbContext.EnquiringCompanies.AsQueryable();

		if (string.IsNullOrWhiteSpace(filterOn) is false && string.IsNullOrWhiteSpace(filterQuery) is false)
		{
			if (filterOn.Equals("CompanyName", StringComparison.OrdinalIgnoreCase))
			{
				enquiringCompanies = enquiringCompanies.Where(x => x.CompanyName.Contains(filterQuery));
			}
			else if (filterOn.Equals("RepresentativeName", StringComparison.OrdinalIgnoreCase))
			{
				enquiringCompanies = enquiringCompanies.Where(x => x.RepresentativeName.Contains(filterQuery));
			}
			else if (filterOn.Equals("DateEnquired", StringComparison.OrdinalIgnoreCase))
			{
				enquiringCompanies = enquiringCompanies.Where(x => x.DateEnquired.Equals(DateTime.Parse(filterQuery)));
			}
			else if (filterOn.Equals("NumberOfSpartansRequired", StringComparison.OrdinalIgnoreCase))
			{
				enquiringCompanies = enquiringCompanies.Where(x => x.NumberOfSpartansRequired.Equals(Int32.Parse(filterQuery)));
			}
			else if (filterOn.Equals("StreamNeeded", StringComparison.OrdinalIgnoreCase))
			{
				enquiringCompanies = enquiringCompanies.Where(x => x.StreamNeeded.Contains(filterQuery));
			}
			else if (filterOn.Equals("CourseTypeNeeded", StringComparison.OrdinalIgnoreCase))
			{
				enquiringCompanies = enquiringCompanies.Where(x => x.CourseTypeNeeded.Contains(filterQuery));
			}
		}

		if (string.IsNullOrWhiteSpace(sortBy) is false)
		{
			if (sortBy.Equals("CompanyName", StringComparison.OrdinalIgnoreCase))
			{
				enquiringCompanies = isAscending ? enquiringCompanies.OrderBy(x => x.CompanyName) : enquiringCompanies.OrderByDescending(x => x.CompanyName);
			}
			else if (sortBy.Equals("RepresentativeName", StringComparison.OrdinalIgnoreCase))
			{
				enquiringCompanies = isAscending ? enquiringCompanies.OrderBy(x => x.RepresentativeName) : enquiringCompanies.OrderByDescending(x => x.RepresentativeName);
			}
			else if (sortBy.Equals("DateEnquired", StringComparison.OrdinalIgnoreCase))
			{
				enquiringCompanies = isAscending ? enquiringCompanies.OrderBy(x => x.DateEnquired) : enquiringCompanies.OrderByDescending(x => x.DateEnquired);
			}
			else if (sortBy.Equals("StreamNeeded", StringComparison.OrdinalIgnoreCase))
			{
				enquiringCompanies = isAscending ? enquiringCompanies.OrderBy(x => x.StreamNeeded) : enquiringCompanies.OrderByDescending(x => x.StreamNeeded);
			}
			else if (sortBy.Equals("CourseTypeNeeded", StringComparison.OrdinalIgnoreCase))
			{
				enquiringCompanies = isAscending ? enquiringCompanies.OrderBy(x => x.CourseTypeNeeded) : enquiringCompanies.OrderByDescending(x => x.CourseTypeNeeded);
			}
		}
		
		return await enquiringCompanies.ToListAsync();
	}

	public async Task<EnquiringCompany?> GetByIdAsync(Guid id)
	{
		return await _dbContext.EnquiringCompanies.FirstOrDefaultAsync(x => x.EnquiringCompanyId == id);
	}

	public async Task<EnquiringCompany?> UpdateAsync(Guid id, EnquiringCompany company)
	{

		var updateItem = await _dbContext.EnquiringCompanies.FirstOrDefaultAsync(x => x.EnquiringCompanyId == id);

		if (updateItem is null)
		{
			return null;
		}

		updateItem.CourseTypeNeeded = company.CourseTypeNeeded ?? updateItem.CourseTypeNeeded;
		updateItem.CompanyName = company.CompanyName ?? updateItem.CompanyName;
		updateItem.ContactNumber = company.ContactNumber ?? updateItem.ContactNumber;
		updateItem.Email = company.Email ?? updateItem.Email;
		updateItem.NumberOfSpartansRequired = company.NumberOfSpartansRequired;
		updateItem.RepresentativeName = company.RepresentativeName ?? updateItem.RepresentativeName;
		updateItem.StreamNeeded = company.StreamNeeded ?? updateItem.StreamNeeded;

		await _dbContext.SaveChangesAsync();

		return updateItem;
	}
}
