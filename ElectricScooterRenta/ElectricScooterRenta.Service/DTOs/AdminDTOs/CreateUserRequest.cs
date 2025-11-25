using System.ComponentModel.DataAnnotations;

namespace ElectricScooterRenta.Service.DTOs.AdminDTOs;

public class CreateUserRequest
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
}