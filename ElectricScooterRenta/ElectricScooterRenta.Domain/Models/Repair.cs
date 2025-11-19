namespace ElectricScooterRenta.Domain.Models;

public class Repair
{
    public Guid Id { get; set; }

    public Guid ScooterId { get; set; }
    public Scooter Scooter { get; set; }

    public Guid TechnicianId { get; set; }
    public User Technician { get; set; }

    public string Description { get; set; }
    public DateTime Date { get; set; }
}