using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.Domain;

public class User
{
	[Key]
	public Guid Id { get; set; }
	public string FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string LastName { get; set; }
	public DateTime DateOfBirth { get; set; }
	public DateTime DateJoined { get; set; }
	public bool IsSpartan { get; set; } = false;
	public string Address { get; set; }
	public string PostCode { get; set; }
	public string CountryOfResidence { get; set; }
	public string? Title { get; set; }
	public string ContactNumber { get; set; }
	public string Email { get; set; }
	public string Role { get; set; } = "User";
	public string About { get; set; }
	public string Education { get; set; }
	public string Experience { get; set; }
	public string Skills { get; set; }
	[ForeignKey("Spartan")]
	public Guid? SpartanId { get; set; }
	public Spartan? Spartan { get; set; }
	public Guid CVId { get; set; }
	public CV CV { get; set; }

	public ICollection<CareerItem> { get; set;}
}
