using ElectricScooterRenta.Domain.Enums;
using ElectricScooterRenta.Service.DTOs.UserDTOs;
using ElectricScooterRenta.Service.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace ElectricScooterRenta.Controllers;

public class UserController:Controller
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }
    public IActionResult Registration()
    {
        var model = new UserRegisterRequest();
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterRequest model)
    {
        if (!ModelState.IsValid)
            return View("Registration", model);

        bool registered = await _service.Register(model);

        if (!registered)
        {
            ModelState.AddModelError(string.Empty, "Пользователь с таким Email или Логином уже существует.");
            return View("Registration", model);
        }

        Response.Cookies.Append("user", model.Username, new CookieOptions { Expires = DateTimeOffset.Now.AddDays(7) });
        return RedirectToAction("SiteInformation", "Home");
    }
    
    public IActionResult Login()
    {
        return View(new UserLoginRequest());
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(UserLoginRequest model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _service.Login(model);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Неверный Email/Логин или пароль");
            return View(model);
        }
        if(model.Role==RoleEnums.User)
        {
            Response.Cookies.Append("user", user.FullName, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7)
            });
        }
        else if(model.Role==RoleEnums.Administrator)
        {
            Response.Cookies.Append("admin", user.FullName, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7)
            });
        }
        else
        {
            Response.Cookies.Append("technical", user.FullName, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7)
            });
        }
        return RedirectToAction("SiteInformation", "Home");
    }
    
    public IActionResult Logout()
    {
        Response.Cookies.Delete("user");
        Response.Cookies.Delete("admin");
        Response.Cookies.Delete("technical");
        return RedirectToAction("SiteInformation", "Home");
    }

}