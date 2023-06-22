namespace SpartaSiteWebApp_API.Models.Domain;

public class CareerItem
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public decimal Salary { get; set; }
	public DateTime PostDate { get; set; }
	public DateTime CloseDate { get; set; }
	public bool IsFilled { get; set; } = false;
	public ICollection<User>? Users { get; set; }
	public Guid AuthorSpartanId { get; set; }
	public Spartan Author { get; set; }
}
