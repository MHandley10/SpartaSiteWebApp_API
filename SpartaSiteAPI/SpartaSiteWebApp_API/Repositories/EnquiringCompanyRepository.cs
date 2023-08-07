﻿using Microsoft.EntityFrameworkCore;
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

	public async Task<List<EnquiringCompany>> GetAllAsync()
	{
		return await _dbContext.EnquiringCompanies.ToListAsync();
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
