using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.CourseDTOs;
using SpartaSiteWebApp_API.Models.DTO.EnquiringCopmanyDTOs;
using SpartaSiteWebApp_API.Repositories;

namespace SpartaSiteWebApp_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnquiringCompanyController : ControllerBase
{	//TODO: implement Repository!!
	private readonly IEnquiringCompanyRepository _enquiringCompanyRepository;
	private readonly IMapper _mapper;
	public EnquiringCompanyController(IEnquiringCompanyRepository enquiringCompanyRepository, IMapper mapper)
	{
		_enquiringCompanyRepository = enquiringCompanyRepository;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true)
	{
		return Ok(_mapper.Map<List<EnquiringCompanyDTO>>(await _enquiringCompanyRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending));
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var enquiringCompany = await _enquiringCompanyRepository.GetByIdAsync(id);

		if (enquiringCompany is null)
		{
			return BadRequest("The Enquiring Company you requested could not be found");
		}

		return Ok(_mapper.Map<EnquiringCompanyDTO>(enquiringCompany));
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateEnquiringCompanyDTO enquiringCompanyDTO)
	{
		try
		{

			await _enquiringCompanyRepository.CreateAsync(_mapper.Map<EnquiringCompany>(enquiringCompanyDTO));
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
		var updateItem = await _enquiringCompanyRepository.UpdateAsync(id, _mapper.Map<EnquiringCompany>(companyDTO));

		if (updateItem is null)
		{
			return BadRequest("The item you want to update could not be found.");
		}

		return Ok(companyDTO);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await _enquiringCompanyRepository.DeleteAsync(id);

		if (deleteItem is null)
		{
			return BadRequest("The item you want to delete could not be found.");
		}

		return Ok(_mapper.Map<EnquiringCompanyDTO>(deleteItem));
	}
}
