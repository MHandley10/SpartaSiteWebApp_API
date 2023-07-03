using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.EnquiringCopmanyDTOs;
using SpartaSiteWebApp_API.Models.DTO.SpartanDTOs;

namespace SpartaSiteWebApp_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpartanController : ControllerBase
{
	private readonly SpartaSiteDbContext _dbContext;
	private readonly IMapper _mapper;
	public SpartanController(SpartaSiteDbContext dbContext, IMapper mapper)
	{
		this._dbContext = dbContext;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var spartans = await _dbContext.Spartans.ToListAsync();

		return Ok(_mapper.Map<List<SpartanDTO>>(spartans));
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var spartan = await _dbContext.Spartans.FirstOrDefaultAsync(x => x.SpartanId
		== id);

		return Ok(_mapper.Map<SpartanDTO>(spartan));
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateSpartanDTO createSpartanDTO)
	{
		try
		{
			var createItem = _mapper.Map<Spartan>(createSpartanDTO);
			_dbContext.Spartans.Add(createItem);
			await _dbContext.SaveChangesAsync();
		}
		catch (Exception)
		{
			return BadRequest("An error occurred, please try again later.");
		}

		return Ok(createSpartanDTO);
	}

	[HttpPut]
	[Route("{id}")]
	public async Task<IActionResult> Update(Guid id, UpdateSpartanDTO spartanDTO)
	{
		var updateItem = await _dbContext.Spartans.FirstOrDefaultAsync(x => x.SpartanId == id);

		if (updateItem is null)
		{
			return BadRequest("The item you want to update could not be found.");
		}

		updateItem.FirstName = spartanDTO.FirstName ?? updateItem.FirstName;
		updateItem.MiddleName = spartanDTO.MiddleName ?? updateItem.MiddleName;
		updateItem.LastName = spartanDTO.LastName ?? updateItem.LastName;
		updateItem.DateOfBirth = spartanDTO.DateOfBirth;
		updateItem.Address = spartanDTO.Address ?? updateItem.Address;
		updateItem.PostCode = spartanDTO.PostCode?? updateItem.PostCode;
		updateItem.CountryOfResidence = spartanDTO.CountryOfResidence ?? updateItem.CountryOfResidence;
		updateItem.Title = spartanDTO.Title ?? updateItem.Title;
		updateItem.ContactNumber = spartanDTO.ContactNumber ?? updateItem.ContactNumber;
		updateItem.Email = spartanDTO.Email ?? updateItem.Email;
		updateItem.Role = spartanDTO.Role ?? updateItem.Role;
		updateItem.About = spartanDTO.About ?? updateItem.About;
		updateItem.Education = spartanDTO.Education ?? updateItem.Education;
		updateItem.Experience = spartanDTO.Experience ?? updateItem.Experience;
		updateItem.Skills = spartanDTO.Skills ?? updateItem.Skills;
		updateItem.PositionName = spartanDTO.PositionName ?? updateItem.PositionName;
		updateItem.Salary = spartanDTO.Salary;


		await _dbContext.SaveChangesAsync();

		return Ok(spartanDTO);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await _dbContext.Spartans.FirstOrDefaultAsync(x => x.SpartanId == id);

		if (deleteItem is null)
		{
			return BadRequest("The item you want to delete could not be found.");
		}

		_dbContext.Spartans.Remove(deleteItem);
		await _dbContext.SaveChangesAsync();

		return Ok(_mapper.Map<SpartanDTO>(deleteItem));
	}
}
