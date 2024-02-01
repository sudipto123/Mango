using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models.Dto
{
	public class RegistrationRequestDto
	{
		[Display(Name = "Please enter your Email"), Required]
		public string Email { get; set; }
        [Display(Name = "Please enter your Name"), Required]
        public string Name { get; set; }
        [Display(Name = "Please enter your Phone Number"), Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
		public string? Role { get; set; }
	}
}
