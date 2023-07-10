using SpartaSiteWebApp_API.Models.Domain;

namespace SpartaSiteWebApp_API.Repositories;

public interface IQuestionBankRepository
{
	Task<List<Question>> GetAllAsync();
	Task<Question?> GetByIdAsync(Guid id);
	Task<Question> CreateAsync(Question question);
	Task<Question?> UpdateAsync(Guid id, Question question);
	Task<Question?> DeleteAsync(Guid id);
}
