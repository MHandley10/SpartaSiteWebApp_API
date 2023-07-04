using System.ComponentModel.DataAnnotations;

namespace SpartaSiteWebApp_API.Models.DTO.NewsItemDTOs;

public class UpdateNewsItemDTO
{
	public string Content { get; set; }
	public string Author { get; set; }
	public string Title { get; set; }
}
