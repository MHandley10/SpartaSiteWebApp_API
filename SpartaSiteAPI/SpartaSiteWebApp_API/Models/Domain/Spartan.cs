using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.Domain;

public class Spartan : IdentityUser
{
	public string FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string LastName { get; set; }
	public DateTime DateOfBirth { get; set; }
	public DateTime DateJoined { get; set; }
	public string Address { get; set; }
	public string PostCode { get; set; }
	public string CountryOfResidence { get; set; }
	public string? Title { get; set; }
	public string Role { get; set; } = "Trainee";
	public string About { get; set; }
	public string Education { get; set; }
	public string Experience { get; set; }
	public string Skills { get; set; }
	public string PositionName { get; set; }
	public decimal Salary { get; set; }
}
