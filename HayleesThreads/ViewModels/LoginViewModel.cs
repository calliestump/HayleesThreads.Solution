using System.ComponentModel.DataAnnotations;

namespace HayleesThreads.ViewModels
{
  public class LoginViewModel
  {
    [Required(ErrorMessage = "Please enter your email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter your password")]
    public string Password { get; set; }
  }
}