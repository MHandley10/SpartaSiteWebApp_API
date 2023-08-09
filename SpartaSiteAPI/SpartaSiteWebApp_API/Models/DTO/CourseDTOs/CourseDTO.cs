using SpartaSiteWebApp_API.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.DTO.CourseDTOs;

public class CourseDTO
{
	public string StreamName { get; set; }
	public string CourseName { get; set; }
	public string CourseType { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	[ForeignKey("Spartans")]
	public Guid? SpartanId { get; set; }
	public Spartan spartan { get; set; }
}
