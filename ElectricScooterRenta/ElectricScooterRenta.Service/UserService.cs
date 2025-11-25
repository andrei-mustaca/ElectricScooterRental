using ElectricScooterRenta.Domain;
using ElectricScooterRenta.Domain.Models;
using ElectricScooterRenta.Service.DTOs.UserDTOs;
using ElectricScooterRenta.Service.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace ElectricScooterRenta.Service;

public class UserService:IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Register(UserRegisterRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Email == request.Email || x.FullName == request.Username);
        if (user != null)
        {
            return false;
        }
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            FullName = request.Username,
            Email = request.Email,
            Password = request.Password,
            Role = request.Role,
            CreatedAt = DateTime.UtcNow
        };
        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<User?> Login(UserLoginRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => (u.Email == request.EmailOrUsername || u.FullName == request.EmailOrUsername) 
                                      && u.Password == request.Password&&u.Role==request.Role);
        return user;
    }
}