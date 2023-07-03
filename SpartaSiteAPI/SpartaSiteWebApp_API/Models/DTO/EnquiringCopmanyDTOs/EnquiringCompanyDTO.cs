namespace SpartaSiteWebApp_API.Models.DTO.EnquiringCopmanyDTOs;

public class EnquiringCompanyDTO
{
	public string CompanyName { get; set; }
	public DateTime DateEnquired { get; set; }
	public int NumberOfSpartansRequired { get; set; }
	public string StreamNeeded { get; set; }
	public string CourseTypeNeeded { get; set; }
}
