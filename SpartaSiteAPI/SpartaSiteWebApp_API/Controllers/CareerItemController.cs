using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.CareerItemDTOs;
using SpartaSiteWebApp_API.Repositories;

namespace SpartaSiteWebApp_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CareerItemController : ControllerBase
{
	private readonly ICareerItemRepository _careerItemRepository;
	private readonly IMapper _mapper;
	public CareerItemController(ICareerItemRepository careerItemRepository, IMapper mapper)
	{
		_careerItemRepository = careerItemRepository;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var careerItems = await _careerItemRepository.GetAllAsync();

		return Ok(_mapper.Map<List<CareerItemDTO>>(careerItems));
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var careerItem = await _careerItemRepository.GetByIdAsync(id);

		return Ok(_mapper.Map<CareerItemDTO>(careerItem));
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateCareerItemDTO createCareerItemDTO)
	{
		try
		{
			var createItem = await _careerItemRepository.CreateAsync(_mapper.Map<CareerItem>(createCareerItemDTO));
		}
		catch (Exception)
		{
			return BadRequest("An error occurred, please try again later.");
		}

		return Ok(_mapper.Map<CreateCareerItemDTO>(createCareerItemDTO));
	}

	[HttpPut]
	[Route("{id}")]
	public async Task<IActionResult> Update(Guid id, UpdateCareerItemDTO updateCareerItemDTO)
	{
		var updateItem = await _careerItemRepository.UpdateAsync(id, _mapper.Map<CareerItem>(updateCareerItemDTO));

		return Ok(_mapper.Map<CareerItemDTO>(updateItem));
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await _careerItemRepository.DeleteAsync(id);

		return Ok(_mapper.Map<CareerItemDTO>(deleteItem));
	}
}
