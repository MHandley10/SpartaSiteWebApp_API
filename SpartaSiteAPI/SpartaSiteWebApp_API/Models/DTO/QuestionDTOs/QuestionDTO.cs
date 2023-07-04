using System.ComponentModel.DataAnnotations;

namespace SpartaSiteWebApp_API.Models.DTO.QuestionDTOs;

public class QuestionDTO
{
	public string ActualQuestion { get; set; }
	public string Answer { get; set; }
	public string? Comments { get; set; }
	public string Author { get; set; }
	public string QuestionTopic { get; set; }
	public DateTime DateUploaded { get; set; }
}
