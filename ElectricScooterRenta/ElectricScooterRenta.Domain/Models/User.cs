using ElectricScooterRenta.Domain.Enums;

namespace ElectricScooterRenta.Domain.Models;

public class User
{
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleEnums Role { get; set; }     
        public DateTime CreatedAt { get; set; }

        public ICollection<Rental> Rentals { get; set; }
        public ICollection<Repair> Repairs { get; set; } 
}