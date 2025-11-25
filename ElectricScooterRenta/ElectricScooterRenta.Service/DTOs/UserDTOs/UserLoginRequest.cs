using System.ComponentModel.DataAnnotations;
using ElectricScooterRenta.Domain.Enums;

namespace ElectricScooterRenta.Service.DTOs.UserDTOs;

public class UserLoginRequest
{
        [Required]
        public string EmailOrUsername { get; set; }
        [Required]
        public string Password { get; set; }
        public RoleEnums Role{get;set;}
}