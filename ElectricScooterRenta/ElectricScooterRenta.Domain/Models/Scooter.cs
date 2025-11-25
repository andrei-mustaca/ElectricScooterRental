using ElectricScooterRenta.Domain.Enums;

namespace ElectricScooterRenta.Domain.Models;

public class Scooter
{
    public Guid Id { get; set; }
    public double Speed { get; set; }
    public double BatteryLevel { get; set; }
    public string Color { get; set; }
    public StatusEnum Status { get; set; }      
    public ConditionEnum Condition { get; set; }

    public ICollection<Rental> Rentals { get; set; }
    public ICollection<Repair> Repairs { get; set; }
}