using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.CareerItemDTOs;
using SpartaSiteWebApp_API.Models.DTO.CourseDTOs;

namespace SpartaSiteWebApp_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
	private readonly SpartaSiteDbContext _dbContext;
	private readonly IMapper _mapper;
	public CourseController(SpartaSiteDbContext dbContext, IMapper mapper)
	{
		this._dbContext = dbContext;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var courseItems = await _dbContext.Courses.ToListAsync();

		return Ok(_mapper.Map<List<CourseDTO>>(courseItems));
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var courseItem = await _dbContext.Courses.FirstOrDefaultAsync(x => x.CourseId
		== id);

		return Ok(_mapper.Map<CourseDTO>(courseItem));
	}

	[HttpPost]
	public async Task<IActionResult> Create(CourseDTO courseDTO)
	{
		try
		{
			var createItem = _mapper.Map<Course>(courseDTO);
			_dbContext.Courses.Add(createItem);
			await _dbContext.SaveChangesAsync();
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
		var updateItem = await _dbContext.Courses.FirstOrDefaultAsync(x => x.CourseId == id);

		if (updateItem is null)
		{
			return BadRequest("The item you want to update could not be found.");
		}

		updateItem.StreamName = courseDTO.StreamName ?? updateItem.StreamName;
		updateItem.CourseName = courseDTO.CourseName ?? updateItem.CourseName;
		updateItem.CourseType = courseDTO.CourseType ?? updateItem.CourseType;
		updateItem.StartDate = courseDTO.StartDate;
		updateItem.EndDate = courseDTO.EndDate;

		await _dbContext.SaveChangesAsync();

		return Ok(courseDTO);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await _dbContext.Courses.FirstOrDefaultAsync(x => x.CourseId == id);

		if (deleteItem is null)
		{
			return BadRequest("The item you want to delete could not be found.");
		}

		_dbContext.Courses.Remove(deleteItem);
		await _dbContext.SaveChangesAsync();

		return Ok(_mapper.Map<CourseDTO>(deleteItem));
	}
}
