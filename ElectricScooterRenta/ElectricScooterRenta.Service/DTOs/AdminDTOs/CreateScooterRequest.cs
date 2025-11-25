using System.ComponentModel.DataAnnotations;
using ElectricScooterRenta.Domain.Enums;

namespace ElectricScooterRenta.Service.DTOs.AdminDTOs;

public class CreateScooterRequest
{
    [Range(0, 100, ErrorMessage = "Скорость должна быть от 0 до 100 км/ч")]
    public double Speed { get; set; }
    [Range(0, 100, ErrorMessage = "Уровень батареи должен быть от 0 до 100%")]
    public double BatteryLevel { get; set; }
    [Required(ErrorMessage = "Цвет обязателен")]
    [StringLength(50, ErrorMessage = "Цвет не может быть длиннее 50 символов")]
    public string Color { get; set; }
    public StatusEnum Status { get; set; }=StatusEnum.Free;      
    public ConditionEnum Condition { get; set; }=ConditionEnum.Working;
}