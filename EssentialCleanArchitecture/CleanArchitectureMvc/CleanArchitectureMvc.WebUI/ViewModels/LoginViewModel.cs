using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureMvc.WebUI.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Username is required.")]
    [EmailAddress(ErrorMessage = "Invalid format email!")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required!")]
    [StringLength(20, ErrorMessage = "Password must be at least {2} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public string ReturnUrl { get; set; } = string.Empty;
}