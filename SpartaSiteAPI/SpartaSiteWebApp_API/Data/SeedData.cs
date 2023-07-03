﻿using SpartaSiteWebApp_API.Models.Domain;
using System.ComponentModel.Design;

namespace SpartaSiteWebApp_API.Data;

public class SeedData
{

	public static void Initialise(IServiceProvider serviceProvider)
	{
		var context = serviceProvider.GetRequiredService<SpartaSiteDbContext>();

		if (context.CareerItems.Any() || context.Courses.Any() || context.CVs.Any() || context.EnquiringCompanies.Any() || context.NewsItems.Any() || context.Questions.Any() || context.Spartans.Any() || context.Users.Any() || context.Videos.Any())
		{
			context.CareerItems.RemoveRange(context.CareerItems);
			context.Courses.RemoveRange(context.Courses);
			context.CVs.RemoveRange(context.CVs);
			context.EnquiringCompanies.RemoveRange(context.EnquiringCompanies);
			context.NewsItems.RemoveRange(context.NewsItems);
			context.Questions.RemoveRange(context.Questions);
			context.Spartans.RemoveRange(context.Spartans);
			context.Users.RemoveRange(context.Users);
			context.Videos.RemoveRange(context.Videos);
			context.SaveChanges();
		}

		var danyalCV = new CV
		{
			CVId = Guid.NewGuid(),
			FileName = "Danyals CV",
			FileExtension = ".pdf",
			FilePath = "./CVs",
			FileSizeInBytes = 50_000
		};

		var daveCV = new CV
		{
			CVId = Guid.NewGuid(),
			FileName = "Daves CV",
			FileExtension = ".pdf",
			FilePath = "./CVs",
			FileSizeInBytes = 49_000
		};

		var nooreenCV = new CV
		{
			CVId = Guid.NewGuid(),
			FileName = "Nooreens CV",
			FileExtension = ".pdf",
			FilePath = "./CVs",
			FileSizeInBytes = 51_000
		};

		var jacobCV = new CV
		{
			CVId = Guid.NewGuid(),
			FileName = "Jacobs CV",
			FileExtension = ".pdf",
			FilePath = "./CVs",
			FileSizeInBytes = 52_000
		};

		var tech211 = new Course
		{
			CourseId = Guid.NewGuid(),
			StreamName = "Developer",
			CourseName = "Tech211",
			CourseType = "C# Developer",
			StartDate = new DateTime(2023, 03, 20)
		};
		var tech212 = new Course
		{
			CourseId = Guid.NewGuid(),
			StreamName = "Developer",
			CourseName = "Tech211",
			CourseType = "Java Developer",
			StartDate = new DateTime(2023, 04, 13)
		};

		var danyalSpartan = new Spartan
		{
			SpartanId = Guid.NewGuid(),
			FirstName = "Danyal",
			LastName = "Saleh",
			DateOfBirth = new DateTime(1999, 1, 1),
			DateJoined = DateTime.Now,
			Address = "101 Memory Lane, Hereford",
			PostCode = "HF12 3OP",
			CountryOfResidence = "United Kingdom",
			ContactNumber = "070000000000",
			Email = "DSaleh@hotmail.com",
			About = "Hi! I'm Danyal with a Y!",
			Education = "Uni versity, University town",
			Experience = "Many years as an excellent C# Developer",
			Skills = "C#, Python, Java",
			CVId = nooreenCV.CVId,
			CV = danyalCV,
			PositionName = "Spartan",
			Salary = (decimal)19_000.00,
			CourseId = tech211.CourseId,
			Course = tech211
		};

		var nooreenSpartan = new Spartan
		{
			SpartanId = Guid.NewGuid(),
			FirstName = "Nooreen",
			LastName = "Ali",
			DateOfBirth = new DateTime(1999, 3, 14),
			DateJoined = new DateTime(2022, 2, 21, 1, 56, 34, 3),
			Address = "88 Victoria way, Stoke-On-Trent",
			PostCode = "ST8 9NW",
			CountryOfResidence = "United Kingdom",
			ContactNumber = "070000000001",
			Email = "NAli@hotmail.com",
			About = "My name is Nooreen, I enjoy pizza and biking.",
			Education = "Oxford Brooks, Oxford",
			Experience = "Very experience mechanical engineer",
			Skills = "C#, CAD, Solidworks",
			CVId = nooreenCV.CVId,
			CV = nooreenCV,
			PositionName = "Talent Team Spartan",
			Salary = (decimal)19_000.00
		};

		var jacobSpartan = new Spartan
		{
			SpartanId = Guid.NewGuid(),
			FirstName = "Jacob",
			LastName = "Banyard",
			DateOfBirth = new DateTime(1997, 3, 14),
			DateJoined = new DateTime(2023, 1, 18, 4, 15, 13, 80),
			Address = "15 Haggis avenue, Glasgow",
			PostCode = "G15 5NM",
			CountryOfResidence = "United Kingdom",
			ContactNumber = "070000000002",
			Email = "JBanyard@hotmail.com",
			About = "I love climbing rocks and solving complex maths problems.",
			Education = "Essex University, Essex",
			Experience = "Lots of teaching experience in Maths, ready to take my career to the next level!",
			Skills = "C#, Python, MATLAB",
			CVId = jacobCV.CVId,
			CV = jacobCV,
			PositionName = "Trainer Spartan",
			Salary = (decimal)19_000.00,
			CourseId = tech211.CourseId,
			Course = tech211
		};

		var danyal = new User
		{
			UserId = Guid.NewGuid(),
			FirstName = "Danyal",
			LastName = "Saleh",
			DateOfBirth = new DateTime(1999, 1, 1),
			DateJoined = DateTime.Now,
			Address = "101 Memory Lane, Hereford",
			PostCode = "HF12 3OP",
			CountryOfResidence = "United Kingdom",
			ContactNumber = "070000000000",
			Email = "DSaleh@hotmail.com",
			About = "Hi! I'm Danyal with a Y!",
			Education = "Uni versity, University town",
			Experience = "Many years as an excellent C# Developer",
			Skills = "C#, Python, Java",
			CVId = nooreenCV.CVId,
			CV = danyalCV
		};
		var nooreen = new User
		{
			UserId = Guid.NewGuid(),
			FirstName = "Nooreen",
			LastName = "Ali",
			DateOfBirth = new DateTime(1999, 3, 14),
			DateJoined = new DateTime(2022, 2, 21, 1, 56, 34, 3),
			Address = "88 Victoria way, Stoke-On-Trent",
			PostCode = "ST8 9NW",
			CountryOfResidence = "United Kingdom",
			ContactNumber = "070000000001",
			Email = "NAli@hotmail.com",
			About = "My name is Nooreen, I enjoy pizza and biking.",
			Education = "Oxford Brooks, Oxford",
			Experience = "Very experience mechanical engineer",
			Skills = "C#, CAD, Solidworks",
			CVId = nooreenCV.CVId,
			CV = nooreenCV
		};
		var jacob = new User
		{
			UserId = Guid.NewGuid(),
			FirstName = "Jacob",
			LastName = "Banyard",
			DateOfBirth = new DateTime(1997, 3, 14),
			DateJoined = new DateTime(2023, 1, 18, 4, 15, 13, 80),
			Address = "15 Haggis avenue, Glasgow",
			PostCode = "G15 5NM",
			CountryOfResidence = "United Kingdom",
			ContactNumber = "070000000002",
			Email = "JBanyard@hotmail.com",
			About = "I love climbing rocks and solving complex maths problems.",
			Education = "Essex University, Essex",
			Experience = "Lots of teaching experience in Maths, ready to take my career to the next level!",
			Skills = "C#, Python, MATLAB",
			CVId = jacobCV.CVId,
			CV = jacobCV
		};
		var dave = new User
		{
			UserId = Guid.NewGuid(),
			FirstName = "Dave",
			LastName = "Ingram",
			DateOfBirth = new DateTime(1956, 12, 25),
			DateJoined = DateTime.Now,
			Address = "15 Buckingham Way, London",
			PostCode = "N15 1RT",
			CountryOfResidence = "United Kingdom",
			ContactNumber = "070000000003",
			Email = "DIngram@hotmail.com",
			About = "Hello! I'm Dave, I've seen a lot of the world and I wanted to try my hand in the tech industry. I like Pina Coladas and walks in the rain.",
			Education = "University of life",
			Experience = "15 years as a self-employed plumber",
			Skills = "I can fit a mean U-bend",
			CVId = daveCV.CVId,
			CV = daveCV
		};

		var career1 = new CareerItem
		{
			CareerItemId = Guid.NewGuid(),
			Title = "C# Back-end Developer",
			Description = "A wonderful opportunity!",
			Salary = (decimal)25_000,
			PostDate = new DateTime(2023, 5, 15),
			CloseDate = new DateTime(2023, 7, 15),
			IsFilled = false,
			SpartanId = nooreenSpartan.SpartanId,
			Author = nooreenSpartan
		};
		var career2 = new CareerItem
		{
			CareerItemId = Guid.NewGuid(),
			Title = "Java Back-end Developer",
			Description = "A wonderful opportunity!",
			Salary = (decimal)25_000,
			PostDate = new DateTime(2023, 6, 15),
			CloseDate = new DateTime(2023, 8, 15),
			IsFilled = false,
			SpartanId = nooreenSpartan.SpartanId,
			Author = nooreenSpartan
		};
		var career3 = new CareerItem
		{
			CareerItemId = Guid.NewGuid(),
			Title = "Test Automation Engineer",
			Description = "A wonderful opportunity!",
			Salary = (decimal)25_000,
			PostDate = new DateTime(2023, 6, 28),
			CloseDate = new DateTime(2023, 9, 01),
			IsFilled = false,
			SpartanId = nooreenSpartan.SpartanId,
			Author = nooreenSpartan
		};
		var company1 = new EnquiringCompany
		{
			EnquiringCompanyId = Guid.NewGuid(),
			CompanyName = "JCB",
			RepresentativeName = "Bob Dole",
			DateEnquired = new DateTime(2022, 5, 15),
			NumberOfSpartansRequired = 15,
			StreamNeeded = "Developer",
			CourseTypeNeeded = "C# Developer",
			ContactNumber = "07000000004",
			Email = "BDole@JCB.com"
		};
		var company2 = new EnquiringCompany
		{
			EnquiringCompanyId = Guid.NewGuid(),
			CompanyName = "Costco",
			DateEnquired = new DateTime(2023, 6, 25),
			NumberOfSpartansRequired = 15,
			StreamNeeded = "Developer",
			CourseTypeNeeded = "Java Developer",
			ContactNumber = "07000000005",
			Email = "HR@Costco.com"
		};
		var company3 = new EnquiringCompany
		{
			EnquiringCompanyId = Guid.NewGuid(),
			CompanyName = "Asda",
			DateEnquired = new DateTime(2022, 5, 15),
			NumberOfSpartansRequired = 15,
			StreamNeeded = "Test Automation Engineer",
			CourseTypeNeeded = "C# Test Automation Engineer",
			ContactNumber = "07000000006",
			Email = "HR@Asda.com"
		};
		var newsItem1 = new NewsItem
		{
			NewsItemId = Guid.NewGuid(),
			Content = "New roles have been made available in Sparta!",
			Author = "David Jones",
			Title = "New Roles!",
			Date = new DateTime(2023, 6, 25)
		};
		var newsItem2 = new NewsItem
		{
			NewsItemId = Guid.NewGuid(),
			Content = "Sitting down is bad for you, get a standing desk and save yourself!",
			Author = "David Jones",
			Title = "Sitting down bad!",
			Date = new DateTime(2023, 6, 1)
		};
		var newsItem3 = new NewsItem
		{
			NewsItemId = Guid.NewGuid(),
			Content = "We are pleased to announce our new company mascot!",
			Author = "Carl Withers",
			Title = "New Mascot",
			Date = new DateTime(2023, 6, 10)
		};
		var question1 = new Question
		{
			QuestionId = Guid.NewGuid(),
			ActualQuestion = "What is a statically typed language?",
			Answer = "A language where you define the data types of variables",
			Author = "Nooreen",
			QuestionTopic = "General programming",
			DateUploaded = DateTime.Now
		};
		var question2 = new Question
		{
			QuestionId = Guid.NewGuid(),
			ActualQuestion = "What is staging?",
			Answer = "git add, adds changes to be commited",
			Author = "Nooreen",
			QuestionTopic = "Git",
			DateUploaded = new DateTime(2022, 10, 1)
		};
		var question3 = new Question
		{
			QuestionId = Guid.NewGuid(),
			ActualQuestion = "What does the modulus operator do?",
			Answer = "returns the remainder of a division calculation",
			Author = "Nooreen",
			QuestionTopic = "General programming",
			DateUploaded = DateTime.Now
		};

		context.CVs.AddRange(
			danyalCV,
			daveCV,
			jacobCV,
			nooreenCV
			);
		context.Courses.AddRange(
			tech211,
			tech212
			);
		context.Spartans.AddRange(
			danyalSpartan,
			jacobSpartan,
			nooreenSpartan
			);
		context.Users.AddRange(
			danyal,
			jacob,
			dave,
			nooreen);
		
		context.CareerItems.AddRange(
			career1,
			career2,
			career3
			);
		context.EnquiringCompanies.AddRange(
			company1,
			company2,
			company3
			);
		context.NewsItems.AddRange(
			newsItem1,
			newsItem2,
			newsItem3
			);
		context.Questions.AddRange(
			question1,
			question2,
			question3
			);
		context.Videos.AddRange(

			);
		context.SaveChanges();
	}
}
