using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpartaSiteWebApp_API.Models.DTO.AuthorisationDTOs;
using SpartaSiteWebApp_API.Repositories;

namespace SpartaSiteWebApp_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorisationController : ControllerBase
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly ITokenRepository tokenRepository;
		public AuthorisationController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
		{
			this.userManager = userManager;
			this.tokenRepository = tokenRepository;
		}

		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
		{
			var identityUser = new IdentityUser
			{
				UserName = registerRequestDTO.Username,
				Email = registerRequestDTO.Username
			};

			var identityResult = await userManager.CreateAsync(identityUser, registerRequestDTO.Password);

			if (identityResult.Succeeded)
			{
				if (registerRequestDTO.Roles is not null && registerRequestDTO.Roles.Any())
				{
					identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);

					if (identityResult.Succeeded)
					{
						return Ok("User was registered! Please login.");
					}
				}
			}

			return BadRequest("Something went wrong");
		}

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
		{
			var user = await userManager.FindByEmailAsync(loginRequestDTO.Username);

			if (user is not null)
			{
				var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

				if (checkPasswordResult)
				{
					var roles = await userManager.GetRolesAsync(user);

					if (roles is not null)
					{
						var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

						var response = new LoginResponseDTO
						{
							JwtToken = jwtToken
						};

						return Ok(response);
					}
				}
			}

			return BadRequest("Username or password incorrect");
		}
	}
}
