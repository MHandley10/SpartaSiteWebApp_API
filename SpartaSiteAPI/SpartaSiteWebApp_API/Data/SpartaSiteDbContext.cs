using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Models.Domain;
using System.Diagnostics.Metrics;

namespace SpartaSiteWebApp_API.Data;

public class SpartaSiteDbContext : IdentityDbContext
{
	public SpartaSiteDbContext(DbContextOptions<SpartaSiteDbContext> dbContextOptions) : base(dbContextOptions)
	{

	}

	public DbSet<CareerItem> CareerItems { get; set; }
	public DbSet<Course> Courses { get; set; }
	public DbSet<CV> CVs { get; set; }
	public DbSet<EnquiringCompany> EnquiringCompanies { get; set; }
	public DbSet<NewsItem> NewsItems { get; set; }
	public DbSet<Question> Questions { get; set; }
	public DbSet<Spartan> Spartans { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<Video> Videos { get; set; }

}
