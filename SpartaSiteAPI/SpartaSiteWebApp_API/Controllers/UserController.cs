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
		return Ok(_mapper.Map<List<UserDTO>>(await _userRepository.GetAllAsync()));
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var user = await _userRepository.GetByIdAsync(id);

		if (user is null)
		{
			return BadRequest("The user you requested could not be found.");
		}

		return Ok(_mapper.Map<UserDTO>(user));
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateUserDTO userDTO)
	{
		try
		{
			await _userRepository.CreateAsync(_mapper.Map<User>(userDTO));
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
		var updateItem = await _userRepository.UpdateAsync(id, _mapper.Map<User>(userDTO));

		if (updateItem is null)
		{
			return BadRequest("The item you want to update could not be found.");
		}

		return Ok(userDTO);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var deleteItem = await _userRepository.DeleteAsync(id);

		if (deleteItem is null)
		{
			return BadRequest("The item you want to delete could not be found.");
		}

		return Ok(_mapper.Map<UserDTO>(deleteItem));
	}
}
