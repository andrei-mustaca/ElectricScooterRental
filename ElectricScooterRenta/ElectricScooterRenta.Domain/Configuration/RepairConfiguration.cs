using ElectricScooterRenta.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectricScooterRenta.Domain.Configuration;

public class RepairConfiguration:IEntityTypeConfiguration<Repair>
{
    public void Configure(EntityTypeBuilder<Repair> builder)
    {
        builder.HasKey(x=>new{x.Id,x.Date});
        builder.HasOne(x => x.Scooter)
            .WithMany(s => s.Repairs)
            .HasForeignKey(x => x.ScooterId);
        builder.HasOne(x=>x.Technician)
            .WithMany(u=>u.Repairs)
            .HasForeignKey(x=>x.TechnicianId);
    }
}