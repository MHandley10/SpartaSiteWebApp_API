using System.ComponentModel.DataAnnotations;

namespace SpartaSiteWebApp_API.Models.DTO.AuthorisationDTOs
{
	public class LoginRequestDTO
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
