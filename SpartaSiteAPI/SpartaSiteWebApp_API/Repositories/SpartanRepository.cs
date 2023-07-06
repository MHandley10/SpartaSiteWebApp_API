using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;

namespace SpartaSiteWebApp_API.Repositories;

public class SpartanRepository : ISpartanRepository
{
	private readonly SpartaSiteDbContext _dbContext;
	public SpartanRepository(SpartaSiteDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Task<Spartan> CreateAsync(Spartan spartan)
	{
		throw new NotImplementedException();
	}

	public Task<Spartan?> DeleteAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<List<Spartan>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<Spartan?> GetByIdAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<Spartan?> UpdateAsync(Guid id, Spartan spartan)
	{
		throw new NotImplementedException();
	}
}
