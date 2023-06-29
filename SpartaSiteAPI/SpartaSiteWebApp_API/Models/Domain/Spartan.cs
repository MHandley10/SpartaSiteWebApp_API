using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.Domain;

public class Spartan
{
	[Key]
	public Guid SpartanId { get; set; }
	public string PositionName { get; set; }
	public decimal Salary { get; set; }
	[ForeignKey("Courses")]
	public Guid? CourseId { get; set; }
	public Course? Course { get; set; }
	public ICollection<CareerItem>? CareerItemsAuthored {get; set;}
}
