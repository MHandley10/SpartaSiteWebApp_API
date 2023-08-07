using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.SpartanDTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.DTO.CareerItemDTOs;

public class CareerItemDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{ddMMyyyyHHmmss}", ApplyFormatInEditMode = true)]
    public DateTime PostDate { get; set; }
    public DateTime CloseDate { get; set; }
    public bool? IsFilled { get; set; } = false;
    public SpartanDTO Author { get; set; }
}
