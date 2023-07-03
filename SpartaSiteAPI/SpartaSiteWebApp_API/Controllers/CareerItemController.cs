using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO;

namespace SpartaSiteWebApp_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CareerItemController : ControllerBase
{
	private readonly SpartaSiteDbContext dbContext;
	private readonly IMapper _mapper;
	public CareerItemController(SpartaSiteDbContext dbContext, IMapper mapper)
	{
		this.dbContext = dbContext;
		_mapper = mapper;
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
	public async Task<IActionResult> Create(Spartan? spartan, CreateCareerItemDTO createCareerItemDTO)
	{
		try
		{
			var createItem = _mapper.Map<CareerItem>(createCareerItemDTO);
			createItem.Author = spartan;
			createItem.SpartanId = spartan.SpartanId;
			dbContext.Add(createItem);
			await dbContext.SaveChangesAsync();
		}
		catch (Exception)
		{
			return BadRequest("An error occurred, please try again later.");
		}

		return Ok(createCareerItemDTO);
	}

	[HttpPost]
	[Route("{id}")]
	public async Task<IActionResult> Update(UpdateCareerItemDTO updateCareerItemDTO)
	{
		var updateItem = await dbContext.CareerItems.FirstOrDefaultAsync(x => x.CareerItemId == updateCareerItemDTO.CareerItemId);

		if (updateCareerItemDTO is null)
		{
			return BadRequest("The item you want to update could not be found.");
		}

		updateItem.Title = updateCareerItemDTO.Title ?? updateItem.Title;
		updateItem.Description = updateCareerItemDTO.Description ?? updateItem.Description;
		updateItem.Salary = updateCareerItemDTO.Salary;
		updateItem.CloseDate = updateCareerItemDTO.CloseDate;
		updateItem.IsFilled = updateCareerItemDTO.IsFilled;

		await dbContext.SaveChangesAsync();

		return Ok(updateCareerItemDTO);
	}

	[HttpPost]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await dbContext.CareerItems.FirstOrDefaultAsync(x => x.CareerItemId == id);

		if (deleteItem is null)
		{
			return BadRequest("The item you want to delete could not be found.");
		}

		dbContext.CareerItems.Remove(deleteItem);
		await dbContext.SaveChangesAsync();

		return Ok(deleteItem);
	}
}
