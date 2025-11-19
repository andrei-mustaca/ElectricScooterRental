using ElectricScooterRenta.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectricScooterRenta.Domain;

public class ApplicationDbContext:DbContext
{
    
    public DbSet<User>  Users { get; set; }
    public DbSet<Scooter> Scooters { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RentalHistory> RentalHistories { get; set; }
    public DbSet<Repair> Repairs { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}