using SpartaSiteWebApp_API.Models.Domain;

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

		var danyal = new User
		{
			UserId = Guid.NewGuid(),
			FirstName = "Danyal",
			LastName = "Saleh",
			DateOfBirth = new DateTime(1999, 1, 1),
			DateJoined = DateTime.Now,
			IsSpartan = true,
			Address = "101 Memory Lane, Hereford",
			PostCode = "HF12 3OP",
			CountryOfResidence = "United Kingdom",
			ContactNumber = "070000000000",
			Email = "DSaleh@hotmail.com",
			Role = "Trainee",
			About = "Hi! I'm Danyal with a Y!",
			Education = "Uni versity, University town",
			Experience = "Many years as an excellent C# Developer",
			Skills = "C#, Python, Java",
		};
		var nooreen = new User
		{
			UserId = Guid.NewGuid(),
			FirstName = "Nooreen",
			LastName = "Ali",
			DateOfBirth = new DateTime(1999, 3, 14),
			DateJoined = new DateTime(2022, 2, 21, 1, 56, 34, 3),
			IsSpartan = true,
			Address = "88 Victoria way, Stoke-On-Trent",
			PostCode = "ST8 9NW",
			CountryOfResidence = "United Kingdom",
			ContactNumber = "070000000001",
			Email = "NAli@hotmail.com",
			Role = "Trainee",
			About = "My name is Nooreen, I enjoy pizza and biking.",
			Education = "Oxford Brooks, Oxford",
			Experience = "Very experience mechanical engineer",
			Skills = "C#, CAD, Solidworks",
		};
		var jacob = new User
		{
			UserId = Guid.NewGuid(),
			FirstName = "Jacob",
			LastName = "Banyard",
			DateOfBirth = new DateTime(1997, 3, 14),
			DateJoined = new DateTime(2023, 1, 18, 4, 15, 13, 80),
			IsSpartan = true,
			Address = "15 Haggis avenue, Glasgow",
			PostCode = "G15 5NM",
			CountryOfResidence = "United Kingdom",
			ContactNumber = "070000000002",
			Email = "JBanyard@hotmail.com",
			Role = "Trainee",
			About = "I love climbing rocks and solving complex maths problems.",
			Education = "Essex University, Essex",
			Experience = "Lots of teaching experience in Maths, ready to take my career to the next level!",
			Skills = "C#, Python, MATLAB",
		};
		var dave = new User
		{
			UserId = Guid.NewGuid(),
			FirstName = "Dave",
			LastName = "Ingram",
			DateOfBirth = new DateTime(1956, 12, 25),
			DateJoined = DateTime.Now,
			IsSpartan = false,
			Address = "15 Buckingham Way, London",
			PostCode = "N15 1RT",
			CountryOfResidence = "United Kingdom",
			ContactNumber = "070000000003",
			Email = "DIngram@hotmail.com",
			About = "Hello! I'm Dave, I've seen a lot of the world and I wanted to try my hand in the tech industry. I like Pina Coladas and walks in the rain.",
			Education = "University of life",
			Experience = "15 years as a self-employed plumber",
			Skills = "I can fit a mean U-bend",
		};

		context.CareerItems.AddRange();
	}
}
