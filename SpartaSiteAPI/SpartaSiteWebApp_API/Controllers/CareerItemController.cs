using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
}
