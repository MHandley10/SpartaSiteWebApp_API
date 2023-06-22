using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.Domain;

public class Spartan
{
	[Key]
	public Guid Id { get; set; }
	public string PositionName { get; set; }
	public string Role { get; set; }
	public decimal Salary { get; set; }
	[ForeignKey("User")]
	public Guid UserId { get; set; }
	public User User { get; set; }
	[ForeignKey("Course")]
	public Guid CourseId { get; set; }
	public ICollection<Course> { get; set; }

}
