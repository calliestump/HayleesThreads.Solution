using System.ComponentModel.DataAnnotations;

namespace HayleesThreads.ViewModels
{
  public class CreateRoleViewModel
  {
    [Required(ErrorMessage = "Please enter your first name")]
    public string RoleName { get; set; }
  }
}