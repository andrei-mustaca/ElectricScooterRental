using ElectricScooterRenta.Service.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace ElectricScooterRenta.Controllers;

public class TechnicianController:Controller
{
    private readonly ITechnicianService _service;

    public TechnicianController(ITechnicianService service)
    {
        _service = service;
    }
}