using System.ComponentModel.DataAnnotations;

namespace SpartaSiteWebApp_API.Models.DTO.EnquiringCopmanyDTOs;

public class UpdateEnquiringCompanyDTO
{
	public string CompanyName { get; set; }
	public string? RepresentativeName { get; set; }
	public int NumberOfSpartansRequired { get; set; }
	public string StreamNeeded { get; set; }
	public string CourseTypeNeeded { get; set; }
	public string ContactNumber { get; set; }
	public string Email { get; set; }
}
