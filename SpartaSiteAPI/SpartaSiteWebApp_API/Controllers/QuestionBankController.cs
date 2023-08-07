using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.EnquiringCopmanyDTOs;
using SpartaSiteWebApp_API.Models.DTO.QuestionDTOs;
using SpartaSiteWebApp_API.Repositories;

namespace SpartaSiteWebApp_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionBankController : ControllerBase
{
	private readonly IQuestionBankRepository _questionBankRepository;
	private readonly IMapper _mapper;
	public QuestionBankController(IQuestionBankRepository questionBankRepository, IMapper mapper)
	{
		_questionBankRepository = questionBankRepository;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		return Ok(_mapper.Map<List<QuestionDTO>>(await _questionBankRepository.GetAllAsync()));
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var question = await _questionBankRepository.GetByIdAsync(id);

		if (question is null)
		{
			return BadRequest("The question you requested could not be found.");
		}

		return Ok(_mapper.Map<QuestionDTO>(question));
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateQuestionDTO questionDTO)
	{
		try
		{
			await _questionBankRepository.CreateAsync(_mapper.Map<Question>(questionDTO));
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
		var updateItem = await _questionBankRepository.UpdateAsync(id, _mapper.Map<Question>(questionDTO));

		if (updateItem is null)
		{
			return BadRequest("The item you want to update could not be found.");
		}

		return Ok(questionDTO);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await _questionBankRepository.DeleteAsync(id);

		if (deleteItem is null)
		{
			return BadRequest("The item you want to delete could not be found.");
		}

		return Ok(_mapper.Map<QuestionDTO>(deleteItem));
	}
}
