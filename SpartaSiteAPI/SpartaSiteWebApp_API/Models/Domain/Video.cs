using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.Domain;

public class Video
{
	public Guid Id { get; set; }
	[NotMapped]
	public IFormFile File { get; set; }
	public string FileName { get; set; }
	public string? FileDescription { get; set; }
	public string FileExtension { get; set; }
	public long FileSizeInBytes { get; set; }
	public string FilePath { get; set; }
	public string Title { get; set; }
	public DateTime DateUploaded { get; set; }
	public string? Author { get; set; }
	public string VideoTopic { get; set; }
}
