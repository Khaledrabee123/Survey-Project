using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Survay.Models.DTO
{
    public class UserRegestertionDTO
    {
		[NotMapped]
		public string? Id { get; set; }
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public string UserName { get; set; }
		[Compare("Password")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

	}
}
