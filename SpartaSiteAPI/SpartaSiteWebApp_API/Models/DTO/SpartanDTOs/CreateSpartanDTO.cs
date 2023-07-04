﻿using SpartaSiteWebApp_API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpartaSiteWebApp_API.Models.DTO.SpartanDTOs;

public class CreateSpartanDTO
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
	public string ContactNumber { get; set; }
	public string Email { get; set; }
	public string Role { get; set; } = "Trainee";
	public string About { get; set; }
	public string Education { get; set; }
	public string Experience { get; set; }
	public string Skills { get; set; }
	[ForeignKey("CVs")]
	public Guid? CVId { get; set; }
	public CV? CV { get; set; }
	public string PositionName { get; set; }
	public decimal Salary { get; set; }
	[ForeignKey("Courses")]
	public Guid? CourseId { get; set; }
	public Course? Course { get; set; }
}