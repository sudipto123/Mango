using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models.Dto
{
	public class LoginRequestDto
	{
        [Display(Name = "User Name"), Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
