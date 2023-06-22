using System.ComponentModel.DataAnnotations;

namespace SpartaSiteWebApp_API.Models.Domain;

public class NewsItem
{
	public Guid Id { get; set; }
	public string Content { get; set; }
	public string Author { get; set; }
	public string Title { get; set; }
	public string Date { get; set; }
}
