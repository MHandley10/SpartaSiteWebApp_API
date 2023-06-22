using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.Domain;

public class Course
{
	[Key]
	public Guid Id { get; set; }
	public string StreamName { get; set; }
	public string CourseName { get; set; }
	public string CourseType { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	[ForeignKey("Spartan")]
	public Guid TrainerSpartanId { get; set; }
	public Spartan Trainer { get; set; }
	public ICollection<Spartan> Trainees { get; set; }
	[ForeignKey("Spartan")]
	public Guid AssistantTrainerSpartanId { get; set; }
	public Spartan AssistantTrainer { get; set; }
}
