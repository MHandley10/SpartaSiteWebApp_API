using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.Domain;

public class Course
{
	[Key]
	public Guid CourseId { get; set; }
	public string StreamName { get; set; }
	public string CourseName { get; set; }
	public string CourseType { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public List<Spartan> spartans { get; set; }
}
