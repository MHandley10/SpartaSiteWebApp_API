using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.SpartanDTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.DTO.CareerItemDTOs;

public class CreateCareerItemDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Salary { get; set; }
    public DateTime CloseDate { get; set; }
    public bool? IsFilled { get; set; } = false;
    [ForeignKey("Spartans")]
    public Guid SpartanId { get; set; }
}
