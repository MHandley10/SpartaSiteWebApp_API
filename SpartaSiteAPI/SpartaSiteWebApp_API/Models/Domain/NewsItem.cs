using System.ComponentModel.DataAnnotations;

namespace SpartaSiteWebApp_API.Models.Domain;

public class NewsItem
{
	[Key]
	public Guid NewsItemId { get; set; }
	public string Content { get; set; }
	public string Author { get; set; }
	public string Title { get; set; }
	public string Date { get; set; }
}
