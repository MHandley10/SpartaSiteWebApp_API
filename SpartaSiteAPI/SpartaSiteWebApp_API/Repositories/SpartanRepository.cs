using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.SpartanDTOs;

namespace SpartaSiteWebApp_API.Repositories;

public class SpartanRepository : ISpartanRepository
{
	private readonly SpartaSiteDbContext _dbContext;
	public SpartanRepository(SpartaSiteDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Spartan> CreateAsync(Spartan spartan)
	{
		spartan.Course = await _dbContext.Courses.FirstOrDefaultAsync(x => x.CourseId == spartan.CourseId);
		if (spartan.Course is null)
		{
			spartan.CourseId = null;
		}
		spartan.CV = await _dbContext.CVs.FirstOrDefaultAsync(x => x.CVId == spartan.CVId);
		if (spartan.CV is null)
		{
			spartan.CVId = null;
		}
		await _dbContext.Spartans.AddAsync(spartan);
		await _dbContext.SaveChangesAsync();

		return spartan;
	}

	public async Task<Spartan?> DeleteAsync(Guid id)
	{
		var existingItem = await _dbContext.Spartans.FirstOrDefaultAsync(x => x.SpartanId == id);

		if (existingItem is null)
		{
			return null;
		}

		_dbContext.Spartans.Remove(existingItem);

		await _dbContext.SaveChangesAsync();

		return existingItem;
	}

	public async Task<List<Spartan>> GetAllAsync()
	{
		return await _dbContext.Spartans.Include(x => x.Course).Include(x => x.CV).ToListAsync();
	}

	public async Task<Spartan?> GetByIdAsync(Guid id)
	{
		var spartan = await _dbContext.Spartans.Include(x => x.Course).Include(x => x.CV).FirstOrDefaultAsync(x => x.SpartanId == id);

		return spartan;
	}

	public async Task<Spartan?> UpdateAsync(Guid id, Spartan spartan)
	{
		var updateItem = await _dbContext.Spartans.FirstOrDefaultAsync(x => x.SpartanId == id);

		if (updateItem is null)
		{
			return null;
		}

		updateItem.FirstName = spartan.FirstName ?? updateItem.FirstName;
		updateItem.MiddleName = spartan.MiddleName ?? updateItem.MiddleName;
		updateItem.LastName = spartan.LastName ?? updateItem.LastName;
		updateItem.DateOfBirth = spartan.DateOfBirth;
		updateItem.Address = spartan.Address ?? updateItem.Address;
		updateItem.PostCode = spartan.PostCode ?? updateItem.PostCode;
		updateItem.CountryOfResidence = spartan.CountryOfResidence ?? updateItem.CountryOfResidence;
		updateItem.Title = spartan.Title ?? updateItem.Title;
		updateItem.ContactNumber = spartan.ContactNumber ?? updateItem.ContactNumber;
		updateItem.Email = spartan.Email ?? updateItem.Email;
		updateItem.About = spartan.About ?? updateItem.About;
		updateItem.Education = spartan.Education ?? updateItem.Education;
		updateItem.Experience = spartan.Experience ?? updateItem.Experience;
		updateItem.Skills = spartan.Skills ?? updateItem.Skills;
		updateItem.PositionName = spartan.PositionName ?? updateItem.PositionName;
		updateItem.Salary = spartan.Salary;
		
		//TODO Decide whether or not to prevent people from entering incorrect Ids and if so whether or not to prevent having no CV or course attached.

		updateItem.CVId = spartan.CVId ?? updateItem.CVId;
		updateItem.CourseId = spartan.CourseId ?? updateItem.CourseId;

		await _dbContext.SaveChangesAsync();

		return updateItem;
	}
}
