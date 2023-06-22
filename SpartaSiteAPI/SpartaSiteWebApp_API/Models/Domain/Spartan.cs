using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.Domain;

public class Spartan
{
	[Key]
	public Guid Id { get; set; }
	public string PositionName { get; set; }
	public decimal Salary { get; set; }
	[ForeignKey("User")]
	public Guid UserId { get; set; }
	public User User { get; set; }
	[ForeignKey("Course")]
	public Guid CourseId { get; set; }
	public ICollection<Course> Courses{ get; set; }
	[ForeignKey("CareerItem")]
	public Guid? CareerItemId { get; set; }
	public ICollection<CareerItem>? CareerItemsAuthored {get; set;}
}
