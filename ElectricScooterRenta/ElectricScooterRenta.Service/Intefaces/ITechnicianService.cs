using ElectricScooterRenta.Domain.Models;

namespace ElectricScooterRenta.Service.Intefaces;

public interface ITechnicianService
{
    public Task<bool> CreateRepair();
    public Task<bool> DeleteRepair(Guid id);
    public List<Scooter> GetScooters(int page, int pageSize, out int totalPages);
    public List<Repair> GetRepairs(int page, int pageSize, out int totalPages);
}