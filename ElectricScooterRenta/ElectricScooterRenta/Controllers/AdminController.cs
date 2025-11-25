using System.Security.Claims;
using ElectricScooterRenta.Domain.Enums;
using ElectricScooterRenta.Domain.Models;
using ElectricScooterRenta.Service.DTOs.AdminDTOs;
using ElectricScooterRenta.Service.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElectricScooterRenta.Controllers;

public class AdminController : Controller
{
    private readonly IAdminService _service;

    public AdminController(IAdminService service)
    {
        _service = service;
    }

    public IActionResult AdminPanel()
    {
        return View();
    }

    public IActionResult CreateScooter()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateScooter(CreateScooterRequest request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        await _service.CreateScooter(request);
        return RedirectToAction("AdminPanel");
    }

    public IActionResult Index(int page = 1)
    {
        int pageSize = 5;
        var scooters = _service.GetScooters(page, pageSize, out int totalPages);

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = totalPages;

        return View(scooters);
    }

    public IActionResult Details(Guid id)
    {
        var scooter = _service.GetById(id);
        if (scooter == null) return NotFound();
        return View(scooter);
    }

    public IActionResult Edit(Guid id)
    {
        var scooter = _service.GetById(id);
        if (scooter == null) return NotFound();

        var dto = new UpdateScooterRequest
        {
            Id = scooter.Id,
            Color = scooter.Color,
            Speed = scooter.Speed,
            BatteryLevel = scooter.BatteryLevel,
            Status = scooter.Status,
            Condition = scooter.Condition
        };

        ViewBag.Statuses = new SelectList(Enum.GetValues(typeof(StatusEnum)), dto.Status);
        ViewBag.Conditions = new SelectList(Enum.GetValues(typeof(ConditionEnum)), dto.Condition);

        return View(dto);
    }

    [HttpPost]
    public IActionResult Edit(UpdateScooterRequest dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Statuses = new SelectList(Enum.GetValues(typeof(StatusEnum)), dto.Status);
            ViewBag.Conditions = new SelectList(Enum.GetValues(typeof(ConditionEnum)), dto.Condition);
            return View(dto);
        }

        _service.UpdateScooter(dto);
        return RedirectToAction("Details", new { id = dto.Id });
    }

    public IActionResult Delete(Guid id)
    {
        _service.DeleteScooter(id);
        return RedirectToAction("Index");
    }

    public IActionResult Admins(int page = 1)
    {
        int pageSize = 5;
        var admins = _service.GetAdmins(page, pageSize, out int totalPages);
        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = totalPages;
        return View(admins);
    }


    public IActionResult AdminDetails(Guid id)
    {
        var admin = _service.GetAdminById(id);
        if (admin == null) return NotFound();
        return View(admin);
    }


    public IActionResult CreateAdmin() => View();

    [HttpPost]
    public async Task<IActionResult> CreateAdmin(CreateUserRequest dto)
    {
        if (!ModelState.IsValid) return View(dto);

        await _service.CreateAdmin(dto);
        return RedirectToAction("Admins");
    }


    public IActionResult DeleteAdmin(Guid id)
    {
        try
        {
            _service.DeleteAdmin(id);
        }
        catch (InvalidOperationException ex)
        {
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction("Admins");
    }

    public IActionResult Technicians(int page = 1)
    {
        int pageSize = 5;
        var techs = _service.GetTechnicians(page, pageSize, out int totalPages);

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = totalPages;

        return View(techs);
    }

    public IActionResult CreateTechnician()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTechnician(CreateUserRequest dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        var result = await _service.CreateTechnician(dto);
        if (!result)
        {
            TempData["Error"] = "Пароли не совпадают!";
            return View(dto);
        }

        return RedirectToAction("Technicians");
    }

    public IActionResult TechnicianDetails(Guid id)
    {
        var tech = _service.GetTechnicianById(id);
        if (tech == null) return NotFound();

        return View(tech);
    }

    public async Task<IActionResult> DeleteTechnician(Guid id)
    {
        await _service.DeleteTechnician(id);
        return RedirectToAction("Technicians");
    }
}