using System.ComponentModel.DataAnnotations;
using ElectricScooterRenta.Domain.Enums;

namespace ElectricScooterRenta.Service.DTOs.UserDTOs;

public class UserRegisterRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string ConfirmPassword { get; set; }

    [Required] public RoleEnums Role { get; set; } = RoleEnums.User;
}