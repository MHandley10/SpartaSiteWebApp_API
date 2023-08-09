
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Repositories;
using System.Text;

namespace SpartaSiteWebApp_API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "Sparta Site API", Version = "v1" });
				options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
				{
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = JwtBearerDefaults.AuthenticationScheme
				});

				options.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
				new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = JwtBearerDefaults.AuthenticationScheme
						},
						Scheme = "Oauth2",
						Name = JwtBearerDefaults.AuthenticationScheme,
						In = ParameterLocation.Header
					},
					new List<string>()
				}
			});
			});

			builder.Services.AddDbContext<SpartaSiteDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SpartaSiteConnectionString")));

			builder.Services.AddScoped<ICareerItemRepository, CareerItemRepository>();

			builder.Services.AddScoped<ISpartanRepository, SpartanRepository>();

			builder.Services.AddScoped<IUserRepository, UserRepository>();

			builder.Services.AddScoped<IEnquiringCompanyRepository, EnquiringCompanyRepository>();

			builder.Services.AddScoped<ICourseRepository, CourseRepository>();

			builder.Services.AddScoped<IQuestionBankRepository, QuestionBankRepository>();

			builder.Services.AddScoped<INewsItemRepository, NewsItemRepository>();

			builder.Services.AddScoped<ITokenRepository, TokenRepository>();

			builder.Services.AddAutoMapper(typeof(Program).Assembly);

			builder.Services.AddIdentityCore<Spartan>()
			.AddRoles<IdentityRole>()
			.AddTokenProvider<DataProtectorTokenProvider<Spartan>>("SpartaSiteAPI")
			.AddEntityFrameworkStores<SpartaSiteDbContext>()
			.AddDefaultTokenProviders();

			builder.Services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 1;
			});

			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = builder.Configuration["Jwt:Issuer"],
					ValidAudience = builder.Configuration["Jwt:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
				});

			var app = builder.Build();

			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				SeedData.Initialise(services);
			}

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}