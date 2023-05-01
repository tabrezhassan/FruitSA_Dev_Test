using System.ComponentModel.DataAnnotations;

namespace FruitSA_Dev_Test.API.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Email Address is required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;

    }
}
