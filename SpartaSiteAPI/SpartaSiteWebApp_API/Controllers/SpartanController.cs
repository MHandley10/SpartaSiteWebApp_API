using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.EnquiringCopmanyDTOs;
using SpartaSiteWebApp_API.Models.DTO.SpartanDTOs;
using SpartaSiteWebApp_API.Repositories;

namespace SpartaSiteWebApp_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpartanController : ControllerBase
{
	private readonly ISpartanRepository _spartanRepository;
	private readonly IMapper _mapper;
	public SpartanController(ISpartanRepository spartanRepository, IMapper mapper)
	{
		_spartanRepository = spartanRepository;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		return Ok(_mapper.Map<List<SpartanDTO>>(await _spartanRepository.GetAllAsync()));
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var spartan = await _spartanRepository.GetByIdAsync(id);
		
		if (spartan is null)
		{
			return BadRequest("The spartan you requested couldn't be found");
		}

		return Ok(_mapper.Map<SpartanDTO>(spartan));
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateUpdateSpartanDTO createSpartanDTO)
	{
		try
		{
			var createItem = await _spartanRepository.CreateAsync(_mapper.Map<Spartan>(createSpartanDTO));
		}
		catch (Exception)
		{
			return BadRequest("An error occurred, please try again later.");
		}

		return Ok(createSpartanDTO);
	}

	[HttpPut]
	[Route("{id}")]
	public async Task<IActionResult> Update(Guid id, CreateUpdateSpartanDTO spartanDTO)
	{
		var updateItem = await _spartanRepository.UpdateAsync(id, _mapper.Map<Spartan>(spartanDTO));

		if (updateItem is null)
		{
			return BadRequest("The item you want to update could not be found.");
		}

		return Ok(spartanDTO);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await _spartanRepository.DeleteAsync(id);

		if (deleteItem is null)
		{
			return BadRequest("The item you want to delete could not be found.");
		}

		return Ok(_mapper.Map<SpartanDTO>(deleteItem));
	}
}
