using ElectricScooterRenta.Domain.Models;
using ElectricScooterRenta.Service.DTOs.AdminDTOs;

namespace ElectricScooterRenta.Service.Intefaces;

public interface IAdminService
{
    public Task<bool> CreateScooter(CreateScooterRequest request);
    public void DeleteScooter(Guid id);
    public void UpdateScooter(UpdateScooterRequest request);
    public List<Scooter> GetScooters(int pageNumber, int pageSize, out int totalPages);
    public Scooter GetById(Guid id);
    public void DeleteAdmin(Guid id);
    public User GetAdminById(Guid id);
    public List<User> GetAdmins(int page, int pageSize, out int totalPages);
    public Task CreateAdmin(CreateUserRequest dto);
    List<User> GetTechnicians(int page, int pageSize, out int totalPages);
    Task<bool> CreateTechnician(CreateUserRequest dto);
    Task<bool> DeleteTechnician(Guid id);
    User GetTechnicianById(Guid id);
}