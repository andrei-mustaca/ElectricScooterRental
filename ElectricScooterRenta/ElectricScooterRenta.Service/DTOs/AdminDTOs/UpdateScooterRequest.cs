using ElectricScooterRenta.Domain.Enums;

namespace ElectricScooterRenta.Service.DTOs.AdminDTOs;

public class UpdateScooterRequest
{
    public Guid Id { get; set; }
    public string Color { get; set; }
    public double Speed { get; set; }
    public double BatteryLevel { get; set; }
    public StatusEnum Status { get; set; }
    public ConditionEnum Condition { get; set; }
}