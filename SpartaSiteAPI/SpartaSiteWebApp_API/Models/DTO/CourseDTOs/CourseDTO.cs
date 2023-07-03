using SpartaSiteWebApp_API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace SpartaSiteWebApp_API.Models.DTO.CourseDTOs;

public class CourseDTO
{
	public string StreamName { get; set; }
	public string CourseName { get; set; }
	public string CourseType { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public ICollection<Spartan> Spartans { get; set; }
}
