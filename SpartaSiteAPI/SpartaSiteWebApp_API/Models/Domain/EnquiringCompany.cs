using System.ComponentModel.DataAnnotations;

namespace SpartaSiteWebApp_API.Models.Domain;

public class EnquiringCompany
{
	[Key]
	public Guid Id { get; set; }
	public string CompanyName { get; set; }
	public string? RepresentativeName { get; set; }
	public DateTime DateEnquired { get; set; }
	public int NumberOfSpartansRequired { get; set; }
	public string StreamNeeded { get; set; }
	public string CourseTypeNeeded { get; set; }
	public string ContactNumber { get; set; }
	public string Email { get; set; }
}
