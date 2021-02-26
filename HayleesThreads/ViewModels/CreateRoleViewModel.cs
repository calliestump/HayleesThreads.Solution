using System.ComponentModel.DataAnnotations;

namespace HayleesThreads.ViewModels
{
  public class CreateRoleViewModel
  {
    [Required]
    public string RoleName { get; set; }
  }
}