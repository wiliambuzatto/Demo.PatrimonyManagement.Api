using System.ComponentModel.DataAnnotations;

namespace Demo.GestaoPatrimonio.Api.ViewModels
{
    public class LoginUserViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
