using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpartaSiteWebApp_API.Data;
using SpartaSiteWebApp_API.Models.Domain;
using SpartaSiteWebApp_API.Models.DTO.SpartanDTOs;
using SpartaSiteWebApp_API.Models.DTO.UserDTOs;
using SpartaSiteWebApp_API.Repositories;

namespace SpartaSiteWebApp_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;
	public UserController(IUserRepository userRepository, IMapper mapper)
	{
		_userRepository = userRepository;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		return Ok(_mapper.Map<List<UserDTO>>(_userRepository.GetAllAsync()));
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId
		== id);

		return Ok(_mapper.Map<UserDTO>(user));
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateUserDTO userDTO)
	{
		try
		{
			var createItem = _mapper.Map<User>(userDTO);
			_dbContext.Users.Add(createItem);
			await _dbContext.SaveChangesAsync();
		}
		catch (Exception)
		{
			return BadRequest("An error occurred, please try again later.");
		}

		return Ok(userDTO);
	}

	[HttpPut]
	[Route("{id}")]
	public async Task<IActionResult> Update(Guid id, UpdateUserDTO userDTO)
	{
		var updateItem = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

		if (updateItem is null)
		{
			return BadRequest("The item you want to update could not be found.");
		}

		updateItem.FirstName = userDTO.FirstName ?? updateItem.FirstName;
		updateItem.MiddleName = userDTO.MiddleName ?? updateItem.MiddleName;
		updateItem.LastName = userDTO.LastName ?? updateItem.LastName;
		updateItem.DateOfBirth = userDTO.DateOfBirth;
		updateItem.Address = userDTO.Address ?? updateItem.Address;
		updateItem.PostCode = userDTO.PostCode ?? updateItem.PostCode;
		updateItem.CountryOfResidence = userDTO.CountryOfResidence ?? updateItem.CountryOfResidence;
		updateItem.Title = userDTO.Title ?? updateItem.Title;
		updateItem.ContactNumber = userDTO.ContactNumber ?? updateItem.ContactNumber;
		updateItem.Email = userDTO.Email ?? updateItem.Email;
		updateItem.About = userDTO.About ?? updateItem.About;
		updateItem.Education = userDTO.Education ?? updateItem.Education;
		updateItem.Experience = userDTO.Experience ?? updateItem.Experience;
		updateItem.Skills = userDTO.Skills ?? updateItem.Skills;


		await _dbContext.SaveChangesAsync();

		return Ok(userDTO);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

		if (deleteItem is null)
		{
			return BadRequest("The item you want to delete could not be found.");
		}

		_dbContext.Users.Remove(deleteItem);
		await _dbContext.SaveChangesAsync();

		return Ok(_mapper.Map<UserDTO>(deleteItem));
	}
}
