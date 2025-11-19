using ElectricScooterRenta.Domain.Enums;

namespace ElectricScooterRenta.Domain.Models;

public class RentalHistory
{
    public Guid Id { get; set; }
    public Guid RentalId { get; set; }
    public Rental Rental { get; set; }

    public StatusRentaEnum StatusRenta { get; set; }    // Started, Finished, etc.
    public DateTime ChangedAt { get; set; }
}