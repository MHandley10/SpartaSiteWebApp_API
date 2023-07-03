﻿using SpartaSiteWebApp_API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaSiteWebApp_API.Models.DTO;

public class CreateCareerItemDTO
{
	public string Title { get; set; }
	public string Description { get; set; }
	public decimal Salary { get; set; }
	public DateTime PostDate { get; set; }
	public DateTime CloseDate { get; set; }
	public bool IsFilled { get; set; } = false;
	[ForeignKey("Spartans")]
	public Guid SpartanId { get; set; }
	public Spartan Author { get; set; }
}