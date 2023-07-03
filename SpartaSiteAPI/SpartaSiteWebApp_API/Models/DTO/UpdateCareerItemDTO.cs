using SpartaSiteWebApp_API.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.DTO;

public class UpdateCareerItemDTO
{
	[Key]
	public Guid CareerItemId { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public decimal Salary { get; set; }
	public DateTime CloseDate { get; set; }
	public bool IsFilled { get; set; } = false;
}
