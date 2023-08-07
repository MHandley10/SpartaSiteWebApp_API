using SpartaSiteWebApp_API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SpartaSiteWebApp_API.Models.DTO.CourseDTOs;

namespace SpartaSiteWebApp_API.Models.DTO.SpartanDTOs;

public class SpartanDTO
{
	public string FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string LastName { get; set; }
	public string CountryOfResidence { get; set; }
	public string? Title { get; set; }
	public string About { get; set; }
	public string Education { get; set; }
	public string Experience { get; set; }
	public string Skills { get; set; }
	public string PositionName { get; set; }
	public CV? CV { get; set; }
	public CourseDTO? Course { get; set; }
}
