using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.EnquiringCopmanyDTOs;
using SpartaSiteWebApp_API.Models.DTO.NewsItemDTOs;
using SpartaSiteWebApp_API.Repositories;

namespace SpartaSiteWebApp_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewsItemController : ControllerBase
{
	private readonly INewsItemRepository _newsItemRepository;
	private readonly IMapper _mapper;
	public NewsItemController(INewsItemRepository newsItemRepository, IMapper mapper)
	{
		_newsItemRepository = newsItemRepository;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		return Ok(_mapper.Map<List<NewsItemDTO>>(await _newsItemRepository.GetAllAsync()));
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		return Ok(_mapper.Map<NewsItemDTO>(await _newsItemRepository.GetByIdAsync(id)));
	}

	[HttpPost]
	public async Task<IActionResult> Create(NewsItemDTO newsItemDTO)
	{
		try
		{
			await _newsItemRepository.CreateAsync(_mapper.Map<NewsItem>(newsItemDTO));
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
		var updateItem = await _newsItemRepository.UpdateAsync(id, _mapper.Map<NewsItem>(newsItemDTO));

		if (updateItem is null)
		{
			return BadRequest("The item you want to update could not be found.");
		}

		return Ok(newsItemDTO);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await _newsItemRepository.DeleteAsync(id);

		if (deleteItem is null)
		{
			return BadRequest("The item you want to delete could not be found.");
		}

		return Ok(_mapper.Map<NewsItemDTO>(deleteItem));
	}
}
