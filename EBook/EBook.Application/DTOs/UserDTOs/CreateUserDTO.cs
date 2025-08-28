using System.ComponentModel.DataAnnotations;

namespace EBook.Application.DTOs.UserDTOs;

public class CreateUserDTO
{
    [Required(ErrorMessage = "Username is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = ("Username must be between 3-100 characters"))]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    public string Email { get; set; } = string.Empty;
}
