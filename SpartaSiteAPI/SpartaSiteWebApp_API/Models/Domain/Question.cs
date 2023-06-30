using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.Domain;

public class Question
{
	[Key]
	public Guid QuestionId { get; set; }
	public string ActualQuestion { get; set; }
	public string Answer { get; set; }
	public string? Comments { get; set; }
	public string Author { get; set; }
	public string QuestionTopic { get; set; }
	public DateTime DateUploaded { get; set; }
}
