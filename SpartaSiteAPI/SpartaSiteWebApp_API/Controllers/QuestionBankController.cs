using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.EnquiringCopmanyDTOs;

namespace SpartaSiteWebApp_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionBankController : ControllerBase
{
	private readonly SpartaSiteDbContext _dbContext;
	private readonly IMapper _mapper;
	public QuestionBankController(SpartaSiteDbContext dbContext, IMapper mapper)
	{
		this._dbContext = dbContext;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var enquiringCompanyItems = await _dbContext.EnquiringCompanies.ToListAsync();

		return Ok(_mapper.Map<List<EnquiringCompanyDTO>>(enquiringCompanyItems));
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var courseItem = await _dbContext.EnquiringCompanies.FirstOrDefaultAsync(x => x.EnquiringCompanyId
		== id);

		return Ok(_mapper.Map<EnquiringCompanyDTO>(courseItem));
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateEnquiringCompanyDTO enquiringCompanyDTO)
	{
		try
		{
			var createItem = _mapper.Map<EnquiringCompany>(enquiringCompanyDTO);
			_dbContext.EnquiringCompanies.Add(createItem);
			await _dbContext.SaveChangesAsync();
		}
		catch (Exception)
		{
			return BadRequest("An error occurred, please try again later.");
		}

		return Ok(enquiringCompanyDTO);
	}

	[HttpPut]
	[Route("{id}")]
	public async Task<IActionResult> Update(Guid id, UpdateEnquiringCompanyDTO companyDTO)
	{
		var updateItem = await _dbContext.EnquiringCompanies.FirstOrDefaultAsync(x => x.EnquiringCompanyId == id);

		if (updateItem is null)
		{
			return BadRequest("The item you want to update could not be found.");
		}

		updateItem.CourseTypeNeeded = companyDTO.CourseTypeNeeded ?? updateItem.CourseTypeNeeded;
		updateItem.CompanyName = companyDTO.CompanyName ?? updateItem.CompanyName;
		updateItem.ContactNumber = companyDTO.ContactNumber ?? updateItem.ContactNumber;
		updateItem.Email = companyDTO.Email ?? updateItem.Email;
		updateItem.NumberOfSpartansRequired = companyDTO.NumberOfSpartansRequired;
		updateItem.RepresentativeName = companyDTO.RepresentativeName ?? updateItem.RepresentativeName;
		updateItem.StreamNeeded = companyDTO.StreamNeeded ?? updateItem.StreamNeeded;

		await _dbContext.SaveChangesAsync();

		return Ok(companyDTO);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await _dbContext.EnquiringCompanies.FirstOrDefaultAsync(x => x.EnquiringCompanyId == id);

		if (deleteItem is null)
		{
			return BadRequest("The item you want to delete could not be found.");
		}

		_dbContext.EnquiringCompanies.Remove(deleteItem);
		await _dbContext.SaveChangesAsync();

		return Ok(_mapper.Map<EnquiringCompanyDTO>(deleteItem));
	}
}
