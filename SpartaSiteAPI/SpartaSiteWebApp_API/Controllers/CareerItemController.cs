using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;

namespace SpartaSiteWebApp_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CareerItemController : ControllerBase
{
	private readonly SpartaSiteDbContext dbContext;
	public CareerItemController(SpartaSiteDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var careerItems = await dbContext.CareerItems.ToListAsync();

		return Ok(careerItems);
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var careerItem = await dbContext.CareerItems.FirstOrDefaultAsync(x => x.CareerItemId == id);

		return Ok(careerItem);
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateCareerItemDTO createCareerItemDTO)
	{

	}
}
