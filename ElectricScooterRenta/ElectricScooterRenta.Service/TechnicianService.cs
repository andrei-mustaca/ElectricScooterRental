using ElectricScooterRenta.Domain;
using ElectricScooterRenta.Domain.Models;
using ElectricScooterRenta.Service.Intefaces;

namespace ElectricScooterRenta.Service;

public class TechnicianService:ITechnicianService
{
    private readonly ApplicationDbContext _context;

    public TechnicianService(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<bool> CreateRepair()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRepair(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Scooter> GetScooters(int page, int pageSize, out int totalPages)
    {
        throw new NotImplementedException();
    }

    public List<Repair> GetRepairs(int page, int pageSize, out int totalPages)
    {
        throw new NotImplementedException();
    }
}