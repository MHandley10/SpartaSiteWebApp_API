using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.CareerItemDTOs;
using SpartaSiteWebApp_API.Models.DTO.CourseDTOs;
using SpartaSiteWebApp_API.Repositories;

namespace SpartaSiteWebApp_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
	private readonly ICourseRepository _courseRepository;
	private readonly IMapper _mapper;
	public CourseController(ICourseRepository courseRepository, IMapper mapper)
	{
		_courseRepository = courseRepository;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		return Ok(_mapper.Map<List<CourseDTO>>(await _courseRepository.GetAllAsync()));
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var course = await _courseRepository.GetByIdAsync(id);

		if (course is null)
		{
			return BadRequest("The Course you requested could not be found");
		}

		return Ok(_mapper.Map<CourseDTO>(course));
	}

	[HttpPost]
	public async Task<IActionResult> Create(CourseDTO courseDTO)
	{
		try
		{
			await _courseRepository.CreateAsync(_mapper.Map<Course>(courseDTO));
		}
		catch (Exception)
		{
			return BadRequest("An error occurred, please try again later.");
		}

		return Ok(courseDTO);
	}

	[HttpPut]
	[Route("{id}")]
	public async Task<IActionResult> Update(Guid id, CourseDTO courseDTO)
	{
		var updateItem = await _courseRepository.UpdateAsync(id, _mapper.Map<Course>(courseDTO));

		if (updateItem is null)
		{
			return BadRequest("The item you want to update could not be found.");
		}

		return Ok(courseDTO);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await _courseRepository.DeleteAsync(id);

		if (deleteItem is null)
		{
			return BadRequest("The item you want to delete could not be found.");
		}

		return Ok(_mapper.Map<CourseDTO>(deleteItem));
	}
}
