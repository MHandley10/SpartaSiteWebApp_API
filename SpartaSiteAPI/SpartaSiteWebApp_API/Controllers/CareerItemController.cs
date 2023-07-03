using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.CareerItemDTOs;

namespace SpartaSiteWebApp_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CareerItemController : ControllerBase
{
	private readonly SpartaSiteDbContext _dbContext;
	private readonly IMapper _mapper;
	public CareerItemController(SpartaSiteDbContext dbContext, IMapper mapper)
	{
		this._dbContext = dbContext;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var careerItems = await _dbContext.CareerItems.ToListAsync();

		return Ok(_mapper.Map<List<CareerItemDTO>>(careerItems));
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var careerItem = _mapper.Map<CareerItemDTO>(await _dbContext.CareerItems.FirstOrDefaultAsync(x => x.CareerItemId == id));

		return Ok(careerItem);
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateCareerItemDTO createCareerItemDTO)
	{
		try
		{
			var createItem = _mapper.Map<CareerItem>(createCareerItemDTO);
			_dbContext.Add(createItem);
			await _dbContext.SaveChangesAsync();
		}
		catch (Exception)
		{
			return BadRequest("An error occurred, please try again later.");
		}

		return Ok(createCareerItemDTO);
	}

	[HttpPut]
	[Route("{id}")]
	public async Task<IActionResult> Update(UpdateCareerItemDTO updateCareerItemDTO)
	{
		var updateItem = await _dbContext.CareerItems.FirstOrDefaultAsync(x => x.CareerItemId == updateCareerItemDTO.CareerItemId);

		if (updateCareerItemDTO is null)
		{
			return BadRequest("The item you want to update could not be found.");
		}

		updateItem.Title = updateCareerItemDTO.Title ?? updateItem.Title;
		updateItem.Description = updateCareerItemDTO.Description ?? updateItem.Description;
		updateItem.Salary = updateCareerItemDTO.Salary;
		updateItem.CloseDate = updateCareerItemDTO.CloseDate;
		updateItem.IsFilled = updateCareerItemDTO.IsFilled;

		await _dbContext.SaveChangesAsync();

		return Ok(updateCareerItemDTO);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await _dbContext.CareerItems.FirstOrDefaultAsync(x => x.CareerItemId == id);

		if (deleteItem is null)
		{
			return BadRequest("The item you want to delete could not be found.");
		}

		_dbContext.CareerItems.Remove(deleteItem);
		await _dbContext.SaveChangesAsync();

		return Ok(deleteItem);
	}
}
