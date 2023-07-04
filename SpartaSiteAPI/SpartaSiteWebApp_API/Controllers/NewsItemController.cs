using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.EnquiringCopmanyDTOs;
using SpartaSiteWebApp_API.Models.DTO.NewsItemDTOs;

namespace SpartaSiteWebApp_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewsItemController : ControllerBase
{
	private readonly SpartaSiteDbContext _dbContext;
	private readonly IMapper _mapper;
	public NewsItemController(SpartaSiteDbContext dbContext, IMapper mapper)
	{
		this._dbContext = dbContext;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var enquiringCompanyItems = await _dbContext.NewsItems.ToListAsync();

		return Ok(_mapper.Map<List<NewsItemDTO>>(enquiringCompanyItems));
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var newsItem = await _dbContext.NewsItems.FirstOrDefaultAsync(x => x.NewsItemId
		== id);

		return Ok(_mapper.Map<NewsItemDTO>(newsItem));
	}

	[HttpPost]
	public async Task<IActionResult> Create(NewsItemDTO newsItemDTO)
	{
		try
		{
			var newsItem = _mapper.Map<NewsItem>(newsItemDTO);
			_dbContext.NewsItems.Add(newsItem);
			await _dbContext.SaveChangesAsync();
		}
		catch (Exception)
		{
			return BadRequest("An error occurred, please try again later.");
		}

		return Ok(newsItemDTO);
	}

	[HttpPut]
	[Route("{id}")]
	public async Task<IActionResult> Update(Guid id, UpdateNewsItemDTO newsItemDTO)
	{
		var updateItem = await _dbContext.NewsItems.FirstOrDefaultAsync(x => x.NewsItemId == id);

		if (updateItem is null)
		{
			return BadRequest("The item you want to update could not be found.");
		}

		updateItem.Content = newsItemDTO.Content ?? updateItem.Content;
		updateItem.Author = newsItemDTO.Author ?? updateItem.Author;
		updateItem.Title = newsItemDTO.Title ?? updateItem.Title;
		

		await _dbContext.SaveChangesAsync();

		return Ok(newsItemDTO);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await _dbContext.NewsItems.FirstOrDefaultAsync(x => x.NewsItemId == id);

		if (deleteItem is null)
		{
			return BadRequest("The item you want to delete could not be found.");
		}

		_dbContext.NewsItems.Remove(deleteItem);
		await _dbContext.SaveChangesAsync();

		return Ok(_mapper.Map<NewsItemDTO>(deleteItem));
	}
}
