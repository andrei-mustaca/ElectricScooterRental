using ElectricScooterRenta.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectricScooterRenta.Domain.Configuration;

public class ScooterConfiguration:IEntityTypeConfiguration<Scooter>
{
    public void Configure(EntityTypeBuilder<Scooter> builder)
    {
        builder.HasKey(x=>x.Id);
    }
}