using ElectricScooterRenta.Domain;
using ElectricScooterRenta.Domain.Enums;
using ElectricScooterRenta.Domain.Models;
using ElectricScooterRenta.Service.DTOs.AdminDTOs;
using ElectricScooterRenta.Service.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace ElectricScooterRenta.Service;

public class AdminService:IAdminService
{
    private readonly ApplicationDbContext _context;

    public AdminService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateScooter(CreateScooterRequest request)
    {
        var scooter=new Scooter
        {
          Id=Guid.NewGuid(),
          Speed = request.Speed,
          BatteryLevel = request.BatteryLevel,
          Color = request.Color,
          Status = request.Status,
          Condition = request.Condition,
        };
        await _context.Scooters.AddAsync(scooter);
        await _context.SaveChangesAsync();
        return true;
    }

    public void DeleteScooter(Guid id)
    {
        var scooter = _context.Scooters.Find(id);
        if(scooter==null) return;
        _context.Scooters.Remove(scooter);
        _context.SaveChanges();
    }
    public List<Scooter> GetScooters(int pageNumber, int pageSize, out int totalPages)
    {
        int totalItems = _context.Scooters.Count();
        totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        return _context.Scooters
            .OrderBy(x => x.Color) 
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
    public Scooter GetById(Guid id) => _context.Scooters.FirstOrDefault(x => x.Id == id);
    public void UpdateScooter(UpdateScooterRequest dto)
    {
        var scooter = _context.Scooters.Find(dto.Id);
        if (scooter == null) return;

        scooter.Color = dto.Color;
        scooter.Speed = dto.Speed;
        scooter.BatteryLevel = dto.BatteryLevel;
        scooter.Status = dto.Status;
        scooter.Condition = dto.Condition;

        _context.SaveChanges();
    }

    public async Task CreateAdmin(CreateUserRequest dto)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = dto.Username,
            Email = dto.Email,
            Password = dto.Password,
            Role = RoleEnums.Administrator
        }; 
        await _context.Users.AddAsync(user); 
        await _context.SaveChangesAsync();
    }
    
        
    public List<User> GetAdmins(int page, int pageSize, out int totalPages)
    {
        int totalItems = _context.Users.Count(u => u.Role == RoleEnums.Administrator);
        totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        return _context.Users
            .Where(u => u.Role == RoleEnums.Administrator)
            .OrderBy(u => u.FullName)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
    
        
    public User GetAdminById(Guid id) => _context.Users.FirstOrDefault(u => u.Id == id && u.Role == RoleEnums.Administrator);
    
        
    public void DeleteAdmin(Guid id)
    {
        var adminsCount = _context.Users.Count(u => u.Role == RoleEnums.Administrator);
    
        if (adminsCount == 1)
        {
            throw new InvalidOperationException("Невозможно удалить единственного администратора");
        }
    
        var user = _context.Users.FirstOrDefault(u => u.Id == id && u.Role == RoleEnums.Administrator);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
    
    public List<User> GetTechnicians(int page, int pageSize, out int totalPages)
    {
        var query = _context.Users.Where(x => x.Role == RoleEnums.Technical);
    
        int totalItems = query.Count();
        totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
    
        return query
            .OrderBy(x => x.FullName)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
    
    public async Task<bool> CreateTechnician(CreateUserRequest dto)
    {
        if (dto.Password != dto.ConfirmPassword)
            return false;
    
        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = dto.Username,
            Email = dto.Email,
            Password = dto.Password,
            Role = RoleEnums.Technical
        };
    
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteTechnician(Guid id)
    {
        var tech = await _context.Users.FindAsync(id);
        if (tech == null || tech.Role != RoleEnums.Technical) return false;
    
        _context.Users.Remove(tech);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public User GetTechnicianById(Guid id)
    {
        return _context.Users.FirstOrDefault(x => x.Id == id && x.Role == RoleEnums.Technical);
    }
}