namespace ElectricScooterRenta.Domain.Models;

public class Rental
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid ScooterId { get; set; }
    public Scooter Scooter { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public double? Price { get; set; }

    public ICollection<RentalHistory> History { get; set; }
}