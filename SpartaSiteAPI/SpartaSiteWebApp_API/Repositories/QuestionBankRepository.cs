using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.QuestionDTOs;

namespace SpartaSiteWebApp_API.Repositories;

public class QuestionBankRepository : IQuestionBankRepository
{
	private readonly SpartaSiteDbContext _dbContext;

	public QuestionBankRepository(SpartaSiteDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Question> CreateAsync(Question question)
	{
		_dbContext.Questions.Add(question);
		await _dbContext.SaveChangesAsync();

		return question;
	}

	public async Task<Question?> DeleteAsync(Guid id)
	{
		var deleteItem = await _dbContext.Questions.FirstOrDefaultAsync(x => x.QuestionId == id);

		if (deleteItem is null)
		{
			return null;
		}

		_dbContext.Questions.Remove(deleteItem);
		await _dbContext.SaveChangesAsync();

		return deleteItem;
	}

	public async Task<List<Question>> GetAllAsync()
	{
		return await _dbContext.Questions.ToListAsync();
	}

	public async Task<Question?> GetByIdAsync(Guid id)
	{
		return await _dbContext.Questions.FirstOrDefaultAsync(x => x.QuestionId == id);
	}

	public async Task<Question?> UpdateAsync(Guid id, Question question)
	{
		var updateItem = await _dbContext.Questions.FirstOrDefaultAsync(x => x.QuestionId == id);

		if (updateItem is null)
		{
			return null;
		}

		updateItem.ActualQuestion = question.ActualQuestion ?? updateItem.ActualQuestion;
		updateItem.Answer = question.Answer ?? updateItem.Answer;
		updateItem.Comments = question.Comments ?? updateItem.Comments;
		updateItem.Author = question.Author ?? updateItem.Author;
		updateItem.QuestionTopic = question.QuestionTopic ?? updateItem.QuestionTopic;

		await _dbContext.SaveChangesAsync();

		return updateItem;
	}
}
