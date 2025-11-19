using ElectricScooterRenta.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectricScooterRenta.Domain.Configuration;

public class RentalConfiguration:IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x=>x.User)
            .WithMany(u=>u.Rentals)
            .HasForeignKey(x=>x.UserId);
        builder.HasOne(x=>x.Scooter)
            .WithMany(s=>s.Rentals)
            .HasForeignKey(x=>x.ScooterId);
    }
}