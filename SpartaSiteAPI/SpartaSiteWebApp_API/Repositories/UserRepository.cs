using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.UserDTOs;

namespace SpartaSiteWebApp_API.Repositories;

public class UserRepository : IUserRepository
{
	private readonly SpartaSiteDbContext _dbContext;
	public UserRepository(SpartaSiteDbContext dbContext)
	{
		_dbContext = dbContext;
	} 
	public async Task<User> CreateAsync(User user)
	{
		_dbContext.Users.Add(user);
		await _dbContext.SaveChangesAsync();

		return user;
	}

	public async Task<User?> DeleteAsync(Guid id)
	{
		var deleteItem = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

		if (deleteItem is null)
		{
			return null;
		}

		_dbContext.Users.Remove(deleteItem);
		await _dbContext.SaveChangesAsync();

		return deleteItem;
	}

	public async Task<List<User>> GetAllAsync()
	{
		return await _dbContext.Users.Include(x => x.CV).ToListAsync();
	}

	public async Task<User?> GetByIdAsync(Guid id)
	{
		var user = await _dbContext.Users.Include(x => x.CV).FirstOrDefaultAsync(x => x.UserId == id);

		return user;
	}

	public async Task<User?> UpdateAsync(Guid id, User user)
	{
		var updateItem = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

		if (updateItem is null)
		{
			return null;
		}

		updateItem.FirstName = user.FirstName ?? updateItem.FirstName;
		updateItem.MiddleName = user.MiddleName ?? updateItem.MiddleName;
		updateItem.LastName = user.LastName ?? updateItem.LastName;
		updateItem.DateOfBirth = user.DateOfBirth;
		updateItem.Address = user.Address ?? updateItem.Address;
		updateItem.PostCode = user.PostCode ?? updateItem.PostCode;
		updateItem.CountryOfResidence = user.CountryOfResidence ?? updateItem.CountryOfResidence;
		updateItem.Title = user.Title ?? updateItem.Title;
		updateItem.ContactNumber = user.ContactNumber ?? updateItem.ContactNumber;
		updateItem.Email = user.Email ?? updateItem.Email;
		updateItem.About = user.About ?? updateItem.About;
		updateItem.Education = user.Education ?? updateItem.Education;
		updateItem.Experience = user.Experience ?? updateItem.Experience;
		updateItem.Skills = user.Skills ?? updateItem.Skills;

		await _dbContext.SaveChangesAsync();

		return updateItem;
	}
}
