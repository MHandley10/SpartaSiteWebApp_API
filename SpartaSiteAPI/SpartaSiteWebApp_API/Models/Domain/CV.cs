using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.Domain;

public class CV
{
	[Key]
	public Guid Id { get; set; }
	[NotMapped]
	public IFormFile File { get; set; }
	public string FileName { get; set; }
	public string FileExtension { get; set; }
	public string FilePath { get; set; }
	public long FileSizeInBytes { get; set; }
	public Guid UserId { get; set; }
	public User User { get; set; }
}
