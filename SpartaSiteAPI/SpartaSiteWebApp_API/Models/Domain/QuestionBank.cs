using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.Domain;

public class QuestionBank
{
	[Key]
	public Guid QuestionBankId { get; set; }
	public string Question { get; set; }
	public string Answer { get; set; }
	public string? Comments { get; set; }
	public string Author { get; set; }
	public string QuestionTopic { get; set; }
	public DateTime DateUploaded { get; set; }
}
