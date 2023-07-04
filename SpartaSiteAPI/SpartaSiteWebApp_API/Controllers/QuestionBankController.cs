using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.EnquiringCopmanyDTOs;
using SpartaSiteWebApp_API.Models.DTO.QuestionDTOs;

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
		var questionItems = await _dbContext.Questions.ToListAsync();

		return Ok(_mapper.Map<List<QuestionDTO>>(questionItems));
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var questionItem = await _dbContext.Questions.FirstOrDefaultAsync(x => x.QuestionId
		== id);

		return Ok(_mapper.Map<EnquiringCompanyDTO>(questionItem));
	}

	[HttpPost]
	public async Task<IActionResult> Create(QuestionDTO questionDTO)
	{
		try
		{
			var createItem = _mapper.Map<Question>(questionDTO);
			_dbContext.Questions.Add(createItem);
			await _dbContext.SaveChangesAsync();
		}
		catch (Exception)
		{
			return BadRequest("An error occurred, please try again later.");
		}

		return Ok(questionDTO);
	}

	[HttpPut]
	[Route("{id}")]
	public async Task<IActionResult> Update(Guid id, UpdateQuestionDTO questionDTO)
	{
		var updateItem = await _dbContext.Questions.FirstOrDefaultAsync(x => x.QuestionId == id);

		if (updateItem is null)
		{
			return BadRequest("The item you want to update could not be found.");
		}

		updateItem.ActualQuestion = questionDTO.ActualQuestion?? updateItem.ActualQuestion;
		updateItem.Answer = questionDTO.Answer ?? updateItem.Answer;
		updateItem.Comments = questionDTO.Comments ?? updateItem.Comments;
		updateItem.Author = questionDTO.Author ?? updateItem.Author;
		updateItem.QuestionTopic = questionDTO.QuestionTopic ?? updateItem.QuestionTopic;

		await _dbContext.SaveChangesAsync();

		return Ok(questionDTO);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await _dbContext.Questions.FirstOrDefaultAsync(x => x.QuestionId == id);

		if (deleteItem is null)
		{
			return BadRequest("The item you want to delete could not be found.");
		}

		_dbContext.Questions.Remove(deleteItem);
		await _dbContext.SaveChangesAsync();

		return Ok(_mapper.Map<QuestionDTO>(deleteItem));
	}
}
